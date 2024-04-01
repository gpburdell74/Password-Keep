using Adaptive.Intelligence.Shared;
using Adaptive.Intelligence.Shared.IO;
using PasswordKeep.Data;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
    /// <summary>
    /// Provides a manager for the data content that is stored in clear text.
    /// </summary>
    /// <seealso cref="Adaptive.Intelligence.Shared.ExceptionTrackingBase" />
    public sealed class ClearTextDataManager : ExceptionTrackingBase, IDataManager
	{
        #region Private Member Declarations                
        /// <summary>
        /// The file name.
        /// </summary>
        private string? _fileName;
        /// <summary>
        /// The bills list.
        /// </summary>
        private BillCollection? _bills;
        /// <summary>
        /// The financial accounts list.
        /// </summary>
        private FinancialAccountCollection? _finAccounts;
        /// <summary>
        /// The data entries list.
        /// </summary>
        private GeneralDataCollection? _dataEntries;
        /// <summary>
        /// The general logins list.
        /// </summary>
        private GeneralLoginCollection? _logins;
        /// <summary>
        /// The ID providers list.
        /// </summary>
        private IdentityProviderCollection? _idProviders;

        #endregion

        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="ClearTextDataManager"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public ClearTextDataManager()
        {
            _bills = new BillCollection();
            _finAccounts = new FinancialAccountCollection();
            _dataEntries = new GeneralDataCollection();
            _logins = new GeneralLoginCollection();
            _idProviders = new IdentityProviderCollection();
		}
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
        /// <b>false</b> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                Clear();
            }

            _bills = null;
            _finAccounts = null;
            _dataEntries = null;
            _logins = null;
            _idProviders = null;
            _fileName = null;

            base.Dispose(disposing);
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the referende to the bills list.
        /// </summary>
        /// <value>
        /// A <see cref="BillCollection"/> containing the data, or <b>null</b>.
        /// </value>
        public BillCollection? Bills => _bills;
        /// <summary>
        /// Gets the referende to the financial accounts list.
        /// </summary>
        /// <value>
        /// A <see cref="FinancialAccountCollection"/> containing the data, or <b>null</b>.
        /// </value>
        public FinancialAccountCollection? FinancialAccounts => _finAccounts;
        /// <summary>
        /// Gets the referende to the general data entries list.
        /// </summary>
        /// <value>
        /// A <see cref="GeneralDataCollection"/> containing the data, or <b>null</b>.
        /// </value>
        public GeneralDataCollection? GeneralDataEntries => _dataEntries;
        /// <summary>
        /// Gets the referende to the general login credentials list.
        /// </summary>
        /// <value>
        /// A <see cref="GeneralLoginCollection"/> containing the data, or <b>null</b>.
        /// </value>
        public GeneralLoginCollection? GeneralLogins => _logins;
        /// <summary>
        /// Gets the referende to the identity provider credentials list.
        /// </summary>
        /// <value>
        /// A <see cref="IdentityProviderCollection"/> containing the data, or <b>null</b>.
        /// </value>
        public IdentityProviderCollection? IdentityProviders => _idProviders;
        #endregion

        #region Public Methods / Functions        
        /// <summary>
        /// Clears the current data content.
        /// </summary>
        public void Clear()
        {
            _bills?.Clear();
            _finAccounts?.Clear();
            _dataEntries?.Clear();
            _logins?.Clear();
            _idProviders?.Clear();
        }
		/// <summary>
		/// Loads the data content from the specified file name.
		/// </summary>
		/// <param name="fileName">
        /// A string containing the fully-qualified path and name of the file to be read.
        /// </param>
		public void Load(string fileName)
        {
			// Try to open the file.
			_fileName = fileName;
			FileStream readStream = OpsIO.OpenFileForReading(fileName);
            if (readStream != null)
            {
                Load(readStream);
                readStream.Close();
                readStream.Dispose();
            }
        }
		/// <summary>
		/// Loads the data content from the specified stream.
		/// </summary>
		/// <param name="sourceStream">A <see cref="Stream" /> to read the contents from.</param>
		public void Load(Stream sourceStream)
		{
			// Try to read the data content.
			ClearEntityReader reader = new ClearEntityReader(sourceStream);
			PKDataSet? dataSet = reader.ReadDataSet();
			reader.Close();
			reader.Dispose();

            // Set the new content if loaded correctly.
			if (dataSet != null)
			{
				// Clear the current data.
				Clear();

				// Load the data entities.
				_bills = new BillCollection(dataSet.Bills);
				_finAccounts = new FinancialAccountCollection(dataSet.FinancialAccounts);
				_dataEntries = new GeneralDataCollection(dataSet.RawData);
				_logins = new GeneralLoginCollection(dataSet.GeneralLogins);
				_idProviders = new IdentityProviderCollection(dataSet.IdentityProviders);
			}
		}
		/// <summary>
		/// Saves the data content to the specified file name.
		/// </summary>
		/// <param name="fileName">
		/// A string containing the fullt-qualified path and name of the file to be saved.
		/// </param>
		public void Save(string fileName)
        {
            if (_bills != null && _finAccounts != null && _logins != null && _dataEntries != null && _idProviders != null)
            {
                // Attempt to write the file.
                _fileName = fileName;
                FileStream? saveStream = OpsIO.OpenFileForSaving(fileName);
                if (saveStream != null)
                {
                    // Write the data.
                    Save(saveStream);
                    saveStream.Close();
					saveStream.Dispose();
				}
            }
        }
        /// <summary>
        /// Saves the data content to the specified stream.
        /// </summary>
        /// <param name="destinationStream">The destination <see cref="Stream" /> to write the contents to.</param>
        public void Save(Stream destinationStream)
        {
            if (_bills != null && _finAccounts != null && _logins != null && _dataEntries != null && _idProviders != null)
            {
                PKDataSet dataSet = new PKDataSet(
                    _bills.ExtractEntityList(),
                    _finAccounts.ExtractEntityList(),
                    _logins.ExtractEntityList(),
                    _dataEntries.ExtractEntityList(),
                    _idProviders.ExtractEntityList());

                ClearEntityWriter writer = new ClearEntityWriter(destinationStream);
                writer.WriteDataSet(dataSet);
                writer.Close();
                writer.Dispose();
                dataSet.Dispose();
            }
        }

		#endregion
	}
}

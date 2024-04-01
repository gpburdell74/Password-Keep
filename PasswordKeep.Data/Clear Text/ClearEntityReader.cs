using Adaptive.Intelligence.Shared;
using Adaptive.Intelligence.Shared.IO;
using PasswordKeep.Data.Entity;
using PasswordKeep.Data.IO;
using System.Data;

namespace PasswordKeep.Data
{
    /// <summary>
    /// Provides the implementation for reading the entity records from a data store in clear text, but 
    /// in a binary format.
    /// </summary>
    /// <seealso cref="ExceptionTrackingBase" />
    /// <seealso cref="IEntityReader" />
    public sealed class ClearEntityReader : ExceptionTrackingBase, IEntityReader
    {
        #region Private Member Declarations        
        /// <summary>
        /// The reader instance.
        /// </summary>
        private ClearSafeReader? _reader;
        /// <summary>
        /// The stream to read from.
        /// </summary>
        private Stream? _stream;
		#endregion

		#region Constructor / Dispose Methods                
		/// <summary>
		/// Initializes a new instance of the <see cref="ClearEntityReader"/> class.
		/// </summary>
		/// <param name="sourceStream">
		/// The source <see cref="Stream"/> instance to be read from.
		/// </param>
		public ClearEntityReader(Stream sourceStream)
        {
            _stream = sourceStream;
            _reader = new ClearSafeReader(_stream);
        }
		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
		/// <b>false</b> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
        {
            Close();

            _reader = null;
            _stream = null;
            base.Dispose(disposing);
        }
        #endregion

        #region Public Methods / Functions        
        /// <summary>
        /// Closes the instance.
        /// </summary>
        public void Close()
        {
            try
            {
                _reader?.Close();
                _reader?.Dispose();
            }
            catch(Exception ex)
            {
                AddException(ex);
            }
            _reader = null;

            try
            {
                _stream?.Close();
                _stream?.Dispose();
            }
            catch (Exception ex)
            {
                AddException(ex);
            }

            _stream = null;
        }
        /// <summary>
        /// Reads the base field / column values onto the provided instance.
        /// </summary>
        /// <param name="entry">The <see cref="EntityBase" /> instance being populated.</param>
        /// <returns>
        ///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        public bool ReadBaseFields(EntityBase entry)
        {
            bool success = false;

            if (entry != null && _reader != null)
            {
                entry.Name = _reader.ReadString();
                entry.Url = _reader.ReadString();
                entry.UserId = _reader.ReadString();
                entry.Password = _reader.ReadString();
                entry.Description = _reader.ReadString();
                success = true;
            }
            return success;
        }
        /// <summary>
        /// Reads the list of <see cref="BillEntry" /> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="BillEntryCollection" /> containing the list.
        /// </returns>
        public BillEntryCollection? ReadBillEntries()
        {
            BillEntryCollection? collection = null;
            if (_reader != null)
            {
                // Read the number of items to read.
                int length = _reader.ReadInt32();
                int count = 0;

                // Read the entities into the collection, if there are any to be read.
                collection = new BillEntryCollection();
                if (length > 0)
                {
                    BillEntry? newItem = null;
                    do
                    {
                        newItem = ReadBillEntry();
                        count++;
                        if (newItem != null)
                            collection.Add(newItem);
                    } while (count < length && newItem != null);
                }
            }
            return collection;
        }
        /// <summary>
        /// Reads the next <see cref="BillEntry" /> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="BillEntry" /> instance containing the data.
        /// </returns>
        public BillEntry? ReadBillEntry()
        {
            if (_reader == null)
                return null;

            BillEntry entry = new BillEntry();
            ReadBaseFields(entry);

            entry.Company = _reader.ReadString();
            entry.Description = _reader.ReadString();
            entry.OutstandingBalance = _reader.ReadSingle();
            entry.LastDatePaid = _reader.ReadDateTimeNullable();
            entry.NextDueDate = _reader.ReadDateTimeNullable();
			entry.IsAutoPay = _reader.ReadBoolean();
			entry.AutoPayDay = _reader.ReadInt32();
			entry.LastAmountPaid = _reader.ReadSingle();

			return entry;
        }
        /// <summary>
        /// Reads the entire content of the data set from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="PKDataSet"/> instance if successful; otherwise, returns <b>null</b>.
        /// </returns>
        public PKDataSet? ReadDataSet()
        {
            PKDataSet? dataSet = null;
            BillEntryCollection? billList = null;
            FinancialAccountEntryCollection? finAccounts = null;
            GeneralLoginEntryCollection? logins = null;
            RawDataEntryCollection? dataEntries = null;
            IdentityProviderEntryCollection? idProviders = null;

            if (_stream != null && _reader != null)
            {
                billList = ReadBillEntries();
                if (billList != null)
                {
                    finAccounts = ReadFinancialAccounts();
                    if (finAccounts != null)
                    {
                        logins = ReadGeneralLogins();
                        if (logins != null)
                        {
                            dataEntries = ReadRawDataEntries();
                            if (dataEntries != null)
                            {
                                idProviders = ReadIdentityProviders();
                                if (idProviders != null)
                                    dataSet = new PKDataSet(billList, finAccounts, logins, dataEntries, idProviders);
                            }
                        }
                    }
                }
            }
            billList?.Clear();
            finAccounts?.Clear();
            logins?.Clear();
            dataEntries?.Clear();
            idProviders?.Clear();

            return dataSet;
        }
        /// <summary>
        /// Reads the next <see cref="FinancialAccountEntry" /> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="FinancialAccountEntry" /> instance containing the data.
        /// </returns>
        public FinancialAccountEntry? ReadFinancialAccount()
        {
            if (_reader == null)
                return null;

            FinancialAccountEntry entry = new FinancialAccountEntry();

            ReadBaseFields(entry);

            entry.AccountType = (FinancialAccountType)_reader.ReadInt32();
            entry.AccountNumber = _reader.ReadString();
			entry.Company = _reader.ReadString();
            entry.Description = _reader.ReadString();
            entry.OutstandingBalance = _reader.ReadSingle();
            entry.LastAmountPaid = _reader.ReadSingle();
            entry.LastDatePaid = _reader.ReadDateTimeNullable();
            entry.NextDueDate = _reader.ReadDateTimeNullable();
            entry.CreditAvailable = _reader.ReadSingle();
            entry.MinimumPayment = _reader.ReadSingle();

            return entry;
        }
        /// <summary>
        /// Reads the list of <see cref="FinancialAccountEntry" /> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="FinancialAccountEntryCollection" /> containing the list.
        /// </returns>
        public FinancialAccountEntryCollection? ReadFinancialAccounts()
        {
            FinancialAccountEntryCollection? collection = null;

            if (_reader != null)
            {
                // Read the number of items to read.
                int length = _reader.ReadInt32();
                int count = 0;
                collection = new FinancialAccountEntryCollection();
                if (length > 0)
                {
                    FinancialAccountEntry? newItem = null;
                    do
                    {
                        newItem = ReadFinancialAccount();
                        count++;
                        if (newItem != null)
                            collection.Add(newItem);
                    } while (count < length && newItem != null);
                }
            }
            return collection;
        }
        /// <summary>
        /// Reads the next <see cref="GeneralLoginEntry" /> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="GeneralLoginEntry" /> instance containing the data.
        /// </returns>
        public GeneralLoginEntry? ReadGeneralLogin()
        {
            if (_reader == null)
                return null;

            GeneralLoginEntry entry = new GeneralLoginEntry();

            ReadBaseFields(entry);

            entry.AssociatedEmail = _reader.ReadString();
            entry.MFAActive = _reader.ReadBoolean();
            entry.Description = _reader.ReadString();
            entry.MFAPhoneNumber = _reader.ReadPhoneNumber();
            entry.ServiceDescription = _reader.ReadString();
            entry.SecurityAnswers = _reader.ReadStringList();
            entry.SecurityQuestions = _reader.ReadStringList();

            return entry;
        }
        /// <summary>
        /// Reads the list of <see cref="GeneralLoginEntry" /> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="GeneralLoginEntryCollection" /> containing the list.
        /// </returns>
        public GeneralLoginEntryCollection? ReadGeneralLogins()
        {
            GeneralLoginEntryCollection? collection = null;

            if (_reader != null)
            {
                int length = _reader.ReadInt32();
                int count = 0;
                collection = new GeneralLoginEntryCollection();
                if (length > 0)
                {
                    GeneralLoginEntry? newItem = null;
                    do
                    {
                        newItem = ReadGeneralLogin();
                        count++;
                        if (newItem != null)
                            collection.Add(newItem);
                    } while (count < length && newItem != null);
                }
            }
            return collection;
        }
        /// <summary>
        /// Reads the next <see cref="IdentityProviderEntry" /> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="IdentityProviderEntry" /> instance containing the data.
        /// </returns>
        public IdentityProviderEntry? ReadIdentityProvider()
        {
            if (_reader == null)
                return null;

            IdentityProviderEntry entry = new IdentityProviderEntry();
            ReadBaseFields(entry);

            entry.AssociatedEmail = _reader.ReadString();
            entry.MFAActive = _reader.ReadBoolean();
            entry.MFAPhoneNumber = _reader.ReadPhoneNumber();
            entry.IdentityService = (IdentityService)_reader.ReadInt32();

            return entry;
        }
        /// <summary>
        /// Reads the list of <see cref="IdentityProviderEntry" /> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="IdentityProviderEntryCollection" /> containing the list.
        /// </returns>
        public IdentityProviderEntryCollection? ReadIdentityProviders()
        {
            IdentityProviderEntryCollection? collection = null;

            if (_reader != null)
            { 
            int length = _reader.ReadInt32();
            int count = 0;
                collection = new IdentityProviderEntryCollection();
                if (length > 0)
                {
                    IdentityProviderEntry? newItem = null;
                    do
                    {
                        newItem = ReadIdentityProvider();
                        count++;
                        if (newItem != null)
                            collection.Add(newItem);
                    } while (count < length && newItem != null);
                }
            }
            return collection;
        }
        /// <summary>
        /// Reads the next <see cref="RawDataEntry" /> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="RawDataEntry" /> instance containing the data.
        /// </returns>
        public RawDataEntry? ReadRawData()
        {
            if (_reader == null)
                return null;

            RawDataEntry entry = new RawDataEntry();
            ReadBaseFields(entry);

            entry.CurrentBalance = _reader.ReadSingle();
            entry.LastPaid = _reader.ReadDateTimeNullable();
            entry.NextDue = _reader.ReadDateTimeNullable();
            entry.Available = _reader.ReadSingle();
            entry.MinimumDue = _reader.ReadSingle();
            entry.SecurityAnswers = _reader.ReadStringList();
            entry.SecurityQuestions = _reader.ReadStringList();
            return entry;
        }
        /// <summary>
        /// Reads the list of <see cref="RawDataEntry" /> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="RawDataEntryCollection" /> containing the list.
        /// </returns>
        public RawDataEntryCollection? ReadRawDataEntries()
        {
            RawDataEntryCollection? collection = null;

            if (_reader != null)
            {
                int length = _reader.ReadInt32();
                int count = 0;
                collection = new RawDataEntryCollection();
                if (length > 0)
                {
                    RawDataEntry? newItem = null;
                    do
                    {
                        newItem = ReadRawData();
                        count++;
                        if (newItem != null)
                            collection.Add(newItem);
                    } while (count < length && newItem != null);
                }
            }
            return collection;
        }
        #endregion
    }
}

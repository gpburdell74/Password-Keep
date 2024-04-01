using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Provides a container for the entity data content.
    /// </summary>
    /// <seealso cref="ExceptionTrackingBase" />
    public sealed class PKDataSet : ExceptionTrackingBase
    {
        #region Private Member Declarations        
        /// <summary>
        /// The bills list.
        /// </summary>
        private BillEntryCollection? _bills;
        /// <summary>
        /// The financial accounts list.
        /// </summary>
        private FinancialAccountEntryCollection? _finAccounts;
        /// <summary>
        /// The general login credentials list.
        /// </summary>
        private GeneralLoginEntryCollection? _logins;
        /// <summary>
        /// The identity providers credentials list.
        /// </summary>
        private IdentityProviderEntryCollection? _idProviders;
        /// <summary>
        /// The general data entries list.
        /// </summary>
        private RawDataEntryCollection? _dataEntries;
        #endregion

        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="PKDataSet"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public PKDataSet()
        {
            _bills = new BillEntryCollection();
            _finAccounts = new FinancialAccountEntryCollection();
            _logins = new GeneralLoginEntryCollection();    
            _idProviders = new IdentityProviderEntryCollection();
            _dataEntries = new RawDataEntryCollection();    
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="PKDataSet"/> class.
        /// </summary>
        /// <param name="bills">
        /// The reference to the <see cref="BillEntryCollection"/> containing items to be copied to the data set.
        /// </param>
        /// <param name="finAccounts">
        /// The reference to the <see cref="FinancialAccountEntryCollection"/> containing items to be copied to the data set.
        /// </param>
        /// <param name="logins">
        /// The reference to the <see cref="GeneralLoginEntryCollection"/> containing items to be copied to the data set.
        /// </param>
        /// <param name="dataEntries">
        /// The reference to the <see cref="RawDataEntryCollection"/> containing items to be copied to the data set.
        /// </param>
        /// <param name="idProviders">
        /// The reference to the <see cref="IdentityProviderEntryCollection"/> containing items to be copied to the data set.
        /// </param>
        public PKDataSet(BillEntryCollection bills, FinancialAccountEntryCollection finAccounts, GeneralLoginEntryCollection logins,
            RawDataEntryCollection dataEntries, IdentityProviderEntryCollection idProviders)
        {
            _bills = new BillEntryCollection();
            _finAccounts = new FinancialAccountEntryCollection();
            _logins = new GeneralLoginEntryCollection();
            _idProviders = new IdentityProviderEntryCollection();
            _dataEntries = new RawDataEntryCollection();

            _bills.AddRange(bills);
            _finAccounts.AddRange(finAccounts);
            _logins.AddRange(logins);
            _idProviders.AddRange(idProviders);
            _dataEntries.AddRange(dataEntries);

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
                _bills?.Clear();
                _finAccounts?.Clear();
                _logins?.Clear();
                _idProviders?.Clear();
                _dataEntries?.Clear();
            }

            _bills = null;
            _finAccounts = null;
            _logins = null;
            _idProviders = null;
            _dataEntries = null;

            base.Dispose(disposing);
        }
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets the reference to the list of <see cref="BillEntry"/> instances.
        /// </summary>
        /// <value>
        /// A <see cref="BillEntryCollection"/> instance containing the list, or <b>null</b>.
        /// </value>
        public BillEntryCollection? Bills => _bills;
        /// <summary>
        /// Gets the reference to the list of <see cref="FinancialAccountEntry"/> instances.
        /// </summary>
        /// <value>
        /// A <see cref="FinancialAccountEntryCollection"/> instance containing the list, or <b>null</b>.
        /// </value>
        public FinancialAccountEntryCollection? FinancialAccounts => _finAccounts;
        /// <summary>
        /// Gets the reference to the list of <see cref="GeneralLoginEntry"/> instances.
        /// </summary>
        /// <value>
        /// A <see cref="GeneralLoginEntryCollection"/> instance containing the list, or <b>null</b>.
        /// </value>
        public GeneralLoginEntryCollection? GeneralLogins => _logins;
        /// <summary>
        /// Gets the reference to the list of <see cref="IdentityProviderEntry"/> instances.
        /// </summary>
        /// <value>
        /// A <see cref="IdentityProviderEntryCollection"/> instance containing the list, or <b>null</b>.
        /// </value>
        public IdentityProviderEntryCollection? IdentityProviders => _idProviders;
        /// <summary>
        /// Gets the reference to the list of <see cref="RawDataEntry"/> instances.
        /// </summary>
        /// <value>
        /// A <see cref="RawDataEntryCollection"/> instance containing the list, or <b>null</b>.
        /// </value>
        public RawDataEntryCollection? RawData => _dataEntries;
        #endregion
    }
}

 

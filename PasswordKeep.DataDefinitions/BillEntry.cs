namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Represents and manages a data record for a household bill entry.
    /// </summary>
    /// <seealso cref="EntityBase" />
    public sealed class BillEntry : EntityBase
    {
        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="BillEntry"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public BillEntry() 
        {

        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
        /// <b>false</b> to release only unmanaged resources.</param>
        /// <returns></returns>
        protected override void Dispose(bool disposing)
        {
            AutoPayDay = 0;
			Company = null;
            IsAutoPay = false;
            OutstandingBalance = 0;
            LastAmountPaid = 0;
			LastDatePaid = null;
            NextDueDate = null;

            base.Dispose(disposing);
        }
		#endregion

		#region Public Properties                
		/// <summary>
		/// Gets or sets the day of the month on which the auto-pay executes.
		/// </summary>
		/// <value>
		/// The number of the day of the month on which the auto-pay executes, or zero (0)
        /// if not applicable.
		/// </value>
		public int AutoPayDay { get; set; }
        /// <summary>
        /// Gets or sets the company name.
        /// </summary>
        /// <value>
        /// A string containing the name of the company.
        /// </value>
        public string? Company { get; set; }
		/// <summary>
		/// Gets or sets a value indicating whether thus item has an auto-pay set up.
		/// </summary>
		/// <value>
		///   <c>true</c> if auto-pay is active for this item; otherwise, <c>false</c>.
		/// </value>
		public bool IsAutoPay { get; set; }
		/// <summary>
		/// Gets or sets the last amount paid.
		/// </summary>
		/// <value>
		/// The last amount paid, in US dollars.
		/// </value>
		public float LastAmountPaid { get; set; }
        /// <summary>
        /// Gets or sets the date/time the bill was last paid.
        /// </summary>
        /// <value>
        /// A <see cref="DateTime"/> the item was last paid, or <b>null</b>.
        /// </value>
        public DateTime? LastDatePaid { get; set; }
        /// <summary>
        /// Gets or sets the next due date for the item.
        /// </summary>
        /// <value>
        /// A <see cref="DateTime"/> specifying the next due date, or <b>null</b>.
        /// </value>
        public DateTime? NextDueDate { get; set; }
        /// <summary>
        /// Gets or sets the outstanding balance value.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> specifying the outstanding balance, in USD.
        /// </value>
        public float OutstandingBalance { get; set; }
        #endregion
    }
}

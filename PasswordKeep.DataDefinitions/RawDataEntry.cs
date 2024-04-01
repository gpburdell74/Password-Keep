using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Represents and manages a data record for a raw record entry with no classification.
    /// </summary>
    /// <seealso cref="EntityBase" />
    public sealed class RawDataEntry : EntityBase
    {
        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="RawDataEntry"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public RawDataEntry() 
        {
            SecurityAnswers = new AdaptiveStringCollection();
            SecurityQuestions = new AdaptiveStringCollection();
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
        /// <b>false</b> to release only unmanaged resources.</param>
        /// <returns></returns>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                SecurityAnswers?.Clear();
                SecurityQuestions?.Clear();
            }

            Available = 0;
            CurrentBalance = 0;
            LastPaid = null;
            MinimumDue = 0;
            NextDue = null;
            SecurityQuestions = null;
            SecurityAnswers = null;

            base.Dispose(disposing);
        }
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the available credit amount.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> specifying the available credit amount, in USD.
        /// </value>
        public float Available { get; set; }
        /// <summary>
        /// Gets or sets the current balance.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> specifying the current balance, in USD.
        /// </value>
        public float CurrentBalance { get; set; }
        /// <summary>
        /// Gets or sets the date the bill was last paid.
        /// </summary>
        /// <value>
        /// The <see cref="DateTime"/> the bill was last paid, or <b>null</b>.
        /// </value>
        public DateTime? LastPaid { get; set; }
        /// <summary>
        /// Gets or sets the minimum due amount.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> specifying the minimum due amount, in USD.
        /// </value>
        public float MinimumDue { get; set; }
        /// <summary>
        /// Gets or sets the next due date for the bill.
        /// </summary>
        /// <value>
        /// The <see cref="DateTime"/> specifying the next due date, or <b>null</b>.
        /// </value>
        public DateTime? NextDue { get; set; }
        /// <summary>
        /// Gets or sets the reference to the list of security answers.
        /// </summary>
        /// <value>
        /// An <see cref="AdaptiveStringCollection"/> instance containing the sequential list of security answers.
        /// </value>
        public AdaptiveStringCollection? SecurityAnswers { get; set; }
        /// <summary>
        /// Gets or sets the reference to the list of security questions.
        /// </summary>
        /// <value>
        /// An <see cref="AdaptiveStringCollection"/> instance containing the sequential list of security questions.
        /// </value>
        public AdaptiveStringCollection? SecurityQuestions { get; set; }
        #endregion
    }
}

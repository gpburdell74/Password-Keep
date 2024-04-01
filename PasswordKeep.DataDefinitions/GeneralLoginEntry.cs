using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Represents and manages a data record for a general login credentials entry.
    /// </summary>
    /// <seealso cref="EntityBase" />
    public sealed class GeneralLoginEntry : EntityBase
    {
        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralLoginEntry"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public GeneralLoginEntry()
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

            AssociatedEmail = null;
            MFAPhoneNumber = null;
            ServiceDescription = null;
            SecurityQuestions = null;
            SecurityAnswers = null;

            base.Dispose(disposing);
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the associated email text.
        /// </summary>
        /// <value>
        /// A string specifying the associated email address.
        /// </value>
        public string? AssociatedEmail { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether MFA is used.
        /// </summary>
        /// <value>
        ///   <c>true</c> if MFA is used; otherwise, <c>false</c>.
        /// </value>
        public bool MFAActive { get; set; }
        /// <summary>
        /// Gets or sets the phone number value used with MFA.
        /// </summary>
        /// <value>
        /// A <see cref="USPhoneNumber"/> instance containing the number, or <b>null</b>.
        /// </value>
        public USPhoneNumber? MFAPhoneNumber { get; set; }
        /// <summary>
        /// Gets or sets the service description.
        /// </summary>
        /// <value>
        /// A string containing the service description.
        /// </value>
        public string? ServiceDescription { get; set; }
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

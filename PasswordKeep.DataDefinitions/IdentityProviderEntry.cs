using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Represents and manages a data record for an identity provider credentials record entry.
    /// </summary>
    /// <seealso cref="EntityBase" />
    public sealed class IdentityProviderEntry : EntityBase
    {
        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderEntry"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public IdentityProviderEntry()
        {
            MFAPhoneNumber = new USPhoneNumber();
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
                MFAPhoneNumber?.Dispose();

            AssociatedEmail = null;
            MFAPhoneNumber = null;

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
        /// Gets or sets the identity service type being used.
        /// </summary>
        /// <value>
        /// An <see cref="IdentityService"/> enumerated value indicating the identity service provider.
        /// </value>
        public IdentityService IdentityService { get; set; } = IdentityService.None;
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
        #endregion
    }
}

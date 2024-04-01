using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
    /// <summary>
    /// Represents and manages an Identity Provider type entry.
    /// </summary>
    /// <seealso cref="BusinessBase{T}" />
    public sealed class IdentityProvider : BusinessBase<IdentityProviderEntry>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProvider"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public IdentityProvider() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProvider"/> class.
        /// </summary>
        /// <param name="entity">
        /// The <see cref="IdentityProviderEntry"/> data entity used to populate the instance.
        /// </param>
        public IdentityProvider(IdentityProviderEntry entity) : base(entity)
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the associated email text.
        /// </summary>
        /// <value>
        /// A string specifying the associated email address.
        /// </value>
        public string? AssociatedEmail
        {
            get => Data?.AssociatedEmail;
            set
            {
                if (Data != null && Data.AssociatedEmail != value)
                {
                    Data.AssociatedEmail = value;
                    OnPropertyChanged(nameof(AssociatedEmail));
                }
            }
        }
		/// <summary>
		/// Gets or sets the description text for the item.
		/// </summary>
		/// <value>
		/// A string containing the item description, or <b>null</b>.
		/// </value>
		public string? Description
		{
			get => Data?.Description;
			set
			{
				if (Data != null && Data.Description != value)
				{
					Data.Description = value;
					OnPropertyChanged(nameof(Description));
				}
			}
		}
		/// <summary>
		/// Gets or sets the identity service type being used.
		/// </summary>
		/// <value>
		/// An <see cref="IdentityService"/> enumerated value indicating the identity service provider.
		/// </value>
		public IdentityService IdentityService
		{
			get
			{
				if (Data == null)
					return IdentityService.None;
				else
					return Data.IdentityService;
			}
			set
			{
				if (Data != null && Data.IdentityService != value)
				{
					Data.IdentityService = value;
					OnPropertyChanged(nameof(IdentityService));
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether MFA is used.
		/// </summary>
		/// <value>
		///   <c>true</c> if MFA is used; otherwise, <c>false</c>.
		/// </value>
		public bool MFAActive
		{
			get
			{
				if (Data == null)
					return false;
				else
					return Data.MFAActive;
			}
			set
			{
				if (Data != null && Data.MFAActive != value)
				{
					Data.MFAActive = value;
					OnPropertyChanged(nameof(MFAActive));
				}
			}
		}
		/// <summary>
		/// Gets or sets the phone number value used with MFA.
		/// </summary>
		/// <value>
		/// A <see cref="USPhoneNumber"/> instance containing the number, or <b>null</b>.
		/// </value>
		public USPhoneNumber? MFAPhoneNumber
		{
			get => Data?.MFAPhoneNumber;
			set
			{
				if (Data != null && Data.MFAPhoneNumber != value)
				{
					Data.MFAPhoneNumber = value.Clone();
					OnPropertyChanged(nameof(MFAPhoneNumber));
				}
			}
		}
		/// <summary>
		/// Gets or sets the name for the item.
		/// </summary>
		/// <value>
		/// A string containing the item name, or <b>null</b>.
		/// </value>
		public string? Name
		{
			get => Data?.Name;
			set
			{
				if (Data != null && Data.Name != value)
				{
					Data.Name = value;
					OnPropertyChanged(nameof(Name));
				}
			}
		}
		/// <summary>
		/// Gets or sets the password value for the item.
		/// </summary>
		/// <value>
		/// A string containing the item value, or <b>null</b>.
		/// </value>
		public string? Password
		{
			get => Data?.Password;
			set
			{
				if (Data != null && Data.Password != value)
				{
					Data.Password = value;
					OnPropertyChanged(nameof(Password));
				}
			}
		}
		/// <summary>
		/// Gets or sets the associated URL for the item.
		/// </summary>
		/// <value>
		/// A string containing the URL value, or <b>null</b>.
		/// </value>
		public string? Url
		{
			get => Data?.Url;
			set
			{
				if (Data != null && Data.Url != value)
				{
					Data.Url = value;
					OnPropertyChanged(nameof(Url));
				}
			}
		}
		/// <summary>
		/// Gets or sets the User ID / email / login name value for the item.
		/// </summary>
		/// <value>
		/// A string containing the user identity value, or <b>null</b>.
		/// </value>
		public string? UserId
		{
			get => Data?.UserId;
			set
			{
				if (Data != null && Data.UserId != value)
				{
					Data.UserId = value;
					OnPropertyChanged(nameof(UserId));
				}
			}
		}
        #endregion

        #region Protected Method Overrides                
        /// <summary>
        /// Creates the new entity instance.
        /// </summary>
        /// <returns>
        /// A new <see cref="BillEntry"/> instance.
        /// </returns>
        protected override IdentityProviderEntry CreateEntity()
        {
            return new IdentityProviderEntry();
        }
        #endregion
    }
}

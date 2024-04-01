using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
    /// <summary>
    /// Represents and manages a Financial Account type entry.
    /// </summary>
    /// <seealso cref="BusinessBase{T}" />
    public sealed class FinancialAccount : BusinessBase<FinancialAccountEntry>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialAccount"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public FinancialAccount() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialAccount"/> class.
        /// </summary>
        /// <param name="entity">
        /// The <see cref="FinancialAccountEntry"/> data entity used to populate the instance.
        /// </param>
        public FinancialAccount(FinancialAccountEntry entity) : base(entity)
        {
        }
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets or sets the type of the account.
		/// </summary>
		/// <value>
		/// A <see cref="FinancialAccountType"/> enumerated value indicating the type of account.
		/// </value>
		public FinancialAccountType AccountType
		{
			get
			{
				if (Data == null)
					return FinancialAccountType.NotSpecified;
				else
					return Data.AccountType;
			}
			set
			{
				if (Data != null && Data.AccountType != value)
				{
					Data.AccountType = value;
					OnPropertyChanged(nameof(AccountType));
				}
			}
		}
		/// <summary>
		/// Gets or sets the company name.
		/// </summary>
		/// <value>
		/// A string containing the name of the company.
		/// </value>
		public string? Company
		{
			get => Data?.Company;
			set
			{
				if (Data != null && Data.Company != value)
				{
					Data.Company = value;
					OnPropertyChanged(nameof(Company));
				}
			}
		}
		/// <summary>
		/// Gets or sets the credit available amount.
		/// </summary>
		/// <value>
		/// A <see cref="float"/> specifying the credit available amount, in USD.
		/// </value>
		public float CreditAvailable
		{
			get
			{
				if (Data == null)
					return 0;
				else
					return Data.CreditAvailable;
			}
			set
			{
				if (Data != null && Data.CreditAvailable != value)
				{
					Data.CreditAvailable = value;
					OnPropertyChanged(nameof(CreditAvailable));
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
		/// Gets or sets the last amount that was paid.
		/// </summary>
		/// <value>
		/// A <see cref="float"/> specifying the last amount that was paid, in USD.
		/// </value>
		public float LastAmountPaid
		{
			get
			{
				if (Data == null)
					return 0;
				else
					return Data.LastAmountPaid;
			}
			set
			{
				if (Data != null && Data.LastAmountPaid != value)
				{
					Data.LastAmountPaid = value;
					OnPropertyChanged(nameof(LastAmountPaid));
				}
			}
		}
		/// <summary>
		/// Gets or sets the date/time the bill was last paid.
		/// </summary>
		/// <value>
		/// A <see cref="DateTime"/> the item was last paid, or <b>null</b>.
		/// </value>
		public DateTime? LastDatePaid
		{
			get => Data?.LastDatePaid;
			set
			{
				if (Data != null && Data.LastDatePaid != value)
				{
					Data.LastDatePaid = value;
					OnPropertyChanged(nameof(LastDatePaid));
				}
			}
		}
		/// <summary>
		/// Gets or sets the next minimum payment required.
		/// </summary>
		/// <value>
		/// A <see cref="float"/> specifying the next minimum payment required, in USD.
		/// </value>
		public float MinimumPayment
		{
			get
			{
				if (Data == null)
					return 0;
				else
					return Data.MinimumPayment;
			}
			set
			{
				if (Data != null && Data.MinimumPayment != value)
				{
					Data.MinimumPayment = value;
					OnPropertyChanged(nameof(MinimumPayment));
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
		/// Gets or sets the next due date for the item.
		/// </summary>
		/// <value>
		/// A <see cref="DateTime"/> specifying the next due date, or <b>null</b>.
		/// </value>
		public DateTime? NextDueDate
		{
			get => Data?.NextDueDate;
			set
			{
				if (Data != null && Data.NextDueDate != value)
				{
					Data.NextDueDate = value;
					OnPropertyChanged(nameof(NextDueDate));
				}
			}
		}
		/// <summary>
		/// Gets or sets the outstanding balance amount.
		/// </summary>
		/// <value>
		/// A <see cref="float"/> specifying the outstanding balance amount, in USD.
		/// </value>
		public float OutstandingBalance
		{
			get
			{
				if (Data == null)
					return 0;
				else
					return Data.OutstandingBalance;
			}
			set
			{
				if (Data != null && Data.OutstandingBalance != value)
				{
					Data.OutstandingBalance = value;
					OnPropertyChanged(nameof(OutstandingBalance));
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
        /// A new <see cref="FinancialAccountEntry"/> instance.
        /// </returns>
        protected override FinancialAccountEntry CreateEntity()
        {
            return new FinancialAccountEntry();
        }
        #endregion
    }
}

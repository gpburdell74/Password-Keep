using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Provides the methods and functions to convert <see cref="FinancialAccountType"/> enumeration types to string values and back.
    /// </summary>
    /// <seealso cref="IValueConverter{F,T}" />
    public sealed class FinancialAccountTypeConverter : IValueConverter<FinancialAccountType, string>
    {
        #region Private Member Declarations        
        /// <summary>
        /// The service names to enumerations list.
        /// </summary>
        private Dictionary<string, FinancialAccountType> _services;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialAccountTypeConverter"/> class.
        /// </summary>
        public FinancialAccountTypeConverter()
        {
            _services = new Dictionary<string, FinancialAccountType>
            {
                { Properties.Resources.FinTypeCreditCard.ToLower(), FinancialAccountType.CreditCard },
                { Properties.Resources.FinTypePersonalLoan.ToLower(), FinancialAccountType.PersonalLoan },
                { Properties.Resources.FinTypeCarLoan.ToLower(), FinancialAccountType.CarLoan },
                { Properties.Resources.FinTypeMortgage.ToLower(), FinancialAccountType.Mortgage },
                { Properties.Resources.FinTypeOther.ToLower(), FinancialAccountType.Other }
            };
        }
        #endregion

        #region Public Methods / Functions        
        /// <summary>
        /// Converts the <see cref="FinancialAccountType"/> enumerated value to a string.
        /// </summary>
        /// <param name="originalValue">
        /// The original value <see cref="FinancialAccountType"/> enumerated value to be converted.
        /// </param>
        /// <returns>
        /// A string matching the specified enumeration value, or <see cref="string.Empty"/> if the match fails.
        /// </returns>
        public string Convert(FinancialAccountType originalValue)
        {
            string value = string.Empty;

            switch (originalValue)
            {
                case FinancialAccountType.Bank:
                    value = Properties.Resources.FinTypeBank;
                    break;

				case FinancialAccountType.CarLoan:
                    value = Properties.Resources.FinTypeCarLoan;
					break;

				case FinancialAccountType.CreditCard:
                    value = Properties.Resources.FinTypeCreditCard;
                    break;

                case FinancialAccountType.CreditUnion:
                    value = Properties.Resources.FinTypeCreditUnion;
					break;

				case FinancialAccountType.Insurance:
                    value = Properties.Resources.FinTypeInsurance;
					break;

				case FinancialAccountType.Investment:
                    value = Properties.Resources.FinTypeInvestment;
					break;

				case FinancialAccountType.Mortgage:
                    value = Properties.Resources.FinTypeMortgage;
					break;

				case FinancialAccountType.Other:
                    value = Properties.Resources.FinTypeOther;
					break;

				case FinancialAccountType.PersonalLoan:
                    value = Properties.Resources.FinTypePersonalLoan;
                    break;

                case FinancialAccountType.SavingsAndLoan:
                    value = Properties.Resources.FinTypeSavingsAndLoan;
					break;

				default:
                    value = Properties.Resources.FinTypeNotSpecified;
                    break;
            }

            return value;
        }
        /// <summary>
        /// Converts the string value to the <see cref="FinancialAccountType"/> enumerated value.
        /// </summary>
        /// <param name="convertedValue">
        /// The string value to be converted to a <see cref="FinancialAccountType"/> enumerated value.
        /// </param>
        /// <returns>
        /// The <see cref="FinancialAccountType"/> enumerated value that matches the specified string.
        /// </returns>
        /// <remarks>
        /// The implementation of this method must be the inverse of the <see cref="Convert" /> method.
        /// </remarks>
        public FinancialAccountType ConvertBack(string convertedValue)
        {
            FinancialAccountType service = FinancialAccountType.Other;

            string compareString = convertedValue.ToLower().Trim();
            if (_services.ContainsKey(compareString))
                service = _services[compareString];

            return service;
        }
        #endregion
    }
}

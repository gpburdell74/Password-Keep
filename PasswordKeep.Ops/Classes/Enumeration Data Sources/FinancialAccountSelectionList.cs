using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
	/// <summary>
	/// Contains a list of, and provides the data source for financial account types for a data grid drop-down.
	/// </summary>
	/// <seealso cref="List{T}" />
	/// <seealso cref="FinancialAccountSelection"/>
	public sealed class FinancialAccountTypeSelectionList : List<FinancialAccountSelection>
	{
		#region Constructor		
		/// <summary>
		/// Initializes a new instance of the <see cref="FinancialAccountTypeSelectionList"/> class.
		/// </summary>
		public FinancialAccountTypeSelectionList()
		{
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.NotSpecified });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.Bank });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.CarLoan });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.CreditCard });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.CreditUnion });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.Insurance });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.Investment });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.Mortgage });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.Other });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.PersonalLoan });
			Add(new FinancialAccountSelection { AccountType = FinancialAccountType.SavingsAndLoan });
		}
		#endregion
	}
}

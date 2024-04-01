namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Lists the types of financial accounts that are currently supported.
    /// </summary>
    public enum FinancialAccountType
    {
        /// <summary>
        /// Indicates the account type is not specified.
        /// </summary>
        NotSpecified = 0,
        /// <summary>
        /// Indicates a credit card account.
        /// </summary>
        CreditCard = 1,
        /// <summary>
        /// Indicates a personal loan.
        /// </summary>
        PersonalLoan = 2,
        /// <summary>
        /// Indicates a car loan.
        /// </summary>
        CarLoan = 3,
        /// <summary>
        /// Indicates a mortgage.
        /// </summary>
        Mortgage = 4,
		/// <summary>
		/// Indicates a banking institution.
		/// </summary>
		Bank = 5,
		/// <summary>
		/// Indicates a savings and loan institution.
		/// </summary>
		SavingsAndLoan = 6,
		/// <summary>
		/// Indicates a credit union institution.
		/// </summary>
		CreditUnion = 7,
		/// <summary>
		/// Indicates an inventment institution / account.
		/// </summary>
		Investment = 8,
		/// <summary>
		/// Indicates an insurance institution / account.
		/// </summary>
		Insurance = 9,
		/// <summary>
		/// Indicates another type.
		/// </summary>
		Other = 99
    }
}

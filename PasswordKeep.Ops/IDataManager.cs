namespace PasswordKeep.Ops
{
	/// <summary>
	/// Provides the signature definition for the data manager implementations.
	/// </summary>
	/// <seealso cref="IDisposable" />
	public interface IDataManager : IDisposable
	{
		#region Properties
		/// <summary>
		/// Gets the referende to the bills list.
		/// </summary>
		/// <value>
		/// A <see cref="BillCollection"/> containing the data, or <b>null</b>.
		/// </value>
		BillCollection? Bills { get; }
		/// <summary>
		/// Gets the referende to the financial accounts list.
		/// </summary>
		/// <value>
		/// A <see cref="FinancialAccountCollection"/> containing the data, or <b>null</b>.
		/// </value>
		FinancialAccountCollection? FinancialAccounts { get; }
		/// <summary>
		/// Gets the referende to the general data entries list.
		/// </summary>
		/// <value>
		/// A <see cref="GeneralDataCollection"/> containing the data, or <b>null</b>.
		/// </value>
		GeneralDataCollection? GeneralDataEntries { get; }
		/// <summary>
		/// Gets the referende to the general login credentials list.
		/// </summary>
		/// <value>
		/// A <see cref="GeneralLoginCollection"/> containing the data, or <b>null</b>.
		/// </value>
		GeneralLoginCollection? GeneralLogins { get; }
		/// <summary>
		/// Gets the referende to the identity provider credentials list.
		/// </summary>
		/// <value>
		/// A <see cref="IdentityProviderCollection"/> containing the data, or <b>null</b>.
		/// </value>
		IdentityProviderCollection? IdentityProviders { get; }
		#endregion

		#region Methods / Functions        
		/// <summary>
		/// Clears the current data content.
		/// </summary>
		void Clear();
		/// <summary>
		/// Loads the data content from the specified file name.
		/// </summary>
		/// <param name="fileName">
		/// A string containing the fully-qualified path and name of the file to be read.
		/// </param>
		void Load(string fileName);
		/// <summary>
		/// Loads the data content from the specified stream.
		/// </summary>
		/// <param name="sourceStream">
		/// A <see cref="Stream"/> to read the contents from.
		/// </param>
		void Load(Stream sourceStream);
		/// <summary>
		/// Saves the data content to the specified file name.
		/// </summary>
		/// <param name="fileName">
		/// A string containing the fully-qualified path and name of the file to be saved.
		/// </param>
		void Save(string fileName);
		/// <summary>
		/// Saves the data content to the specified stream.
		/// </summary>
		/// <param name="destinationStream">
		/// The destination <see cref="Stream"/> to write the contents to.
		/// </param>
		void Save(Stream destinationStream);
		#endregion
	}
}
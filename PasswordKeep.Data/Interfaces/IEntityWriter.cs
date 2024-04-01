using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Data
{
    /// <summary>
    /// Provides the signature definition for instances that write the data entity content to a source.
    /// </summary>
    /// <seealso cref="IExceptionTracking" />
    public interface IEntityWriter : IExceptionTracking
    {
        #region Methods / Functions
        /// <summary>
        /// Closes the instance.
        /// </summary>
        void Close();
        /// <summary>
        /// Writes the base field / column values from the provided instance.
        /// </summary>
        /// <param name="entityBase">
        /// The <see cref="EntityBase"/> instance being written to the data source.
        /// </param>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool WriteBaseFields(EntityBase entityBase);
        /// <summary>
        /// Writes the list of <see cref="BillEntry"/> instances to the data source.
        /// </summary>
        /// <param name="collection">
        /// A <see cref="BillEntryCollection"/> instance containing the list to write.
        /// </param>
        void WriteBillEntries(BillEntryCollection collection);
        /// <summary>
        /// Writes the <see cref="BillEntry"/> instance to the data source.
        /// </summary>
        /// <param name="entry">
        /// A <see cref="BillEntry"/> instance containing the data to be written.
        /// </param>
        void WriteBillEntry(BillEntry entry);
        /// <summary>
        /// Writes the entire content of the data set to the data source.
        /// </summary>
        /// <param name="dataSet">
        /// The <see cref="PKDataSet"/> whose contents are to be saved.
        /// </param>
        void WriteDataSet(PKDataSet dataSet);
        /// <summary>
        /// Writes the <see cref="FinancialAccountEntry"/> instance to the data source.
        /// </summary>
        /// <param name="entry">
        /// A <see cref="FinancialAccountEntry"/> instance containing the data to be written.
        /// </param>
        void WriteFinancialAccount(FinancialAccountEntry entry);
        /// <summary>
        /// Writes the list of <see cref="FinancialAccountEntry"/> instances to the data source.
        /// </summary>
        /// <param name="collection">
        /// A <see cref="FinancialAccountEntryCollection"/> instance containing the list to write.
        /// </param>
        void WriteFinancialAccounts(FinancialAccountEntryCollection collection);
        /// <summary>
        /// Writes the <see cref="GeneralLoginEntry"/> instance to the data source.
        /// </summary>
        /// <param name="entry">
        /// A <see cref="GeneralLoginEntry"/> instance containing the data to be written.
        /// </param>
        void WriteGeneralLogin(GeneralLoginEntry entry);
        /// <summary>
        /// Writes the list of <see cref="GeneralLoginEntry"/> instances to the data source.
        /// </summary>
        /// <param name="collection">
        /// A <see cref="GeneralLoginEntryCollection"/> instance containing the list to write.
        /// </param>
        void WriteGeneralLogins(GeneralLoginEntryCollection collection);
        /// <summary>
        /// Writes the <see cref="IdentityProviderEntry"/> instance to the data source.
        /// </summary>
        /// <param name="entry">
        /// A <see cref="IdentityProviderEntry"/> instance containing the data to be written.
        /// </param>
        void WriteIdentityProvider(IdentityProviderEntry entry);
        /// <summary>
        /// Writes the list of <see cref="IdentityProviderEntry"/> instances to the data source.
        /// </summary>
        /// <param name="collection">
        /// A <see cref="IdentityProviderEntryCollection"/> instance containing the list to write.
        /// </param>
        void WriteIdentityProviders(IdentityProviderEntryCollection collection);
        /// <summary>
        /// Writes the <see cref="RawDataEntry"/> instance to the data source.
        /// </summary>
        /// <param name="entry">
        /// A <see cref="RawDataEntry"/> instance containing the data to be written.
        /// </param>
        void WriteRawData(RawDataEntry entry);
        /// <summary>
        /// Writes the list of <see cref="RawDataEntry"/> instances to the data source.
        /// </summary>
        /// <param name="collection">
        /// A <see cref="RawDataEntryCollection"/> instance containing the list to write.
        /// </param>
        void WriteRawDataEntries(RawDataEntryCollection collection);
        #endregion
    }
}

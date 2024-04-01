using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Data
{
    /// <summary>
    /// Provides the signature definition for instances that read the data entity content from a source.
    /// </summary>
    /// <seealso cref="IExceptionTracking" />
    public interface IEntityReader : IExceptionTracking
    {
        #region Methods / Functions        
        /// <summary>
        /// Closes the instance.
        /// </summary>
        void Close();
        /// <summary>
        /// Reads the base field / column values onto the provided instance.
        /// </summary>
        /// <param name="entry">
        /// The <see cref="EntityBase"/> instance being populated.
        /// </param>
        /// <returns>
        /// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
        /// </returns>
        bool ReadBaseFields(EntityBase entry);
        /// <summary>
        /// Reads the list of <see cref="BillEntry"/> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="BillEntryCollection"/> containing the list.
        /// </returns>
        BillEntryCollection? ReadBillEntries();
        /// <summary>
        /// Reads the next <see cref="BillEntry"/> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="BillEntry"/> instance containing the data.
        /// </returns>
        BillEntry? ReadBillEntry();
        /// <summary>
        /// Reads the entire content of the data set from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="PKDataSet"/> instance if successful; otherwise, returns <b>null</b>.
        /// </returns>
        PKDataSet? ReadDataSet();
        /// <summary>
        /// Reads the next <see cref="FinancialAccountEntry"/> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="FinancialAccountEntry"/> instance containing the data.
        /// </returns>
        FinancialAccountEntry? ReadFinancialAccount();
        /// <summary>
        /// Reads the list of <see cref="FinancialAccountEntry"/> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="FinancialAccountEntryCollection"/> containing the list.
        /// </returns>
        FinancialAccountEntryCollection? ReadFinancialAccounts();
        /// <summary>
        /// Reads the next <see cref="GeneralLoginEntry"/> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="GeneralLoginEntry"/> instance containing the data.
        /// </returns>
        GeneralLoginEntry? ReadGeneralLogin();
        /// <summary>
        /// Reads the list of <see cref="GeneralLoginEntry"/> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="GeneralLoginEntryCollection"/> containing the list.
        /// </returns>
        GeneralLoginEntryCollection? ReadGeneralLogins();
        /// <summary>
        /// Reads the next <see cref="IdentityProviderEntry"/> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="IdentityProviderEntry"/> instance containing the data.
        /// </returns>
        IdentityProviderEntry? ReadIdentityProvider();
        /// <summary>
        /// Reads the list of <see cref="IdentityProviderEntry"/> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="IdentityProviderEntryCollection"/> containing the list.
        /// </returns>
        IdentityProviderEntryCollection? ReadIdentityProviders();
        /// <summary>
        /// Reads the next <see cref="RawDataEntry"/> record from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="RawDataEntry"/> instance containing the data.
        /// </returns>
        RawDataEntry? ReadRawData();
        /// <summary>
        /// Reads the list of <see cref="RawDataEntry"/> instances from the data source.
        /// </summary>
        /// <returns>
        /// A <see cref="RawDataEntryCollection"/> containing the list.
        /// </returns>
        RawDataEntryCollection? ReadRawDataEntries();
        #endregion
    }
}

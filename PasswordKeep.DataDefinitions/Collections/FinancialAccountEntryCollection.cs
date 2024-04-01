namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Contains a list of <see cref="FinancialAccountEntry"/> instances.
    /// </summary>
    /// <seealso cref="List{T}" />
    public sealed class FinancialAccountEntryCollection : List<FinancialAccountEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialAccountEntryCollection"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public FinancialAccountEntryCollection()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="FinancialAccountEntryCollection"/> class.
        /// </summary>
        /// <param name="entries">
        /// The <see cref="IEnumerable{T}"/> list of <see cref="FinancialAccountEntry"/> instances to populate the collection.
        /// </param>
        public FinancialAccountEntryCollection(IEnumerable<FinancialAccountEntry> entries)
        {
            AddRange(entries);
        }
    }
}

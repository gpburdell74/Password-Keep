namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Contains a list of <see cref="BillEntry"/> instances.
    /// </summary>
    /// <seealso cref="List{T}" />
    public sealed class BillEntryCollection : List<BillEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillEntryCollection"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public BillEntryCollection()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BillEntryCollection"/> class.
        /// </summary>
        /// <param name="entries">
        /// The <see cref="IEnumerable{T}"/> list of <see cref="BillEntry"/> instances to populate the collection.
        /// </param>
        public BillEntryCollection(IEnumerable<BillEntry> entries) 
        {
            AddRange(entries);
        }
    }
}

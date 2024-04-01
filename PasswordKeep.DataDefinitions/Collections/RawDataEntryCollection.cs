namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Contains a list of <see cref="RawDataEntry"/> instances.
    /// </summary>
    /// <seealso cref="List{T}" />
    public sealed class RawDataEntryCollection : List<RawDataEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RawDataEntryCollection"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public RawDataEntryCollection()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RawDataEntryCollection"/> class.
        /// </summary>
        /// <param name="entries">
        /// The <see cref="IEnumerable{T}"/> list of <see cref="RawDataEntry"/> instances to populate the collection.
        /// </param>
        public RawDataEntryCollection(IEnumerable<RawDataEntry> entries)
        {
            AddRange(entries);
        }
    }
}

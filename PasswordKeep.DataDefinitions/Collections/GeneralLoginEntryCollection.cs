namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Contains a list of <see cref="GeneralLoginEntry"/> instances.
    /// </summary>
    /// <seealso cref="List{T}" />
    public sealed class GeneralLoginEntryCollection : List<GeneralLoginEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralLoginEntryCollection"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public GeneralLoginEntryCollection()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralLoginEntryCollection"/> class.
        /// </summary>
        /// <param name="entries">
        /// The <see cref="IEnumerable{T}"/> list of <see cref="GeneralLoginEntry"/> instances to populate the collection.
        /// </param>
        public GeneralLoginEntryCollection(IEnumerable<GeneralLoginEntry> entries)
        {
            AddRange(entries);
        }
    }
}

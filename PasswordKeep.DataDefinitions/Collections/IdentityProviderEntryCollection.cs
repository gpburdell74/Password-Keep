namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Contains a list of <see cref="IdentityProviderEntry"/> instances.
    /// </summary>
    /// <seealso cref="List{T}" />
    public sealed class IdentityProviderEntryCollection : List<IdentityProviderEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderEntryCollection"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public IdentityProviderEntryCollection()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityProviderEntryCollection"/> class.
        /// </summary>
        /// <param name="entries">
        /// The <see cref="IEnumerable{T}"/> list of <see cref="IdentityProviderEntry"/> instances to populate the collection.
        /// </param>
        public IdentityProviderEntryCollection(IEnumerable<IdentityProviderEntry> entries)
        {
            AddRange(entries);
        }
    }
}

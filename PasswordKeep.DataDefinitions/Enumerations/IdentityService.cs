namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Lists the types of identity services that are currently supported.
    /// </summary>
    public enum IdentityService
    {
        /// <summary>
        /// Indicates no identity service is specified.
        /// </summary>
        None = 0,
        /// <summary>
        /// Indicates the Microsoft Identity Provider.
        /// </summary>
        Microsoft = 1,
        /// <summary>
        /// Indicates the Google Identity Provider.
        /// </summary>
        Google = 2,
        /// <summary>
        /// Indicates the Facebook Identity Provider.
        /// </summary>
        Facebook = 3,
        /// <summary>
        /// Indicates the Apple Identity Provider.
        /// </summary>
        Apple = 4,
        /// <summary>
        /// Indicates another identity provider.
        /// </summary>
        Custom = 5
    }
}

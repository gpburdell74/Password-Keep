using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Provides the methods and functions to convert <see cref="IdentityService"/> enumeration types to string values and back.
    /// </summary>
    /// <seealso cref="IValueConverter{F,T}" />
    public sealed class IdentityServiceConverter : IValueConverter<IdentityService, string>
    {
        #region Private Member Declarations        
        /// <summary>
        /// The service names to enumerations list.
        /// </summary>
        private Dictionary<string, IdentityService> _services;
        #endregion

        #region Constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="IdentityServiceConverter"/> class.
        /// </summary>
        public IdentityServiceConverter()
        {
            _services = new Dictionary<string, IdentityService>
            {
                { Properties.Resources.OfficialNameApple.ToLower(), IdentityService.Apple },
                { Properties.Resources.OfficialNameFacebook.ToLower(), IdentityService.Facebook },
                { Properties.Resources.OfficialNameGoogle.ToLower(), IdentityService.Google },
                { Properties.Resources.OfficialNameMicrosoft.ToLower(), IdentityService.Microsoft },
                { Properties.Resources.OfficialNameCustom.ToLower(), IdentityService.Custom }
            };
        }
        #endregion

        #region Public Methods / Functions        
        /// <summary>
        /// Converts the <see cref="IdentityService"/> enumerated value to a string.
        /// </summary>
        /// <param name="originalValue">
        /// The original value <see cref="IdentityService"/> enumerated value to be converted.
        /// </param>
        /// <returns>
        /// A string matching the specified enumeration value, or <see cref="string.Empty"/> if the match fails.
        /// </returns>
        public string Convert(IdentityService originalValue)
        {
            string value = string.Empty;

            switch(originalValue)
            {
                case IdentityService.Apple:
                    value = Properties.Resources.OfficialNameApple;
                    break;

                case IdentityService.Facebook:
                    value = Properties.Resources.OfficialNameFacebook;
                    break;

                case IdentityService.Google:
                    value = Properties.Resources.OfficialNameGoogle;
                    break;

                case IdentityService.Microsoft:
                    value = Properties.Resources.OfficialNameMicrosoft;
                    break;

                case IdentityService.None:
                    value = Properties.Resources.OfficialNameNone;
                    break;

                case IdentityService.Custom:
                    value = Properties.Resources.OfficialNameCustom;
                    break;
            }

            return value;
        }
        /// <summary>
        /// Converts the converted value to the original representation.
        /// </summary>
        /// <param name="convertedValue">
        /// The string value to be converted to a <see cref="IdentityService"/> enumerated value.
        /// </param>
        /// <returns>
        /// The <see cref="IdentityService"/> enumerated value that matches the specified string.
        /// </returns>
        /// <remarks>
        /// The implementation of this method must be the inverse of the <see cref="Convert" /> method.
        /// </remarks>
        public IdentityService ConvertBack(string convertedValue)
        {
            IdentityService service = IdentityService.None;

            string compareString = convertedValue.ToLower().Trim();
            if (_services.ContainsKey(compareString))
                service = _services[compareString];

            return service;
        }
        #endregion
    }
}

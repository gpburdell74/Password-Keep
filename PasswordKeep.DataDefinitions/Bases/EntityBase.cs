using Adaptive.Intelligence.Shared;
using Adaptive.Intelligence.Shared.Security;

namespace PasswordKeep.Data.Entity
{
    /// <summary>
    /// Provides the base definition for the data entities in the application.
    /// </summary>
    /// <seealso cref="DisposableObjectBase" />
    public abstract class EntityBase : DisposableObjectBase
    {
        #region Private Methods / Functions        
        /// <summary>
        /// The secure string container for the user ID value.
        /// </summary>
        private SecureString? _userId;
        /// <summary>
        /// The secure string container for the password value.
        /// </summary>
        private SecureString? _password;
        #endregion

        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        protected EntityBase()
        {
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
        /// <b>false</b> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                _userId?.Dispose();
                _password?.Dispose();
            }

            Name = null;
            Description = null;
            Url = null;
            _userId = null;
            _password = null;
            base.Dispose(disposing);
        }
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets or sets the description text for the item.
        /// </summary>
        /// <value>
        /// A string containing the item description, or <b>null</b>.
        /// </value>
        public virtual string? Description { get; set; }
        /// <summary>
        /// Gets or sets the name for the item.
        /// </summary>
        /// <value>
        /// A string containing the item name, or <b>null</b>.
        /// </value>
        public virtual string? Name { get; set; }
        /// <summary>
        /// Gets or sets the password value for the item.
        /// </summary>
        /// <value>
        /// A string containing the item value, or <b>null</b>.
        /// </value>
        public virtual string? Password
        {
            get { return _password?.Value; }
            set
            {
                if (value == null)
                {
                    _password?.Dispose();
                    _password = null;
                }
                else
                {
                    if (_password == null)
                        _password = new SecureString(value);
                    else
                    {
                        _password.ClearStorage();
                        _password.Value = value;
                    }
                }
            }
        }
        /// <summary>
        /// Gets or sets the associated URL for the item.
        /// </summary>
        /// <value>
        /// A string containing the URL value, or <b>null</b>.
        /// </value>
        public virtual string? Url { get; set; }
        /// <summary>
        /// Gets or sets the User ID / email / login name value for the item.
        /// </summary>
        /// <value>
        /// A string containing the user identity value, or <b>null</b>.
        /// </value>
        public virtual string? UserId
        {
            get { return _userId?.Value; }
            set
            {
                if (value == null)
                {
                    _userId?.Dispose();
                    _userId = null;
                }
                else
                {
                    if (_userId == null)
                        _userId = new SecureString(value);
                    else
                    {
                        _userId.ClearStorage();
                        _userId.Value = value;
                    }
                }
            }
        }
        #endregion
    }
}

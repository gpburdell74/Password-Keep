using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;
using System.ComponentModel;

namespace PasswordKeep.Ops
{
    /// <summary>
    /// Provides the base definition for business classes.
    /// </summary>
    /// <seealso cref="ExceptionTrackingBase" />
    public abstract class BusinessBase<T> : ExceptionTrackingBase, INotifyPropertyChanged where T : EntityBase
    {
        #region Public Events        
        /// <summary>
        /// Occurs when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        #endregion

        #region Private Member Declarations        
        /// <summary>
        /// The data entity instance.
        /// </summary>
        private T? _entity;
        #endregion

        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessBase{T}"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public BusinessBase()
        {
            _entity = CreateEntity();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessBase{T}"/> class.
        /// </summary>
        /// <param name="entity">
        /// The <typeparamref name="T"/>" data entity used to populate the instance.
        /// </param>
        public BusinessBase(T entity)
        {
            _entity = entity;
        }
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
        /// <b>false</b> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            _entity?.Dispose();
            _entity = null;
            base.Dispose(disposing);
        }
        #endregion

        #region Public Properties        
        /// <summary>
        /// Gets the reference to the underlying data content.
        /// </summary>
        /// <value>
        /// The <typeparamref name="T"/> data instance being managed.
        /// </value>
        public T? Data => _entity;
        #endregion

        #region Protected Abstract Methods                
        /// <summary>
        /// Creates the new entity instance.
        /// </summary>
        /// <returns>
        /// A new instance of <typeparamref name="T"/>.
        /// </returns>
        protected abstract T CreateEntity();
        #endregion

        #region Protected Event Methods        
        /// <summary>
        /// Raises the <see cref="E:PropertyChanged" /> event.
        /// </summary>
        /// <param name="propertyName">
        /// A string containing the name of the property whose value was modified.
        /// </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Raises the <see cref="E:PropertyChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="PropertyChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        #endregion
    }
}

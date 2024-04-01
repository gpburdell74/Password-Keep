using Adaptive.Intelligence.Shared;
using PasswordKeep.Data;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
    /// <summary>
    /// Provides the base definition for the business object collections.
    /// </summary>
    /// <typeparam name="T">
    /// The data type of the business objects to be stored in the collection.
    /// </typeparam>
    /// <typeparam name="E">
    /// The data type of the entity objects related to the <typeparamref name="T"/> classes.
    /// </typeparam>
    /// <seealso cref="AdaptiveCollectionBase{T}" />
    public abstract class BusinessCollectionBase<T, E> : AdaptiveCollectionBase<T>
        where T: BusinessBase<E>
        where E: EntityBase
    {
        #region Constructor / Dispose Methods        
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessCollectionBase{T, E}"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public BusinessCollectionBase() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessCollectionBase{T, E}"/> class.
        /// </summary>
        /// <param name="capacity">The number of elements that the new list can initially store.</param>
        public BusinessCollectionBase(int capacity) : base(capacity) 
        { 
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessCollectionBase{T, E}"/> class.
        /// </summary>
        /// <param name="collection">The collection whose elements are copied to the new list.</param>
        public BusinessCollectionBase(IEnumerable<T> collection) : base(collection)
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessCollectionBase{T, E}"/> class.
        /// </summary>
        /// <param name="dataRecordList">
        /// An <see cref="IEnumerable{T}"/> list of <typeparamref name="E"/> entity instances used to 
        /// populate the collection.
        /// </param>
        public BusinessCollectionBase(IEnumerable<E>? dataRecordList) : base()
        {
            if (dataRecordList != null)
            {
                foreach (E dataRecord in dataRecordList)
                {
                    Add(CreateInstance(dataRecord));
                }
            }
        }
        #endregion

        #region Public Abstract Methods
        /// <summary>
        /// Extracts the list of data record entities from the business objects in the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="List{T}"/> of <typeparamref name="E"/> instances containing the data to be written to a data store.
        /// </returns>
        public abstract List<E> ExtractEntityList();
        #endregion

        #region Protected Abstract Methods        
        /// <summary>
        /// Creates the business object instance from the provided data entity record.
        /// </summary>
        /// <param name="dataRecord">
        /// The <typeparamref name="E"/> data entity/record to create the business object from.
        /// </param>
        /// <returns>
        /// A new instance of <typeparamref name="T"/>.
        /// </returns>
        protected abstract T CreateInstance(E dataRecord);
        /// <summary>
        /// Reads the data entries from the supplied reader instance.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="IEntityReader"/> implementation instance used to read the data.
        /// </param>
        /// <returns>
        /// A <see cref="List{T}"/> of <typeparamref name="E"/> instances used to populate a new collection.
        /// </returns>
        protected abstract List<E>? ReadEntries(IEntityReader reader);
        /// <summary>
        /// Writes the data entries to the data store.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="IEntityWriter"/> implementation instance used to write the data.
        /// </param>
        /// <param name="entries">
        /// The <see cref="List{E}"/> of data entity records to be written.
        /// </param>
        protected abstract void WriteEntries(IEntityWriter writer, List<E> entries);
        #endregion

        #region Public Methods / Functions        
        /// <summary>
        /// Loads the data content from the specified reader instance.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="IEntityReader"/> implementation instance used to read the data.
        /// </param>
        public virtual void LoadContent(IEntityReader reader)
        {
            Clear();

            List<E>? dataList = ReadEntries(reader);
            if (dataList != null)
            {
                foreach (E entity in dataList)
                {
                    Add(CreateInstance(entity));
                }
            }
            dataList?.Clear();
        }
        /// <summary>
        /// Saves the content to the data store.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="IEntityWriter"/> implementation instance used to write the data.
        /// </param>
        public virtual void SaveContent(IEntityWriter writer)
        {
            List<E> dataList = ExtractEntityList();
            WriteEntries(writer, dataList);
            dataList.Clear();
        }
        #endregion
    }
}

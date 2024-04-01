using PasswordKeep.Data;
using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
	/// <summary>
	/// Contains and manages a list of <see cref="GeneralData"/> objects.
	/// </summary>
	/// <seealso cref="BusinessCollectionBase{T, D}" />
	public sealed class GeneralDataCollection : BusinessCollectionBase<GeneralData, RawDataEntry>
    {
		#region Constructors        
		/// <summary>
		/// Initializes a new instance of the <see cref="GeneralDataCollection"/> class.
		/// </summary>
		/// <remarks>
		/// This is the default constructor.
		/// </remarks>
		public GeneralDataCollection()
		{

		}
		/// <summary>
		/// Initializes a new instance of the <see cref="GeneralDataCollection"/> class.
		/// </summary>
		/// <param name="entries">
		/// The <see cref="IEnumerable{T}"/> list of <see cref="RawDataEntry"/> instances used to populate the collection.
		/// </param>
		public GeneralDataCollection(IEnumerable<RawDataEntry>? entries) : base(entries)
		{

		}
		#endregion

		#region Protected Method Overrides        
		/// <summary>
		/// Creates the business object instance from the provided data entity record.
		/// </summary>
		/// <param name="dataRecord">
		/// The <see cref="BillEntry"/> data entity/record to create the business object from.
		/// </param>
		/// <returns>
		/// A new instance of <see cref="GeneralData"/>.
		/// </returns>
		protected override GeneralData CreateInstance(RawDataEntry dataRecord)
        {
            return new GeneralData(dataRecord);
        }
		/// <summary>
		/// Extracts the list of data record entities from the business objects in the collection.
		/// </summary>
		/// <returns>
		/// A <see cref="RawDataEntryCollection" />  containing the list of of <see cref="RawDataEntry"/> instances containing the data to be written to a data store.
		/// </returns>
		public override RawDataEntryCollection ExtractEntityList()
        {
			RawDataEntryCollection list = new RawDataEntryCollection();
            foreach (GeneralData item in this)
            {
                if (item.Data != null)
                    list.Add(item.Data);
            }
            return list;
        }
        /// <summary>
        /// Reads the data entries from the supplied reader instance.
        /// </summary>
        /// <param name="reader">
        /// The <see cref="IEntityReader" /> implementation instance used to read the data.
        /// </param>
        /// <returns>
        /// A <see cref="List{T}" /> of <see cref="BillEntry"/> instances used to populate a new collection.
        /// </returns>
        protected override List<RawDataEntry>? ReadEntries(IEntityReader reader)
        {
            return reader.ReadRawDataEntries();
        }
        /// <summary>
        /// Writes the data entries to the data store.
        /// </summary>
        /// <param name="writer">
        /// The <see cref="IEntityWriter" /> implementation instance used to write the data.
        /// </param>
        /// <param name="entries">
        /// The <see cref="List{E}" /> of <see cref="BillEntry"/> data entity records to be written.
        /// </param>
        protected override void WriteEntries(IEntityWriter writer, List<RawDataEntry> entries)
        {
            writer.WriteRawDataEntries(new RawDataEntryCollection(entries));
        }
        #endregion
    }
}

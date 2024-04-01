using Adaptive.Intelligence.Shared;
using Adaptive.Intelligence.Shared.IO;
using PasswordKeep.Data.Entity;
using PasswordKeep.Data.IO;

namespace PasswordKeep.Data
{
	/// <summary>
	/// Provides the implementation for wrting the entity records to a data store as encrypted content.
	/// </summary>
	/// <seealso cref="ExceptionTrackingBase" />
	/// <seealso cref="IEntityWriter" />
	public sealed class CryptoEntityWriter : ExceptionTrackingBase, IEntityWriter
	{
		#region Private Member Declarations        
		/// <summary>
		/// The underlying stream to write to.
		/// </summary>
		private Stream? _stream;
		/// <summary>
		/// The writer instance.
		/// </summary>
		private CryptoSafeWriter? _writer;
		#endregion

		#region Constructor / Dispose Methods        
		/// <summary>
		/// Initializes a new instance of the <see cref="ClearEntityWriter"/> class.
		/// </summary>
		/// <param name="destinationStream">
		/// The reference to the <see cref="Stream"/> instance to be written to.
		/// </param>
		/// <param name="userId">
		/// A string containing the user name / ID for the file login.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the password for the file login.
		/// </param>
		public CryptoEntityWriter(Stream destinationStream, string userId, string filePassword)
		{
			_stream = destinationStream;
				_writer = new CryptoSafeWriter(_stream, userId, filePassword);
		}
		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
		/// <b>false</b> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			Close();

			_stream = null;
			_writer = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Public Methods / Functions        
		/// <summary>
		/// Closes the instance.
		/// </summary>
		public void Close()
		{
			try
			{
				_writer?.Close();
				_writer?.Dispose();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}
			_writer = null;

			try
			{
				_stream?.Close();
				_stream?.Dispose();
			}
			catch (Exception ex)
			{
				AddException(ex);
			}
			_stream = null;
		}
		/// <summary>
		/// Writes the specified data set.
		/// </summary>
		/// <param name="dataSet">
		/// The <see cref="PKDataSet"/> instace whose contents are to be written.
		/// </param>
		public void WriteDataSet(PKDataSet dataSet)
		{
			if (_stream != null && _writer != null)
			{
				if (dataSet.Bills != null)
					WriteBillEntries(dataSet.Bills);

				if (dataSet.FinancialAccounts != null)
					WriteFinancialAccounts(dataSet.FinancialAccounts);

				if (dataSet.GeneralLogins != null)
					WriteGeneralLogins(dataSet.GeneralLogins);

				if (dataSet.RawData != null)
					WriteRawDataEntries(dataSet.RawData);

				if (dataSet.IdentityProviders != null)
					WriteIdentityProviders(dataSet.IdentityProviders);
			}
		}
		/// <summary>
		/// Writes the base field / column values from the provided instance.
		/// </summary>
		/// <param name="entityBase">
		/// The <see cref="EntityBase"/> instance being written to the data source.
		/// </param>
		/// <returns>
		/// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public bool WriteBaseFields(EntityBase entityBase)
		{
			bool success = false;

			if (_writer != null)
			{
				if (_writer.Write(entityBase.Name))
				{
					if (_writer.Write(entityBase.Url))
					{
						if (_writer.Write(entityBase.UserId))
						{
							if (_writer.Write(entityBase.Password))
							{
								success = _writer.Write(entityBase.Description);
							}
						}
					}
				}
				if (success)
					_writer.Flush();
			}

			return success;
		}
		/// <summary>
		/// Writes the list of <see cref="BillEntry" /> instances to the data source.
		/// </summary>
		/// <param name="collection">A <see cref="BillEntryCollection" /> instance containing the list to write.</param>
		public void WriteBillEntries(BillEntryCollection collection)
		{
			if (_writer != null)
			{
				_writer.Write(collection.Count);
				foreach (BillEntry item in collection)
				{
					WriteBillEntry(item);
					_writer.Flush();
				}
			}
		}
		/// <summary>
		/// Writes the <see cref="BillEntry" /> instance to the data source.
		/// </summary>
		/// <param name="entry">A <see cref="BillEntry" /> instance containing the data to be written.</param>
		public void WriteBillEntry(BillEntry entry)
		{
			if (_writer != null)
			{
				WriteBaseFields(entry);

				_writer.Write(entry.Company);
				_writer.Write(entry.Description);
				_writer.Write(entry.OutstandingBalance);
				_writer.Write(entry.LastDatePaid);
				_writer.Write(entry.NextDueDate);
				_writer.Write(entry.IsAutoPay);
				_writer.Write(entry.AutoPayDay);
				_writer.Write(entry.LastAmountPaid);

			}
		}
		/// <summary>
		/// Writes the <see cref="FinancialAccountEntry" /> instance to the data source.
		/// </summary>
		/// <param name="entry">A <see cref="FinancialAccountEntry" /> instance containing the data to be written.</param>
		public void WriteFinancialAccount(FinancialAccountEntry entry)
		{
			if (_writer != null)
			{
				WriteBaseFields(entry);

				_writer.Write((int)entry.AccountType);
				_writer.Write(entry.AccountNumber);
				_writer.Write(entry.Company);
				_writer.Write(entry.Description);
				_writer.Write(entry.OutstandingBalance);
				_writer.Write(entry.LastAmountPaid);
				_writer.Write(entry.LastDatePaid);
				_writer.Write(entry.NextDueDate);
				_writer.Write(entry.CreditAvailable);
				_writer.Write(entry.MinimumPayment);
				_writer.Write(entry.IsAutoPay);
				_writer.Write(entry.AutoPayDay);
				_writer.Flush();
			}
		}
		/// <summary>
		/// Writes the list of <see cref="FinancialAccountEntry" /> instances to the data source.
		/// </summary>
		/// <param name="collection">A <see cref="FinancialAccountEntryCollection" /> instance containing the list to write.</param>
		public void WriteFinancialAccounts(FinancialAccountEntryCollection collection)
		{
			if (_writer != null)
			{
				_writer.Write(collection.Count);
				foreach (FinancialAccountEntry item in collection)
				{
					WriteFinancialAccount(item);
					_writer.Flush();
				}
			}
		}
		/// <summary>
		/// Writes the <see cref="GeneralLoginEntry" /> instance to the data source.
		/// </summary>
		/// <param name="entry">A <see cref="GeneralLoginEntry" /> instance containing the data to be written.</param>
		public void WriteGeneralLogin(GeneralLoginEntry entry)
		{
			if (_writer != null)
			{
				WriteBaseFields(entry);

				_writer.Write(entry.AssociatedEmail);
				_writer.Write(entry.MFAActive);
				_writer.Write(entry.Description);
				_writer.Write(entry.MFAPhoneNumber);
				_writer.Write(entry.ServiceDescription);
				_writer.Write(entry.SecurityAnswers);
				_writer.Write(entry.SecurityQuestions);
			}
		}
		/// <summary>
		/// Writes the list of <see cref="GeneralLoginEntry" /> instances to the data source.
		/// </summary>
		/// <param name="collection">A <see cref="GeneralLoginEntryCollection" /> instance containing the list to write.</param>
		public void WriteGeneralLogins(GeneralLoginEntryCollection collection)
		{
			if (_writer != null)
			{
				_writer.Write(collection.Count);
				foreach (GeneralLoginEntry item in collection)
				{
					WriteGeneralLogin(item);
					_writer.Flush();
				}
			}
		}
		/// <summary>
		/// Writes the <see cref="IdentityProviderEntry" /> instance to the data source.
		/// </summary>
		/// <param name="entry">A <see cref="IdentityProviderEntry" /> instance containing the data to be written.</param>
		public void WriteIdentityProvider(IdentityProviderEntry entry)
		{
			if (_writer != null)
			{
				WriteBaseFields(entry);

				_writer.Write(entry.AssociatedEmail);
				_writer.Write(entry.MFAActive);
				_writer.Write(entry.MFAPhoneNumber);
				_writer.Write((int)entry.IdentityService);
			}
		}
		/// <summary>
		/// Writes the list of <see cref="IdentityProviderEntry" /> instances to the data source.
		/// </summary>
		/// <param name="collection">A <see cref="IdentityProviderEntryCollection" /> instance containing the list to write.</param>
		public void WriteIdentityProviders(IdentityProviderEntryCollection collection)
		{
			if (_writer != null)
			{

				_writer.Write(collection.Count);
				foreach (IdentityProviderEntry item in collection)
				{
					WriteIdentityProvider(item);
					_writer.Flush();
				}
			}
		}
		/// <summary>
		/// Writes the list of <see cref="RawDataEntry" /> instances to the data source.
		/// </summary>
		/// <param name="collection">A <see cref="RawDataEntryCollection" /> instance containing the list to write.</param>
		public void WriteRawDataEntries(RawDataEntryCollection collection)
		{
			if (_writer != null)
			{
				_writer.Write(collection.Count);
				foreach (RawDataEntry item in collection)
				{
					WriteRawData(item);
					_writer.Flush();
				}
			}
		}
		/// <summary>
		/// Writes the <see cref="RawDataEntry" /> instance to the data source.
		/// </summary>
		/// <param name="entry">A <see cref="RawDataEntry" /> instance containing the data to be written.</param>
		public void WriteRawData(RawDataEntry entry)
		{
			if (_writer != null)
			{
				WriteBaseFields(entry);

				_writer.Write(entry.CurrentBalance);
				_writer.Write(entry.LastPaid);
				_writer.Write(entry.NextDue);
				_writer.Write(entry.Available);
				_writer.Write(entry.MinimumDue);
				_writer.Write(entry.SecurityAnswers);
				_writer.Write(entry.SecurityQuestions);
			}
		}
		#endregion
	}
}
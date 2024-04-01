using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.IO
{
	/// <summary>
	/// Provides an implementation for writing the Password Keep data fields to a stream as secured content.
	/// </summary>
	/// <seealso cref="ExceptionTrackingBase" />
	/// <seealso cref="ISafeWriter" />
	public sealed class CryptoSafeWriter : ExceptionTrackingBase, ISafeWriter
	{
		#region Private Member Declarations        
		/// <summary>
		/// The stream reference
		/// </summary>
		private Stream? _streamReference;
		/// <summary>
		/// The writer instance.
		/// </summary>
		private CryptoBinaryWriter? _writer;
		#endregion

		#region Constructor / Dispsoe Methods        
		/// <summary>
		/// Initializes a new instance of the <see cref="CryptoSafeWriter"/> class.
		/// </summary>
		/// <param name="destinationStream">
		/// The reference to the destination <see cref="Stream"/> to be written to.
		/// </param>
		/// <param name="userId">
		/// A strng containing the user id / name for the file.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the file password value.
		/// </param>
		public CryptoSafeWriter(Stream destinationStream, string userId, string filePassword)
		{
			_streamReference = destinationStream;
			_writer = new CryptoBinaryWriter(destinationStream, userId, filePassword);
		}
		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><b>true</b> to release both managed and unmanaged resources;
		/// <b>false</b> to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			Close();
			base.Dispose(disposing);
		}
		#endregion

		#region Public Properties        
		/// <summary>
		/// Gets the refernece to the base stream the writer is acting on.
		/// </summary>
		/// <value>
		/// The <see cref="Stream"/> implementation the writer is using.
		/// </value>
		public Stream? BaseStream => _streamReference;
		#endregion


		#region Public Methods / Functions        
		/// <summary>
		/// Closes this instance.
		/// </summary>
		public void Close()
		{
			_writer?.Dispose();
			_writer = null;
			_streamReference = null;
		}
		/// <summary>
		/// Flushes the contents of the buffer to the data store.
		/// </summary>
		/// <returns>
		/// <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public bool Flush()
		{
			bool success = false;
			if (_writer != null)
			{
				try
				{
					_writer.Flush();
					success = true;
				}
				catch (Exception ex)
				{
					AddException(ex);
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="bool" /> value to the data source.
		/// </summary>
		/// <param name="value">The <see cref="bool" /> value to be written.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public bool Write(bool value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					try
					{
						_writer.Write(value);
						success = true;
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="DateTime" /> value to the data source.
		/// </summary>
		/// <param name="value">The <see cref="DateTime" /> value to be written.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public bool Write(DateTime value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					try
					{
						_writer.Write(value.ToFileTime());
						success = true;
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="DateTime" /> value or NULL to the data source.
		/// </summary>
		/// <param name="value">The <see cref="DateTime" /> value to be written, or <b>null</b>.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		/// <remarks>
		/// This method will write a NULL indicator value before the data value.
		/// </remarks>
		public bool Write(DateTime? value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					if (value == null)
						success = WriteNullIndicator(true);
					else
						success = WriteNullIndicator(false);
					if (success && value != null)
					{
						Write(value.Value);
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="int" /> value to the data source.
		/// </summary>
		/// <param name="value">The <see cref="int" /> value to be written.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public bool Write(int value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					try
					{
						_writer.Write(value);
						success = true;
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="int" /> value or NULL to the data source.
		/// </summary>
		/// <param name="value">The <see cref="int" /> value to be written, or <b>null</b>.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		/// <remarks>
		/// This method will write a NULL indicator value before the data value.
		/// </remarks>
		public bool Write(int? value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					if (value == null)
						success = WriteNullIndicator(true);
					else
						success = WriteNullIndicator(false);
					if (success && value != null)
					{
						Write(value.Value);
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="float" /> value to the data source.
		/// </summary>
		/// <param name="value">The <see cref="float" /> value to be written.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public bool Write(float value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					try
					{
						_writer.Write(value);
						success = true;
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="float" /> value or NULL to the data source.
		/// </summary>
		/// <param name="value">The <see cref="float" /> value to be written, or <b>null</b>.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		/// <remarks>
		/// This method will write a NULL indicator value before the data value.
		/// </remarks>
		public bool Write(float? value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					if (value == null)
						success = WriteNullIndicator(true);
					else
						success = WriteNullIndicator(false);
					if (success && value != null)
					{
						Write(value.Value);
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the specified <see cref="string" /> value or NULL to the data source.
		/// </summary>
		/// <param name="value">The <see cref="string" /> value to be written, or <b>null</b>.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		/// <remarks>
		/// This method will write a NULL indicator value before the data value.
		/// </remarks>
		public bool Write(string? value)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					if (value == null)
						success = WriteNullIndicator(true);
					else
						success = WriteNullIndicator(false);
					if (success && value != null)
					{
						try
						{
							_writer.Write(value);
							success = true;
						}
						catch (Exception ex)
						{
							AddException(ex);
						}
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the contents of the specified <see cref="AdaptiveStringCollection" /> value or NULL to the data source.
		/// </summary>
		/// <param name="list">The <see cref="AdaptiveStringCollection" /> list whose contents are to be written, or <b>null</b>.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		/// <remarks>
		/// This method will write a NULL indicator value before the data value.
		/// </remarks>
		public bool Write(AdaptiveStringCollection? list)
		{
			bool success = false;
			if (_writer != null && list != null)
			{
				if (_writer.CanWrite)
				{
					success = Write(list.Count);
					if (success && list.Count > 0)
					{
						int pos = 0;
						int len = list.Count;
						do
						{
							success = Write(list[pos]);
							pos++;
						} while (success && pos < len);
						Flush();
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the contents of the specified <see cref="USPhoneNumber" /> value or NULL to the data source.
		/// </summary>
		/// <param name="number"></param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		/// <remarks>
		/// This method will write a NULL indicator value before the data value.
		/// </remarks>
		public bool Write(USPhoneNumber? number)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					if (number == null)
						success = WriteNullIndicator(true);
					else
						success = WriteNullIndicator(false);

					if (success && number != null)
					{
						_writer.Write(number.ToString());
					}
				}
			}
			return success;
		}
		/// <summary>
		/// Writes the null indicator.
		/// </summary>
		/// <param name="isNull"><b>true</b> if the data value is NULL; otherwise, <b>false</b>.</param>
		/// <returns>
		///   <b>true</b> if the operation is successful; otherwise, returns <b>false</b>.
		/// </returns>
		public bool WriteNullIndicator(bool isNull)
		{
			bool success = false;
			if (_writer != null)
			{
				if (_writer.CanWrite)
				{
					try
					{
						// Write "0" for null, "1" for not null.
						if (isNull)
							_writer.Write((byte)0);
						else
							_writer.Write((byte)1);

						success = true;
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return success;
		}
		#endregion

		#region Public Methods / Functions        
		/// <summary>
		/// Disconencts the current object from the underlying stream without closing or
		/// disposing of the underlying stream instance.
		/// </summary>
		public void ReleaseStream()
		{
			// Ensure any content is written.
			Flush();

			_streamReference = null;
			_writer = null;
		}
		#endregion

	}
}
using Adaptive.Intelligence.Shared;

namespace PasswordKeep.Data.IO
{
	/// <summary>
	/// Provides an implementation for reading the Password Keep entities to a stream from secured content.
	/// </summary>
	/// <seealso cref="ExceptionTrackingBase" />
	/// <seealso cref="ISafeReader" />
	public sealed class CryptoSafeReader : ExceptionTrackingBase, ISafeReader
	{
		#region Private Member Declarations        
		/// <summary>
		/// The stream source.
		/// </summary>
		private Stream? _sourceStream;
		/// <summary>
		/// The reader instance.
		/// </summary>
		private CryptoBinaryReader? _reader;
		#endregion

		#region Constructor / Dispsoe Methods        
		/// <summary>
		/// Initializes a new instance of the <see cref="CryptoSafeReader"/> class.
		/// </summary>
		/// <param name="sourceStream">
		/// The reference to the destination <see cref="Stream"/> to be read from.
		/// </param>
		/// <param name="userId">
		/// A strng containing the user id / name for the file.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the file password value.
		/// </param>
		public CryptoSafeReader(Stream sourceStream, string userId, string filePassword)
		{
			_sourceStream = sourceStream;
			if (sourceStream != null)
				_reader = new CryptoBinaryReader(sourceStream, userId, filePassword);
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

		#region Public Methods / Functions        
		/// <summary>
		/// Closes this instance.
		/// </summary>
		public void Close()
		{
			_reader?.Dispose();
			_reader = null;
			_sourceStream = null;
		}
		/// <summary>
		/// Reads a boolean value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="bool" /> value that was read, or <b>false</b> on failure.
		/// </returns>
		public bool ReadBoolean()
		{
			bool value = false;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					try
					{
						value = _reader.ReadBoolean();
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return value;
		}
		/// <summary>
		/// Reads a <see cref="DateTime" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="DateTime" /> value that was read, or <b>false</b> on failure.
		/// </returns>
		public DateTime ReadDateTime()
		{
			DateTime value = DateTime.MinValue;

			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					try
					{
						long fileTime = _reader.ReadInt64();
						value = DateTime.FromFileTime(fileTime);
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return value;
		}
		/// <summary>
		/// Reads a <see cref="DateTime" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="DateTime" /> value that was read, or <b>null</b>.
		/// </returns>
		public DateTime? ReadDateTimeNullable()
		{
			DateTime? value = null;

			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					bool isNull = ReadNullIndicator();
					if (!isNull)
					{
						try
						{
							long fileTime = _reader.ReadInt64();
							value = DateTime.FromFileTime(fileTime);
						}
						catch (Exception ex)
						{
							AddException(ex);
						}
					}
				}
			}
			return value;
		}
		/// <summary>
		/// Reads a <see cref="int" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="int" /> value that was read, or <b>false</b> on failure.
		/// </returns>
		public int ReadInt32()
		{
			int value = 0;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					try
					{
						value = _reader.ReadInt32();
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return value;
		}
		/// <summary>
		/// Reads a <see cref="int" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="int" /> value that was read, or <b>null</b>&gt;.
		/// </returns>
		public int? ReadInt32Nullable()
		{
			int? value = null;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					if (!ReadNullIndicator())
					{
						try
						{
							value = _reader.ReadInt32();
						}
						catch (Exception ex)
						{
							AddException(ex);
						}
					}
				}
			}
			return value;
		}
		/// <summary>
		/// Reads a <see cref="float" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="float" /> value that was read, or <b>false</b> on failure.
		/// </returns>
		public float ReadSingle()
		{
			float value = 0;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					try
					{
						value = _reader.ReadSingle();
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return value;
		}
		/// <summary>
		/// Reads a <see cref="float" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="float" /> value that was read, or <b>null</b>.
		/// </returns>
		public float? ReadSingleNullable()
		{
			float? value = null;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					if (!ReadNullIndicator())
					{
						try
						{
							value = _reader.ReadSingle();
						}
						catch (Exception ex)
						{
							AddException(ex);
						}
					}
				}
			}
			return value;
		}
		/// <summary>
		/// Reads a <see cref="string" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="string" /> value that was read, or <b>null</b>.
		/// </returns>
		public string? ReadString()
		{
			string? value = null;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					if (!ReadNullIndicator())
					{
						try
						{
							value = _reader.ReadString();
						}
						catch (Exception ex)
						{
							AddException(ex);
						}
					}
				}
			}
			return value;

		}
		/// <summary>
		/// Reads a <see cref="AdaptiveStringCollection" /> value from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="AdaptiveStringCollection" /> value that was read, or <b>null</b>.
		/// </returns>
		public AdaptiveStringCollection? ReadStringList()
		{
			AdaptiveStringCollection? list = null;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					list = new AdaptiveStringCollection();
					int length = ReadInt32();
					int count = 0;
					if (length > 0)
					{
						string? data = null;
						do
						{
							data = ReadString();
							if (data != null)
								list.Add(data);
							count++;
						} while (data != null && count < length);
					}
				}
			}
			return list;
		}
		/// <summary>
		/// Reads a <see cref="USPhoneNumber" /> instace from the data source.
		/// </summary>
		/// <returns>
		/// The <see cref="USPhoneNumber" /> instace that was read, or <b>null</b>.
		/// </returns>
		public USPhoneNumber? ReadPhoneNumber()
		{
			USPhoneNumber? number = null;
			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					if (!ReadNullIndicator())
					{
						string content = _reader.ReadString();
						if (!string.IsNullOrEmpty(content))
						{
							number = new USPhoneNumber(content);
						}
					}
				}
			}
			return number;
		}
		/// <summary>
		/// Reads a NULL value indicator.
		/// </summary>
		/// <returns>
		///   <b>true</b> if the NULL indicator field indicates NULL; otherwise, returns <b>false</b>.
		/// </returns>
		public bool ReadNullIndicator()
		{
			bool isNull = true;

			if (_reader != null)
			{
				if (_reader.CanRead)
				{
					try
					{
						byte data = _reader.ReadByte();
						// Read "0" for null, "1" for not null.
						isNull = (data == 0);
					}
					catch (Exception ex)
					{
						AddException(ex);
					}
				}
			}
			return isNull;
		}
		#endregion
	}
}
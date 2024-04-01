using Adaptive.Intelligence.Shared;
using Adaptive.Intelligence.Shared.Security;
using PasswordKeep.Data.Interfaces;
using System.Buffers.Binary;
using System.Security.Cryptography;
using System.Text;

namespace PasswordKeep.Data
{
	/// <summary>
	/// Provides a cryptographic binary reader implementation for reading from a stream created by <see cref="CryptoBinaryWriter"/>.
	/// </summary>
	/// <seealso cref="ExceptionTrackingBase" />
	public sealed class CryptoBinaryReader : DisposableObjectBase, ICryptoCompatibleObject
	{
		#region Private Member Declarations
		/// <summary>
		/// The stream reference
		/// </summary>
		private Stream? _streamReference;
		/// <summary>
		/// The primary AES cryptographic provider.
		/// </summary>
		private AesProvider? _aesPrimary;
		/// <summary>
		/// The secondary AES cryptographic provider.
		/// </summary>
		private AesProvider? _aesSecondary;
		/// <summary>
		/// The tertiary AES cryptographic provider.
		/// </summary>
		private AesProvider? _aesTertiary;
		/// <summary>
		/// The encoding for text.
		/// </summary>
		private readonly Encoding _encoding;

		// Calculate these once.
		private int _floatSize = sizeof(float);
		private int _doubleSize = sizeof(double);
		private int _shortSize = sizeof(short);
		private int _intSize = sizeof(int);
		private int _longSize = sizeof(long);
		private int _halfSize = sizeof(ushort);
		#endregion

		#region Constructor / Dispose Methods		
		/// <summary>
		/// Initializes a new instance of the <see cref="CryptoBinaryReader"/> class.
		/// </summary>
		/// <param name="input">
		/// The reference to the output <see cref="Stream"/> to be read from.
		/// </param>
		/// <param name="userId">
		/// A strng containing the user id / name for the file.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the file password value.
		/// </param>
		public CryptoBinaryReader(Stream input, string userId, string filePassword) : this(input, Encoding.UTF8, userId, filePassword)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="CryptoBinaryReader"/> class.
		/// </summary>
		/// <param name="input">
		/// The reference to the output <see cref="Stream"/> to be written to.
		/// </param>
		/// <param name="encoding">
		/// The <see cref="Encoding"/> instance indicating the text encoding method to use.
		/// </param>
		/// <param name="userId">
		/// A strng containing the user id / name for the file.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the file password value.
		/// </param>
		public CryptoBinaryReader(Stream input, Encoding encoding, string userId, string filePassword) : base()
		{
			ArgumentNullException.ThrowIfNull(input);
			ArgumentNullException.ThrowIfNull(encoding);
			ArgumentNullException.ThrowIfNull(userId);
			ArgumentNullException.ThrowIfNull(filePassword);

			if (!input.CanRead)
				throw new ArgumentException("The input stream could not be read from.");

			_streamReference = input;
			_encoding = encoding;

			PrepareCryptographicInstances(userId, filePassword);
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
				_streamReference?.Close();
				_streamReference?.Dispose();
				_aesPrimary?.Dispose();
				_aesSecondary?.Dispose();
				_aesTertiary?.Dispose();

			}
			_aesPrimary = null;
			_aesSecondary = null;
			_aesTertiary = null;
			_streamReference = null;
			base.Dispose(disposing);
		}
		#endregion

		#region Public Properties
		/// <summary>
		/// Gets the reference to the stream associated with the reader.
		/// </summary>
		/// <value>
		/// The <see cref="Stream"/> being read from.
		/// </value>
		public Stream? BaseStream => _streamReference;
		/// <summary>
		/// Gets a value indicating whether the underlying stream can be read from.
		/// </summary>
		/// <value>
		///   <c>true</c> if the underlying stream can be read from; otherwise, <c>false</c>.
		/// </value>
		public bool CanRead
		{
			get
			{
				if (_streamReference == null)
					return false;
				else
					return _streamReference.CanRead;
			}
		}
		#endregion

		#region Public Methods / Functions
		/// <summary>
		/// Closes this reader and releases any system resources associated with the
		/// reader. Following a call to Close, any operations on the reader may raise exceptions.
		/// </summary>
		public void Close()
		{
			Dispose(true);
		}
		/// <summary>
		/// Sets the position in the underlying stream instance to the specified offset.
		/// </summary>
		/// <param name="offset">
		/// Am integer specifying the offset value.
		/// </param>
		/// <param name="origin">
		/// The <see cref="SeekOrigin"/> enumerated value indicating from what location to 
		/// calculate the offset.
		/// </param>
		/// <returns>
		/// A <see cref="long"/> specifying the new position in the stream.
		/// </returns>
		public long Seek(int offset, SeekOrigin origin)
		{
			if (_streamReference == null)
				return -1;
			else
				return _streamReference.Seek(offset, origin);
		}
		/// <summary>
		/// Reads and decrypts the next section of data, and returns the boolean result.
		/// </summary>
		/// <returns>
		/// The <see cref="bool"/> value that was read and decrypted.
		/// </returns>
		public bool ReadBoolean()
		{
			bool result = false;

			byte[]? encrypted = ReadRecord();
			if (encrypted != null)
			{
				byte[]? clearData = Decrypt(encrypted);
				if (!ArrayExtensions.IsNullOrEmpty(clearData))
				{
					byte value = clearData[0];
					result = (value != 0);
					clearData.ClearArray();
				}
			}
			return result;
		}
		/// <summary>
		/// Reads and decrypts the next section of data, and returns the next (single) byte value.
		/// </summary>
		/// <returns>
		/// The <see cref="byte"/> value that was read and decrypted.
		/// </returns>
		public byte ReadByte()
		{
			byte result = 0;

			byte[]? encrypted = ReadRecord();
			if (encrypted != null)
			{
				byte[]? clearData = Decrypt(encrypted);
				if (!ArrayExtensions.IsNullOrEmpty(clearData))
				{
					result = clearData[0];
					clearData.ClearArray();
				}
			}
			return result;
		}
		/// <summary>
		/// Reads a byte array from the encrypted content.
		/// </summary>
		/// <remarks>
		/// The length of the array is written by the writer, and read from the record content.
		/// </remarks>
		/// <returns>
		/// The decrypted byte array from the source content, or <b>null</b> if the data is missing or invalid.
		/// </returns>
		public byte[]? ReadBytes()
		{
			byte[]? clearData = null;

			byte[]? encrypted = ReadRecord();
			if (encrypted != null)
			{
				clearData = Decrypt(encrypted);
				encrypted.ClearArray();
			}
			return clearData;
		}
		/// <summary>
		/// Reads and decrypts the next section of data, and returns the next (single) byte value.
		/// </summary>
		/// <returns>
		/// The <see cref="byte"/> value that was read and decrypted.
		/// </returns>
		public char ReadChar()
		{
			char data = '\0';

			byte[]? encrypted = ReadRecord();
			if (encrypted != null)
			{
				byte[]? clearData = Decrypt(encrypted);
				

				if (_encoding.IsSingleByte)
					data = (char)clearData[0];
				else
					data = BitConverter.ToChar(clearData);

				clearData?.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads a character array from the encrypted content.
		/// </summary>
		/// <remarks>
		/// The length of the array is written by the writer, and read from the record content.
		/// </remarks>
		/// <returns>
		/// The decrypted character array from the source content, or <b>null</b> if the data is missing or invalid.
		/// </returns>
		public char[] ReadCharArray()
		{
			char[]? charData = null;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				charData = _encoding.GetChars(clearData);
				clearData.ClearArray();
			}
			return charData;
		}
		/// <summary>
		/// Reads a double precision floating point value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="double"/> value.
		/// </returns>
		public double ReadDouble()
		{
			double data = 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadDoubleLittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads a decimal structure from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="decimal"/> value.
		/// </returns>
		public decimal ReadDecimal()
		{
			decimal data = 0;

			byte[]? clearData = ReadRecord();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = Convert.ToDecimal(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads a short integer value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="short"/> value.
		/// </returns>
		public short ReadInt16()
		{
			short data = 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadInt16LittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads an unsigned short integer value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="ushort"/> value.
		/// </returns>
		public ushort ReadUInt16()
		{
			ushort data = 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadUInt16LittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads am integer value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="short"/> value.
		/// </returns>
		public int ReadInt32()
		{
			int data = 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadInt32LittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads an unsigned integer value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="uint"/> value.
		/// </returns>
		public uint ReadUInt32()
		{
			uint data = 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadUInt32LittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads a long integer value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="long"/> value.
		/// </returns>
		public long ReadInt64()
		{
			long data = 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadInt64LittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads an unsigned long integer value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="ulong"/> value.
		/// </returns>
		public ulong ReadUInt64()
		{
			ulong data= 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadUInt64LittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads a double precision floating point value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="float"/> value.
		/// </returns>
		public float ReadSingle()
		{
			float data = 0;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadSingleLittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads half of a floating point value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted <see cref="Half"/> value.
		/// </returns>
		public Half ReadHalf()
		{
			Half data = Half.Zero;

			byte[]? clearData = ReadBytes();
			if (!ArrayExtensions.IsNullOrEmpty(clearData))
			{
				data = BinaryPrimitives.ReadHalfLittleEndian(clearData);
				clearData.ClearArray();
			}
			return data;
		}
		/// <summary>
		/// Reads a string value from the encrypted content.
		/// </summary>
		/// <returns>
		/// The decrypted string value, or <b>null</b> of the operation fails.
		/// </returns>
		public string? ReadString()
		{
			string? data = null;

			byte[]? encrypted = ReadRecord();
			if (!ArrayExtensions.IsNullOrEmpty(encrypted))
			{
				byte[]? clearData = Decrypt(encrypted);
				encrypted?.ClearArray();

				if (clearData != null)
				{
					data = _encoding.GetString(clearData);
					clearData.ClearArray();
				}
			}
			return data;
		}
		/// <summary>
		/// Decrypts the specified Date/Time value from the source stream.
		/// </summary>
		/// <remarks>
		/// This method actually reads the Date/time as a <see cref="long"/> value from the <see cref="DateTime.FromFileTimeUtc(long)"/>
		/// function.
		/// </remarks>
		/// <returns>
		/// The decryptede <see cref="DateTime"/> value.
		/// </returns>
		public DateTime ReadDateTime()
		{
			long fileTime = ReadInt64();
			return DateTime.FromFileTime(fileTime);
		}
		#endregion

		#region Private Methods / Functions		

		#region Cryptographic Initialization and Key Derivation
		/// <summary>
		/// Performs the key-derivation activities and initializes the cryptographic provider instances.
		/// </summary>
		/// <param name="userId">
		/// A string containing the ID of the user.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the password value for the user.
		/// </param>
		private void PrepareCryptographicInstances(string userId, string filePassword)
		{
			// Create key and key variants.
			byte[] primaryKey = PasswordKeyCreator.CreatePrimaryKeyData(userId, filePassword);
			byte[] secondaryKey = PasswordKeyCreator.CreateKeyVariant(primaryKey);
			byte[] tertiaryKey = PasswordKeyCreator.CreateKeyVariant(secondaryKey);

			// Create AES instances.
			_aesPrimary = new AesProvider();
			_aesPrimary.SetKeyIV(primaryKey);

			_aesSecondary = new AesProvider();
			_aesSecondary.SetKeyIV(secondaryKey);

			_aesTertiary = new AesProvider();
			_aesTertiary.SetKeyIV(tertiaryKey);

			// Clear.
			Array.Clear(primaryKey, 0, primaryKey.Length);
			Array.Clear(secondaryKey, 0, secondaryKey.Length);
			Array.Clear(tertiaryKey, 0, tertiaryKey.Length);
		}
		#endregion

		/// <summary>
		/// Decrypts the specified byte array.
		/// </summary>
		/// <param name="encrypted">
		/// A byte array containing the encrypted data content.
		/// </param>
		/// <returns>
		/// A byte array containing the decrypted (clear) data.
		/// </returns>
		private byte[]? Decrypt(byte[]? encrypted)
		{
			byte[]? content = null;

			if (encrypted == null)
				throw new ArgumentNullException(nameof(encrypted));

			if (_aesTertiary == null || _aesSecondary == null || _aesPrimary == null)
				throw new InvalidOperationException("The cryptographic components where not initialized.");
			else
			{
				content =
					_aesPrimary.Decrypt(
						_aesSecondary.Decrypt(
							_aesTertiary.Decrypt(encrypted)));
			}
			return content;
		}
		/// <summary>
		/// Reads the data record from the stream.
		/// </summary>
		/// <remarks>
		/// This method reads a 4-byte array (integer) indicating the length of the data, and 
		/// then reads that number of bytes from the stream as a byte array.
		/// </remarks>
		/// <returns>
		/// A byte array containing the data read from the stream, or <b>null</b> if the data length indicator was zero (0).
		/// </returns>>
		private byte[]? ReadRecord()
		{
			byte[]? recordContent = null;

			if (_streamReference != null)
			{
				// Read the next 4 bytes to determine the length of the following block.
				byte[] length = new byte[4];
				_streamReference.Read(length, 0, 4);
				int dataLength = BitConverter.ToInt32(length, 0);
				Array.Clear(length, 0, 4);

				// Read the remaining data.
				if (dataLength > 0)
				{
					recordContent = new byte[dataLength];
					_streamReference.ReadExactly(recordContent, 0, dataLength);
				}
			}
			return recordContent;
		}
		#endregion

		/// <summary>
		/// Validates that the current instance and the specified instance are using the same cryptographic keys and algorithms
		/// in order to with with each other.
		/// </summary>
		/// <param name="instance"></param>
		/// <returns>
		///   <b>true</b> if the two objects utilize the same cryptographic algorithms and keys; otherwise, <b>false</b>.
		/// </returns>
		public bool ValidateCompatible(ICryptoCompatibleObject instance)
		{
			if (_aesPrimary != null && _aesSecondary != null && _aesTertiary != null)
			{
				return
					instance.ValidatePrimaryKeyData(_aesPrimary.GetKeyData()) &&
					instance.ValidateSecondaryKeyData(_aesSecondary.GetKeyData()) &&
					instance.ValidateTertiaryKeyData(_aesTertiary.GetKeyData());
			}
			else
				return false;

		}
		/// <summary>
		/// Validates the primary key data.
		/// </summary>
		/// <param name="keyData">A byte array containing the key data.</param>
		/// <returns>
		///   <b>true</b> if the specified key data can be / is used by the instance.
		/// </returns>
		public bool ValidatePrimaryKeyData(byte[]? keyData)
		{
			bool isValid = false;
			if (keyData != null && _aesPrimary != null)
			{
				byte[]? primary = _aesPrimary.GetKeyData();
				if (primary != null && primary.Length == keyData.Length)
				{
					int result =  primary.Compare(keyData);
					isValid = (result == 0);
				}
				primary?.ClearArray();
			}
			return isValid;
		}
		/// <summary>
		/// Validates the secondary key data.
		/// </summary>
		/// <param name="keyData">A byte array containing the key data.</param>
		/// <returns>
		///   <b>true</b> if the specified key data can be / is used by the instance.
		/// </returns>
		public bool ValidateSecondaryKeyData(byte[]? keyData)
		{
			bool isValid = false;
			if (keyData != null && _aesSecondary != null)
			{
				byte[]? secondary = _aesSecondary.GetKeyData();
				if (secondary != null && secondary.Length == keyData.Length)
				{
					int result = secondary.Compare(keyData);
					isValid = (result == 0);
				}
				secondary?.ClearArray();
			}
			return isValid;
		}
		/// <summary>
		/// Validates the tertiary key data.
		/// </summary>
		/// <param name="keyData">A byte array containing the key data.</param>
		/// <returns>
		///   <b>true</b> if the specified key data can be / is used by the instance.
		/// </returns>
		public bool ValidateTertiaryKeyData(byte[]? keyData)
		{
			bool isValid = false;
			if (keyData != null && _aesTertiary != null)
			{
				byte[]? tertiary = _aesTertiary.GetKeyData();
				if (tertiary != null && tertiary.Length == keyData.Length)
				{
					int result = tertiary.Compare(keyData);
					isValid = (result == 0);
				}
				tertiary?.ClearArray();
			}
			return isValid;
		}
	}
}
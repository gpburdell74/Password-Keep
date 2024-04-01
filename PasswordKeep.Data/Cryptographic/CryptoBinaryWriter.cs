using Adaptive.Intelligence.Shared;
using Adaptive.Intelligence.Shared.Security;
using PasswordKeep.Data.Interfaces;
using System;
using System.Buffers.Binary;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace PasswordKeep.Data
{
	/// <summary>
	/// Provides a cryptographic binary writer implementation for writing to a stream.
	/// </summary>
	/// <seealso cref="ExceptionTrackingBase" />
	public sealed class CryptoBinaryWriter : DisposableObjectBase, ICryptoCompatibleObject
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
		/// <summary>
		/// The leave stream open flag.
		/// </summary>
		private readonly bool _leaveOpen;

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
		/// Initializes a new instance of the <see cref="CryptoBinaryWriter"/> class.
		/// </summary>
		/// <param name="output">
		/// The reference to the output <see cref="Stream"/> to be written to.
		/// </param>
		/// <param name="userId">
		/// A strng containing the user id / name for the file.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the file password value.
		/// </param>
		public CryptoBinaryWriter(Stream output, string userId, string filePassword) : this(output, Encoding.UTF8, false, userId, filePassword)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="CryptoBinaryWriter"/> class.
		/// </summary>
		/// <param name="output">
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
		public CryptoBinaryWriter(Stream output, Encoding encoding, string userId, string filePassword) : this(output, encoding, false, userId, filePassword)
		{
		}
		/// <summary>
		/// Initializes a new instance of the <see cref="CryptoBinaryWriter"/> class.
		/// </summary>
		/// <param name="output">
		/// The reference to the output <see cref="Stream"/> to be written to.
		/// </param>
		/// <param name="encoding">
		/// The <see cref="Encoding"/> enumerated value indicating the text encoding method to use.
		/// </param>
		/// <param name="leaveOpen">
		/// <b>true</b> to leave the stream open when the writer is closed; otherwise, <b>false</b>.
		/// </param>
		/// <param name="userId">
		/// A strng containing the user id / name for the file.
		/// </param>
		/// <param name="filePassword">
		/// A string containing the file password value.
		/// </param>
		/// <exception cref="ArgumentNullException">
		/// Thrown if the <i>output</i> Stream reference is null, if <see cref="Encoding"/> reference is null, if the 
		/// <i>userID</i> is null, or the <i>filePassword</i> value is null.
		/// </exception>
		/// <exception cref="ArgumentException">
		/// Thrown if the output stream cannot be written to.
		/// </exception>
		public CryptoBinaryWriter(Stream output, Encoding encoding, bool leaveOpen, string userId, string filePassword)
		{
			ArgumentNullException.ThrowIfNull(output);
			ArgumentNullException.ThrowIfNull(encoding);
			ArgumentNullException.ThrowIfNull(userId);
			ArgumentNullException.ThrowIfNull(filePassword);

			if (!output.CanWrite)
				throw new ArgumentException("The output stream could not be written to.");

			_streamReference = output;
			_encoding = encoding;
			_leaveOpen = leaveOpen;

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
				if (_leaveOpen)
					_streamReference?.Flush();
				else
				{
					_streamReference?.Close();
					_streamReference?.Dispose();
				}

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
		/// Gets a value indicating whether the underlying stream can be written to.
		/// </summary>
		/// <value>
		///   <c>true</c> if the underlying stream can be written to; otherwise, <c>false</c>.
		/// </value>
		public bool CanWrite
		{
			get
			{
				if (_streamReference == null)
					return false;
				else
					return _streamReference.CanWrite;
			}
		}
		/// <summary>
		/// Gets the reference to the stream associated with the writer. It flushes all pending
		/// writes before returning.
		/// </summary>
		/// <value>
		/// The <see cref="Stream"/> being written to.
		/// </value>
		public Stream? BaseStream
		{
			get
			{
				Flush();
				return _streamReference; ;
			}
		}
		#endregion

		#region Public Methods / Functions
		/// <summary>
		/// Closes this writer and releases any system resources associated with the
		/// writer. Following a call to Close, any operations on the writer may raise exceptions.
		/// </summary>
		public void Close()
		{
			Dispose(true);
		}
		/// <summary>
		/// Clears all buffers for this writer and causes any buffered data to be
		///written to the underlying device. 
		/// </summary>
		public void Flush()
		{
			_streamReference?.Flush();
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
		/// Encrypts the specified boolean value and then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="bool"/> value to be written.
		/// </param>
		public void Write(bool value)
		{
			// Translate.
			byte data = 0;

			if (value)
				data = 1;
			WriteRecord(Encrypt(new byte[] { data }));
		}
		/// <summary>
		/// Encrypts the specified byte value and then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="byte"/> value to be written.
		/// </param>
		public void Write(byte value)
		{
			WriteRecord(Encrypt(new byte[] { value }));
		}
		/// <summary>
		/// Encrypts the specified byte array and then writes the result to the output stream.
		/// </summary>
		/// <param name="buffer">
		/// The <see cref="byte"/> array to be written.
		/// </param>
		public void Write(byte[] buffer)
		{
			WriteRecord(Encrypt(buffer));
		}
		/// <summary>
		/// Encrypts the a section of the specified byte array and then writes the result to the output stream.
		/// </summary>
		/// <param name="buffer">
		/// The <see cref="byte"/> array to be written.
		/// </param>
		/// <param name="index">
		/// The ordinal index of the source array at which to begin copying the data content.
		/// </param>
		/// <param name="count">
		/// An integer specifying the number of bytes to be written.
		/// </param>
		public void Write(byte[] buffer, int index, int count)
		{
			if (index + count > buffer.Length)
				throw new ArgumentException("Specified bounds exceed the length of the array.", nameof(index));

			int len = buffer.Length;
			byte[] copyData = new byte[count];
			Array.Copy(buffer,index, copyData, 0, count);
			Write(copyData);
			Array.Clear(copyData, 0, len);
		}
		/// <summary>
		/// Encrypts the specified character then writes the result to the output stream.
		/// </summary>
		/// <param name="ch">
		/// The <see cref="char"/> to be written.
		/// </param>
		public void Write(char ch)
		{
			byte[]? data = null;

			if (_encoding.IsSingleByte)
				data = new byte[] { (byte)ch };
			else
				data = BitConverter.GetBytes(ch);

			WriteRecord(Encrypt(data));
			Array.Clear(data, 0, data.Length);
		}
		/// <summary>
		/// Encrypts the specified character array then writes the result to the output stream.
		/// </summary>
		/// <param name="chars">
		/// The <see cref="char"/> array to be written.
		/// </param>
		public void Write(char[] chars)
		{
			ArgumentNullException.ThrowIfNull(chars);

			byte[] clearData = _encoding.GetBytes(chars);
			WriteRecord(Encrypt(clearData));
			Array.Clear(clearData, 0, clearData.Length);
		}
		/// <summary>
		/// Encrypts the specified double-precision value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="double"/> value to be written.
		/// </param>
		public void Write(double value)
		{
			Span<byte> buffer = stackalloc byte[_doubleSize];
			BinaryPrimitives.WriteDoubleLittleEndian(buffer, value);
			WriteRecord(Encrypt(buffer));
			buffer.Clear();
		}
		/// <summary>
		/// Encrypts the specified decimal value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="decimal"/> value to be written.
		/// </param>
		public void Write(decimal value)
		{
			byte[] clearData = value.GetBytes();
			WriteRecord(Encrypt(clearData));
			Array.Clear(clearData, 0, clearData.Length);
		}
		/// <summary>
		/// Encrypts the specified short integer value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="short"/> value to be written.
		/// </param>
		public void Write(short value)
		{
			Span<byte> clearData = stackalloc byte[_shortSize];
			BinaryPrimitives.WriteInt16LittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified unsigned short integer value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="ushort"/> value to be written.
		/// </param>
		public void Write(ushort value)
		{
			Span<byte> clearData = stackalloc byte[_shortSize];
			BinaryPrimitives.WriteUInt16LittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified integer value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="int"/> value to be written.
		/// </param>
		public void Write(int value)
		{
			Span<byte> clearData = stackalloc byte[_intSize];
			BinaryPrimitives.WriteInt32LittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified unsigned integer value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="uint"/> value to be written.
		/// </param>
		public void Write(uint value)
		{
			Span<byte> clearData = stackalloc byte[_intSize];
			BinaryPrimitives.WriteUInt32LittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified long integer value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="long"/> value to be written.
		/// </param>
		public void Write(long value)
		{
			Span<byte> clearData = stackalloc byte[_longSize];
			BinaryPrimitives.WriteInt64LittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified unsigned long integer value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="ulong"/> value to be written.
		/// </param>
		public void Write(ulong value)
		{
			Span<byte> clearData = stackalloc byte[_longSize];
			BinaryPrimitives.WriteUInt64LittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified single-precision floating point value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="float"/> value to be written.
		/// </param>
		public void Write(float value)
		{
			Span<byte> clearData = stackalloc byte[_floatSize];
			BinaryPrimitives.WriteSingleLittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified Half value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="Half"/> value to be written.
		/// </param>
		public void Write(Half value)
		{
			Span<byte> clearData = stackalloc byte[_halfSize];
			BinaryPrimitives.WriteHalfLittleEndian(clearData, value);
			WriteRecord(Encrypt(clearData));
			clearData.Clear();
		}
		/// <summary>
		/// Encrypts the specified string value then writes the result to the output stream.
		/// </summary>
		/// <param name="value">
		/// The <see cref="string"/> value to be written.
		/// </param>
		public void Write(string value)
		{
			ArgumentNullException.ThrowIfNull(value);

			byte[] clearData = _encoding.GetBytes(value);
			WriteRecord(Encrypt(clearData));
			Array.Clear(clearData, 0, clearData.Length);
		}
		/// <summary>
		/// Encrypts the specified Date/Time vlue then writes the result to the output stream.
		/// </summary>
		/// <remarks>
		/// This method actually writes the Date/time as a <see cref="long"/> value from the <see cref="DateTime.FromFileTimeUtc(long)"/>
		/// function.
		/// </remarks>
		/// <param name="value">
		/// The <see cref="DateTime"/> value to be written.
		/// </param>
		public void Write(DateTime value)
		{
			long fileTime = value.ToFileTime();
			Write(fileTime);
			fileTime = 0;
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
		/// Encrypts the specified byte array.
		/// </summary>
		/// <param name="clearData">
		/// A byte array containing the clear data content to be written.
		/// </param>
		/// <returns>
		/// A byte array containing the encrypted data.
		/// </returns>
		private byte[]? Encrypt(byte[] clearData)
		{
			if (_aesTertiary == null || _aesSecondary == null || _aesPrimary == null)
				throw new InvalidOperationException("The cryptographic components where not initialized.");
			else
			{
				return
				_aesTertiary.Encrypt(
					_aesSecondary.Encrypt(
						_aesPrimary.Encrypt(clearData)));
			}
		}
		/// <summary>
		/// Encrypts the specified <see cref="Span{T}"/> of <see cref="byte"/>.
		/// </summary>
		/// <param name="clearData">
		/// A byte array containing the clear data content to be written.
		/// </param>
		/// <returns>
		/// A byte array containing the encrypted data.
		/// </returns>
		private byte[]? Encrypt(Span<byte> clearData)
		{
			byte[]? result = null;

			if (_aesTertiary == null || _aesSecondary == null || _aesPrimary == null)
				throw new InvalidOperationException("The cryptographic components where not initialized.");
			else
			{
				byte[] content = clearData.ToArray();
				result = _aesTertiary.Encrypt(
							_aesSecondary.Encrypt(
								_aesPrimary.Encrypt(content)));
				Array.Clear(content, 0, content.Length);
			}
			return result;

		}
		/// <summary>
		/// Writes the data record to the stream.
		/// </summary>
		/// <remarks>
		/// This method writes a 4-byte array (integer) indicating the length of the data, and 
		/// then writes the data byte array.
		/// </remarks>
		/// <param name="dataToWrite">
		/// A byte array containing the data to write.
		/// </param>
		private void WriteRecord(byte[]? dataToWrite)
		{
			if (dataToWrite == null)
				throw new ArgumentNullException("Invalid data provided.");

			if (_streamReference != null)
			{
				// Convert the array length into a four-byte array.
				int dataLength = dataToWrite.Length;
				byte[] length = BitConverter.GetBytes(dataLength);

				// Write the length,
				_streamReference.Write(length, 0, 4);
				Array.Clear(length, 0, 4);

				// Write the data.
				if (dataLength > 0)
					_streamReference.Write(dataToWrite, 0, dataLength);
			}
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
					int result = primary.Compare(keyData);
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
using Adaptive.Intelligence.Shared;
using Newtonsoft.Json.Linq;
using PasswordKeep.Data.IO;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace PasswordKeep.Data.Test
{
	public class ClearSafeWriterTests
	{
		#region Flush()
		[Fact]
		public void FlushTest()
		{
			ISafeWriter writer = CreateWriterWithStream();
			writer.Write("Test");

			bool success = writer.Flush();
			Assert.True(success);

			Assert.True(DidWrite(writer, 0));

			DisposeAll(writer);

		}
		[Fact]
		public void WriteBooleanTest()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();

			// Test success / fail.
			bool success = writer.Write(true);
			Assert.True(success);
			
			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));
			int len = (int)writer.BaseStream.Length;

			// Test success / fail.
			success = writer.Write(false);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, len));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			bool first = reader.ReadBoolean();
			bool second = reader.ReadBoolean();

			reader.Dispose();

			Assert.True(first);
			Assert.False(second);

			// Clean up.
			DisposeAll(writer);

		}
		#endregion

		#region Date/Time
		[Fact]
		public void WriteDateTimeTest()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			DateTime originalDate = DateTime.Parse("07/12/1974 11:12:34");

			// Test success / fail.
			bool success = writer.Write(originalDate);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));
			
			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			long data = reader.ReadInt64();
			DateTime readDate = DateTime.FromFileTime(data);
			reader.Dispose();

			Assert.Equal(originalDate, readDate);

			// Clean up.
			DisposeAll(writer);

		}
		
		[Fact]
		public void WriteDateTimeNullableTest()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			DateTime? originalDate = DateTime.Parse("07/12/1974 11:12:34");

			// Test success / fail.
			bool success = writer.Write(originalDate);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.True(isNull != 0);

			long data = reader.ReadInt64();
			DateTime readDate = DateTime.FromFileTime(data);
			reader.Dispose();

			Assert.Equal(originalDate, readDate);

			// Clean up.
			DisposeAll(writer);

		}

		[Fact]
		public void WriteDateTimeNullableTestWithNull()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			DateTime? originalDate = null;

			// Test success / fail.
			bool success = writer.Write(originalDate);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(0, isNull);
			reader.Dispose();

			// Clean up.
			DisposeAll(writer);

		}
		#endregion

		#region Int32
		[Fact]
		public void WriteInt32Test()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			int value = 29312;

			// Test success / fail.
			bool success = writer.Write(value);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			int data = reader.ReadInt32();
			reader.Dispose();

			Assert.Equal(data, value);

			// Clean up.
			DisposeAll(writer);

		}
		[Theory]
		[InlineData(0),
		 InlineData(1),
			InlineData(Int32.MaxValue),
			InlineData(Int32.MinValue),
			InlineData(256),
			InlineData(-99),
			InlineData(12)]
		public void WriteInt32RangeTest( int value)
		{
			// Create / Setup
			ISafeWriter writer = CreateWriterWithStream();

			// Test success / fail.
			bool success = writer.Write(value);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			int data = reader.ReadInt32();
			reader.Dispose();

			Assert.Equal(data, value);

			// Clean up.
			DisposeAll(writer);

		}
		[Fact]
		public void WriteInt32NullableTest()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			int? value = 29312;

			// Test success / fail.
			bool success = writer.Write(value);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.True(isNull != 0);

			int data = reader.ReadInt32();
			reader.Dispose();

			Assert.Equal(value, data);

			// Clean up.
			DisposeAll(writer);

		}

		[Fact]
		public void WriteInt32NullableTestWithNull()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			int? original = null;

			// Test success / fail.
			bool success = writer.Write(original);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(0, isNull);
			reader.Dispose();

			// Clean up.
			DisposeAll(writer);

		}
		#endregion

		#region Single / Float
		[Fact]
		public void WriteSingleTest()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			float value = 29312.772981f;

			// Test success / fail.
			bool success = writer.Write(value);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			float data = reader.ReadSingle();
			reader.Dispose();

			Assert.Equal(data, value);

			// Clean up.
			DisposeAll(writer);

		}
		[Theory]
		[InlineData(0f),
		 InlineData(1f),
		 InlineData(-1f),
		 InlineData(Single.MaxValue),
		 InlineData(Single.MinValue),
		 InlineData(256.212),
		 InlineData(-99.22f),
		 InlineData(3.141592653589f)]
		public void WriteSingleRangeTest(float value)
		{
			// Create / Setup
			ISafeWriter writer = CreateWriterWithStream();

			// Test success / fail.
			bool success = writer.Write(value);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			float data = reader.ReadSingle();
			reader.Dispose();

			Assert.Equal(data, value);

			// Clean up.
			DisposeAll(writer);

		}
		[Fact]
		public void WriteSingleNullableTest()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			float? value = 29.312f;

			// Test success / fail.
			bool success = writer.Write(value);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.True(isNull != 0);

			float data = reader.ReadSingle();
			reader.Dispose();

			Assert.Equal(value, data);

			// Clean up.
			DisposeAll(writer);

		}

		[Fact]
		public void WriteSingleNullableTestWithNull()
		{
			// Create / Setup 
			ISafeWriter writer = CreateWriterWithStream();
			float? original = null;

			// Test success / fail.
			bool success = writer.Write(original);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(0, isNull);
			reader.Dispose();

			// Clean up.
			DisposeAll(writer);

		}
		#endregion

		#region String
		[Fact]
		public void WriteStringTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			// Test success / fail.
			string original = "This is some data Content to be written.\r\n\t123456780.";

			bool success = writer.Write(original);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(1, isNull);

			string data = reader.ReadString();
			reader.Dispose();

			Assert.Equal(data, original);

			// Clean up.
			DisposeAll(writer);
		}
		[Fact]
		public void WriteEmptyStringTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			// Test success / fail.
			string original = string.Empty;

			bool success = writer.Write(original);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(1, isNull);

			string data = reader.ReadString();
			reader.Dispose();

			Assert.Equal(data, original);

			// Clean up.
			DisposeAll(writer);
		}
		[Fact]
		public void WriteNullStringTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			// Test success / fail.
			string original = null;

			bool success = writer.Write(original);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(0, isNull);
			reader.Dispose();

			// Clean up.
			DisposeAll(writer);
		}
		#endregion

		#region Adaptive String Collection
		[Fact]
		public void WriteAdaptiveStringCollectionTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			AdaptiveStringCollection collection = new AdaptiveStringCollection();
			collection.Add("A");
			collection.Add("This is some data Content to be written.\r\n\t");
			collection.Add("123456780");

			bool success = writer.Write(collection);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			AdaptiveStringCollection newCollection = new AdaptiveStringCollection();
			int len = reader.ReadInt32();
			for (int count = 0; count < len; count++)
			{
				byte isNull = reader.ReadByte();
				Assert.Equal(1, isNull);

				string data = reader.ReadString();
				newCollection.Add(data);
			}
			reader.Dispose();

			Assert.Equal(newCollection.Count, collection.Count);
			for (int count = 0; count < len; count++)
			{
				Assert.Equal(newCollection[count], collection[count]);
			}

			// Clean up.
			collection.Clear();
			newCollection.Clear();
			DisposeAll(writer);
		}
		[Fact]
		public void WriteAdaptiveStringCollectionAsEmptyTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			AdaptiveStringCollection collection = new AdaptiveStringCollection();

			bool success = writer.Write(collection);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			AdaptiveStringCollection newCollection = new AdaptiveStringCollection();
			int len = reader.ReadInt32();
			Assert.Equal(0, len);
			reader.Dispose();

			Assert.Equal(newCollection.Count, collection.Count);

			// Clean up.
			collection.Clear();
			newCollection.Clear();
			DisposeAll(writer);

		}
		[Fact]
		public void WriteAdaptiveStringCollectionAsNullTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			// Test success / fail.
			AdaptiveStringCollection? original = null;

			// Ensure failure on attempting to write a null collection.
			bool success = writer.Write(original);
			Assert.False(success);

			// Ensure nothing was written.
			Assert.False(DidWrite(writer, 0));

			// Clean up.
			DisposeAll(writer);
		}
		#endregion

		#region USPhoneNumber
		[Fact]
		public void WritePhoneNumberTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			USPhoneNumber original = new USPhoneNumber("6788223654");
			bool success = writer.Write(original);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(1, isNull);

			string data = reader.ReadString();
			reader.Dispose();

			USPhoneNumber newNumber = new USPhoneNumber(data);
			Assert.Equal(original, newNumber);

			// Clean up.
			DisposeAll(writer);
		}
		[Fact]
		public void WritePhoneNumberAsNullTest()
		{
			ISafeWriter writer = CreateWriterWithStream();

			USPhoneNumber? original = null;
			bool success = writer.Write(original);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(0, isNull);
			reader.Dispose();

			// Clean up.
			DisposeAll(writer);
		}
		#endregion

		#region Boolean Indicator
		[Fact]
		public void WriteBooleanIndicatorTrue()
		{
			ISafeWriter writer = CreateWriterWithStream();

			bool success = writer.WriteNullIndicator(true);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(0, isNull);
			reader.Dispose();

			// Clean up.
			DisposeAll(writer);
		}
		[Fact]
		public void WriteBooleanIndicatorFalse()
		{
			ISafeWriter writer = CreateWriterWithStream();

			bool success = writer.WriteNullIndicator(false);
			Assert.True(success);

			// Ensure something was written.
			Assert.True(DidWrite(writer, 0));

			// Ensure the correct data was written.
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			stream.Seek(0, SeekOrigin.Begin);
			BinaryReader reader = new BinaryReader(stream);

			byte isNull = reader.ReadByte();
			Assert.Equal(1, isNull);
			reader.Dispose();

			// Clean up.
			DisposeAll(writer);
		}
		#endregion

		private static ISafeWriter CreateWriterWithStream()
		{
			MemoryStream stream = new MemoryStream();
			ISafeWriter  writer= new ClearSafeWriter(stream);
			return writer;
		}
		private static void DisposeAll(ISafeWriter writer)
		{
			MemoryStream stream = (MemoryStream)writer.BaseStream;
			writer.Dispose();
			writer = null;
			stream.Dispose();
			stream = null;
		}
		private static bool DidWrite(ISafeWriter writer, int startPosition)
		{
			writer.Flush();
			int len = (int)writer.BaseStream.Length;
			return (len > startPosition);
		}
	}
}

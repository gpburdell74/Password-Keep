using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordKeep.Data.Test
{
	public class ClearSafeReaderTests
	{
		#region Read Boolean
		[Fact]
		public void ReadBooleanFalseTest()
		{
			Stream stream = CreateReaderStream(false);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			bool data = reader.ReadBoolean();
			Assert.False(data);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}

		[Fact]
		public void ReadBooleanTrueTest()
		{
			Stream stream = CreateReaderStream(true);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			bool data = reader.ReadBoolean();
			Assert.True(data);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		#endregion

		#region Date/Time
		[Fact]
		public void ReadDateTimeTest()
		{
			// Create / Setup 
			DateTime originalDate = DateTime.Parse("07/12/1974 11:12:34");
			Stream stream = CreateReaderStream(originalDate);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			DateTime value = reader.ReadDateTime();
			Assert.Equal(originalDate, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}

		[Fact]
		public void ReadDateTimeNullableTest()
		{
			// Create / Setup 
			DateTime? originalDate = DateTime.Parse("07/12/1974 11:12:34");
			Stream stream = CreateReaderStream(originalDate);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			DateTime? value = reader.ReadDateTimeNullable();
			Assert.NotNull(value);
			Assert.Equal(originalDate, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}

		[Fact]
		public void WriteDateTimeNullableTestWithNull()
		{
			// Create / Setup 
			DateTime? originalDate = null;
			Stream stream = CreateReaderStream(originalDate);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			DateTime? value = reader.ReadDateTimeNullable();
			Assert.Null(value);
			Assert.Equal(originalDate, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		#endregion

		#region Int32
		[Fact]
		public void WriteInt32Test()
		{
			// Create / Setup 
			int original = 42;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			int value = reader.ReadInt32();
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		[Theory]
		[InlineData(0),
		 InlineData(1),
			InlineData(Int32.MaxValue),
			InlineData(Int32.MinValue),
			InlineData(256),
			InlineData(-99),
			InlineData(12)]
		public void WriteInt32RangeTest(int original)
		{
			// Create / Setup 
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			int value = reader.ReadInt32();
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		[Fact]
		public void WriteInt32NullableTest()
		{
			// Create / Setup 
			int? original = 32;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			int? value = reader.ReadInt32Nullable();
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();


		}

		[Fact]
		public void WriteInt32NullableTestWithNull()
		{
			// Create / Setup 
			int? original = null;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			int? value = reader.ReadInt32Nullable();
			Assert.Null(value);
			Assert.Equal(original, value);
			
			// Clean up.
			reader.Dispose();
			stream.Dispose();

		}
		#endregion

		#region Single / Float
		[Fact]
		public void WriteSingleTest()
		{
			// Create / Setup 
			float original = 29312.772981f;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			float value = reader.ReadSingle();
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
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
		public void WriteSingleRangeTest(float original)
		{
			// Create / Setup 
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			float value = reader.ReadSingle();
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		[Fact]
		public void WriteSingleNullableTest()
		{
			// Create / Setup 
			float? original = 29312.772981f;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			float? value = reader.ReadSingleNullable();
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();


		}

		[Fact]
		public void WriteSingleNullableTestWithNull()
		{
			// Create / Setup 
			float? original = null;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			float? value = reader.ReadSingleNullable();
			Assert.Null(value);
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();


		}
		#endregion

		#region String
		[Fact]
		public void WriteStringTest()
		{
			// Test success / fail.
			string original = "This is some data Content to be written.\r\n\t123456780.";
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			string? value = reader.ReadString();
			Assert.NotNull(value);
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		[Fact]
		public void WriteEmptyStringTest()
		{
			// Test success / fail.
			string original = string.Empty;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			string? value = reader.ReadString();
			Assert.NotNull(value);
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		[Fact]
		public void WriteNullStringTest()
		{
			// Test success / fail.
			string original = null;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			string? value = reader.ReadString();
			Assert.Null(value);
			Assert.Equal(original, value);

			// Clean up.
			reader.Dispose();
			stream.Dispose();
		}
		#endregion

		#region Adaptive String Collection
		[Fact]
		public void WriteAdaptiveStringCollectionTest()
		{
			AdaptiveStringCollection original = new AdaptiveStringCollection();
			original.Add("A");
			original.Add("This is some data Content to be written.\r\n\t");
			original.Add("123456780");
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			AdaptiveStringCollection? value = reader.ReadStringList();
			Assert.NotNull(value);
			Assert.Equal(3, value.Count);
			for(int count = 0; count < value.Count; count++)
			{
				Assert.Equal(original[count], value[count]);
			}

			reader.Dispose();
			stream.Dispose();
		}
		[Fact]
		public void WriteAdaptiveStringCollectionAsEmptyTest()
		{
			AdaptiveStringCollection original = new AdaptiveStringCollection();
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			// Test success / fail.
			AdaptiveStringCollection? value = reader.ReadStringList();
			Assert.NotNull(value);
			Assert.Equal(0, value.Count);

			reader.Dispose();
			stream.Dispose();

		}
		#endregion

		#region USPhoneNumber
		[Fact]
		public void WritePhoneNumberTest()
		{
			USPhoneNumber original = new USPhoneNumber("6788223654");
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			USPhoneNumber? value = reader.ReadPhoneNumber();
			Assert.NotNull(value);
			Assert.Equal(original, value);

			reader.Dispose();
			stream.Dispose();
		}
		[Fact]
		public void WritePhoneNumberAsNullTest()
		{
			USPhoneNumber? original = null;
			Stream stream = CreateReaderStream(original);
			ISafeReader reader = new ClearSafeReader(stream);

			USPhoneNumber? value = reader.ReadPhoneNumber();
			Assert.Null(value);
			Assert.Equal(original, value);

			reader.Dispose();
			stream.Dispose();
		}
		#endregion

		#region Boolean Indicator
		[Fact]
		public void WriteBooleanIndicatorTrue()
		{
			MemoryStream ms = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(ms);
			writer.WriteNullIndicator(true);
			writer.ReleaseStream();
			ms.Seek(0, SeekOrigin.Begin);

			ClearSafeReader reader = new ClearSafeReader(ms);
			bool isNull = reader.ReadNullIndicator();
			Assert.True(isNull);
			reader.Dispose();
			ms.Dispose();
		}
		[Fact]
		public void WriteBooleanIndicatorFalse()
		{
			MemoryStream ms = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(ms);
			writer.WriteNullIndicator(false);
			writer.ReleaseStream();
			ms.Seek(0, SeekOrigin.Begin);

			ClearSafeReader reader = new ClearSafeReader(ms);
			bool isNull = reader.ReadNullIndicator();
			Assert.False(isNull);
			reader.Dispose();
			ms.Dispose();

		}
		#endregion
		private static Stream CreateReaderStream(bool value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(DateTime value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(DateTime? value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}

		private static Stream CreateReaderStream(int value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(int? value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(float value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(float? value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(string? value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(USPhoneNumber value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
		private static Stream CreateReaderStream(AdaptiveStringCollection value)
		{
			MemoryStream stream = new MemoryStream();
			ClearSafeWriter writer = new ClearSafeWriter(stream);

			writer.Write(value);
			writer.ReleaseStream();
			writer.Close();

			stream.Seek(0, SeekOrigin.Begin);

			return stream;
		}
	}
}


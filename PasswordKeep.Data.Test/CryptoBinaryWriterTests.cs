using Adaptive.Intelligence.Shared;
using System.Collections.Concurrent;
using System.Numerics;
using Xunit;

namespace PasswordKeep.Data.Test
{
	public class CryptoBinaryWriterTests
	{
		[Fact()]
		public void CreateTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Dispose();
			testStream.Dispose();
		}

		[Fact()]
		public void KeyCheckTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			MemoryStream readStream = new MemoryStream();
			CryptoBinaryWriter reader = new CryptoBinaryWriter(readStream, "abcde", "1234567890");

			writer.ValidateCompatible(reader);
			reader.ValidateCompatible(writer);

			writer.Dispose();
			testStream.Dispose();
		}

		[Fact()]
		public void DisposeSafetyTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Dispose();
			testStream.Dispose();

			writer.Dispose();
			writer.Dispose();
			writer.Dispose();
			writer.Dispose();

		}

		[Fact()]
		public void WriteBooleanTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write(true);
			writer.Write(false);
			writer.Flush();

			Assert.Equal(104, testStream.Length);
			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();

			
			bool valueA = reader.ReadBoolean();
			bool valueB = reader.ReadBoolean();
			reader.Dispose();
			readStream.Dispose();

			Assert.True(valueA);
			Assert.False(valueB);

		}
		[Fact()]
		public void WriteByteTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((byte)32);
			writer.Write((byte)255);
			writer.Write((byte)0);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			byte valueA = reader.ReadByte();
			byte valueB = reader.ReadByte();
			byte valueC = reader.ReadByte();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(32, valueA);
			Assert.Equal(255, valueB);
			Assert.Equal(0, valueC);

		}
		[Fact()]
		public void WriteByteArrayTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			byte[] data = new byte[] { 0, 1, 2, 3, 4, 90, 128, 253, 254, 255 };

			writer.Write(data);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();

			byte[]? result = reader.ReadBytes();
			reader.Dispose();
			readStream.Dispose();

			Assert.NotNull(result);
			Assert.Equal(0, result.Compare(data));

		}
		[Fact()]
		public void WriteShortTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((short)57);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			short value = reader.ReadInt16();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(57, value);

		}
		[Fact()]
		public void WriteUShortTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((ushort)257);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			ushort value = reader.ReadUInt16();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(257, value);

		}
		[Fact()]
		public void WriteInt32Test()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write(99);
			writer.Write(Int32.MaxValue);
			writer.Write(Int32.MinValue);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			int valueA = reader.ReadInt32();
			int valueB = reader.ReadInt32();
			int valueC = reader.ReadInt32();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(99, valueA);
			Assert.Equal(int.MaxValue, valueB);
			Assert.Equal(int.MinValue, valueC);

		}
		[Fact()]
		public void WriteUInt32Test()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((uint)9912);
			writer.Write(UInt32.MaxValue);
			writer.Write(UInt32.MinValue);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			uint valueA = reader.ReadUInt32();
			uint valueB = reader.ReadUInt32();
			uint valueC = reader.ReadUInt32();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal((uint)9912, valueA);
			Assert.Equal(uint.MaxValue, valueB);
			Assert.Equal(uint.MinValue, valueC);

		}
		[Fact()]
		public void WriteInt64Test()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((long)9912);
			writer.Write(long.MaxValue);
			writer.Write(long.MinValue);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			long valueA = reader.ReadInt64();
			long valueB = reader.ReadInt64();
			long valueC = reader.ReadInt64();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(9912, valueA);
			Assert.Equal(long.MaxValue, valueB);
			Assert.Equal(long.MinValue, valueC);

		}
		[Fact()]
		public void WriteUInt64Test()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((ulong)9912);
			writer.Write(ulong.MaxValue);
			writer.Write(ulong.MinValue);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			ulong valueA = reader.ReadUInt64();
			ulong valueB = reader.ReadUInt64();
			ulong valueC = reader.ReadUInt64();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal((ulong)9912, valueA);
			Assert.Equal(ulong.MaxValue, valueB);
			Assert.Equal(ulong.MinValue, valueC);
		}
		[Fact()]
		public void WriteDateTimeTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			DateTime testTime = DateTime.Parse("07/12/1974 23:22:11");

			writer.Write(testTime);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			DateTime valueA = reader.ReadDateTime();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(testTime, valueA);
		}
		[Fact()]
		public void WriteStringTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			string testData = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()_+=<>?,./";
			writer.Write(testData);

			writer.Write(ulong.MaxValue);
			writer.Write(ulong.MinValue);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			string valueA = reader.ReadString();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(testData, valueA);
		}

		[Fact]
		public void WriteCharTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			char c1 = (char)1;
			char c2 = (char)0;
			char c3 = (char)255;

			writer.Write(c1);
			writer.Write(c2);
			writer.Write(c3);

			writer.Write(ulong.MaxValue);
			writer.Write(ulong.MinValue);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			char ca = reader.ReadChar();
			char cb = reader.ReadChar();
			char cc = reader.ReadChar();

			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(c1, ca);
			Assert.Equal(c2, cb);
			Assert.Equal(c3, cc);

		}
		[Fact]
		public void WriteCharArrayTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			string testData = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*()_+=<>?,./";

			writer.Write(testData.ToCharArray());
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			char[] data = reader.ReadCharArray();
			reader.Dispose();
			readStream.Dispose();

			Assert.Equal(data, testData.ToCharArray());

		}

		[Fact]
		public void WriteDoubleTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((double)3.14159);
			writer.Flush();

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Dispose();
			testStream.Dispose();


			double pi = reader.ReadDouble();

			reader.Dispose();
			readStream.Dispose();

			Assert.Equal((double)3.14159, pi);
		}
		[Fact]
		public void WriteSingleTest()
		{
			MemoryStream testStream = new MemoryStream();
			CryptoBinaryWriter writer = new CryptoBinaryWriter(testStream, "abcde", "1234567890");

			writer.Write((float)3.14159);
			writer.Flush();

			MemoryStream s = (MemoryStream)writer.BaseStream;

			MemoryStream readStream = new MemoryStream(testStream.ToArray());
			CryptoBinaryReader reader = new CryptoBinaryReader(readStream, "abcde", "1234567890");

			s = (MemoryStream)reader.BaseStream;

			Assert.True(writer.ValidateCompatible(reader));
			Assert.True(reader.ValidateCompatible(writer));

			writer.Close();
			testStream.Dispose();


			float pi = reader.ReadSingle();

			reader.Dispose();
			readStream.Dispose();

			Assert.Equal((float)3.14159, pi);

		}
	}
}


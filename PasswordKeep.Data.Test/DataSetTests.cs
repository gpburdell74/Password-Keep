using PasswordKeep.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PasswordKeep.Data.Test
{
	public class DataSetTests
	{
		private const string StdUserID = "abch.2919@22mss.com";
		private const string StdPassword = "738920910/cjskdjf.,123";

		[Fact]
		public void ReadWriteDataSetTest()
		{
			PKDataSet ds = TestDataProvider.CreateDataSet();

			MemoryStream ms = new MemoryStream();
			CryptoEntityWriter writer = new CryptoEntityWriter(ms, StdUserID, StdPassword);
			writer.WriteDataSet(ds);
			ms.Seek(0, SeekOrigin.Begin);

			CryptoEntityReader reader = new CryptoEntityReader(ms, StdUserID, StdPassword);
			PKDataSet rds = reader.ReadDataSet();
			reader.Dispose();

			ds.Dispose();
			writer.Close();
			writer.Dispose();
			rds.Dispose();
		}

	}
}

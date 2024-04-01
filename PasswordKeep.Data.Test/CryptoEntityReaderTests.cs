using Adaptive.Intelligence.Shared;
using Adaptive.Intelligence.Shared.IO;
using PasswordKeep.Data.Entity;
using PasswordKeep.Data.IO;
using Xunit;
using Xunit.Sdk;

namespace PasswordKeep.Data.Test
{
	public class CryptoEntityReaderTests
	{
		private const string StdUserID = "abch.2919@22mss.com";
		private const string StdPassword = "738920910/cjskdjf.,123";

		[Fact]
		public void CreateTest()
		{
			string testFile = GenerateFileName();
			FileStream fs = new FileStream(testFile, FileMode.CreateNew, FileAccess.Write);
			IEntityWriter writer = new CryptoEntityWriter(fs, StdUserID, StdPassword);
			Assert.NotNull(writer);
			writer.Dispose();
			SafeIO.DeleteFile(testFile);
		}
		[Fact]
		public void ReadeBaseFieldsTest()
		{
			RawDataEntry entity = new RawDataEntry()
			{
				Available = 1,
				CurrentBalance = 2,
				Description = "Test",
				LastPaid = DateTime.UtcNow,
				MinimumDue = 3.1f,
				Name = "Test 1",
				NextDue = DateTime.UtcNow,
				Password = "123",
				Url = "http://123",
				UserId = "abc"
			};

			string testFile = GenerateFileName();
			IEntityWriter writer = CreateWriter(testFile);
			bool success = writer.WriteBaseFields(entity);
			Assert.True(success);
			writer.Dispose();

			IEntityReader reader = CreateReader(testFile);
			RawDataEntry entityRead = new RawDataEntry();
			success = reader.ReadBaseFields(entityRead);
			Assert.True(success);

			reader.Dispose();

			Assert.Equal(entityRead.Name, entity.Name);
			Assert.Equal(entityRead.Url, entity.Url);
			Assert.Equal(entityRead.UserId, entity.UserId);
			Assert.Equal(entityRead.Password, entity.Password);
			Assert.Equal(entityRead.Description, entity.Description);

			reader.Dispose();
			SafeIO.DeleteFile(testFile);

		}
		[Fact]
		public void ReadRawDataEntryTest()
		{
			string testFile = GenerateFileName();
			PKDataSet dataset = TestDataProvider.CreateDataSet();
			IEntityWriter writer = CreateWriter(testFile);

			RawDataEntry original = dataset.RawData[0];
			writer.WriteRawData(original);
			writer.Dispose();

			RawDataEntry saved = new RawDataEntry();
			ISafeReader reader = CreateSafeReader(testFile);

			saved.Name = reader.ReadString();
			saved.Url = reader.ReadString();
			saved.UserId = reader.ReadString();
			saved.Password = reader.ReadString();
			saved.Description = reader.ReadString();

			saved.CurrentBalance = reader.ReadSingle();
			saved.LastPaid = reader.ReadDateTimeNullable();
			saved.NextDue = reader.ReadDateTimeNullable();
			saved.Available = reader.ReadSingle();
			saved.MinimumDue = reader.ReadSingle();
			saved.SecurityAnswers = reader.ReadStringList();
			saved.SecurityQuestions = reader.ReadStringList();

			Assert.Equal(original.Name, saved.Name);
			Assert.Equal(original.Url, saved.Url);
			Assert.Equal(original.UserId, saved.UserId);
			Assert.Equal(original.Password, saved.Password);
			Assert.Equal(original.Description, saved.Description);

			Assert.Equal(original.CurrentBalance, saved.CurrentBalance);
			Assert.Equal(original.LastPaid, saved.LastPaid);
			Assert.Equal(original.NextDue, saved.NextDue);
			Assert.Equal(original.Available, saved.Available);
			Assert.Equal(original.MinimumDue, saved.MinimumDue);

			Assert.True(original.SecurityQuestions.Equals(saved.SecurityQuestions));
			Assert.True(original.SecurityAnswers.Equals(saved.SecurityAnswers));
			DisposeAll(reader);
			SafeIO.DeleteFile(testFile);
		}
		[Fact]
		public void ReadFinancialAccountTest()
		{
			string testFile = GenerateFileName();
			PKDataSet dataset = TestDataProvider.CreateDataSet();
			IEntityWriter writer = CreateWriter(testFile);

			FinancialAccountEntry original = dataset.FinancialAccounts[0];
			writer.WriteFinancialAccount(original);
			writer.Dispose();

			FinancialAccountEntry saved = new FinancialAccountEntry();
			ISafeReader reader = CreateSafeReader(testFile);

			saved.Name = reader.ReadString();
			saved.Url = reader.ReadString();
			saved.UserId = reader.ReadString();
			saved.Password = reader.ReadString();
			saved.Description = reader.ReadString();

			saved.AccountType = (FinancialAccountType)reader.ReadInt32();
			saved.AccountNumber = reader.ReadString();
			saved.Company = reader.ReadString();
			saved.Description = reader.ReadString();
			saved.OutstandingBalance = reader.ReadSingle();
			saved.LastAmountPaid = reader.ReadSingle();
			saved.LastDatePaid = reader.ReadDateTimeNullable();
			saved.NextDueDate = reader.ReadDateTimeNullable();
			saved.CreditAvailable = reader.ReadSingle();
			saved.MinimumPayment = reader.ReadSingle();
			saved.IsAutoPay = reader.ReadBoolean();
			saved.AutoPayDay = reader.ReadInt32();

			DisposeAll(reader);

			Assert.Equal(saved.AccountType, original.AccountType);
			Assert.Equal(saved.AccountNumber, original.AccountNumber);
			Assert.Equal(saved.Company, original.Company);
			Assert.Equal(saved.Description, original.Description);
			Assert.Equal(saved.OutstandingBalance, original.OutstandingBalance);
			Assert.Equal(saved.LastAmountPaid, original.LastAmountPaid);
			Assert.Equal(saved.LastDatePaid, original.LastDatePaid);
			Assert.Equal(saved.NextDueDate, original.NextDueDate);
			Assert.Equal(saved.CreditAvailable, original.CreditAvailable);
			Assert.Equal(saved.MinimumPayment, original.MinimumPayment);
			Assert.Equal(saved.IsAutoPay, original.IsAutoPay);
			Assert.Equal(saved.AutoPayDay, original.AutoPayDay);

			SafeIO.DeleteFile(testFile);
		}
		[Fact]
		public void WriteGeneralLoginTest()
		{
			string testFile = GenerateFileName();
			PKDataSet dataset = TestDataProvider.CreateDataSet();
			IEntityWriter writer = CreateWriter(testFile);

			GeneralLoginEntry original = dataset.GeneralLogins[0];
			writer.WriteGeneralLogin(original);
			writer.Dispose();

			GeneralLoginEntry saved = new GeneralLoginEntry();
			ISafeReader reader = CreateSafeReader(testFile);

			saved.Name = reader.ReadString();
			saved.Url = reader.ReadString();
			saved.UserId = reader.ReadString();
			saved.Password = reader.ReadString();
			saved.Description = reader.ReadString();

			saved.AssociatedEmail = reader.ReadString();
			saved.MFAActive = reader.ReadBoolean();
			saved.Description = reader.ReadString();
			saved.MFAPhoneNumber = reader.ReadPhoneNumber();
			saved.ServiceDescription = reader.ReadString();
			saved.SecurityAnswers = reader.ReadStringList();
			saved.SecurityQuestions = reader.ReadStringList();

			DisposeAll(reader);

			Assert.Equal(saved.AssociatedEmail, original.AssociatedEmail);
			Assert.Equal(saved.MFAActive, original.MFAActive);
			Assert.Equal(saved.Description, original.Description);
			Assert.Equal(saved.Description, original.Description);
			Assert.Equal(saved.MFAPhoneNumber, original.MFAPhoneNumber);
			Assert.Equal(saved.ServiceDescription, original.ServiceDescription);
			Assert.True(saved.SecurityAnswers.Equals(original.SecurityAnswers));
			Assert.True(saved.SecurityQuestions.Equals(original.SecurityQuestions));

			SafeIO.DeleteFile(testFile);
		}
		[Fact]
		public void WriteIdProviderTest()
		{
			string testFile = GenerateFileName();
			PKDataSet dataset = TestDataProvider.CreateDataSet();
			IEntityWriter writer = CreateWriter(testFile);

			IdentityProviderEntry original = dataset.IdentityProviders[0];
			writer.WriteIdentityProvider(original);
			writer.Dispose();

			IdentityProviderEntry saved = new IdentityProviderEntry();
			ISafeReader reader = CreateSafeReader(testFile);

			saved.Name = reader.ReadString();
			saved.Url = reader.ReadString();
			saved.UserId = reader.ReadString();
			saved.Password = reader.ReadString();
			saved.Description = reader.ReadString();

			saved.AssociatedEmail = reader.ReadString();
			saved.MFAActive = reader.ReadBoolean();
			saved.MFAPhoneNumber = reader.ReadPhoneNumber();
			saved.IdentityService = (IdentityService)reader.ReadInt32();

			DisposeAll(reader);

			Assert.Equal(saved.AssociatedEmail, original.AssociatedEmail);
			Assert.Equal(saved.MFAActive, original.MFAActive);
			Assert.Equal(saved.MFAPhoneNumber, original.MFAPhoneNumber);
			Assert.Equal(saved.IdentityService, original.IdentityService);

			SafeIO.DeleteFile(testFile);
		}
		[Fact]
		public void WriteBillTest()
		{
			string testFile = GenerateFileName();
			PKDataSet dataset = TestDataProvider.CreateDataSet();
			IEntityWriter writer = CreateWriter(testFile);

			BillEntry original = dataset.Bills[0];
			writer.WriteBillEntry(original);
			writer.Dispose();

			BillEntry saved = new BillEntry();
			ISafeReader reader = CreateSafeReader(testFile);

			saved.Name = reader.ReadString();
			saved.Url = reader.ReadString();
			saved.UserId = reader.ReadString();
			saved.Password = reader.ReadString();
			saved.Description = reader.ReadString();

			saved.Company = reader.ReadString();
			saved.Description = reader.ReadString();
			saved.OutstandingBalance = reader.ReadSingle();
			saved.LastDatePaid = reader.ReadDateTimeNullable();
			saved.NextDueDate = reader.ReadDateTimeNullable();
			saved.IsAutoPay = reader.ReadBoolean();
			saved.AutoPayDay = reader.ReadInt32();
			saved.LastAmountPaid = reader.ReadSingle();

			DisposeAll(reader);

			Assert.Equal(saved.Name, original.Name);
			Assert.Equal(saved.Url, original.Url);
			Assert.Equal(saved.UserId, original.UserId);
			Assert.Equal(saved.Password, original.Password);
			Assert.Equal(saved.Description, original.Description);
			Assert.Equal(saved.Company, original.Company);
			Assert.Equal(saved.OutstandingBalance, original.OutstandingBalance);
			Assert.Equal(saved.LastAmountPaid, original.LastAmountPaid);
			Assert.Equal(saved.LastDatePaid, original.LastDatePaid);
			Assert.Equal(saved.NextDueDate, original.NextDueDate);
			Assert.Equal(saved.IsAutoPay, original.IsAutoPay);
			Assert.Equal(saved.AutoPayDay, original.AutoPayDay);

			SafeIO.DeleteFile(testFile);
		}

		private ISafeReader CreateSafeReader(string testFile)
		{
			FileStream fs = new FileStream(testFile, FileMode.Open, FileAccess.Read);
			CryptoSafeReader reader = new CryptoSafeReader(fs, StdUserID, StdPassword);
			return reader;
		}
		private static void DisposeAll(ISafeReader reader)
		{
			reader.Dispose();
		}
		private static IEntityWriter CreateWriter(string testFile)
		{
			if (File.Exists(testFile))
				File.Delete(testFile);
			FileStream fs = new FileStream(testFile, FileMode.CreateNew, FileAccess.Write);
			return new CryptoEntityWriter(fs, StdUserID, StdPassword);
		}
		private static IEntityReader CreateReader(string testFile)
		{
			FileStream fs = new FileStream(testFile, FileMode.Open, FileAccess.Read);
			return new CryptoEntityReader(fs, StdUserID, StdPassword);
		}

	private static string GenerateFileName()
		{
			return @"C:\Temp\TestFile-" +
				System.Environment.TickCount.ToString() + ".samk";
		}
	}
}

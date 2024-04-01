using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;
using PasswordKeep.Data.IO;
using Xunit;

namespace PasswordKeep.Data.Test
{
	public class ClearEntityWriterTests
	{
		[Fact]
		public void CreateTest()
		{
			string testFile = @"C:\Temp\TestFile.sam";
			IEntityWriter writer = CreateClearEntityWriter(testFile);
			Assert.NotNull(writer);
			writer.Dispose();

		}
		[Fact]
		public void WriteBaseFieldsTest()
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

			IEntityWriter writer = CreateWriter();
			bool success = writer.WriteBaseFields(entity);
			Assert.True(success);
			writer.Dispose();

			IEntityReader reader = CreateReader();
			RawDataEntry entityRead = new RawDataEntry();
			success = reader.ReadBaseFields(entityRead);
			Assert.True(success);

			reader.Dispose();

			Assert.Equal(entityRead.Name , entity.Name);
			Assert.Equal(entityRead.Url, entity.Url);
			Assert.Equal(entityRead.UserId, entity.UserId);
			Assert.Equal(entityRead.Password, entity.Password);
			Assert.Equal(entityRead.Description, entity.Description);

			reader.Dispose();

		}
		[Fact]
		public void WriteRawDataEntryTest()
		{
			PKDataSet dataset = CreateDataSet();
			IEntityWriter writer = CreateWriter();

			RawDataEntry original = dataset.RawData[0];
			writer.WriteRawData(original);
			writer.Dispose();

			RawDataEntry saved = new RawDataEntry();
			ISafeReader reader = CreateSafeReader();

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

		}
		[Fact] 
		public void WriteFinancialAccountTest()
		{
			PKDataSet dataset = CreateDataSet();
			IEntityWriter writer = CreateWriter();

			FinancialAccountEntry original = dataset.FinancialAccounts[0];
			writer.WriteFinancialAccount(original);
			writer.Dispose();

			FinancialAccountEntry saved = new FinancialAccountEntry();
			ISafeReader reader = CreateSafeReader();

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
		}
		[Fact]
		public void WriteGeneralLoginTest()
		{
			PKDataSet dataset = CreateDataSet();
			IEntityWriter writer = CreateWriter();

			GeneralLoginEntry original = dataset.GeneralLogins[0];
			writer.WriteGeneralLogin(original);
			writer.Dispose();

			GeneralLoginEntry saved = new GeneralLoginEntry();
			ISafeReader reader = CreateSafeReader();

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

		}
		[Fact]
		public void WriteIdProviderTest()
		{
			PKDataSet dataset = CreateDataSet();
			IEntityWriter writer = CreateWriter();

			IdentityProviderEntry original = dataset.IdentityProviders[0];
			writer.WriteIdentityProvider(original);
			writer.Dispose();

			IdentityProviderEntry saved = new IdentityProviderEntry();
			ISafeReader reader = CreateSafeReader();

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
		}
		[Fact]
		public void WriteBillTest()
		{
			PKDataSet dataset = CreateDataSet();
			IEntityWriter writer = CreateWriter();

			BillEntry original = dataset. Bills[0];
			writer.WriteBillEntry(original);
			writer.Dispose();

			BillEntry saved = new BillEntry();
			ISafeReader reader = CreateSafeReader();

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

		}

		private ISafeReader CreateSafeReader()
		{
			string testFile = @"C:\Temp\TestFile.sam";
			FileStream fs = new FileStream(testFile, FileMode.Open, FileAccess.Read);
			ClearSafeReader reader = new ClearSafeReader(fs);
			return reader;
		}
		private static void DisposeAll(ISafeReader reader)
		{
			string testFile = @"C:\Temp\TestFile.sam";
			reader.Dispose();
			File.Delete(testFile);
		}
		private static IEntityWriter CreateWriter()
		{
			string testFile = @"C:\Temp\TestFile.sam";
			if (File.Exists(testFile))
				File.Delete(testFile);
			FileStream fs = new FileStream(testFile, FileMode.CreateNew, FileAccess.Write);
			return new ClearEntityWriter(fs);
		}
		private static IEntityReader CreateReader()
		{
			string testFile = @"C:\Temp\TestFile.sam";
			FileStream fs = new FileStream(testFile, FileMode.Open, FileAccess.Read);
			return new ClearEntityReader(fs);
		}

		#region Test Data Creation

		private static PKDataSet CreateDataSet()
		{
			PKDataSet dataSet = new PKDataSet();

			dataSet.RawData.AddRange(CreateRawDataEntries());
			dataSet.IdentityProviders.AddRange(CreateIdProviderEntries());
			dataSet.Bills.AddRange(CreateBillEntries());
			dataSet.GeneralLogins.AddRange(CreateGeneralLoginEntries());
			dataSet.FinancialAccounts.AddRange(CreateFinancialAccountEntries());

			return dataSet;
		}

		private static List<RawDataEntry> CreateRawDataEntries()
		{
			List<RawDataEntry> list = new List<RawDataEntry>();

			RawDataEntry entry = new RawDataEntry
			{
				Name = "Fidelity",
				Description = "Investment",
				Url = "https://workplaceservices200.fidelity.com/mybenefits/navstation/navigation",
				UserId = "",
				Password = "",
				CurrentBalance = 0,
				LastPaid = null,
				NextDue = null,
				Available = 1,
				MinimumDue = 2,
			};
			entry.SecurityAnswers.Add("SA1");
			entry.SecurityAnswers.Add("SA2");
			entry.SecurityAnswers.Add("SA3");
			entry.SecurityQuestions.Add("SQ1");
			entry.SecurityQuestions.Add("SQ2");
			entry.SecurityQuestions.Add("SQ3");
			list.Add(entry);

			entry = new RawDataEntry
			{
				Name = "North Georgia Realty",
				Description = "Rent",
				Url = "http://www.ngeorgiarealty.net/",
				UserId = "gpburdell74@outlook.com\r\n",
				Password = "0210.Xnydym\r\n",
				CurrentBalance = 10,
				LastPaid = DateTime.Now.AddDays(-30),
				NextDue = DateTime.Now,
				Available =21,
				MinimumDue = 22
			};
			entry.SecurityAnswers.Add("1SA1");
			entry.SecurityAnswers.Add("1SA2");
			entry.SecurityAnswers.Add("1SA3");
			entry.SecurityQuestions.Add("1SQ1");
			entry.SecurityQuestions.Add("1SQ2");
			entry.SecurityQuestions.Add("1SQ3");
			list.Add(entry);

			entry = new RawDataEntry
			{
				Name = "Facebook",
				Description = "",
				Url = "https://workplaceservices200.fidelity.com/mybenefits/navstation/navigation",
				UserId = "6784315012",
				Password = "Z.x.C.34%11.aSd",
				CurrentBalance = 2.21f,
				LastPaid = null,
				NextDue = null,
				Available = 1.1f,
				MinimumDue = 2.3f,
			};
			entry.SecurityAnswers.Add("2SA1");
			entry.SecurityAnswers.Add("2SA2");
			entry.SecurityAnswers.Add("2SA3");
			entry.SecurityQuestions.Add("2SQ1");
			entry.SecurityQuestions.Add("2SQ2");
			entry.SecurityQuestions.Add("2SQ3");
			list.Add(entry);

			return list;
		}

		private static List<IdentityProviderEntry> CreateIdProviderEntries()
		{
			List<IdentityProviderEntry> list = new List<IdentityProviderEntry>();

			IdentityProviderEntry entry = new IdentityProviderEntry
			{
				Name = "Microsoft",
				Description = "Microsoft",
				Url = "http://www.microsoft.com",
				UserId = "gpburdell74@outlook.com",
				Password = "2976.Xnydym",
				AssociatedEmail = "gpburdell74@outlook.com",
				MFAActive = true,
				MFAPhoneNumber = new USPhoneNumber("6788223654")
			};
			list.Add(entry);
			 entry = new IdentityProviderEntry
			{
				Name = "Facebook",
				Description = "Facebook",
				Url = "http://www.facebook.com",
				UserId = "6784315012",
				Password = "Z.x.C.34%11.aSd",
				AssociatedEmail = "gpburdell74@outlook.com",
				MFAActive = true,
				MFAPhoneNumber = new USPhoneNumber("6788223654")
			};
			list.Add(entry);
			entry = new IdentityProviderEntry
			{
				Name = "Google",
				Description = "Personal}",
				Url = "http://www.google.com",
				UserId = "csharpsam74@gmail.com",
				Password = "2976.Xnydym",
				AssociatedEmail = "gpburdell74@outlook.com",
				MFAActive = true,
				MFAPhoneNumber = new USPhoneNumber("6788223654")
			};
			list.Add(entry);

			return list;
		}
		private static List<GeneralLoginEntry> CreateGeneralLoginEntries()
		{
			List<GeneralLoginEntry> list = new List<GeneralLoginEntry>();

			GeneralLoginEntry entry = new GeneralLoginEntry
			{
				Name = "Amazon",
				Description = "Shopping",
				ServiceDescription = "Web Site",
				Url= "http://www.amazon.com",
				UserId = "6788223654",
				Password = "913724Xnygtd722a",
				AssociatedEmail = "gpburdell74@Outlook.com",
				MFAActive = true,
				MFAPhoneNumber = new USPhoneNumber("6788223654")
			};
			list.Add(entry);

			entry = new GeneralLoginEntry
			{
				Name = "Anthem BCBS",
				Description = "Old Health Insurance",
				ServiceDescription = "Web Site",
				Url = "https://www.anthem.com/login/",
				UserId = "gpburdell74@outlook.com",
				Password = "0210Xnydym",
				AssociatedEmail = "gpburdell74@Outlook.com",
				MFAActive = false,
				MFAPhoneNumber = null
			};
			list.Add(entry);

			entry = new GeneralLoginEntry
			{
				Name = "Connect Your Care",
				Description = "Health Care",
				ServiceDescription = "Web Site",
				Url = "http://www.connectyourcare.com",
				UserId = "gpburdell74\r\n",
				Password = "0210Xnydym\r\ngtd722a\r\n",
				AssociatedEmail = "gpburdell74@Outlook.com",
				MFAActive = false,
				MFAPhoneNumber = null
			};
			entry.SecurityAnswers.Add("SDB9XDUTWBH6A6JQ4JK5D3RZ");

			list.Add(entry);
			return list;
		}
		private static List<FinancialAccountEntry> CreateFinancialAccountEntries()
		{
			List<FinancialAccountEntry> list = new List<FinancialAccountEntry>();

			FinancialAccountEntry entry = new FinancialAccountEntry
			{
				Name = "Truist",
				Description = "Primary Bank",
				AccountType = FinancialAccountType.NotSpecified,
				Company = "Truist",
				Url = "http://www.truist.com",
				UserId = "adaptiveint",
				Password = "66ww3241zXnygtd722a",
				OutstandingBalance = 0,
				LastAmountPaid = 0,
				LastDatePaid = null,
				NextDueDate = null,
				CreditAvailable = 0,
				MinimumPayment = 0
			};
			list.Add(entry);
			entry = new FinancialAccountEntry
			{
				Name = "Synchrony Bank",
				Description = "Discount Tire Credit Card",
				AccountType = FinancialAccountType.CreditCard,
				Company = "Synchrony Bank",
				Url = "https://www.mysynchrony.com/?show_cc_login_frame=Y",
				UserId = "gpburdell74",
				Password = "0210Xnydym",
				OutstandingBalance = 92.14f,
				LastAmountPaid = 92.14f,
				LastDatePaid = DateTime.Parse("03/18/2024"),
				NextDueDate = DateTime.Parse("04/20/2024"),
				CreditAvailable = 657f,
				MinimumPayment = 0f
			};
			list.Add(entry);
			entry = new FinancialAccountEntry
			{
				Name = "Lending Club",
				Description = "Debt Consolidation Loan",
				AccountType = FinancialAccountType.PersonalLoan,
				Company = "Lending Club",
				Url = "https://banking.lendingclub.com/login?next=%2F%3FfromMC%3Dtrue",
				UserId = "gpburdell74@outlook.com",
				Password = "0210.Xnydym",
				OutstandingBalance = 12102.66f,
				LastAmountPaid = 493.06f,
				LastDatePaid = DateTime.Parse("03/18/2024"),
				NextDueDate = DateTime.Parse("04/20/2024"),
				CreditAvailable = 0f,
				MinimumPayment = 493.06f,
				IsAutoPay = true,
				AutoPayDay = 28

			};
			list.Add(entry);

			return list;
		}
		private static List<BillEntry> CreateBillEntries()
		{
			List<BillEntry> list = new List<BillEntry>();

			BillEntry entry = new BillEntry
			{
				Name = "Sawnee",
				Description = "Electric Bill",
				Company = "Sawnee Electric",
				Url = "https://sawnee.smarthub.coop/",
				UserId = "gpburdell74@outlook.com",
				Password = "gtd722a",
				OutstandingBalance = 3.01f,
				LastDatePaid = DateTime.Parse("03/18/2024"),
				NextDueDate = DateTime.Parse("04/20/2024"),
				LastAmountPaid = 117.25f,
				IsAutoPay = false,
				AutoPayDay = 0
			};
			list.Add(entry);
			entry = new BillEntry
			{
				Name = "Tru Natural Gas",
				Description = "Gas Bill",
				Company = "Sawnee Electric",
				Url = "http://www.truenaturalgas.com",
				UserId = "gpburdell74",
				Password = "gtd722a",
				OutstandingBalance = 13.01f,
				LastDatePaid = DateTime.Parse("03/18/2024"),
				NextDueDate = DateTime.Parse("04/20/2024"),
				LastAmountPaid = 1247.45f,
				IsAutoPay = false,
				AutoPayDay = 0
			};
			list.Add(entry);
			entry = new BillEntry
			{
				Name = "Rent",
				Description = "Rent",
				Company = "North Georgia Realty",
				Url = "http://www.ngeorgiarealty.net/",
				UserId = "gpburdell74@outlook.com",
				Password = "0210.Xnydym",
				OutstandingBalance = 0,
				LastDatePaid = DateTime.Parse("03/01/2024"),
				NextDueDate = DateTime.Parse("04/01/2024"),
				LastAmountPaid = 1540.00f,
				IsAutoPay = true,
				AutoPayDay = 1
			};
			list.Add(entry);

			return list;
		}


		private static IEntityWriter CreateClearEntityWriter(string testFile)
		{
			FileStream fs = new FileStream(testFile, FileMode.CreateNew, FileAccess.Write);
			return new ClearEntityWriter(fs);
		}
		private static IEntityReader CreateClearEntityReader(string testFile)
		{
			FileStream fs = new FileStream(testFile, FileMode.Open, FileAccess.Read);
			return new ClearEntityReader(fs);
		}
		#endregion

	}
}

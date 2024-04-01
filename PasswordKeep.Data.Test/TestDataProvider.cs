using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeep.Data.Test
{
	public static class TestDataProvider
	{

		#region Test Data Creation

		public static PKDataSet CreateDataSet()
		{
			PKDataSet dataSet = new PKDataSet();

			dataSet.RawData.AddRange(CreateRawDataEntries());
			dataSet.IdentityProviders.AddRange(CreateIdProviderEntries());
			dataSet.Bills.AddRange(CreateBillEntries());
			dataSet.GeneralLogins.AddRange(CreateGeneralLoginEntries());
			dataSet.FinancialAccounts.AddRange(CreateFinancialAccountEntries());

			return dataSet;
		}

		public static List<RawDataEntry> CreateRawDataEntries()
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
				Available = 21,
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

		public static List<IdentityProviderEntry> CreateIdProviderEntries()
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
		public static List<GeneralLoginEntry> CreateGeneralLoginEntries()
		{
			List<GeneralLoginEntry> list = new List<GeneralLoginEntry>();

			GeneralLoginEntry entry = new GeneralLoginEntry
			{
				Name = "Amazon",
				Description = "Shopping",
				ServiceDescription = "Web Site",
				Url = "http://www.amazon.com",
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
		public static List<FinancialAccountEntry> CreateFinancialAccountEntries()
		{
			List<FinancialAccountEntry> list = new List<FinancialAccountEntry>();

			FinancialAccountEntry entry = new FinancialAccountEntry
			{
				Name = "Truist",
				Description = "Primary Bank",
				AccountType = FinancialAccountType.Bank,
				AccountNumber = "1234",
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
		public static List<BillEntry> CreateBillEntries()
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
		#endregion

	}
}

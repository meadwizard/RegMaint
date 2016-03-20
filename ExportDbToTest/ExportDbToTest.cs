using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using RegData;

namespace ExportDbToTest
{
	class Program
	{
		static void Main(string[] args)
		{
			string outputFile = @"x:\\Earthspirit\register\fieldList.csv";
			try
			{
				using (TextWriter wr = new StreamWriter(outputFile))
				{
					Export(wr);
					wr.WriteLine("# Output Completed {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
				}
			}
			catch (Exception exc)
			{
				Console.WriteLine("Exception:" + exc.Message);
			}
		}

		static void Export(TextWriter stream)
		{
			RegDatabase regDB = DbAccess.LoadDatabase();
			stream.WriteLine("RegId,firstName,lastName,akaName,address,city,state,zipcode,country,earlyBird,regOption,mealPlanOption,fname1,lname1,age1,gender1,mealPlan1,fname2,lname2,age2,gender2,mealPlan2,fname3,lname3,age3,gender3,mealPlan3,fname4,lname4,age4,gender4,mealPlan4,housing,cost,CLAN0,CLAN1,CLAN2,CLAN3,CLAN_MSG0,CLAN_MSG1,CLAN_MSG2,CLAN_MSG3,vendor,vendorBusiness,vendorAddress,vendorPhone,vendorEmail,vendorMerchandise,donateFlag,donateDetail,vendorSetup,vendorHistory,vendorSleeping,maSalesTaxNbr,barterFlag,cashFlag,checkFlag,visamcFlag,discoverFlag,amexFlag");
			foreach( Registration reg in regDB.regData )
			{
				CSV csvOut = new CSV();
				List<Person> personList = regDB.personData.Where( x => x.regID == reg.RegId).ToList();
				if (personList.Count == 0)
				{
					stream.WriteLine("#There are no person records associated with registration #{0}", reg.RegId);
					continue;
				}
				Person primary = personList[0];
				csvOut.Add(reg.RegId);
				csvOut.Add(reg.FirstName);
				csvOut.Add(reg.LastName);
				csvOut.Add(primary.akaName);
				csvOut.Add(reg.Address);
				csvOut.Add(reg.City);
				csvOut.Add(reg.State);
				csvOut.Add(reg.Zipcode);
				csvOut.Add(reg.Country);
				csvOut.Add( reg.EarlyBird);
				csvOut.Add(reg.RegOptionId);
				csvOut.Add(primary.MealPlan);
				for (int i = 1; i < 5; ++i)
				{
					if (personList.Count > i)
					{
						csvOut.Add(personList[i].FirstName);
						csvOut.Add(personList[i].LastName);
						csvOut.Add(personList[i].age);
						csvOut.Add(personList[i].gender);
						csvOut.Add(personList[i].MealPlan);
					}
					else
					{
						csvOut.BlankField();
						csvOut.BlankField();
						csvOut.BlankField();
						csvOut.BlankField();
						csvOut.BlankField();
					}
				}
				csvOut.Add(reg.Housing);
				csvOut.Add(reg.AmountDue);

				csvOut.Add(primary.Clan0);
				csvOut.Add(primary.Clan1);
				csvOut.Add(primary.Clan2);
				csvOut.Add(primary.Clan3);
				csvOut.Add(primary.Clan_Msg0);
				csvOut.Add(primary.Clan_Msg1);
				csvOut.Add(primary.Clan_Msg2);
				csvOut.Add(primary.Clan_Msg3);

				Merchant merchant = regDB.merchantData.FirstOrDefault(x => x.regID == reg.RegId);
				if (merchant != null)
				{
					csvOut.Add(true);
					csvOut.Add(merchant.businessName);
					csvOut.Add(merchant.businessAddress);
					csvOut.Add(merchant.businessPhone);
					csvOut.Add(merchant.businessEmail);
					csvOut.Add(merchant.merchandise);
					csvOut.Add(string.IsNullOrWhiteSpace(merchant.donateDetail));
					csvOut.Add(merchant.donateDetail);
					csvOut.Add(merchant.description); // setup
					csvOut.Add(merchant.previous); // history
					csvOut.Add(merchant.sleepInMerchants);
					csvOut.BlankField(); //maSalexTaxNbrr
					csvOut.Add( merchant.barterFlag);
					csvOut.Add( merchant.cashFlag);
					csvOut.Add( merchant.checkFlag);
					csvOut.Add( merchant.visamcFlag);
					csvOut.Add( merchant.discoverFlag);
					csvOut.Add( merchant.amexFlag);
				}
				else
				{
					csvOut.Add(false);
				}

				stream.WriteLine(csvOut.ToString());
			}
		}
	}

	class CSV
	{
		private StringBuilder line = new StringBuilder();

		public string ToString()
		{
			return line.ToString();
		}

		public void Add(int value)
		{
			if (line.Length > 0) line.Append(',');
			line.AppendFormat("{0}", value);
		}

		public void Add(decimal value)
		{
			if (line.Length > 0) line.Append(',');
			line.AppendFormat("{0}", value);
		}

		public void Add(string value)
		{
			if (line.Length > 0) line.Append(',');
			line.AppendFormat("\"{0}\"", value.Replace("\"", "\\\"").Replace("\n","<cr>").Trim());
		}

		public void Add(bool value)
		{
			if (line.Length > 0) line.Append(',');
			line.Append(value ? "on" : "off");
		}

		public void BlankField()
		{
			if (line.Length > 0) line.Append(',');
		}

	}

}

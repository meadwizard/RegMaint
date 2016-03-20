using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RegData;
using System.Xml.Serialization;
using System.IO;

namespace RegData
{

	public class DbAccess
	{
		//public static string ConnectionStr = "Server=enki;Uid=root;Pwd=thunder;Database=rowan_ritesregistration;";
		//public static string ConnectionStr = "Server=enki;Uid=hhgReg;Pwd=T*X$c9;an1Kb;Database=rowan_ritesregistration;";
		//$link = new mysqli("localhost", "hhgReg", 'T*X$c9;an1Kb', "rites");

		static string fileName = "DatabaseExport.xml";

		static RegDatabase regDb = new RegDatabase();

		public static RegDatabase LoadLocal()
		{
			regDb = new RegDatabase();
			if (File.Exists(fileName))
			{
				XmlSerializer xml = new XmlSerializer(regDb.GetType());
				TextReader rdr = new StreamReader(fileName);
				regDb = (RegDatabase)xml.Deserialize(rdr);
			}
			return regDb;
		}

		public static void SaveLocal()
		{
			XmlSerializer xml = new XmlSerializer(regDb.GetType());
			using (TextWriter wr = new StreamWriter(fileName))
			{
				xml.Serialize(wr, regDb);
			}
		}

		private static List<RegOption> _regOptionList  = null;
		public static List<RegOption> RegistrationOptionList
		{
			get 
			{
				if (_regOptionList == null)
				{
					_regOptionList = new List<RegOption>();
					_regOptionList.Add(new RegOption() { RegOptionId = 0, Description = "Unspecified" });
					_regOptionList.Add(new RegOption() { RegOptionId = 1, Description = "Full Rites" });
					_regOptionList.Add(new RegOption() { RegOptionId = 2, Description = "Weekend Only" });
					_regOptionList.Add(new RegOption() { RegOptionId = 3, Description = "Village Builders" });
				}
				return _regOptionList;
			}
		}


		public static RegDatabase LoadDatabase()
		{
			regDb = new RegDatabase();

			MySqlConnectionStringBuilder conn_string = new MySqlConnectionStringBuilder();
			conn_string.Server = "enki";
			//conn_string.Server = "rowantree.org";
			conn_string.UserID = "rowan_RosReg";
			conn_string.Password = "eBssEzAjvpCU";
			conn_string.Database = "rowan_RitesRegistration";
			//conn_string.SslMode = MySqlSslMode.Required;

			using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
			{
				conn.Open();

				using (MySqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = "SELECT * FROM registration";
					using (MySqlDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							regDb.regData.Add(new Registration(rdr));
						}
					}
				}

				using (MySqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = "SELECT * FROM person";
					using (MySqlDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							Person person = new Person(rdr);
							regDb.personData.Add(person);
							Registration reg = regDb.regData.FirstOrDefault(x => x.RegId == person.regID);
							reg.personList.Add(person);
							//regDb.regData.First(x => x.RegId == person.regID).personList.Add(person);
						}
					}
				}

				using (MySqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = "SELECT * FROM merchant";
					using (MySqlDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							Merchant merchant = new Merchant(rdr);
							regDb.merchantData.Add(merchant);
							Registration reg = regDb.regData.FirstOrDefault(x => x.RegId == merchant.regID);
							if (reg != null)
							{
								reg.merchantInfo = merchant;
							}
							else
							{
								// this is an error
							}
						}
					}
				}

			}

			return regDb;

		}


		public static bool GetBoolFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr, string column)
		{
			try
			{
				int ord = rdr.GetOrdinal(column);
				if (rdr[ord] == DBNull.Value) return false;
				string typeName = rdr.GetDataTypeName(ord);
				if (typeName == "TINYINT")
				{
					return rdr.GetInt16(ord) == 1;
				}
				return (bool)rdr[column];
			}
			catch (Exception exc)
			{
				return false;
			}
		}

		public static int GetIntFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr, string column)
		{
			try
			{
				int ord = rdr.GetOrdinal(column);
				if (rdr[ord] == DBNull.Value) return 0;
				string typeName = rdr.GetDataTypeName(ord);
				if (typeName == "TINYINT")
				{
					return rdr.GetInt16(ord);
				}
				return rdr.GetInt32(ord);
			}
			catch (Exception exc)
			{
				return 0;
			}
		}

		public static string GetStringFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr, string column)
		{
			try
			{
				return rdr[column].ToString();
			}
			catch (Exception exc)
			{
				return null;
			}
		}

		public static decimal GetDecimalFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr, string column)
		{
			try
			{
				return (decimal)rdr[column];
			}
			catch (Exception exc)
			{
				return 0;
			}

		}

		public static DateTime GetDateTimeFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr, string column)
		{
			try
			{
				int ord = rdr.GetOrdinal(column);
				//if (rdr[ord] == DBNull.Value) return DateTime.MinValue;
				string typeName = rdr.GetDataTypeName(ord);
				if (typeName == "DATE")
				{
					rdr.GetMySqlDateTime(ord).GetDateTime();
				}
				return (DateTime)rdr[column];
			}
			catch (Exception exc)
			{
				return DateTime.Now;
			}
		}
	}
}

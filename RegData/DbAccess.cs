﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RegData;
using System.Xml.Serialization;
using System.IO;
using log4net;

namespace RegData
{

	public class DbAccess
	{
		//public static string ConnectionStr = "Server=enki;Uid=root;Pwd=thunder;Database=rowan_ritesregistration;";
		//public static string ConnectionStr = "Server=enki;Uid=hhgReg;Pwd=T*X$c9;an1Kb;Database=rowan_ritesregistration;";
		//$link = new mysqli("localhost", "hhgReg", 'T*X$c9;an1Kb', "rites");

		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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
				log.InfoFormat("Data loaded from local file:{0}", fileName);
			}
			else
			{
				log.Info("Could not load from local, file does not exist");
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
			log.InfoFormat("Data saved to local file:{0}", fileName);
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


		private static List<RegGroup> _regGroupList = null;
		public static List<RegGroup> RegistrationGroupList
		{
			get
			{
				if (_regGroupList == null)
				{
					_regGroupList = new List<RegGroup>();
					_regGroupList.Add(new RegGroup() { Description = "Housing", GroupName = "Housing", type = RegGroupType.Housing });
					_regGroupList.Add(new RegGroup() { Description = "Other", GroupName = "Other", type = RegGroupType.Other });
				}
				return _regGroupList;
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

			log.InfoFormat("Loading data from MySql Server:{0} ", conn_string.Server);

			using (MySqlConnection conn = new MySqlConnection(conn_string.ToString()))
			{
				conn.Open();

				using (MySqlCommand cmd = conn.CreateCommand())
				{
					cmd.CommandType = System.Data.CommandType.Text;
					cmd.CommandText = "SELECT (SELECT count(*) FROM registration) RegCnt, (SELECT count(*) FROM person) PeopleCnt";
					using (MySqlDataReader rdr = cmd.ExecuteReader())
					{
						while (rdr.Read())
						{
							regDb.RegCount = rdr.GetInt32(0);
							regDb.PersonCount = rdr.GetInt32(1);
						}
					}
				}

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

			log.InfoFormat("Loaded {0} Registration {1} Person {2} Merchant Records", regDb.regData.Count, regDb.personData.Count, regDb.merchantData.Count);

			return regDb;

		}

		#region Access Utilities

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
				log.Error("GetBoolFromRdr", exc);
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
				log.Error("GetIntFromRdr", exc);
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
				log.Error("GetStringFromRdr", exc);
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
				log.Error("GetDecimalFromRdr", exc);
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
				log.Error("GetDateTimeFromRdr", exc);
				return DateTime.Now;
			}
		}

		#endregion

	}
}

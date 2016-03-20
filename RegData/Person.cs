using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace RegData
{
	public class Person : INotifyPropertyChanged
	{
		public Person()
		{
		}

		public Person(MySql.Data.MySqlClient.MySqlDataReader rdr)
		{
			LoadFromRdr(rdr);
		}



		public int PersonID
		{
			get { return _personID; }
			set
			{
				if (value != _personID)
				{
					_personID = value;
					NotifyPropertyChanged("personID ");
				}
			}
		}
		public int regID
		{
			get { return _regID; }
			set
			{
				if (value != _regID)
				{
					_regID = value;
					NotifyPropertyChanged("regID ");
				}
			}
		}
		public int idx
		{
			get { return _idx; }
			set
			{
				if (value != _idx)
				{
					_idx = value;
					NotifyPropertyChanged("idx ");
				}
			}
		}
		public string FirstName
		{
			get { return _firstName; }
			set
			{
				if (value != _firstName)
				{
					_firstName = value;
					NotifyPropertyChanged("firstName ");
				}
			}
		}
		public string LastName
		{
			get { return _lastName; }
			set
			{
				if (value != _lastName)
				{
					_lastName = value;
					NotifyPropertyChanged("lastName");
				}
			}
		}
		public string akaName
		{
			get { return _akaName; }
			set
			{
				if (value != _akaName)
				{
					_akaName = value;
					NotifyPropertyChanged("akaName");
				}
			}
		}
		public bool member
		{
			get { return _member; }
			set
			{
				if (value != _member)
				{
					_member = value;
					NotifyPropertyChanged("member");
				}
			}
		}
		public string gender
		{
			get { return _gender; }
			set
			{
				if (value != _gender)
				{
					_gender = value;
					NotifyPropertyChanged("gender");
				}
			}
		}
		public bool firstros
		{
			get { return _firstros; }
			set
			{
				if (value != _firstros)
				{
					_firstros = value;
					NotifyPropertyChanged("firstros");
				}
			}
		}
		public int MealPlan
		{
			get { return _mealPlan; }
			set
			{
				if (value != _mealPlan)
				{
					_mealPlan = value;
					NotifyPropertyChanged("mealPlan");
				}
			}
		}
		public bool veggie
		{
			get { return _veggie; }
			set
			{
				if (value != _veggie)
				{
					_veggie = value;
					NotifyPropertyChanged("veggie");
				}
			}
		}
		public string age
		{
			get { return _age; }
			set
			{
				if (value != _age)
				{
					_age = value;
					NotifyPropertyChanged("age");
				}
			}
		}
		public bool waiverSigned
		{
			get { return _waiverSigned; }
			set
			{
				if (value != _waiverSigned)
				{
					_waiverSigned = value;
					NotifyPropertyChanged("waiverSigned");
				}
			}
		}
		public DateTime birthDate
		{
			get { return _birthDate; }
			set
			{
				if (value != _birthDate)
				{
					_birthDate = value;
					NotifyPropertyChanged("birthDate");
				}
			}
		}
		public string workshift
		{
			get { return _workshift; }
			set
			{
				if (value != _workshift)
				{
					_workshift = value;
					NotifyPropertyChanged("workshift");
				}
			}
		}
		public string ride_need
		{
			get { return _ride_need; }
			set
			{
				if (value != _ride_need)
				{
					_ride_need = value;
					NotifyPropertyChanged("ride_need");
				}
			}
		}
		public string ride_provide
		{
			get { return _ride_provide; }
			set
			{
				if (value != _ride_provide)
				{
					_ride_provide = value;
					NotifyPropertyChanged("ride_provide");
				}
			}
		}
		public string ride_info
		{
			get { return _ride_info; }
			set
			{
				if (value != _ride_info)
				{
					_ride_info = value;
					NotifyPropertyChanged("ride_info");
				}
			}
		}
		public bool family
		{
			get { return _family; }
			set
			{
				if (value != _family)
				{
					_family = value;
					NotifyPropertyChanged("family");
				}
			}
		}
		public bool quiet
		{
			get { return _quiet; }
			set
			{
				if (value != _quiet)
				{
					_quiet = value;
					NotifyPropertyChanged("quiet");
				}
			}
		}
		public bool allfemale
		{
			get { return _allfemale; }
			set
			{
				if (value != _allfemale)
				{
					_allfemale = value;
					NotifyPropertyChanged("allfemale");
				}
			}
		}
		public bool allmale
		{
			get { return _allmale; }
			set
			{
				if (value != _allmale)
				{
					_allmale = value;
					NotifyPropertyChanged("allmale");
				}
			}
		}
		public bool substance
		{
			get { return _substance; }
			set
			{
				if (value != _substance)
				{
					_substance = value;
					NotifyPropertyChanged("substance");
				}
			}
		}
		public bool latenight
		{
			get { return _latenight; }
			set
			{
				if (value != _latenight)
				{
					_latenight = value;
					NotifyPropertyChanged("latenight");
				}
			}
		}
		public string Clan0
		{
			get { return _Clan0; }
			set
			{
				if (value != _Clan0)
				{
					_Clan0 = value;
					NotifyPropertyChanged("Clan0");
				}
			}
		}
		public string Clan_Msg0
		{
			get { return _Clan_Msg0; }
			set
			{
				if (value != _Clan_Msg0)
				{
					_Clan_Msg0 = value;
					NotifyPropertyChanged("Clan_Msg0");
				}
			}
		}
		public string Clan1
		{
			get { return _Clan1; }
			set
			{
				if (value != _Clan1)
				{
					_Clan1 = value;
					NotifyPropertyChanged("Clan1");
				}
			}
		}
		public string Clan_Msg1
		{
			get { return _Clan_Msg1; }
			set
			{
				if (value != _Clan_Msg1)
				{
					_Clan_Msg1 = value;
					NotifyPropertyChanged("Clan_Msg1");
				}
			}
		}
		public string Clan2
		{
			get { return _Clan2; }
			set
			{
				if (value != _Clan2)
				{
					_Clan2 = value;
					NotifyPropertyChanged("Clan2");
				}
			}
		}
		public string Clan_Msg2
		{
			get { return _Clan_Msg2; }
			set
			{
				if (value != _Clan_Msg2)
				{
					_Clan_Msg2 = value;
					NotifyPropertyChanged("Clan_Msg2");
				}
			}
		}
		public string Clan3
		{
			get { return _Clan3; }
			set
			{
				if (value != _Clan3)
				{
					_Clan3 = value;
					NotifyPropertyChanged("Clan3");
				}
			}
		}
		public string Clan_Msg3
		{
			get { return _Clan_Msg3; }
			set
			{
				if (value != _Clan_Msg3)
				{
					_Clan_Msg3 = value;
					NotifyPropertyChanged("Clan_Msg3");
				}
			}
		}
		public string howmanytimes
		{
			get { return _howmanytimes; }
			set
			{
				if (value != _howmanytimes)
				{
					_howmanytimes = value;
					NotifyPropertyChanged("howmanytimes");
				}
			}
		}
		public string lasttime
		{
			get { return _lasttime; }
			set
			{
				if (value != _lasttime)
				{
					_lasttime = value;
					NotifyPropertyChanged("lasttime");
				}
			}
		}
		public string howlong
		{
			get { return _howlong; }
			set
			{
				if (value != _howlong)
				{
					_howlong = value;
					NotifyPropertyChanged("howlong");
				}
			}
		}
		public string training
		{
			get { return _training; }
			set
			{
				if (value != _training)
				{
					_training = value;
					NotifyPropertyChanged("training");
				}
			}
		}
		public bool fridayBuffet
		{
			get { return _fridayBuffet; }
			set
			{
				if (value != _fridayBuffet)
				{
					_fridayBuffet = value;
					NotifyPropertyChanged("fridayBuffet");
				}
			}
		}
		public bool saturdayLunch
		{
			get { return _saturdayLunch; }
			set
			{
				if (value != _saturdayLunch)
				{
					_saturdayLunch = value;
					NotifyPropertyChanged("saturdayLunch");
				}
			}
		}
		public bool sundayBrunch
		{
			get { return _sundayBrunch; }
			set
			{
				if (value != _sundayBrunch)
				{
					_sundayBrunch = value;
					NotifyPropertyChanged("sundayBrunch");
				}
			}
		}
		public int masque
		{
			get { return _masque; }
			set
			{
				if (value != _masque)
				{
					_masque = value;
					NotifyPropertyChanged("masque ");
				}
			}
		}
		public bool skipFeast
		{
			get { return _skipFeast; }
			set
			{
				if (value != _skipFeast)
				{
					_skipFeast = value;
					NotifyPropertyChanged("skipFeast");
				}
			}
		}
		public string grove
		{
			get { return _grove; }
			set
			{
				if (value != _grove)
				{
					_grove = value;
					NotifyPropertyChanged("grove");
				}
			}
		}


		#region Local Variables
		private int _personID;
		private int _regID;
		private int _idx;
		private string _firstName;
		private string _lastName;
		private string _akaName;
		private bool _member;
		private string _gender;
		private bool _firstros;
		private int _mealPlan;
		private bool _veggie;
		private string _age;
		private bool _waiverSigned;
		private DateTime _birthDate;
		private string _workshift;
		private string _ride_need;
		private string _ride_provide;
		private string _ride_info;
		private bool _family;
		private bool _quiet;
		private bool _allfemale;
		private bool _allmale;
		private bool _substance;
		private bool _latenight;
		private string _Clan0;
		private string _Clan_Msg0;
		private string _Clan1;
		private string _Clan_Msg1;
		private string _Clan2;
		private string _Clan_Msg2;
		private string _Clan3;
		private string _Clan_Msg3;
		private string _howmanytimes;
		private string _lasttime;
		private string _howlong;
		private string _training;
		private bool _fridayBuffet;
		private bool _saturdayLunch;
		private bool _sundayBrunch;
		private int _masque;
		private bool _skipFeast;
		private string _grove;
		#endregion


		public void LoadFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr)
		{
			_personID = DbAccess.GetIntFromRdr(rdr, "personID");
			_regID = DbAccess.GetIntFromRdr(rdr, "regID");
			_idx = DbAccess.GetIntFromRdr(rdr, "idx");
			_firstName = DbAccess.GetStringFromRdr(rdr, "firstName");
			_lastName = DbAccess.GetStringFromRdr(rdr, "lastName");
			_akaName = DbAccess.GetStringFromRdr(rdr, "akaName");
			_member = DbAccess.GetBoolFromRdr(rdr, "member");
			_gender = DbAccess.GetStringFromRdr(rdr, "gender");
			_firstros = DbAccess.GetBoolFromRdr(rdr, "firstros");
			_mealPlan = DbAccess.GetIntFromRdr(rdr, "mealPlan");
			_veggie = DbAccess.GetBoolFromRdr(rdr, "veggie");
			_age = DbAccess.GetStringFromRdr(rdr, "age");
			_waiverSigned = DbAccess.GetBoolFromRdr(rdr, "waiverSigned");
			//_birthDate = DbAccess.GetDateTimeFromRdr(rdr, "birthDate");
			_workshift = DbAccess.GetStringFromRdr(rdr, "workshift");
			_ride_need = DbAccess.GetStringFromRdr(rdr, "ride_need");
			_ride_provide = DbAccess.GetStringFromRdr(rdr, "ride_provide");
			_ride_info = DbAccess.GetStringFromRdr(rdr, "ride_info");
			_family = DbAccess.GetBoolFromRdr(rdr, "family");
			_quiet = DbAccess.GetBoolFromRdr(rdr, "quiet");
			_allfemale = DbAccess.GetBoolFromRdr(rdr, "allfemale");
			_allmale = DbAccess.GetBoolFromRdr(rdr, "allmale");
			_substance = DbAccess.GetBoolFromRdr(rdr, "substance");
			_latenight = DbAccess.GetBoolFromRdr(rdr, "latenight");
			_Clan0 = DbAccess.GetStringFromRdr(rdr, "Clan0");
			_Clan_Msg0 = DbAccess.GetStringFromRdr(rdr, "Clan_Msg0");
			_Clan1 = DbAccess.GetStringFromRdr(rdr, "Clan1");
			_Clan_Msg1 = DbAccess.GetStringFromRdr(rdr, "Clan_Msg1");
			_Clan2 = DbAccess.GetStringFromRdr(rdr, "Clan2");
			_Clan_Msg2 = DbAccess.GetStringFromRdr(rdr, "Clan_Msg2");
			_Clan3 = DbAccess.GetStringFromRdr(rdr, "Clan3");
			_Clan_Msg3 = DbAccess.GetStringFromRdr(rdr, "Clan_Msg3");
			_howmanytimes = DbAccess.GetStringFromRdr(rdr, "howmanytimes");
			_lasttime = DbAccess.GetStringFromRdr(rdr, "lasttime");
			_howlong = DbAccess.GetStringFromRdr(rdr, "howlong");
			_training = DbAccess.GetStringFromRdr(rdr, "training");
			_fridayBuffet = DbAccess.GetBoolFromRdr(rdr, "fridayBuffet");
			_saturdayLunch = DbAccess.GetBoolFromRdr(rdr, "saturdayLunch");
			_sundayBrunch = DbAccess.GetBoolFromRdr(rdr, "sundayBrunch");
			_masque = DbAccess.GetIntFromRdr(rdr, "masque");
			_skipFeast = DbAccess.GetBoolFromRdr(rdr, "skipFeast");
			_grove = DbAccess.GetStringFromRdr(rdr, "grove");
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
			}
		}

	}
}

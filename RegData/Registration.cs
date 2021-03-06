﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RegData
{
	public class Registration : INotifyPropertyChanged
	{
		public Registration()
		{
			personList = new List<Person>();
			regGroupList = new List<RegGroup>();
		}

		public Registration(MySql.Data.MySqlClient.MySqlDataReader rdr) : this()
		{
			LoadFromRdr(rdr);
		}

		public Merchant merchantInfo { get; set;  }

		public List<Person> personList { get; set; }


		#region Not In Database

		public List<RegGroup> RegistrationGroupList { get { return DbAccess.RegistrationGroupList; } }

		public List<RegGroup> regGroupList { get; set;  }

		private bool _AttentionFlag = false;
		public bool AttentionFlag {
			get { return _AttentionFlag; }
			set{
				if ( value != _AttentionFlag )
				{
					_AttentionFlag = value;
					NotifyPropertyChanged("AttentionFlag");
					NotifyPropertyChanged("BtnAttentionColor");
				}
			}
		}

		public string BtnAttentionColor
		{
			get
			{
				return AttentionFlag ? "Green" : "Gray";
			}
		}

		public int PersonCnt
		{
			get
			{
				return personList.Count();
			}
		}

		#endregion


		public int RegId
		{
			get { return _regID; }
			set { _regID = value;  }
		}

		public string FullName
		{
			get
			{
				return string.Format("#{0} {1} {2}", RegId, FirstName, LastName);
			}
		}

		public string PreferredName
		{
			get
			{
				return
					(personList.Count > 0) ? ( string.IsNullOrWhiteSpace(personList[0].akaName) ? "n/a" : personList[0].akaName ): "n/a";
			}
		}

		public string FirstName
		{
			get { return _firstName ;}
			set { _firstName = value; }
		}
		public string LastName
		{
			get { return _lastName;}
			set { _lastName = value; }
		}
		public DateTime RegDate
		{
			get { return _regDate; }
			set { _regDate = value; }
		}

		public string AddressBlock
		{
			get
			{
				return string.Format("{0}\n{1} {2} {3}\n{4}", _address, _city, _state, _zipcode, _country);
			}
		}
		public int RegOptionId
		{
			get { return _optionCode; }
			set { _optionCode = value; }
		}

		public string Housing
		{
			get { return _housing; }
			set { _housing = value; }
		}

		public string Address
		{
			get { return _address;  }
			set { _address = value;  }
		}
		public string City
		{
			get { return _city;  }
			set { _city = value;  }
		}
		public string State
		{
			get { return _state;  }
			set { _state = value;  }
		}
		public string Zipcode
		{
			get { return _zipcode;  }
			set { _zipcode = value;  }
		}
		public string Country
		{
			get { return _country;  }
			set { _country = value;  }
		}
		public bool Vendor
		{
			get { return _vendor;  }
			set { _vendor = value;  }
		}

		public bool NotVendor
		{
			get
			{
				return !Vendor;
			}
		}

		public decimal CalculatedAmount
		{
			get { return _calculatedAmount; }
			set { _calculatedAmount = value; }
		}
		public decimal AmountDue
		{
			get { return _amountDue; }
			set { _amountDue = value; }
		}
		public decimal AmountPaid
		{
			get { return _amountPaid; }
			set { _amountPaid = value; }
		}
		public string BestPhone
		{
			get { return _bestPhone; }
			set { _bestPhone = value; }
		}
		public string SecondPhone
		{
			get { return _secondPhone; }
			set { _secondPhone = value; }
		}
		public string Needs
		{
			get { return _needs; }
			set { _needs = value; }
		}
		public string GroupName
		{
			get { return _group_name; }
			set { _group_name = value; }
		}

		public bool EarlyBird
		{
			get { return _earlybird; }
			set { _earlybird = value; }
		}
		public bool NoisePreference
		{
			get { return _noisePreference == 1; }
			set { _noisePreference = value ? 1 : 0; }
		}
		public bool HousingGender
		{
			get { return _housingGender == 1; }
			set { _housingGender = value ? 1 : 0; }
		}

		#region Private Variables
		private int _regID;
		private string _firstName;
		private string _lastName;
		private string _address;
		private string _city;
		private string _state;
		private string _zipcode;
		private string _country;
		private string _bestPhone;
		private string _secondPhone;
		private string _email;
		private string _housing;
		private string _group_name;
		private string _otherNames;
		private string _paymentType;
		private decimal _schfund;
		private decimal _amountDue;
		private decimal _calculatedAmount;
		private decimal _amountPaid;
		private DateTime _regDate;
		private bool _speaker;
		private bool _vendor;
		private bool _staff;
		private string _notes;
		private int _noticeDate;
		private int _noticeCount;
		private string _guardian;
		private string _needs;
		private int _housingGender;
		private int _noisePreference;
		private int _substance;
		private string _coupon;
		private int _optionCode;
		private string _transactionId;
		private bool _earlybird;
		private bool _emailList;
		private string _qualifications;
		private string _eventCode;
		private int _eventYear;
		#endregion

		public void LoadFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr)
		{
			_regID = DbAccess.GetIntFromRdr(rdr, "regID");
			_firstName = DbAccess.GetStringFromRdr(rdr, "firstName");
			_lastName = DbAccess.GetStringFromRdr(rdr, "lastName");
			_address = DbAccess.GetStringFromRdr(rdr, "address");
			_city = DbAccess.GetStringFromRdr(rdr, "city");
			_state = DbAccess.GetStringFromRdr(rdr, "state");
			_zipcode = DbAccess.GetStringFromRdr(rdr, "zipcode");
			_country = DbAccess.GetStringFromRdr(rdr, "country");
			_bestPhone = DbAccess.GetStringFromRdr(rdr, "bestPhone");
			_secondPhone = DbAccess.GetStringFromRdr(rdr, "secondPhone");
			_email = DbAccess.GetStringFromRdr(rdr, "email");
			_housing = DbAccess.GetStringFromRdr(rdr, "housing");
			_group_name = DbAccess.GetStringFromRdr(rdr, "group_name");
			_otherNames = DbAccess.GetStringFromRdr(rdr, "otherNames");
			_paymentType = DbAccess.GetStringFromRdr(rdr, "paymentType");
			_schfund = DbAccess.GetDecimalFromRdr(rdr, "schfund");
			_amountDue = DbAccess.GetDecimalFromRdr(rdr, "amountDue");
			_calculatedAmount = DbAccess.GetDecimalFromRdr(rdr, "calculatedAmount");
			_amountPaid = DbAccess.GetDecimalFromRdr(rdr, "amountPaid");
			_regDate = DbAccess.GetDateTimeFromRdr(rdr, "regDate");
			_speaker = DbAccess.GetBoolFromRdr(rdr, "speaker");
			_vendor = DbAccess.GetBoolFromRdr(rdr, "vendor");
			_staff = DbAccess.GetBoolFromRdr(rdr, "staff");
			_notes = DbAccess.GetStringFromRdr(rdr, "notes");
			//_noticeDate = DbAccess.GetIntFromRdr(rdr, "noticeDate");
			//_noticeCount = DbAccess.GetIntFromRdr(rdr, "noticeCount");
			_guardian = DbAccess.GetStringFromRdr(rdr, "guardian");
			_needs = DbAccess.GetStringFromRdr(rdr, "needs");
			_housingGender = DbAccess.GetIntFromRdr(rdr, "housingGender");
			_noisePreference = DbAccess.GetIntFromRdr(rdr, "noisePreference");
			_substance = DbAccess.GetIntFromRdr(rdr, "substance");
			_coupon = DbAccess.GetStringFromRdr(rdr, "coupon");
			_optionCode = DbAccess.GetIntFromRdr(rdr, "optionCode");
			_transactionId = DbAccess.GetStringFromRdr(rdr, "transactionId");
			_earlybird = DbAccess.GetBoolFromRdr(rdr, "earlybird");
			_emailList = DbAccess.GetBoolFromRdr(rdr, "emailList");
			_qualifications = DbAccess.GetStringFromRdr(rdr, "qualifications");
			_eventCode = DbAccess.GetStringFromRdr(rdr, "eventCode");
			_eventYear = DbAccess.GetIntFromRdr(rdr, "eventYear");

			// HACK
			_amountDue = _calculatedAmount - _amountPaid;
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

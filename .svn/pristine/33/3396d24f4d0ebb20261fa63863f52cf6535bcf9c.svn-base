using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace RegData
{
	public class Merchant : INotifyPropertyChanged
	{
		public Merchant()
		{
		}

		public Merchant(MySql.Data.MySqlClient.MySqlDataReader rdr)
		{
			LoadFromRdr(rdr);
		}



		public int merchantID
		{
			get { return _merchantID; }
			set
			{
				if (value != _merchantID)
				{
					_merchantID = value;
					NotifyPropertyChanged("merchantID");
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
					NotifyPropertyChanged("regID");
				}
			}
		}
		public string businessName
		{
			get { return _businessName; }
			set
			{
				if (value != _businessName)
				{
					_businessName = value;
					NotifyPropertyChanged("businessName");
				}
			}
		}
		public string businessAddress
		{
			get { return _businessAddress; }
			set
			{
				if (value != _businessAddress)
				{
					_businessAddress = value;
					NotifyPropertyChanged("businessAddress");
				}
			}
		}
		public string businessPhone
		{
			get { return _businessPhone; }
			set
			{
				if (value != _businessPhone)
				{
					_businessPhone = value;
					NotifyPropertyChanged("businessPhone");
				}
			}
		}
		public string businessEmail
		{
			get { return _businessEmail; }
			set
			{
				if (value != _businessEmail)
				{
					_businessEmail = value;
					NotifyPropertyChanged("businessEmail");
				}
			}
		}
		public string description
		{
			get { return _description; }
			set
			{
				if (value != _description)
				{
					_description = value;
					NotifyPropertyChanged("description");
				}
			}
		}
		public string merchandise
		{
			get { return _merchandise; }
			set
			{
				if (value != _merchandise)
				{
					_merchandise = value;
					NotifyPropertyChanged("merchandise");
				}
			}
		}
		public string previous
		{
			get { return _previous; }
			set
			{
				if (value != _previous)
				{
					_previous = value;
					NotifyPropertyChanged("previous");
				}
			}
		}
		public bool sleepInMerchants
		{
			get { return _sleepInMerchants; }
			set
			{
				if (value != _sleepInMerchants)
				{
					_sleepInMerchants = value;
					NotifyPropertyChanged("sleepInMerchants");
				}
			}
		}
		public string donateDetail
		{
			get { return _donateDetail; }
			set
			{
				if (value != _donateDetail)
				{
					_donateDetail = value;
					NotifyPropertyChanged("donateDetail");
				}
			}
		}
		public bool barterFlag
		{
			get { return _barterFlag; }
			set
			{
				if (value != _barterFlag)
				{
					_barterFlag = value;
					NotifyPropertyChanged("barterFlag");
				}
			}
		}
		public bool cashFlag
		{
			get { return _cashFlag; }
			set
			{
				if (value != _cashFlag)
				{
					_cashFlag = value;
					NotifyPropertyChanged("cashFlag");
				}
			}
		}
		public bool checkFlag
		{
			get { return _checkFlag; }
			set
			{
				if (value != _checkFlag)
				{
					_checkFlag = value;
					NotifyPropertyChanged("checkFlag");
				}
			}
		}
		public bool visamcFlag
		{
			get { return _visamcFlag; }
			set
			{
				if (value != _visamcFlag)
				{
					_visamcFlag = value;
					NotifyPropertyChanged("visamcFlag");
				}
			}
		}
		public bool discoverFlag
		{
			get { return _discoverFlag; }
			set
			{
				if (value != _discoverFlag)
				{
					_discoverFlag = value;
					NotifyPropertyChanged("discoverFlag");
				}
			}
		}
		public bool amexFlag
		{
			get { return _amexFlag; }
			set
			{
				if (value != _amexFlag)
				{
					_amexFlag = value;
					NotifyPropertyChanged("amexFlag");
				}
			}
		}

		#region Local Variables
		private int _merchantID;
		private int _regID;
		private string _businessName;
		private string _businessAddress;
		private string _businessPhone;
		private string _businessEmail;
		private string _description;
		private string _merchandise;
		private string _previous;
		private bool _sleepInMerchants;
		private string _donateDetail;
		private bool _barterFlag;
		private bool _cashFlag;
		private bool _checkFlag;
		private bool _visamcFlag;
		private bool _discoverFlag;
		private bool _amexFlag;
		#endregion



		public void LoadFromRdr(MySql.Data.MySqlClient.MySqlDataReader rdr)
		{
			_merchantID = DbAccess.GetIntFromRdr(rdr, "merchantID");
			_regID = DbAccess.GetIntFromRdr(rdr, "regID");
			_businessName = DbAccess.GetStringFromRdr(rdr, "businessName");
			_businessAddress = DbAccess.GetStringFromRdr(rdr, "businessAddress");
			_businessPhone = DbAccess.GetStringFromRdr(rdr, "businessPhone");
			_businessEmail = DbAccess.GetStringFromRdr(rdr, "businessEmail");
			_description = DbAccess.GetStringFromRdr(rdr, "description");
			_merchandise = DbAccess.GetStringFromRdr(rdr, "merchandise");
			_previous = DbAccess.GetStringFromRdr(rdr, "previous");
			_sleepInMerchants = DbAccess.GetBoolFromRdr(rdr, "sleepInMerchants");
			_donateDetail = DbAccess.GetStringFromRdr(rdr, "donateDetail");
			_barterFlag = DbAccess.GetBoolFromRdr(rdr, "barterFlag");
			_cashFlag = DbAccess.GetBoolFromRdr(rdr, "cashFlag");
			_checkFlag = DbAccess.GetBoolFromRdr(rdr, "checkFlag");
			_visamcFlag = DbAccess.GetBoolFromRdr(rdr, "visamcFlag");
			_discoverFlag = DbAccess.GetBoolFromRdr(rdr, "discoverFlag");
			_amexFlag = DbAccess.GetBoolFromRdr(rdr, "amexFlag");
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
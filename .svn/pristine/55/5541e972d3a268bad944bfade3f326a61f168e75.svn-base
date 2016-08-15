using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using RegData;
using System.Windows;
using log4net;
using DevExpress.Mvvm;

namespace RegMaint
{
	public class MainViewModel : INotifyPropertyChanged
	{
		private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


		public MainViewModel()
		{
			LoadDataCmd = new DelegateCommand<string>(LoadDataCmdExecute);
		}




		private RegDatabase _regDB;
		public RegDatabase regDB
		{
			get { return _regDB; }
			set
			{
				if (value != _regDB)
				{
					_regDB = value;
					NotifyPropertyChanged("regDB");
				}
			}
		}

		public string StatusMsg { get; set;  }



		public DelegateCommand<string> LoadDataCmd { get; private set; }
		public void LoadDataCmdExecute(string parameter)
		{
			MessageBox.Show("LoadDataCmdExecute=" + parameter);
		}


		private ObservableCollection<DevExpress.Xpf.Core.DXTabItem> _tabItems = null;
		public ObservableCollection<DevExpress.Xpf.Core.DXTabItem> TabItems
		{
			get
			{
				if (_tabItems == null)
				{
					_tabItems = new ObservableCollection<DevExpress.Xpf.Core.DXTabItem>();
					_tabItems.Add(new DevExpress.Xpf.Core.DXTabItem() { Content = new ucRegistrationGrid() { ViewModel = this }, Header = "RegList" });
					CurrentTabItem = _tabItems[0];
				}
				return _tabItems;

			}
		}


		private Dictionary<int, DevExpress.Xpf.Core.DXTabItem> tabList = new Dictionary<int, DevExpress.Xpf.Core.DXTabItem>();

		DevExpress.Xpf.Core.DXTabItem _currentTabItem = null;
		public DevExpress.Xpf.Core.DXTabItem CurrentTabItem
		{
			get
			{
				return _currentTabItem;
			}
			set
			{
				if (_currentTabItem != value)
				{
					_currentTabItem = value;
					NotifyPropertyChanged("CurrentTabItem");
				}
			}
		}

		public void OpenRegistration(Registration regData)
		{
			if (tabList.ContainsKey(regData.RegId))
			{
				CurrentTabItem = tabList[regData.RegId];
				tabList[regData.RegId].Focus();
				log.Info("OpenRegistration: Focus on tab for " + regData.FullName);
			}
			else
			{
				DevExpress.Xpf.Core.DXTabItem tab = new DevExpress.Xpf.Core.DXTabItem{ Header = string.Format("{0} {1}", regData.FirstName, regData.LastName), AllowHide = DevExpress.Utils.DefaultBoolean.True };
				_tabItems.Add(tab);
				tabList.Add(regData.RegId, tab);
				CurrentTabItem = tab;

				tab.Content = new ucRegData(regData, regDB.personData.Where( x => x.regID == regData.RegId).ToList());
				log.Info("OpenRegistration: Create new tab for " + regData.FullName);
			}
		}



		#region Database Access

		public void LoadLocal()
		{
			regDB = DbAccess.LoadLocal();
			//RegGridView.BestFitColumns();
			StatusMsg = "Data Loaded From Local Source";
		}

		public void LoadFromMySql()
		{
			try
			{
				regDB = DbAccess.LoadDatabase();
				//RegGridView.BestFitColumns();
				StatusMsg = "Data Loaded From MySql";
			}
			catch (Exception exc)
			{
				MessageBox.Show("Unable to access MySql server:" + exc.Message);
				log.Error("Failed to load from MySql", exc);
				StatusMsg = "Failed to load from MySql";
			}
		}

		#endregion


		#region PropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
			}
		}

		#endregion



		public List<RegOption> RegOptionList
		{
			get
			{
				return DbAccess.RegistrationOptionList;
			}
		}


	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RegData;

namespace RegMaint
{
	/// <summary>
	/// Interaction logic for ucRegistrationGrid.xaml
	/// </summary>
	public partial class ucRegistrationGrid : UserControl
	{
		public ucRegistrationGrid()
		{
			InitializeComponent();
			RegGrid.Loaded += RegGrid_Loaded;
		}

		void RegGrid_Loaded(object sender, RoutedEventArgs e)
		{
			RegGridView.BestFitColumns();
		}

		public MainViewModel ViewModel { get; set;  }


		private void RegGridView_RowDoubleClick(object sender, DevExpress.Xpf.Grid.RowDoubleClickEventArgs e)
		{
			if ( e.HitInfo.InRow )
			{
				FrameworkElement el = RegGridView.GetRowElementByRowHandle(e.HitInfo.RowHandle);
				Registration reg = ((el.DataContext as DevExpress.Xpf.Grid.RowData).Row as Registration);
				ViewModel.OpenRegistration(reg);
			}
		}


	}
}

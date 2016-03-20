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
	/// Interaction logic for ucRegData.xaml
	/// </summary>
	public partial class ucRegData : UserControl
	{
		public ucRegData(Registration regData, List<Person> personData)
		{
			InitializeComponent();
			this.DataContext = regData;
			dgPeople.ItemsSource = personData;
			cbeRegOption.ItemsSource = RegData.DbAccess.RegistrationOptionList;
		}

		private void BtnAttention_Click(object sender, RoutedEventArgs e)
		{
			Registration regData = (Registration)this.DataContext;
			regData.AttentionFlag = !regData.AttentionFlag;
		}
	}
}

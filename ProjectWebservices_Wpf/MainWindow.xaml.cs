using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ProjectWebservices_Wpf
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		LogfileService.LogfileServiceClient client = new LogfileService.LogfileServiceClient();
		public MainWindow()
		{
			InitializeComponent();
		}

		
	}
	struct Data
	{
		public DateTime Tid { get; set; }
		public string ID { get; set; }
		public string Alarm { get; set; }
		public string Navn { get; set; }
		public string Afdeling { get; set; }
		public string Bolig { get; set; }
		public DateTime Afmeldt { get; set; }
	}
}

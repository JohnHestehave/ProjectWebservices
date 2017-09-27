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
		List<Data> LogfileData;
		public MainWindow()
		{
			InitializeComponent();
			LogfileData = new List<Data>();
		}


		public void LoadData()
		{
			Thread thread = new Thread(()=> {
				LogfileService.Logfile[] data = client.ReadLogfiles();
				Dispatcher.Invoke(new UpdateDataGrid(UpdateDataGridMethod), (object)data);
			});
			thread.Start();
		}
		public delegate void UpdateDataGrid(LogfileService.Logfile[] data);
		public void UpdateDataGridMethod(LogfileService.Logfile[] data)
		{
			LogfileDataGrid.Items.Clear();
			LogfileDataGrid.Items.Refresh();
			foreach(LogfileService.Logfile d in data)
			{
				LogfileData.Add(new Data() { Tid = d.Tid, ID = d.ID, Alarm = d.Alarm, Navn = d.Navn, Afdeling = d.Afdeling, Bolig = d.Bolig, Afmeldt = d.Afmeldt});
			}
			LogfileDataGrid.ItemsSource = LogfileData;
		}

		private void LoadDataButton_Click(object sender, RoutedEventArgs e)
		{
			LoadData();
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

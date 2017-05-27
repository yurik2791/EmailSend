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
using System.Windows.Shapes;

namespace EmailApp
{
	/// <summary>
	/// Interaction logic for LogMail.xaml
	/// </summary>
	public partial class LogMail : Window
	{
		public LogMail()
		{
			InitializeComponent();
		}

		private void btnSign_Click(object sender, RoutedEventArgs e)
		{
			var main=new MainWindow(txtMail.Text, passwordBox.Password);
			main.Show();
			Close();
		}
	}
}

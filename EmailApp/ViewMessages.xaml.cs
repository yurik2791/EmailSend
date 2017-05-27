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
using S22.Imap;

namespace EmailApp
{
	/// <summary>
	/// Interaction logic for ViewMessages.xaml
	/// </summary>
	public partial class ViewMessages : Window
	{
		public ViewMessages(string email, string subject, string body)
		{
			InitializeComponent();

			lblFrom.Content = email;
			lblSubject.Content = subject;
			txtBody.Text = body;
		}
	}
}

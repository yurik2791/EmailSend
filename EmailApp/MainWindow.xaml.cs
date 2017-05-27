using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
using S22.Imap;

namespace EmailApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string _email;
		private readonly string _password;

		public MainWindow(string email, string password)
		{
			_email = email;
			_password = password;
			InitializeComponent();
			lblEmail.Content = _email;
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			MailAddress to = new MailAddress(txtTo.Text);
			MailAddress from = new MailAddress(_email);
			MailMessage mail = new MailMessage(from, to);

			mail.Subject = txtHeader.Text;
			mail.Body = new TextRange(rtbMessage.Document.ContentStart, rtbMessage.Document.ContentEnd).Text;

			SmtpClient smtp = new SmtpClient();
			smtp.Host = "smtp.gmail.com";
			smtp.Port = 587;

			smtp.Credentials = new NetworkCredential(_email, _password);
			smtp.EnableSsl = true;
			smtp.Send(mail);
		}

		private void button1_Click(object sender, RoutedEventArgs e)
		{
			using (var imapClient = new ImapClient("imap.gmail.com", 993, true))
			{
				imapClient.Login(_email, _password, AuthMethod.Login);
				var uids = imapClient.Search(SearchCondition.From("tat.draganova@gmail.com"));
				var messages = imapClient.GetMessages(uids);
				var msg = (from m in messages select new {m.From, m.Subject, m.Body}).ToList();
				foreach (var message in msg)
				{
					string mail = message.From.ToString();
					string subject = message.Subject;
					string body = message.Body;
					var dGmsg = new ViewMessages(mail, subject, body);
					dGmsg.Show();
				}


			}
		}
	}
}

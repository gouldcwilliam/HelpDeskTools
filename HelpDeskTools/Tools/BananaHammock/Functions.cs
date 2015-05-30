using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using System.IO;
using System.Net.NetworkInformation;
using System.Threading;
using System.Net.Mail;
using System.Web;

using BananaHammock.Properties;
using LDAP;

namespace BananaHammock
{
	/// <summary>
	/// 
	/// </summary>
	public static class Functions
	{
		/// <summary>
		/// Adds store to
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static List<string> GetComputerList(string[] args)
		{
			List<string> value = new List<string>();
			if (args.Count() == 0) { return value; }

			for (int i = 0; i < args.Count(); i++)
			{
				value.Add(args[i]);
			}
			Console.WriteLine();
			return value;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="computer"></param>
		/// <returns></returns>
		public static bool CheckNetwork(string computer)
		{
			try
			{
				int echo = 0;
				for (int i = 0; i < 6; i++)
				{

					Ping ping = new Ping();
					byte[] buffer = new byte[32];
					int timeout = 1000;
					PingOptions options = new PingOptions();
					PingReply reply = ping.Send(computer, timeout, buffer, options);
					if (reply.Status == IPStatus.Success)
					{
						echo++;
					}
				}
				if (echo >= 3) { return true; }
				return false;
			}
			catch (Exception)
			{
				return false;
			}
		}



		public static bool CopyFile(string ComputerName)
		{
			
			try
			{
				string Destination = string.Format(@"\\{0}\C$\{1}", ComputerName, Shared.Settings.Default._TempFile.Substring(3));
				//Console.WriteLine(Destination);
				File.Copy(Shared.Settings.Default._TempFile, Destination, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}
	
		public static bool WriteFile(string Contents)
		{
			try { File.WriteAllText(Shared.Settings.Default._TempFile, Contents); }
			catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
			return true;
		}

		public static bool PlaceCerts(string Computer)
		{
			try
			{
				string Cert1 = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\global.cer";
				string Cert2 = @"\\wwwint\roc\IS-Share\Helpdesk\Retail Helpdesk\Software\verisign-root.cer";
				string Destination1 = string.Format(@"\\{0}\C$\Temp\global.cer", Computer);
				string Destination2 = string.Format(@"\\{0}\C$\Temp\verisign-root.cer", Computer);
				File.Copy(Cert1, Destination1, true);
				File.Copy(Cert2, Destination2, true);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			return true;
		}

		public static int i_ExecuteCommand(string ExecutableFile, bool Interactive, string Arguments, bool Wait)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = ExecutableFile;
			startInfo.Arguments = Arguments;
			startInfo.CreateNoWindow = (!Interactive);
			startInfo.UseShellExecute = Interactive;
			Process process = Process.Start(startInfo);
			if (Wait) { process.WaitForExit(); return process.ExitCode; }
			return 0;
		}








		/// <summary>
		/// Send mail using WWINC Domain settings
		/// </summary>
		/// <param name="From">Sender</param>
		/// <param name="To">Receiver</param>
		/// <param name="Subject">Subject of message</param>
		/// <param name="Body">Body of message</param>
		/// <param name="Attachments">List of files to attach</param>
		/// <param name="HTML">Boolean to enable HTML in body</param>
		/// <returns>on success</returns>
		public static bool SendMail(string From, string To, string Subject, string Body, string[] Attachments, bool HTML)
		{
			// new mail message container
			MailMessage message = new MailMessage(From, To);
			// add subject line
			message.Subject = Subject;
			// add body
			message.Body = Body;
			// use HTML in body
			message.IsBodyHtml = HTML;
			//
			message.ReplyToList.Add("ITRetailHelpdeskDL@wwwinc.com");
			// add attachments
			foreach (string path in Attachments)
			{
				if (File.Exists(path))
				{
					message.Attachments.Add(new Attachment(path));
				}
			}
			// our domain specific settings
			System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("wwwsmtp.wwwint.corp", 25);
			// use network credentials
			client.UseDefaultCredentials = true;


			try { client.Send(message); }
			catch { return false; }
			return true;
		}
		/// <summary>
		/// Send mail using WWINC Domain settings
		/// </summary>
		/// <param name="From">Sender</param>
		/// <param name="To">Receiver</param>
		/// <param name="Subject">Subject of message</param>
		/// <param name="Body">Body of message</param>
		/// <param name="Attachments">List of files to attach</param>
		/// <returns></returns>
		public static bool SendMail(string From, string To, string Subject, string Body, string[] Attachments)
		{
			return SendMail(From, To, Subject, Body, Attachments, false);
		}
		/// <summary>
		/// Send mail using WWINC Domain settings
		/// </summary>
		/// <param name="From">Sender</param>
		/// <param name="To">Receiver</param>
		/// <param name="Subject">Subject of message</param>
		/// <param name="Body">Body of message</param>
		/// <param name="HTML">Boolean to enable HTML in body</param>
		/// <returns>on success</returns>
		public static bool SendMail(string From, string To, string Subject, string Body, bool HTML)
		{
			return SendMail(From, To, Subject, Body, new string[] { }, HTML);
		}
		/// <summary>
		/// Send mail using WWINC Domain settings
		/// </summary>
		/// <param name="From">Sender</param>
		/// <param name="To">Receiver</param>
		/// <param name="Subject">Subject of message</param>
		/// <param name="Body">Body of message</param>
		/// <param name="Attachment">file to attach</param>
		/// <returns>on success</returns>
		public static bool SendMail(string From, string To, string Subject, string Body, string Attachment)
		{
			return SendMail(From, To, Subject, Body, new string[] { Attachment }, false);
		}
		/// <summary>
		/// Send mail using WWINC Domain settings
		/// </summary>
		/// <param name="From">Sender</param>
		/// <param name="To">Receiver</param>
		/// <param name="Subject">Subject of message</param>
		/// <param name="Body">Body of message</param>
		/// <returns>on success</returns>
		public static bool SendMail(string From, string To, string Subject, string Body)
		{
			return SendMail(From, To, Subject, Body, new string[] { }, false);
		}

	}
}

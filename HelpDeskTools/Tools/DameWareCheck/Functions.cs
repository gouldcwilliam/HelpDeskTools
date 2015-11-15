using System;
using System.Collections.Generic;
using System.Linq;

using System.IO;
using System.Net.NetworkInformation;
using System.Net.Mail;

namespace DameWareCheck
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
		public static List<string> GetIgnoreList(string[] args)
		{
			List<string> value = new List<string>();
			if (args.Count() == 0) { return value; }

			Console.Write("Stores to ignore: ");
			for (int i = 0; i < args.Count(); i++)
			{
				string add = string.Empty;
				int store = 0;

				if (int.TryParse(args[i].Trim(), out store))
				{
					add = store.ToString() + "SAP";
					if (add.Length < 7) { add = "0" + add; }
					Console.Write(add + " ");
					value.Add(add);
				}
			}
			Console.WriteLine();
			return value;
		}

		/// <summary>
		/// search the computer for DameWare install
		/// </summary>
		/// <param name="computer"></param>
		/// <returns></returns>
        public static bool FindDameWare(string computer)
        {
            try
            {
                return System.IO.Directory.Exists(
                    string.Format(@"\\{0}\C$\Windows\dwrcs", computer));
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); return false; }
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

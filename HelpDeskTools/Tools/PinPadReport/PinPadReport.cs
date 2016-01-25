using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using PinPadReport.Properties;
namespace PinPadReport
{
	class PinPadReport
	{
		static void Main(string[] args)
		{
			string body = Settings.Default.header;
			body += "Calls for VeriFone reboots and/or power cycles from: ";
			body += System.DateTime.Today.AddDays(-7.0).ToShortDateString() + " - " + System.DateTime.Today.AddDays(-1.0).ToShortDateString();
			body += "<br /><br />TOTAL CALLS: " + Shared.SQL.Select(Settings.Default.query_count).Rows[0][0].ToString();
			body += Settings.Default.tableHead;


			DataTable dt;
			for (int i = -7; i < 0; i++)
			{
				dt = Shared.SQL.Select(Settings.Default.query_calls, new System.Data.SqlClient.SqlParameter("@D", i));
				body += string.Format(Settings.Default.row, dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString());
				Console.WriteLine(dt.Rows[0][0].ToString() + " | " + dt.Rows[0][1].ToString());
			}


			body += Settings.Default.footer;


			Console.WriteLine("Mail Sent: {0}", Shared.Functions.b_SendEmail(Settings.Default.to, body, Settings.Default.subject));
			Console.ReadKey();
		}
	}
}

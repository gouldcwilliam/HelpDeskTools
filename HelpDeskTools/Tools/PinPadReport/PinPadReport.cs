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
			body += Settings.Default.tableHead;

			DataTable dt = Shared.SQL.Select(Settings.Default.query);
			
			foreach (DataRow r in dt.Rows)
			{
				body += string.Format(Settings.Default.row, r[0], r[1]);
			}
			
			body += Settings.Default.footer;

			Shared.Functions.b_SendEmail(Settings.Default.to, body, Settings.Default.subject);
		}
	}
}

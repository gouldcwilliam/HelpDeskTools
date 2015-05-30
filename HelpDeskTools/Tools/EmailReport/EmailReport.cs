using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmailReport
{
	class EmailReport
	{
		static void Main(string[] args)
		{
			string body = Settings.Default.header;
			
			DataTable dt = Shared.SQL.Select(Settings.Default.select_techs_calls);
			string rows = string.Empty;
			foreach (DataRow r in dt.Rows)
			{
				rows += string.Format(Settings.Default.row_tech, r[0], r[1]);
			}
			body += string.Format(Settings.Default.table_tech, rows);

			DataRow dr = Shared.SQL.Select(Settings.Default.select_total_calls).Rows[0];
			body += string.Format(Settings.Default.table_total, dr[0]);
	
			body += Settings.Default.footer;

			Shared.Functions.b_SendEmail(Settings.Default.to, body, Settings.Default.subject);
		}
	}
}

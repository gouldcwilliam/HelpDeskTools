using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace B9Weekly
{
	class B9Weekly
	{
		static void Main(string[] args)
		{
			Shared.SQL.conn = new SqlConnection("server=retb9sp02;database=das;Integrated Security=true");
			string body = Properties.Settings.Default.header;

			DataTable dt = Shared.SQL.Select(Properties.Settings.Default.sql);
			string rows = string.Empty;
			foreach (DataRow r in dt.Rows)
			{
				rows += string.Format(Properties.Settings.Default.row, r[0], r[1], r[2], r[3], r[4], r[5], r[6], r[7]);
			}

			body += string.Format(Properties.Settings.Default.table, rows);

			body += Properties.Settings.Default.footer;

			Shared.Functions.SendEmail(Properties.Settings.Default.to, body, "Bit9 Weekly Report");
		}
	}
}

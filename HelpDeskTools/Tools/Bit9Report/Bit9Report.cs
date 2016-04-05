using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
namespace Bit9Report
{
    class Bit9Report
    {
        static void Main(string[] args)
        {
            Shared.SQL.conn = new SqlConnection("server=retb9sp02;database=das;Integrated Security=true");
            string body = Settings.Default.header;

            DataTable dt = Shared.SQL.Select(Settings.Default.ahcSelect);
            string rows = string.Empty;
            foreach (DataRow r in dt.Rows)
            {
                rows += string.Format(Settings.Default.ahcRow, r[0], r[1], r[2], r[3], r[4]);
            }

            body += string.Format(Settings.Default.ahcTable, rows);
            rows = string.Empty;
            dt = Shared.SQL.Select(Settings.Default.ebSelect);
            foreach (DataRow r in dt.Rows)
            {
                rows += string.Format(Settings.Default.ebRow, r[0], r[1], r[2], r[3], r[4], r[5]);
            }

            body += string.Format(Settings.Default.ebTable, rows);

            body += Settings.Default.footer;

            List<string> to = new List<string>();

            Shared.Functions.SendEmail(Settings.Default.to, body, "Bit9 Daily Report");
        }
    }
}

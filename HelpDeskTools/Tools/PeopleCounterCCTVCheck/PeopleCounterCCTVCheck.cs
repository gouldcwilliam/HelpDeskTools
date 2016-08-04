using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Shared;

namespace PeopleCounterCCTVCheck
{
    class PeopleCounterCCTVCheck
    {
        static void Main(string[] args)
        {
            string start = DateTime.Now.ToString();
            Console.WriteLine("Job started at: " + start);

            string body = Properties.Settings.Default.header;
            body += start + "<br>";
            body += Properties.Settings.Default.tableHead;
            
            #region Sensormatics

            List<string> exclusions = new List<string>();
            exclusions.AddRange(Properties.Settings.Default.ignoreSensors.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            //exclusions.AddRange(Functions.GetIgnoreList(exclude));

            List<IPInfo> listIPInfo = new List<IPInfo>();
            System.Data.DataTable dt = Shared.SQL.Select("SELECT [store], [1st], [2nd], [3rd], [lan2], [gate2] FROM [Stores] WHERE [open] = 1 AND [store] < 1000");
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                string prefix = dr["1st"].ToString() + "." + dr["2nd"].ToString() + "." + dr["3rd"].ToString();
                string sensorIP = prefix + "." + dr["lan2"].ToString();
                string sensorGate = prefix + "." + dr["gate2"].ToString();
                listIPInfo.Add(new IPInfo(dr["store"].ToString(), sensorIP, sensorGate));
            }
            foreach (string store in exclusions) { listIPInfo.RemoveAll(x => x.Store == store); }
            foreach (IPInfo ipInfo in listIPInfo)
            {
                if (!Functions.CheckNetwork(ipInfo.IP)) { body+=string.Format(Properties.Settings.Default.body,ipInfo.Store,"Sensormatic",ipInfo.IP,""); }
                //else { body += string.Format(Properties.Settings.Default.body, ipInfo.Store, "Sensormatic", ipInfo.IP, "Currently Up"); }
                if (!Functions.CheckNetwork(ipInfo.Gate)) { body += string.Format(Properties.Settings.Default.body, ipInfo.Store, "Sensormatic Gate", ipInfo.Gate, ""); }
                //else { body += string.Format(Properties.Settings.Default.body, ipInfo.Store, "Sensormatic Gate", ipInfo.Gate, "Currently Up"); }
            }

            #endregion

            #region CCTVs

            exclusions = new List<string>();
            exclusions.AddRange(Properties.Settings.Default.ignoreCCTVs.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
            //exclusions.AddRange(Functions.GetIgnoreList(excludes));

            listIPInfo = new List<IPInfo>();
            dt = Shared.SQL.Select("SELECT [store], [1st], [2nd], [3rd], [gate2], [cctv] FROM [Stores] WHERE [open] = 1 AND NOT [cctv] IS NULL");
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                string Gate = dr["1st"].ToString() + "." + dr["2nd"].ToString() + "." + dr["3rd"].ToString() + "." + dr["gate2"].ToString();
                listIPInfo.Add(new IPInfo(dr["store"].ToString(), dr["cctv"].ToString(), Gate));
            }
            foreach(string store in exclusions) { listIPInfo.RemoveAll(x => x.Store == store); }
            foreach(IPInfo ipInfo in listIPInfo)
            {
                if (!Functions.CheckNetwork(ipInfo.IP))
                {
                    if (!Functions.CheckNetwork(ipInfo.IP))
                    {
                        if (!Functions.CheckNetwork(ipInfo.IP))
                        {
                            if (!Functions.CheckNetwork(ipInfo.IP))
                            {
                                if (!Functions.CheckNetwork(ipInfo.IP))
                                {
                                    body += string.Format(Properties.Settings.Default.body, ipInfo.Store, "CCTV", ipInfo.IP, "");
                                }
                            }
                        }
                    }
                }
                //else { body += string.Format(Properties.Settings.Default.body, ipInfo.Store, "CCTV", ipInfo.IP, "Currently Up"); }
                if (!Functions.CheckNetwork(ipInfo.Gate))
                {
                    if (!Functions.CheckNetwork(ipInfo.Gate))
                    {
                        if (!Functions.CheckNetwork(ipInfo.Gate))
                        {
                            if (!Functions.CheckNetwork(ipInfo.Gate))
                            {
                                if (!Functions.CheckNetwork(ipInfo.Gate))
                                {
                                    body += string.Format(Properties.Settings.Default.body, ipInfo.Store, "CCTV Gate", ipInfo.Gate, "");
                                }
                            }
                        }
                    }
                }
                
                //else { body += string.Format(Properties.Settings.Default.body, ipInfo.Store, "CCTV Gate", ipInfo.Gate, "Currently Up"); }
            }

            #endregion
            body += Properties.Settings.Default.footer;
            body += DateTime.Now.ToString();
            Console.Write("\n * Sending email : ");

            if (Functions.SendMail(Properties.Settings.Default.from, Properties.Settings.Default.to, Properties.Settings.Default.subject, body, true))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Sent");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Failed!");
            }

            //Console.ReadKey();
        }
    }

    class IPInfo
    {
        public string Store;
        public string IP;
        public string Gate;
        public string CCTV;

        public IPInfo(string store, string ip, string gate)
        {
            Store = store;
            IP = ip;
            Gate = gate;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retail_HD.Classes
{
    /// <summary>
    /// Current users call queue status object
    /// </summary>
    public class AgentStatus
    {
        /// <summary>
        /// name
        /// </summary>
        public string AgentName { get; set; }
        /// <summary>
        /// ACD
        /// </summary>
        public int AgentID { get; set; }
        /// <summary>
        /// call status
        /// </summary>
        public CiscoFinesseNET.UserState CurrentStatus { get; set; }
        /// <summary>
        /// derp
        /// </summary>
        public DateTime TimeStatusChanged { get; set; }
        /// <summary>
        /// holder 1
        /// </summary>
        public string Information1 { get; set; }
        /// <summary>
        /// holder 2
        /// </summary>
        public string Information2 { get; set; }
        /// <summary>
        /// domain user account
        /// </summary>
        public string LoginName { get; set; }
        /// <summary>
        /// create new AgentStatus object
        /// </summary>
        public AgentStatus()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Row"></param>
        public AgentStatus(System.Windows.Forms.DataGridViewRow Row)
        {
            try
            {
                AgentName = Row.Cells["Name"].Value.ToString();
                int id = 0;
                if (int.TryParse(Row.Cells["Information2"].Value.ToString(), out id)) { AgentID = id; } else { AgentID = 0; }
                CurrentStatus = (CiscoFinesseNET.UserState)Enum.Parse(typeof(CiscoFinesseNET.UserState), Row.Cells["CurrentStatus"].Value.ToString());
                //Console.WriteLine(CurrentStatus);
                TimeStatusChanged = (DateTime)Row.Cells["TimeStatusChanged"].Value;
                Information1 = Row.Cells["Information1"].Value.ToString();
                Information2 = Row.Cells["Information2"].Value.ToString();
                LoginName = Row.Cells["login"].Value.ToString();
            }
            catch(Exception) {; }
        }
    }

}

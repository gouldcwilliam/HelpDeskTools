using System;

namespace CiscoFinesseNET
{
	public class AgentStatus
    {
        public string AgentName { get; set; }
        public int AgentID { get; set; }
        public CiscoFinesseNET.UserState CurrentStatus { get; set; }
        public DateTime TimeStatusChanged { get; set; }
        public string Information1 { get; set; }
        public string Information2 { get; set; }
        public string LoginName { get; set; }
        public string statusSince 
        {
            get
            {
                if (CurrentStatus == CiscoFinesseNET.UserState.LOGOUT) return string.Format("{0} since {1} on {2}", CurrentStatus.ToString(), TimeStatusChanged.ToShortTimeString(), TimeStatusChanged.ToShortDateString());
                else return string.Format("{0} since {1}", CurrentStatus.ToString(), TimeStatusChanged.ToShortTimeString());
            }
        }

        public AgentStatus()
        {

        }
    }
}
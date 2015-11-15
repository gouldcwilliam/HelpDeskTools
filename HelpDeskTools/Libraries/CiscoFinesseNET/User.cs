using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CiscoFinesseNET
{
	public class User
    {
        public string uri { get; set; }
        [XmlIgnore]
        public Role role { get; private set; }
        [XmlIgnore]
        private string[] _r;
        [XmlArrayItemAttribute("role")]
        public string[] roles
        {
            get { return _r; }
            set
            {
                if (value.Length > 1)
                {
                    role = ((Role)Enum.Parse(typeof(Role), value[0]) | (Role)Enum.Parse(typeof(Role), value[1]));
                    _r = value;
                }
                else
                {
                    role = (Role)Enum.Parse(typeof(Role), value[0]);
                    _r = value;
                }
            }
        }
        public string loginId { get; set; }
        public string loginName { get; set; }
        public UserState state { get; set; }
        public string stateChangeTime { get; set; }
        //[XmlIgnore]
        //public UserState pendState;
        public string pendingState { get; set; }
        public ReasonCode reasonCode { get; set; }
        public UserSettings settings { get; set; }
        public string reasonCodeId { get; set; }
        public string extension { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string teamId { get; set; }
        public string teamName { get; set; }
        public string dialogs { get; set; }
        public List<Team> teams { get; set; }

        //lists
        public Dialogs _dialogList { get; set; }
        public Queues _queueList { get; set; }
    }

    [Flags]
    public enum Role
    {
        Agent = 1,
        Supervisor = 1 << 1
    }

    public enum UserState
    {
        LOGOUT,
        NOT_READY,
        READY,
        RESERVED,
        RESERVED_OUTBOUND,
        RESERVED_OUTBOUND_PREVIEW,
        TALKING,
        HOLD,
        WORK,
        WORK_READY,
        UNKNOWN
    }

    //removed for ease of Reflection
    //public enum WrapUpOnIncoming
    //{
    //    REQUIRED,
    //    OPTIONAL,
    //    NOT_ALLOWED,
    //    REQUIRED_WITH_WRAP_UP_DATA
    //}

    public class UserSettings
    {
        public string wrapUpOnIncoming { get; set; }
    }
}

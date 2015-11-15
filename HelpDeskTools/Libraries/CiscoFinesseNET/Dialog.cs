using System;
using System.Collections.Generic;

namespace CiscoFinesseNET
{
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Dialogs
    {

        private DialogsDialog[] dialogField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Dialog")]
        public DialogsDialog[] Dialog
        {
            get
            {
                return this.dialogField;
            }
            set
            {
                this.dialogField = value;
            }
        }
    }

    //public class DialogsDialog
    //{
    //    public string id { get; set; }
    //    public string uri { get; set; }
    //    public string associatedDialogUri { get; set; }
    //    //public MediaType mediaType { get; set; }
    //    public string mediaType { get; set; }
    //    //public DialogState state { get; set; }
    //    public string state { get; set; }
    //    public string fromAddress { get; set; }
    //    public string toAddress { get; set; }
    //    public MediaProperties mediaProperties { get; set; }
    //    private DialogsDialogParticipant[] participantsField;
    //    [System.Xml.Serialization.XmlArrayItemAttribute("Participant", IsNullable = false)]
    //    public DialogsDialogParticipant[] participants
    //    {
    //        get
    //        {
    //            return this.participantsField;
    //        }
    //        set
    //        {
    //            this.participantsField = value;
    //        }
    //    }

    //}
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DialogsDialog
    {

        private string associatedDialogUriField;

        private string fromAddressField;

        private string idField;

        private MediaProperties mediaPropertiesField;

        private string mediaTypeField;

        private DialogsDialogParticipant[] participantsField;

        private string stateField;

        private string toAddressField;

        private string uriField;

        /// <remarks/>
        public string associatedDialogUri
        {
            get
            {
                return this.associatedDialogUriField;
            }
            set
            {
                this.associatedDialogUriField = value;
            }
        }

        /// <remarks/>
        public string fromAddress
        {
            get
            {
                return this.fromAddressField;
            }
            set
            {
                this.fromAddressField = value;
            }
        }

        /// <remarks/>
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public MediaProperties mediaProperties
        {
            get
            {
                return this.mediaPropertiesField;
            }
            set
            {
                this.mediaPropertiesField = value;
            }
        }

        /// <remarks/>
        public string mediaType
        {
            get
            {
                return this.mediaTypeField;
            }
            set
            {
                this.mediaTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Participant", IsNullable = false)]
        public DialogsDialogParticipant[] participants
        {
            get
            {
                return this.participantsField;
            }
            set
            {
                this.participantsField = value;
            }
        }

        /// <remarks/>
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string toAddress
        {
            get
            {
                return this.toAddressField;
            }
            set
            {
                this.toAddressField = value;
            }
        }

        /// <remarks/>
        public string uri
        {
            get
            {
                return this.uriField;
            }
            set
            {
                this.uriField = value;
            }
        }
    }

    public enum MediaType
    {
        Voice,
        Email,
        Chat
    }

    public enum DialogState
    {
        INITIATING,
        INITIATED,
        ALTERTING,
        ACTIVE,
        FAILED,
        DROPPED,
        ACCEPTED
    }

    public enum ParticipantState
    {
        INITIATING,
        INITIATED,
        ALERTING,
        ACTIVE,
        FAILED,
        HELD,
        DROPPED,
        WRAP_UP,
        ACCEPTED
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class MediaProperties
    {
        private string dNISField;

        private CallType callTypeField;

        private string dialedNumberField;

        private string outboundClassificationField;

        private CallVariable[] callvariablesField;

        private string wrapUpReasonField;

        public string wrapUpReason
        {
            get
            {
                return this.wrapUpReasonField;
            }
            set
            {
                this.wrapUpReasonField = value;
            }
        }

        /// <remarks/>
        public string DNIS
        {
            get
            {
                return this.dNISField;
            }
            set
            {
                this.dNISField = value;
            }
        }

        /// <remarks/>
        public CallType callType
        {
            get
            {
                return this.callTypeField;
            }
            set
            {
                this.callTypeField = value;
            }
        }

        /// <remarks/>
        public string dialedNumber
        {
            get
            {
                return this.dialedNumberField;
            }
            set
            {
                this.dialedNumberField = value;
            }
        }

        /// <remarks/>
        public string outboundClassification
        {
            get
            {
                return this.outboundClassificationField;
            }
            set
            {
                this.outboundClassificationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("CallVariable", IsNullable = false)]
        public CallVariable[] callvariables
        {
            get
            {
                return this.callvariablesField;
            }
            set
            {
                this.callvariablesField = value;
            }
        }
        //public string dialedNumber { get; set; }
        //public CallType callType { get; set; }
        //public string DNIS { get; set; }
        //public string wrapUpReason { get; set; }
        ////[System.Xml.Serialization.XmlArrayItemAttribute("CallVariable", IsNullable=false)]
        ////public CallVariable[] callVariables { get; set; }
        ////public List<CallVariable> callVariables { get; set; }
    }

    public enum CallType
    {
        ACD_IN,
        PREROUTE_ACD_IN,
        PREROUTE_DIRECT_AGENT,
        TRANSFER,
        OTHER_IN,
        OUT,
        AGENT_INSIDE,
        CONSULT,
        CONFERENCE,
        SUPERVISOR_MONITOR,
        OUTBOUND,
        OUTBOUND_PREVIEW,
        OUTBOUND_CALLBACK,
        OUTBOUND_CALLBACK_PREVIEW,
        OUTBOUND_PERSONAL_CALLBACK,
        OUTBOUND_PERSONAL_CALLBACK_PREVIEW,
        OUTBOUND_DIRECT_PREVIEW
    }

    public enum ParticpantCause
    {
        BUSY,
        BAD_DESTINATION,
        OTHER
    }

    //public struct CallVariable
    //{
    //    public string name { get; set; }
    //    public string value { get; set; }
    //}

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class CallVariable
    {

        private string nameField;

        private string valueField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    public class Participant
    {
        //[System.Xml.Serialization.XmlIgnore]
        //public Actions _action { get; set; }
        //private string[] _actions;
        //public string[] actions
        //{
        //    get
        //    {
        //        return _actions;
        //    }
        //    set
        //    {
        //        _actions = value;
        //        if (value.Length > 1)
        //        {
        //            foreach (string _a in value)
        //            {
        //                _action = _action | ((Actions)Enum.Parse(typeof(Actions), _a));
        //            }
        //        }
        //        else
        //        {
        //            _action = (Actions)Enum.Parse(typeof(Actions), value[0]);
        //        }
        ////                public string[] roles
        ////{
        ////    get { return _r; }
        ////    set
        ////    {
        ////        if (value.Length > 1)
        ////        {
        ////            role = ((Role)Enum.Parse(typeof(Role), value[0]) | (Role)Enum.Parse(typeof(Role), value[1]));
        ////            _r = value;
        ////        }
        ////        else
        ////        {
        ////            role = (Role)Enum.Parse(typeof(Role), value[0]);
        ////            _r = value;
        ////        }
        ////    }
        ////}
        //    }
        //}
        [System.Xml.Serialization.XmlArrayItemAttribute("action", IsNullable=false)]
        public string[] actions { get; set; }
        public string mediaAddress { get; set; }
        public string mediaAddressType { get; set; }
        public string startTime { get; set; }
        //public ParticipantState state { get; set; }
        //public ParticpantCause stateCause { get; set; }
        public string stateChangeTime { get; set; }

        public static List<Actions> ConvertIntToActionsList(Actions action)
        {
            int actionInit = Convert.ToInt32(action);

            List<Actions> retval = new List<Actions>();

            if ((action & Actions.MAKE_CALL) == Actions.MAKE_CALL)
            {
                retval.Add(Actions.MAKE_CALL);
            }

            if ((action & Actions.ANSWER) == Actions.ANSWER)
            {
                retval.Add(Actions.ANSWER);
            }

            if ((action & Actions.HOLD) == Actions.HOLD)
            {
                retval.Add(Actions.HOLD);
            }

            if ((action & Actions.RETRIEVE) == Actions.RETRIEVE)
            {
                retval.Add(Actions.RETRIEVE);
            }

            if ((action & Actions.DROP) == Actions.DROP)
            {
                retval.Add(Actions.DROP);
            }

            if ((action & Actions.UPDATE_CALL_DATA) == Actions.UPDATE_CALL_DATA)
            {
                retval.Add(Actions.UPDATE_CALL_DATA);
            }

            if ((action & Actions.SEND_DTMF) == Actions.SEND_DTMF)
            {
                retval.Add(Actions.SEND_DTMF);
            }

            if ((action & Actions.CONSULT_CALL) == Actions.CONSULT_CALL)
            {
                retval.Add(Actions.CONSULT_CALL);
            }

            if ((action & Actions.CONFERENCE) == Actions.CONFERENCE)
            {
                retval.Add(Actions.CONFERENCE);
            }

            if ((action & Actions.TRANSFER) == Actions.TRANSFER)
            {
                retval.Add(Actions.TRANSFER);
            }

            if ((action & Actions.TRANSFER_SST) == Actions.TRANSFER_SST)
            {
                retval.Add(Actions.TRANSFER_SST);
            }

            if ((action & Actions.SILENT_MONITOR) == Actions.SILENT_MONITOR)
            {
                retval.Add(Actions.SILENT_MONITOR);
            }

            if ((action & Actions.BARGE_CALL) == Actions.BARGE_CALL)
            {
                retval.Add(Actions.BARGE_CALL);
            }

            if ((action & Actions.PARTICIPANT_DROP) == Actions.PARTICIPANT_DROP)
            {
                retval.Add(Actions.PARTICIPANT_DROP);
            }

            if ((action & Actions.START_RECORDING) == Actions.START_RECORDING)
            {
                retval.Add(Actions.START_RECORDING);
            }

            if ((action & Actions.UPDATE_SCHEDULED_CALLBACK) == Actions.UPDATE_SCHEDULED_CALLBACK)
            {
                retval.Add(Actions.UPDATE_SCHEDULED_CALLBACK);
            }

            if ((action & Actions.CANCEL_SHCEDULED_CALLBACK) == Actions.CANCEL_SHCEDULED_CALLBACK)
            {
                retval.Add(Actions.CANCEL_SHCEDULED_CALLBACK);
            }

            return retval;
        }
    }

    [Flags]
    public enum Actions
    {
        MAKE_CALL = 1,
        ANSWER = 1 << 1,
        HOLD = 1 << 2,
        RETRIEVE = 1 << 3,
        DROP = 1 << 4,
        UPDATE_CALL_DATA = 1 << 5,
        SEND_DTMF = 1 << 6,
        CONSULT_CALL = 1 << 7,
        CONFERENCE = 1 << 8,
        TRANSFER = 1 << 9,
        TRANSFER_SST = 1 << 10,
        SILENT_MONITOR = 1 << 11,
        BARGE_CALL = 1 << 12,
        PARTICIPANT_DROP = 1 << 13,
        START_RECORDING = 1 << 14,
        UPDATE_SCHEDULED_CALLBACK = 1 << 15,
        CANCEL_SHCEDULED_CALLBACK = 1 << 16
    }

    public class ScheduledCallbackInfo
    {
        public string callbackTime { get; set; }
        public string callbackNumber { get; set; }
    }

    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class DialogsDialogParticipant
    {

        private string[] actionsField;

        private string mediaAddressField;

        private string mediaAddressTypeField;

        private System.DateTime startTimeField;

        private string stateField;

        private string stateCauseField;

        private System.DateTime stateChangeTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("action", IsNullable = false)]
        public string[] actions
        {
            get
            {
                return this.actionsField;
            }
            set
            {
                this.actionsField = value;
            }
        }

        /// <remarks/>
        public string mediaAddress
        {
            get
            {
                return this.mediaAddressField;
            }
            set
            {
                this.mediaAddressField = value;
            }
        }

        /// <remarks/>
        public string mediaAddressType
        {
            get
            {
                return this.mediaAddressTypeField;
            }
            set
            {
                this.mediaAddressTypeField = value;
            }
        }

        /// <remarks/>
        public System.DateTime startTime
        {
            get
            {
                return this.startTimeField;
            }
            set
            {
                this.startTimeField = value;
            }
        }

        /// <remarks/>
        public string state
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public string stateCause
        {
            get
            {
                return this.stateCauseField;
            }
            set
            {
                this.stateCauseField = value;
            }
        }

        /// <remarks/>
        public System.DateTime stateChangeTime
        {
            get
            {
                return this.stateChangeTimeField;
            }
            set
            {
                this.stateChangeTimeField = value;
            }
        }
    }
}

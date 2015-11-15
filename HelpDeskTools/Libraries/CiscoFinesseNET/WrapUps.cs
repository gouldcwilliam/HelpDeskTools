namespace CiscoFinesseNET
{

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class WrapUpReasons
    {
        private WrapUpReason[] wrapUpReasonField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("WrapUpReason")]
        public WrapUpReason[] WrapUpReason
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
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class WrapUpReason
    {
        public override string ToString()
        {
            return label;
        }

        private string uriField;

        private string labelField;

        private string forAllField;

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

        /// <remarks/>
        public string label
        {
            get
            {
                return this.labelField;
            }
            set
            {
                this.labelField = value;
            }
        }

        /// <remarks/>
        public string forAll
        {
            get
            {
                return this.forAllField;
            }
            set
            {
                this.forAllField = value;
            }
        }
    }


}

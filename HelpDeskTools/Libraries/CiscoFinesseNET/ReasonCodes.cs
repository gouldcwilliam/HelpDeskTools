namespace CiscoFinesseNET
{

	/// <remarks/>
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ReasonCodes
    {

        private ReasonCode[] reasonCodeField;

        private string categoryField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReasonCode")]
        public ReasonCode[] ReasonCode
        {
            get
            {
                return this.reasonCodeField;
            }
            set
            {
                this.reasonCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ReasonCode
    {

        private string uriField;

        private string categoryField;

        private int codeField;

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
        public string category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        public int code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
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

        public override string ToString()
        {
            return this.labelField;
        }
    }


}

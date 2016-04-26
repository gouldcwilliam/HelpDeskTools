namespace LDAP
{
	/// <summary>
	/// Provides container for LDAP Attribute Value pairs
	/// </summary>
	public class Result
	{
		/// <summary>
		/// Initializes a new instance of the LDAP.Property class using the specified
		/// attribute and value
		/// </summary>
		/// <param name="Attribute">Name of LDAP attribute</param>
		/// <param name="Value">Value of LDAP attribute</param>
		public Result(string Attribute, string Value)
		{
			this.Attribute = Attribute;
			this.Value = Value;
		}

		/// <summary>
		/// Gets or sets the name of the LDAP Property
		/// </summary>
		public string Attribute { get; set; }

		/// <summary>
		/// LDAP Property Value
		/// </summary>
		public string Value { get; set; }

		/// <summary>
		/// Gets the string value
		/// </summary>
		/// <param name="result">attribute value pair</param>
		/// <returns></returns>
		public static string GetValue(Result result)
		{
			return result.Value;
		}

        /// <summary>
        /// Allows casting a Result as a string
        /// </summary>
        /// <param name="result">Attribute/Value pair object</param>
        public static implicit operator string(Result result)
        {
            return result.Value;
        }

        /// <summary>
        /// Allows casting strings as a Result
        /// </summary>
        /// <param name="resultValue">Result.Value as string</param>
        public static implicit operator Result(string resultValue)
        {
            return new Result(string.Empty, resultValue);
        }
    }
}
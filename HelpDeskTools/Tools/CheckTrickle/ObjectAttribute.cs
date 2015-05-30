using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Specifies identifiers for LDAP Attributes
/// </summary>
public static class ObjectAttribute
{
	/// <summary>
	/// value "name", domain name
	/// </summary>
	public const string ComputerName = "name";
	/// <summary>
	/// value "cn", common name
	/// </summary>
	public const string CN = "cn";
	/// <summary>
	/// value "mail", email address
	/// </summary>
	public const string Mail = "mail";
	/// <summary>
	/// value "postalCode", zip code
	/// </summary>
	public const string PostalCode = "postalCode";
	/// <summary>
	/// value "postalCode", zip code
	/// </summary>
	public const string Zip = "postalCode";
	/// <summary>
	/// value "streetAddress", address
	/// </summary>
	public const string Address = "streetAddress";
	/// <summary>
	/// value "sAMAccountName", user account name
	/// </summary>
	public const string Account = "sAMAccountName";
	/// <summary>
	/// value "street"
	/// </summary>
	public const string Street = "street";
	/// <summary>
	/// value "st"
	/// </summary>
	public const string State = "st";
	/// <summary>
	/// value "c"
	/// </summary>
	public const string Country = "c";
}


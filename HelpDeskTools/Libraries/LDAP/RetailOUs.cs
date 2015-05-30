using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDAP
{
	/// <summary>
	/// Specifies computer and user LDAP search root and store number upper and lower bounds
	/// </summary>
	public static class RetailOUs
	{
		/// <summary>
		/// Michigan based stores computer and user OU and store number range lower and upper bounds
		/// </summary>
		public static OU Michigan = new OU(
			"LDAP://OU=Retail Stores,OU=North America,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreComputers,OU=DistrictMGRComputers,OU=Retail Stores,OU=North America,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreUsers,OU=DistrictMGRUsers,OU=Retail Stores,OU=North America,OU=WWW,DC=wwwint,DC=corp",
			500,
			999);
		/// <summary>
		/// Boston based stores computer and user OU and store number range lower and upper bounds
		/// </summary>
		public static OU Boston = new OU(
			"LDAP://OU=Retail Stores-BBB,OU=North America,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreComputers,OU=Retail Stores-BBB,OU=North America,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreUsers,OU=Retail Stores-BBB,OU=North America,OU=WWW,DC=wwwint,DC=corp",
			1000,
			9999);
		/// <summary>
		/// Europe  based stores computer and user OU and store number range lower and upper bounds
		/// </summary>
		public static OU Europe = new OU(
			"LDAP://OU=Retail Stores,OU=Europe,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreComputers,OU=DistrictMGRComputers,OU=Retail Stores,OU=Europe,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreUsers,OU=DistrictMGRUsers,OU=Retail Stores,OU=Europe,OU=WWW,DC=wwwint,DC=corp",
			850,
			890);
		/// <summary>
		/// 
		/// </summary>
		public static OU All = new OU(
			"LDAP://OU=Retail,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreComputers,OU=Retail,OU=WWW,DC=wwwint,DC=corp",
			"LDAP://OU=StoreUsers,OU=Retail,OU=WWW,DC=wwwint,DC=corp",
			0,
			9999);
	}
}

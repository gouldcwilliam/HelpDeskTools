using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.DirectoryServices;


/// <summary>
/// Provides a set of methods for Active Directory Domain queries
/// </summary>
public static class AD
{
	/// <summary>
	/// Gets OU by store number
	/// </summary>
	/// <param name="store">store number as int</param>
	/// <returns></returns>
	public static string GetOU(int store)
	{
		if (RetailOUs.Europe.Lower <= store && store <= RetailOUs.Europe.Upper)
		{
			return RetailOUs.Europe.BaseOU;
		}
		else if (RetailOUs.Michigan.Lower <= store && store <= RetailOUs.Michigan.Upper)
		{
			return RetailOUs.Michigan.BaseOU;
		}
		else if (RetailOUs.Boston.Lower <= store && store <= RetailOUs.Boston.Upper)
		{
			return RetailOUs.Boston.BaseOU;
		}
		else
		{ return string.Empty; }
	}
	/// <summary>
	/// Gets OU by store number, attempts to convert and returns empty string on fail
	/// </summary>
	/// <param name="store">store numbers as string</param>
	/// <returns></returns>
	public static string GetOU(string store)
	{
		int value = 0;
		// Convert string to int
		if (int.TryParse(store, out value))
		{
			return GetOU(value);
		}
		return string.Empty;
	}



	/// <summary>
	/// Search AD Directory Entry (OU) using LDAP query filter for specified properties
	/// </summary>
	/// <param name="Entry">Directory Entry (OU search root)</param>
	/// <param name="Filter">LDAP query to narrow results</param>
	/// <param name="Properties">LDAP property name to include in results</param>
	/// <returns>List of LDAP property values</returns>
	public static List<Result> SearchAD(DirectoryEntry Entry, string Filter, string[] Properties)
	{
		List<Result> value = new List<Result>();
		try
		{
			DirectorySearcher searcher = new DirectorySearcher();
			searcher.SearchRoot = Entry;
			searcher.Filter = Filter;
			if (Properties.Count() > 0)
			{
				searcher.PropertiesToLoad.Clear();
				searcher.PropertiesToLoad.AddRange(Properties);
			}

			SearchResultCollection results = searcher.FindAll();

			foreach (SearchResult result in results)
			{
				foreach (var rpvCollection in result.Properties.PropertyNames)
				{
					Result info = new Result(rpvCollection.ToString(), result.Properties[rpvCollection.ToString()][0].ToString());
					if (Properties.Count() > 0)
					{
						foreach (string property in Properties)
						{
							if (rpvCollection.ToString() == property)
							{
								Console.WriteLine(info.Value);
								value.Add(info); 
							}
						}
					}
					else
					{ value.Add(info); }
				}
			}
		}
		catch (Exception ex) { Console.WriteLine(ex.Message); }
		return value;
	}
	/// <summary>
	/// Search AD Directory Entry (OU) using LDAP query filter for specified properties
	/// </summary>
	/// <param name="OU">String containing directory entry (OU)</param>
	/// <param name="Filter">LDAP query to narrow results</param>
	/// <param name="Properties">LDAP property name to include in results</param>
	/// <returns>List of LDAP property values</returns>
	public static List<Result> SearchAD(string OU, string Filter, string[] Properties)
	{
		DirectoryEntry entry = new DirectoryEntry(OU);
		return SearchAD(entry, Filter, Properties);
	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="OU"></param>
	/// <param name="Filter"></param>
	/// <param name="Property"></param>
	/// <returns></returns>
	public static List<Result> SearchAD(string OU, string Filter, string Property)
	{
		string[] Properties = { Property };
		return SearchAD(OU, Filter, Properties);
	}
	/// <summary>
	/// Search AD Directory Entry (OU) using LDAP query filter
	/// </summary>
	/// <param name="Entry">Directory Entry (OU search root)</param>
	/// <param name="Filter">LDAP query to narrow results</param>
	/// <returns>List of LDAP property values</returns>
	public static List<Result> SearchAD(DirectoryEntry Entry, string Filter)
	{
		return SearchAD(Entry, Filter, new string[] { });
	}
	/// <summary>
	/// Search AD Directory Entry (OU) using LDAP query filter
	/// </summary>
	/// <param name="OU">String containing directory entry (OU)</param>
	/// <param name="Filter">LDAP query to narrow results</param>
	/// <returns>List of LDAP property values</returns>
	public static List<Result> SearchAD(string OU, string Filter)
	{
		DirectoryEntry entry = new DirectoryEntry(OU);
		return SearchAD(entry, Filter, new string[] { });
	}
	/// <summary>
	/// Search entire AD Directory Entry (OU) using LDAP query filter
	/// </summary>
	/// <param name="Filter">LDAP query to narrow results</param>
	/// <returns>List of LDAP property values</returns>
	public static List<Result> SearchAD(string Filter)
	{
		DirectoryEntry entry = new DirectoryEntry("LDAP://OU=WWW,DC=wwwint,DC=corp");
		return SearchAD(entry, Filter);
	}
}


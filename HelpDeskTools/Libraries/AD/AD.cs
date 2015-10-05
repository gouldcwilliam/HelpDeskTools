using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.DirectoryServices;
using LDAP;

/// <summary>
/// Provides a set of methods for Active Directory Domain queries
/// </summary>
public static class AD
{





	/// <summary>
	/// Search AD Directory Entry (OU) using LDAP query filter for specified properties
	/// </summary>
	/// <param name="Entry">Directory Entry (OU search root)</param>
	/// <param name="Filter">LDAP query to narrow results</param>
	/// <param name="Properties">LDAP property name to include in results</param>
	/// <returns>List of LDAP property values</returns>
	public static List<Result> SearchAD(DirectoryEntry Entry, string Filter, string[] Properties, bool useOneLevel=true)
	{
		List<Result> value = new List<Result>();
		try
		{
			DirectorySearcher searcher = new DirectorySearcher();
			searcher.SearchRoot = Entry;
			searcher.Filter = Filter;
            if (useOneLevel) { searcher.SearchScope = SearchScope.OneLevel; }
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
								//Console.WriteLine(info.Value);
								value.Add(info); 
							}
						}
					}
					else
					{ value.Add(info); }
				}
			}

            return value;
		}
        catch (Exception ex) { Console.WriteLine(ex.Message); return null; } //changed to null for error checking
	}

    public static SearchResult SearchADOneResult(string Entry, string Filter)
    {
        DirectoryEntry entry = new DirectoryEntry(Entry);
        List<Result> value = new List<Result>();
        try
        {
            DirectorySearcher searcher = new DirectorySearcher();
            searcher.SearchRoot = entry;
            searcher.Filter = Filter;

            return searcher.FindOne();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); return null; }
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
    public static List<Result> SearchAD(string OU, string Filter, bool useOneLevel = true)
    {
        DirectoryEntry entry = new DirectoryEntry(OU);
        return SearchAD(entry, Filter, new string[] { }, useOneLevel);
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices;

namespace Retail_HD
{


    class ADwww
    {
        /// <summary>
        /// get OU by store value
        /// </summary>
        /// <param name="store">store number</param>
        /// <returns>OU as string</returns>
        public static string GetOU(int store)
        {
            string domain = string.Empty;
            if (System.Environment.UserDomainName.ToString().ToUpper() == "WWWINT")
            {
                domain = ",DC=wwwint,DC=corp";
            }
            else
            {
                domain = ",DC=rage-it,DC=local";
            }

			if (store <= 999)
			{
				if (850 <= store && store <= 870)
                {
                    return "LDAP://OU=Retail Stores,OU=Europe,OU=WWW" + domain;
                }
            
                {
                    return "LDAP://OU=Retail Stores,OU=North America,OU=WWW" + domain;
                }
            }
            else
            {
                return "LDAP://OU=Retail Stores-BBB,OU=North America,OU=WWW" + domain;
            }
        }


        public static bool Search(out List<LDAPInfo> list, string OU, string name, string category)
        {
            list = new List<LDAPInfo>();
            bool valueReturn = false;
            try
            {
                DirectoryEntry directoryEntry = new DirectoryEntry(OU);
                DirectorySearcher directorySearcher = new DirectorySearcher(directoryEntry);
                directorySearcher.Filter = string.Format("(&(Name=*{0}*)(objectCategory={1}))", name, category);
                SearchResultCollection searchResults = directorySearcher.FindAll();

                valueReturn = searchResults.Count > 0;
                list = ResultsToList(searchResults);

                directoryEntry.Dispose();
                directorySearcher.Dispose();
                searchResults.Dispose();
            }
			catch (Exception) { valueReturn = false; }
            return valueReturn;
        }


        public static List<LDAPInfo> ResultsToList(SearchResultCollection searchResults)
        {
            List<LDAPInfo> returnList = new List<LDAPInfo>();
			LDAPInfo ldapInfo;
            foreach (SearchResult result in searchResults)
            {
                foreach (var prop in result.Properties.PropertyNames)
                {
					ldapInfo = new LDAPInfo(prop.ToString(), result.Properties[prop.ToString()][0].ToString());
                    returnList.Add(ldapInfo);
                }
            }
            return returnList;
        }

		public static List<LDAPInfo> SearchOUs(string[] OUs, string attribute)
		{
			List<LDAPInfo> value = new List<LDAPInfo>();
			List<LDAPInfo> returnValue = new List<LDAPInfo>();
			foreach (string OU in OUs)
			{
				Console.WriteLine(OU);
				if (AD.Search(out value, OU, "SAP", "Computer"))
				{
					returnValue.AddRange(value);
				}
			}
			return returnValue.FindAll(x => x.Attribute == attribute);
		}

		public static List<LDAPInfo> SearchOU(string OU, string attribute)
		{
			List<LDAPInfo> value = new List<LDAPInfo>();
			Console.WriteLine(OU);
			if (AD.Search(out value, OU, "SAP", "Computer"))
			{
				return value.FindAll(x => x.Attribute == attribute);
			}
			return new List<LDAPInfo>();
		}
    }
}

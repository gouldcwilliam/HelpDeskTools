using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace UpdateComputerList
{
	class UpdateComputerList
	{
		static string sqlConnection = string.Format(
				"server={0};database={1};Integrated Security=TRUE",
				Properties.Settings.Default._serverName,
				Properties.Settings.Default._dataBase);

		static void Main(string[] args)
		{
			if (!ClearTable())
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Write("Unable to clear SQL table!");
				Console.ReadKey();
				return;
			}
			Console.WriteLine("Cleared SQL Computer table");

			string ADFilter =
				string.Format("(&(objectCategory={0})(&({1}=*SAP*)(!({1}=*SAPQ*))))",
				LDAP.ObjectClasses.Computer,
				LDAP.ObjectAttribute.ComputerName);

            LDAP.OU ou = LDAP.RetailOUs.All;

            string sStore = "";

			List<LDAP.Result> searchResults = AD.SearchAD(ou.ComputerOU, ADFilter, LDAP.ObjectAttribute.ComputerName);

            if (searchResults != null )
            {
                if (searchResults.Count > 0)
                {
                    ProgressBar retBar = new ProgressBar(ou.Upper - ou.Lower, ou.Name);
                    for (int i = ou.Lower; i < ou.Upper + 1; i++)
                    {
                        sStore = i.ToString();

                        while (sStore.Length < 4) { sStore = "0" + sStore; }

                        foreach (LDAP.Result item in searchResults.FindAll(x => x.Value.Contains(sStore)))
                        {
                            InsertIntoTable(Properties.Settings.Default._tableName, item.Value, i.ToString());
                        }
                        retBar.Update(i - ou.Lower);
                    }
                    retBar.Completed();
                }
            }
			InsertIntoTable(Properties.Settings.Default._tableName, "SAPTESTLAB", "9999");
            Console.WriteLine("Defaulting Open Status: {0}", ExecuteNonQuery(Properties.Settings.Default._setAllOpen));
            Console.WriteLine("Setting Status to closed for stores without computers: {0}", ExecuteNonQuery(Properties.Settings.Default._setClosedStores));
			Console.Write("\nCompleted....");
			System.Threading.Thread.Sleep(5000);
			Console.WriteLine("Exiting");
		}

		static public bool ClearTable()
		{
			string sql = string.Format(@"DELETE FROM {0}", Properties.Settings.Default._tableName);
			return ExecuteNonQuery(sql);
		}


		static public bool InsertIntoTable(string tblName, string computer, string store)
		{
			string sql = string.Format(@"INSERT INTO {0} ([computer], [store]) VALUES (@computer, @store)", tblName);
			SqlParameter[] parameters = { new SqlParameter("@computer", computer), new SqlParameter("@store", store) };
			return ExecuteNonQuery(sql, parameters);
		}
		static public bool ExecuteNonQuery(string sql, SqlParameter[] parameters)
		{
			SqlConnection connection = new SqlConnection(UpdateComputerList.sqlConnection);
			SqlCommand command = new SqlCommand(sql, connection);
			command.Parameters.AddRange(parameters);

			try
			{
				connection.Open();
				command.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(ex.Message);
				Console.ResetColor();
				return false;
			}
			finally { connection.Close(); }
		}
		static public bool ExecuteNonQuery(string sql)
		{
			SqlParameter[] parameters = new SqlParameter[] { };
			return ExecuteNonQuery(sql, parameters);
		}
	}
}

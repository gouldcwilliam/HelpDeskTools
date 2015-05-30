using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

			List<LDAP.Result> results = new List<LDAP.Result>();

			LDAP.OU[] OUs = { LDAP.RetailOUs.Boston, LDAP.RetailOUs.Michigan, LDAP.RetailOUs.Europe };

			int o = 1;
			foreach (LDAP.OU ou in OUs)
			{
				List<LDAP.Result> temp = AD.SearchAD(ou.ComputerOU, ADFilter, LDAP.ObjectAttribute.ComputerName);
				ProgressBar bar = new ProgressBar(ou.Upper-ou.Lower, "Update " + o.ToString());
				for (int i = ou.Lower; i < ou.Upper; i++)
				{
					foreach (LDAP.Result item in temp.FindAll(x => x.Value.Contains(i.ToString())))
					{
						//Console.WriteLine("computer: {0} store: {1}", item.Value, i.ToString());
						InsertIntoTable(Properties.Settings.Default._tableName, item.Value, i.ToString());
					}
					bar.Update(i - ou.Lower);
				}
				bar.Completed();
				o++;
			}

			List<LDAP.Result> canada = AD.SearchAD(LDAP.RetailOUs.Boston.ComputerOU, ADFilter, LDAP.ObjectAttribute.ComputerName);
			ProgressBar canBar = new ProgressBar(50, "Update 4");
			for (int i = 400; i < 450; i++)
			{
				foreach (LDAP.Result item in canada.FindAll(x => x.Value.Contains("0" + i.ToString())))
				{
					InsertIntoTable(Properties.Settings.Default._tableName, item.Value, i.ToString());
				}
				canBar.Update(i - 400);
			}
			canBar.Completed();

			List<LDAP.Result> retail = AD.SearchAD(LDAP.RetailOUs.All.ComputerOU, ADFilter, LDAP.ObjectAttribute.ComputerName);
			ProgressBar retBar = new ProgressBar(9900, "Update 5");
			for (int i = 100; i < 10000; i++ )
			{
				if (i < 1000)
				{
					foreach (LDAP.Result item in retail.FindAll(x => x.Value.Contains("0" + i.ToString())))
					{
						InsertIntoTable(Properties.Settings.Default._tableName, item.Value, i.ToString());
					}
				}
				else
				{
					foreach(LDAP.Result item in retail.FindAll(x=>x.Value.Contains(i.ToString())))
					{
						InsertIntoTable(Properties.Settings.Default._tableName, item.Value, i.ToString());
					}
				}
				retBar.Update(i - 100);
			}
			retBar.Completed();

			InsertIntoTable(Properties.Settings.Default._tableName, "SAPTESTLAB", "9999");

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

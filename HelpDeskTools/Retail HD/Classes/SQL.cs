using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Retail_HD
{
	public static class SQL
	{
		// MAIN connection string
		private static string connString = string.Format("server={0};database={1};Integrated Security={2}", Setting.SQL.Default._ServerName, Setting.SQL.Default._Database, true);

		/// <summary> read only connection string settings
		/// </summary>
		public static SqlConnection conn = new SqlConnection(connString);

		/// <summary> check for database connection
		/// </summary>
		/// <returns>success/fail</returns>
		public static bool b_CheckConnection()
		{
			try
			{
				conn.Open();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			finally { conn.Close(); }
		}





		/* INSERT */
		#region INSERT - Add new info to SQL


		/// <summary> Inserts the call wrap up into the database
		/// </summary>
		/// <param name="store">store number</param>
		/// <param name="problem">reason for call</param>
		/// <param name="solution">resolution</param>
		/// <param name="Category"></param>
		/// <param name="type">incoming or outgoing</param>
		/// <param name="technician">name of tech</param>
		/// <returns>success/fail</returns>
		static public bool b_InsertCall(string store, string details, string category, string topic, string type, string technician, bool trax, string url)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@store", store));
			paramList.Add(new SqlParameter("@details", details));
			paramList.Add(new SqlParameter("@Category", category));
			paramList.Add(new SqlParameter("@topic", topic));
			paramList.Add(new SqlParameter("@type", type));
			paramList.Add(new SqlParameter("@technician", technician));
			paramList.Add(new SqlParameter("@trax", trax));
			paramList.Add(new SqlParameter("@url", url));

			return Insert(Setting.SQL.Default._InsertCall, paramList);
		}


		/// <summary> Insert Category and wrapup Text into the wrapup table
		/// </summary>
		/// <param name="Category">solution Category</param>
		/// <param name="topic">Text for wrap up</param>
		/// <returns>true for success</returns>
		static public bool b_InsertTopic(string category, string topic, bool mandatory)
		{

			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@Category", category));
			paramList.Add(new SqlParameter("@topic", topic));
			paramList.Add(new SqlParameter("@Mandatory", mandatory));

			return Insert(Setting.SQL.Default._InsertTopic, paramList);
		}


		/// <summary> Add new store entry into the SQL database
		/// </summary>
		/// <param name="Store"></param>
		/// <param name="TZ"></param>
		/// <param name="MPID"></param>
		/// <param name="Manager"></param>
		/// <param name="DM"></param>
		/// <param name="Mall"></param>
		/// <param name="Name"></param>
		/// <param name="Type"></param>
		/// <param name="Address"></param>
		/// <param name="City"></param>
		/// <param name="State"></param>
		/// <param name="Zip"></param>
		/// <param name="Email"></param>
		/// <param name="Phone"></param>
		/// <param name="PosGate"></param>
		/// <param name="Pos"></param>
		/// <param name="MimGate"></param>
		/// <param name="Mim"></param>
		/// <param name="SensorGate"></param>
		/// <param name="Sensor"></param>
		/// <returns></returns>
		public static bool b_InsertStore(string Store, string TZ, string MPID, string Manager, string DM, string Mall,
			string Name, string Type, string Address, string City, string State, string Zip, string Email, string Phone,
			string PosGate, string Pos, string MimGate, string Mim, string SensorGate, string Sensor)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", Store));
			parameters.Add(new SqlParameter("@TZ", TZ));
			parameters.Add(new SqlParameter("@MP", MPID));
			parameters.Add(new SqlParameter("@manager", Manager));
			parameters.Add(new SqlParameter("@dm", DM));
			parameters.Add(new SqlParameter("@mall", Mall));
			parameters.Add(new SqlParameter("@name", Name));
			parameters.Add(new SqlParameter("@type", Type));
			parameters.Add(new SqlParameter("@address", Address));
			parameters.Add(new SqlParameter("@city", City));
			parameters.Add(new SqlParameter("@state", State));
			parameters.Add(new SqlParameter("@zip", Zip));
			parameters.Add(new SqlParameter("@email", Email));
			parameters.Add(new SqlParameter("@phone", Phone));
			parameters.Add(new SqlParameter("@pos_gate", PosGate));
			parameters.Add(new SqlParameter("@pos", Pos));
			parameters.Add(new SqlParameter("@mim_gate", MimGate));
			parameters.Add(new SqlParameter("@mim", Mim));
			parameters.Add(new SqlParameter("@sensor_gate", SensorGate));
			parameters.Add(new SqlParameter("@sensor", Sensor));

			return Insert(Setting.SQL.Default._InsertStore, parameters);
		}

		// Add tab to the info window
		static public bool b_InsertInfoTab(string Tab, int Order)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@tab", Tab));
			paramList.Add(new SqlParameter("@order", Order.ToString()));
			
			return Insert(Setting.SQL.Default._InsertInfoTab, paramList);
		}



		/// <summary> Executes insert statement
		/// </summary>
		/// <param name="insertSQL">statement to execute</param>
		/// <returns>true on success</returns>
		static public bool Insert(string insertSQL)
		{
			return Insert(insertSQL, new List<SqlParameter>());
		}
		static public bool Insert(string insertSQL, SqlParameter sp)
		{
			List<SqlParameter> sps = new List<SqlParameter>();
			sps.Add(sp);
			return Insert(insertSQL, sps);
		}
		/// <summary> Executes insert statement
		/// </summary>
		/// <param name="insertSQL">statement to execute</param>
		/// <param name="paramList">list of sql parameters</param>
		/// <returns>true on success</returns>
		static public bool Insert(string insertSQL, List<SqlParameter> paramList)
		{
			SqlCommand command = new SqlCommand(insertSQL, conn);
			if (paramList.Count > 0) { command.Parameters.AddRange(paramList.ToArray()); }
			try
			{
				conn.Open();
				command.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			finally { conn.Close(); }
		}

		#endregion


		/* SELECT */
		#region SELECT STATEMENTS - Execute SQL Queries to obtain information

		

		/// <summary> Gets the last 20 call wrap ups by store
		/// </summary>
		/// <param name="store">store number</param>
		/// <returns>data table</returns>
		static public DataTable dt_SelectRecentCalls(int store)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", store.ToString()));

			return Select(Setting.SQL.Default._RecentCallsByStore, parameters);
		}

		/// <summary> Gets store information
		/// </summary>
		/// <param name="store">store number</param>
		/// <returns>data table</returns>
		static public DataTable dt_SelectStore(int store)
		{
			return dt_SelectStore(store.ToString());
		}

		static public DataTable dt_SelectStore(string store)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", store));

			return Select(Setting.SQL.Default._StoreInfo, parameters);
		}

		// Get store# from phone
		static public DataTable dt_SelectStoreByPhone(string phone)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@phone", phone));

			return Select(Setting.SQL.Default._StoreByPhone, parameters);
		}

		/// <summary> gets retList for check list box
		/// </summary>
		/// <param name="store">store number</param>
		/// <returns>data table</returns>
		static public DataTable dt_SelectComputers(int store)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", store.ToString()));

			return Select(Setting.SQL.Default._ComputersByStore, parameters);
		}

		/// <summary> Gets the useful info's tab names
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_UsefulInfo_Tabs()
		{
			string sql = "SELECT [tab] FROM [Info] ORDER BY [order]";
			return Select(sql);
		}

		/// <summary> Gets the useful info's tab names
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_UsefulInfo()
		{
			string sql = "SELECT [tab], [Text] FROM [Info] ORDER BY [order]";
			return Select(sql);
		}

		/// <summary> Gets useful info Text by tab name
		/// </summary>
		/// <param name="tab"></param>
		/// <returns></returns>
		static public DataTable dt_UsefulInfo_Text(string tab)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@tab", tab));

			string sql = "SELECT TOP 1 [Text] FROM [Info] WHERE [tab] = @tab";
			return Select(sql, parameters);
		}

		/// <summary> Get the total wrapups per day
		/// </summary>
		/// <returns>datatable</returns>
		static public DataTable dt_CallCount_User()
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@TECH", Environment.UserName.ToUpper()));

			return Select(Setting.SQL.Default._CallCount_User, parameters);
		}

		/// <summary> Gets the total calls taken by the team for the day
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_CallCount_Team()
		{
			return Select(Setting.SQL.Default._CallCount_Team);
		}

		/// <summary> Search call history
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_HistorySearch()
		{
			string query = string.Format("{0} \n {1}",
				Setting.SQL.Default._HistoryDeclare,
				string.Format(Setting.SQL.Default._HistorySearch, "1000"));

			return Select(query);
		}

		/// <summary> Search call history with parameters and 1 date
		/// </summary>
		/// <param name="store"></param>
		/// <param name="useDate"></param>
		/// <param name="date"></param>
		/// <param name="type"></param>
		/// <param name="category"></param>
		/// <param name="topic"></param>
		/// <param name="tech"></param>
		/// <param name="details"></param>
		/// <param name="trax"></param>
		/// <param name="url"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		static public DataTable dt_HistorySearch(
			string store, bool useDate, DateTime date, string type, string category,
			string topic, string tech, string details, bool trax, string url, int limit)
		{
			string setStatement = string.Empty;

			if (store != string.Empty) { setStatement += string.Format("SET @STORE = '{0}'\n", store); }
			if (useDate) { setStatement += string.Format("SET @DATE1 = '{0}'\n", date.ToShortDateString()); }
			if (type != string.Empty) { setStatement += string.Format("SET @TYPE = '{0}'\n", type); }
			if (category != string.Empty) { setStatement += string.Format("SET @CATEGORY = '{0}'\n", category); }
			if (topic != string.Empty) { setStatement += string.Format("SET @TOPIC = '{0}'\n", topic); }
			if (tech != string.Empty) { setStatement += string.Format("SET @TECH = '{0}'\n", tech); }
			if (details != string.Empty) { setStatement += string.Format("SET @DETAILS = '{0}'\n", details); }
			if (trax) { setStatement += "SET @TRAX = 1\n"; }
			if (url != string.Empty) { setStatement += string.Format("SET @URL = '{0}'\n", url); }

			string query = string.Format("{0} \n {1} \n {2}",
				Setting.SQL.Default._HistoryDeclare,
				setStatement,
				string.Format(Setting.SQL.Default._HistorySearch, limit));
			Console.WriteLine(query);
			return Select(query);
		}

		/// <summary> Search call history using parameters and date range
		/// </summary>
		/// <param name="store"></param>
		/// <param name="date1"></param>
		/// <param name="date2"></param>
		/// <param name="type"></param>
		/// <param name="category"></param>
		/// <param name="topic"></param>
		/// <param name="tech"></param>
		/// <param name="details"></param>
		/// <param name="trax"></param>
		/// <param name="url"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		static public DataTable dt_HistorySearch(
			string store, DateTime date1, DateTime date2, string type, string category,
			string topic, string tech, string details, bool trax, string url, int limit)
		{
			string setStatement = string.Empty;

			if (store != string.Empty) { setStatement += string.Format("SET @STORE = '{0}'\n", store); }
			setStatement += string.Format("SET @DATE1 = '{0}'\n", date1.ToShortDateString());
			setStatement += string.Format("SET @DATE2 = '{0}'\n", date2.ToShortDateString());
			if (type != string.Empty) { setStatement += string.Format("SET @TYPE = '{0}'\n", type); }
			if (category != string.Empty) { setStatement += string.Format("SET @CATEGORY = '{0}'\n", category); }
			if (topic != string.Empty) { setStatement += string.Format("SET @TOPIC = '{0}'\n", topic); }
			if (tech != string.Empty) { setStatement += string.Format("SET @TECH = '{0}'\n", tech); }
			if (details != string.Empty) { setStatement += string.Format("SET @DETAILS = '{0}'\n", details); }
			if (trax) { setStatement += "SET @TRAX = 1\n"; }
			if (url != string.Empty) { setStatement += string.Format("SET @URL = '{0}'\n", url); }

			string query = string.Format("{0} \n {1} \n {2}",
				Setting.SQL.Default._HistoryDeclare,
				setStatement,
				string.Format(Setting.SQL.Default._HistorySearchRange, limit.ToString()));
			Console.WriteLine(query);
			return Select(query);
		}

		/// <summary> Search for store with the given parameters (Optional parameters are string.empty or "")
		/// </summary>
		/// <param name="tz"></param>
		/// <param name="mp"></param>
		/// <param name="dm"></param>
		/// <param name="name"></param>
		/// <param name="type"></param>
		/// <param name="address"></param>
		/// <param name="city"></param>
		/// <param name="state"></param>
		/// <param name="zip"></param>
		/// <param name="phone"></param>
		/// <returns></returns>
		static public DataTable dt_StoreSearch(string tz, string mp, string dm, string name, string type, string address, string city, string state, string zip, string phone)
		{
			string setStatement = string.Empty;

			if (tz != string.Empty) { setStatement += string.Format("SET @TZ = '{0}'\n", tz); }
			if (mp != string.Empty) { setStatement += string.Format("SET @MP = '{0}'\n", mp); }
			if (dm != string.Empty) { setStatement += string.Format("SET @DM = '{0}'\n", dm); }
			if (name != string.Empty) { setStatement += string.Format("SET @NAME = '{0}\n", name); }
			if (type != string.Empty) { setStatement += string.Format("SET @TYPE = '{0}'\n", type); }
			if (address != string.Empty) { setStatement += string.Format("SET @ADDRESS = '{0}'\n", address); }
			if (city != string.Empty) { setStatement += string.Format("SET @CITY = '{0}'\n", city); }
			if (state != string.Empty) { setStatement += string.Format("SET @STATE='{0}'\n", state); }
			if (zip != string.Empty) { setStatement += string.Format("SET @ZIP='{0}'\n", zip); }
			if (phone != string.Empty) { setStatement += string.Format("SET @PHONE='{0}'\n", phone); }

			string query = string.Format("{0} \n {1} \n {2}",
				Setting.SQL.Default._StoreSearchDeclare,
				setStatement,
				Setting.SQL.Default._StoreSearch);
			Console.WriteLine(query);
			return Select(query);
		}

		/// <summary> Retrieve the technicians last used category
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_LastCategory()
		{
			SqlParameter p = new SqlParameter("@TECH", Environment.UserName.ToUpper());
			return Select(Setting.SQL.Default._LastCategory, p);
		}


		static public DataTable ListTables()
		{
			return Select("SELECT Distinct TABLE_NAME FROM information_schema.TABLES");
		}

		/// <summary> executes select statement
		/// </summary>
		/// <param name="selectSQL">statement to execute</param>
		/// <param name="paramList">parameters to add to sql string</param>
		/// <returns>DataTable containing results</returns>
		static public DataTable Select(string selectSQL, List<SqlParameter> paramList)
		{
			DataSet ds = new DataSet();
			SqlDataAdapter adapter = new SqlDataAdapter(selectSQL, conn);
			if (paramList.Count > 0)
			{
				adapter.SelectCommand.Parameters.AddRange(paramList.ToArray());
			}
			try
			{
				adapter.Fill(ds);
				return ds.Tables[0];
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.Errors);
				return new DataTable();
			}
			finally { conn.Close(); }
		}
		static public DataTable Select(string selectSQL)
		{
			return Select(selectSQL, new List<SqlParameter>());
		}
		static public DataTable Select(string selectSQL, SqlParameter sqlParam)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(sqlParam);
			return Select(selectSQL, paramList);
		}


		#endregion



		/* DELETE */
		#region DELETE - Remove unwanted info from SQL

		/// <summary> clears the temporary computer table
		/// </summary>
		/// <returns>true on success</returns>
		static public bool b_ClearTempComputers()
		{
			string sql = "DELETE FROM [Test].[dbo].[Computers]";
			return Delete(sql);
		}

		/// <summary> executes delete statement
		/// </summary>
		/// <param name="deleteSQL">statment to execute</param>
		/// <returns>true on success</returns>
		public static bool Delete(string deleteSQL)
		{
			return Delete(deleteSQL, new List<SqlParameter>());
		}
		/// <summary> executes delete statement
		/// </summary>
		/// <param name="deleteSQL">statment to execute</param>
		/// <param name="paramList">list of sql parameters</param>
		/// <returns>true on success</returns>
		public static bool Delete(string deleteSQL, List<SqlParameter> paramList)
		{
			SqlCommand command = new SqlCommand(deleteSQL, conn);
			if (paramList.Count > 0)
			{
				command.Parameters.AddRange(paramList.ToArray());
			}
			try
			{
				conn.Open();
				command.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			finally { conn.Close(); }
		}



		#endregion



		#region UPDATE - Replace/Modify information


		/* UPDATE */

		public static bool b_UpdateCall( string id, string store, string topic, string details, string type, bool trax, string url)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@id", int.Parse(id)));
			paramList.Add(new SqlParameter("@store", int.Parse(store)));
			paramList.Add(new SqlParameter("@topic", topic));
			paramList.Add(new SqlParameter("@details", details));
			paramList.Add(new SqlParameter("@type", type));
			paramList.Add(new SqlParameter("@trax", trax));
			paramList.Add(new SqlParameter("@url", url));
			return Update(Setting.SQL.Default._UpdateCall, paramList);
		}


		public static bool b_UpdateStore( string Store, string Phone, string Manager, string MPID, string Address, string Email, string IPreg1,
			string City, string DM, string Name, string Type, string State, string Zip, string TZ)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", Store));
			parameters.Add(new SqlParameter("@phone", Phone));
			parameters.Add(new SqlParameter("@manager", Manager));
			parameters.Add(new SqlParameter("@mpid", MPID));
			parameters.Add(new SqlParameter("@address", Address));
			parameters.Add(new SqlParameter("@email", Email));
			parameters.Add(new SqlParameter("@pos", IPreg1));
			parameters.Add(new SqlParameter("@city", City));
			parameters.Add(new SqlParameter("@dm", DM));
			parameters.Add(new SqlParameter("@name", Name));
			parameters.Add(new SqlParameter("@type", Type));
			parameters.Add(new SqlParameter("@state", State));
			parameters.Add(new SqlParameter("@zip", Zip));
			parameters.Add(new SqlParameter("@tz", TZ));

			string updateSQL = "UPDATE [STORES] SET [phone] = dbo.RemoveNonNumericCharacters(@phone),[manager] = @manager,[MP] = @mpid,[address] = @address,[email] = @email,[pos] = @pos,[city] = @city,[dm] = @dm,[name] = @name,[type] = @type,[state] = @state,[zip] = @zip,[TZ] = @tz WHERE [store] = @store";
			return Update(updateSQL, parameters);

		}


		// TODO - Combine b_UsefulInfo_Update and b_EditInfoTabTitle into one SQL
		/// <summary> Inserts Text area of info form into sql
		/// </summary>
		/// <param name="tabName">name of the table</param>
		/// <param name="textDisplayed">contents of the rich Text box</param>
		/// <returns></returns>
		static public bool b_UsefulInfo_Update(string tabName, string textDisplayed)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@textDisplayed", textDisplayed));
			paramList.Add(new SqlParameter("@tabName", tabName));

			string sql = "UPDATE [Info] SET [Text] = @textDisplayed WHERE [tab] = @tabName";
			return Insert(sql, paramList);
		}



		// change title of the tab
		static public bool b_EditInfoTabTitle(string oldName, string newName)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@old", oldName));
			paramList.Add(new SqlParameter("@new", newName));
			string sql = "UPDATE [Info] SET [tab] = @new WHERE [tab] = @old";
			return Insert(sql, paramList);
		}



		/// <summary> Updates agent status for Team visibility
		/// </summary>
		/// <param name="agent">Agent updating</param>
		/// <param name="status">Agent/User status</param>
		/// <param name="info1">Optional: Current store or phone number</param>
		/// <param name="info2">Optional: Extra info needed to be passed</param>
		/// <returns></returns>
		static public bool b_UpdateAgentInformation(string agent, string status, string info1, string info2 = "")
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@agent", agent));
			parameters.Add(new SqlParameter("@status", status));
			parameters.Add(new SqlParameter("@info1", info1));
			parameters.Add(new SqlParameter("@time", DateTime.Now));
			if (info2 != string.Empty) parameters.Add(new SqlParameter("@info2", info2));

			string sqlFull = "UPDATE AgentStatus SET CurrentStatus=@status, TimeStatusChanged=@time, Information1=@info1, Information2=@info2 WHERE TechnicianID=(SELECT id FROM Technicians WHERE technician=@agent) IF @@ROWCOUNT = 0 INSERT INTO AgentStatus (TechnicianID,CurrentStatus,TimeStatusChanged,Information1,Information2) VALUES ((SELECT id FROM Technicians WHERE technician=@agent),@status,GETDATE(),@info1,@info2);";
			string sqlNoInfo2 = "UPDATE AgentStatus SET CurrentStatus=@status, TimeStatusChanged=@time, Information1=@info1 WHERE TechnicianID=(SELECT id FROM Technicians WHERE technician=@agent) IF @@ROWCOUNT = 0 INSERT INTO AgentStatus (TechnicianID,CurrentStatus,TimeStatusChanged,Information1) VALUES ((SELECT id FROM Technicians WHERE technician=@agent),@status,GETDATE(),@info1);";

			if (info2 != string.Empty)
			{
				//sql full
				return Update(sqlFull, parameters);
			}
			else
			{
				//no info2
				return Update(sqlNoInfo2, parameters);
			}
		}



		/// <summary> Update a table's information
		/// </summary>
		/// <param name="updateSQL">SQL string to execute</param>
		/// <param name="paramList">list of parameters </param>
		/// <returns>on success</returns>
		public static bool Update(string updateSQL, List<SqlParameter> paramList)
		{
			SqlCommand command = new SqlCommand(updateSQL, conn);
			if (paramList.Count > 0) { command.Parameters.AddRange(paramList.ToArray()); }
			try
			{
				conn.Open();
				command.ExecuteNonQuery();
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return false;
			}
			finally { conn.Close(); }

		}

		#endregion

	}

}

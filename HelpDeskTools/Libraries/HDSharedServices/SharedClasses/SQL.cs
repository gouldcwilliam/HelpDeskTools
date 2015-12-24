using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Shared
{

	public static class SQL
	{
        public static string connString = string.Format("server={0};database={1};Integrated Security={2}", 
            SQLSettings.Default._ServerName, 
            SQLSettings.Default._Database,
            true
        );

		/// <summary>
		/// read only connection string settings
		/// </summary>
		public static SqlConnection conn =  new SqlConnection(connString);
		
		

		/// <summary>
		/// check for database connection
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

		/// <summary>
		/// Inserts the call wrap up into the database
		/// </summary>
		/// <param name="store">store number</param>
		/// <param name="problem">reason for call</param>
		/// <param name="solution">resolution</param>
		/// <param name="Category"></param>
		/// <param name="type">incoming or outgoing</param>
		/// <param name="technician">name of tech</param>
		/// <returns>success/fail</returns>
		static public bool WrapUp_InsertCall(
			string store, 
			string details,
			string category,
			string topic,
			string type, 
			string technician,
			bool trax,
			string url)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@store", store));
			paramList.Add(new SqlParameter("@details", string.IsNullOrEmpty(details) ? (object)DBNull.Value : details));
			paramList.Add(new SqlParameter("@Category", category));
			paramList.Add(new SqlParameter("@topic", topic));
			paramList.Add(new SqlParameter("@type", type));
			paramList.Add(new SqlParameter("@technician", technician));
			paramList.Add(new SqlParameter("@trax", trax));
            paramList.Add(new SqlParameter("@url", string.IsNullOrEmpty(url) ? (object)DBNull.Value : url));

            return Insert(SQLSettings.Default._LogCall, paramList);
		}



		/// <summary>
		/// Insert Category and wrapup Text into the wrapup table
		/// </summary>
		/// <param name="Category">solution Category</param>
		/// <param name="topic">Text for wrap up</param>
		/// <returns>true for success</returns>
        static public bool AddQuickWrap_Insert(string category, string topic, bool mandatory)
        {
			
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@Category", category));
			paramList.Add(new SqlParameter("@topic", topic));
			paramList.Add(new SqlParameter("@Mandatory", mandatory));

            return Insert(SQLSettings.Default._AddCallTopic, paramList);
        }

		/// <summary>
		/// Add new store entry into the SQL database
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
		public static bool b_InsertNewStore(
			string Store,
			string TZ,
			string MPID,
			string Manager,
			string DM,
			string Mall,
			string Name,
			string Type,
			string Address,
			string City,
			string State,
			string Zip,
			string Email,
			string Phone,
			string First,
            string Second,
            string Third,
            string lan1,
            string lan2,
            string lan3,
            string lan4,
            string gate1,
            string gate2,
            string gate3,
            string gate4,
            string svs,
            string bams,
            string tid1,
            string tid2,
            string tid3,
            string tid4
			)
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
            parameters.Add(new SqlParameter("@first", First));
            parameters.Add(new SqlParameter("@second", Second));
            parameters.Add(new SqlParameter("@third", Third));
            parameters.Add(new SqlParameter("@lan1", lan1));
            parameters.Add(new SqlParameter("@lan2", lan2));
            parameters.Add(new SqlParameter("@lan3", lan3));
            parameters.Add(new SqlParameter("@lan4", lan4));
            parameters.Add(new SqlParameter("@gate1", gate1));
            parameters.Add(new SqlParameter("@gate2", gate2));
            parameters.Add(new SqlParameter("@gate3", gate3));
            parameters.Add(new SqlParameter("@gate4", gate4));
            parameters.Add(new SqlParameter("@svs", svs));
            parameters.Add(new SqlParameter("@bams", bams));
            parameters.Add(new SqlParameter("@tid1", tid1));
            parameters.Add(new SqlParameter("@tid2", tid2));
            parameters.Add(new SqlParameter("@tid3", tid3));
            parameters.Add(new SqlParameter("@tid4", tid4));

            string updateSQL = "INSERT INTO [Stores] ([store],[TZ],[MP],[manager],[dm],[mall],[name],[type],[address],[city],[state],[zip],[email],[1st],[2nd],[3rd],[lan1],[gate1],[lan2],[gate2],[lan3],[gate3],[lan4],[gate4],[BAMS],[SVS],[TID1],[TID2],[TID3],[TID4]) VALUES(dbo.InitCap(@store),UPPER(@TZ),dbo.InitCap(@MP),dbo.InitCap(@manager),dbo.InitCap(@dm),dbo.InitCap(@mall),dbo.InitCap(@name),dbo.InitCap(@type),dbo.InitCap(@address),dbo.InitCap(@city),UPPER(@state),@zip,@email,@first,@second,@third,@lan1,@gate1,@lan2,@gate2,@lan3,@gate3,@lan4,@gate4,@svs,@bams,@tid1,@tid2,@tid3,@tid4)";
			bool bstore = Insert(updateSQL, parameters);

            parameters.Clear();
			parameters.Add(new SqlParameter("@store", Store));
            parameters.Add(new SqlParameter("@phone", Phone));

            updateSQL = "INSERT INTO [Phones] ([store],[phone]) values (@store,@phone)";
            bool bphone = Insert(updateSQL, parameters);

            if (bstore && bphone) { return true; } else { return false; }
		}

		static public bool b_UsefulInfo_AddTab(string Tab, int Order)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@tab", Tab));
			paramList.Add(new SqlParameter("@order", Order.ToString()));
			string sql = "INSERT INTO [Info] ([tab], [order]) VALUES (@tab, @order)";
			return Insert(sql, paramList);
		}


		static public bool VersionEntry_InsertChangeLog(string version, string changelog)
		{
			List<SqlParameter> lsp = new List<SqlParameter>();
			lsp.Add(new SqlParameter("@version", version));
			lsp.Add(new SqlParameter("@changelog", changelog));
			return Insert("insert into [ChangeSet] ([version], [change]) values (@version, @changelog)", lsp);
		}

		/// <summary>
		/// Executes insert statement
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
		/// <summary>
		/// Executes insert statement
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





		/* SELECT */

		/// <summary>
		/// Gets the last 20 call wrap ups by store
		/// </summary>
		/// <param name="store">store number</param>
		/// <returns>data table</returns>
		static public DataTable dt_SelectRecentCalls(int store)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", store.ToString()));

            return Select(SQLSettings.Default._RecentCallsByStore, parameters);
		}

		/// <summary>
		/// Gets store information
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

            return Select(SQLSettings.Default._StoreInfo, parameters);
		}

        static public DataTable dt_SelectStoreByPhone(string phone)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@phone", phone));

            return Select(SQLSettings.Default._StoreByPhone, parameters);
        }

        /// <summary>
        /// Updates agent status for Team visibility
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
                return b_ExecuteQuery(sqlFull, parameters);
            }
            else
            {
                //no info2
                return b_ExecuteQuery(sqlNoInfo2, parameters);
            }
        }

		/// <summary>
		/// gets retList for check list box
		/// </summary>
		/// <param name="store">store number</param>
		/// <returns>data table</returns>
		static public DataTable dt_SelectComputers(int store)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", store.ToString()));

            return Select(SQLSettings.Default._ComputersByStore, parameters);
		}

		/// <summary>
		/// Gets the useful info's tab names
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_UsefulInfo_Tabs()
		{
			string sql = "SELECT [tab] FROM [Info] ORDER BY [order]";
			return Select(sql);
		}
		/// <summary>
		/// Gets the useful info's tab names
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_UsefulInfo()
		{
			string sql = "SELECT [tab], [Text] FROM [Info] ORDER BY [order]";
			return Select(sql);
		}

		/// <summary>
		/// Gets useful info Text by tab name
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




		/// <summary>
		/// Get all categories from tblWrapups
		/// </summary>
		/// <returns>DataTable of categories</returns>
		static public DataTable dt_SelectCategories()
		{
			string sql = "SELECT [Category] FROM [Calls] GROUP BY [Category] ORDER BY [Category]";
			return Select(sql);
		}

		/// <summary>
		/// Gets all categories and wrapups from tblWrapups
		/// </summary>
		/// <returns>DataTable of  tblWrapups</returns>
		static public DataTable dt_SelectAllWrapUps()
		{
			string sql = "SELECT * FROM [WrapUps] ORDER BY [Category]";
			return Select(sql);
		}

		/// <summary>
		/// gets the row to edit info with the edit call form
		/// </summary>
		/// <param name="id">call id number</param>
		/// <returns>data row</returns>
		static public DataRow dr_SelectCallRow(string id)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@id", id));

			string sql = "SELECT [id],[date],[technician],[Category],[problem],[solution],[type] FROM [Calls] WHERE [id] = @id";
			try
			{
				return Select(sql, parameters).Rows[0];
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		/// <summary>
		/// Get the total wrapups per day
		/// </summary>
		/// <returns>datatable</returns>
		static public DataTable dt_SelectWrapupsTotal()
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@TECH", Environment.UserName.ToUpper()));

            return Select(SQLSettings.Default._UserCallCount, parameters);
		}

		/// <summary>
		/// Gets the total calls taken by the team for the day
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_teamCalls()
		{
            return Select(SQLSettings.Default._TeamCallCount);
		}

		/// <summary>
		/// Search call history
		/// </summary>
		/// <returns></returns>
		static public DataTable dt_HistorySearch()
		{
			string query = string.Format("{0} \n {1}",
                SQLSettings.Default._HistoryDeclare,
                string.Format(SQLSettings.Default._HistorySearch, "1000"));

			return Select(query);
		}
		
		/// <summary>
		/// Search call history with parameters and 1 date
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
                SQLSettings.Default._HistoryDeclare,
				setStatement,
                string.Format(SQLSettings.Default._HistorySearch, limit));
			Console.WriteLine(query);
			return Select(query);
		}

		/// <summary>
		/// Search call history using parameters and date range
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
                SQLSettings.Default._HistoryDeclare,
				setStatement,
                string.Format(SQLSettings.Default._HistorySearchRange, limit.ToString()));
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
		static public DataTable dt_StoreSearch(string tz,string bams, string mp,string manager, string dm, string name, string type, string address, string city, string state, string zip, string phone, string ip)
		{
			string setStatement = string.Empty;

			if (tz != string.Empty) { setStatement += string.Format("SET @TZ = '{0}'\n", tz); }
			if (bams != string.Empty) { setStatement += string.Format("SET @BAMS = '{0}'\n", bams); }
			if (mp != string.Empty) { setStatement += string.Format("SET @MP = '{0}'\n", mp); }
            if (manager != string.Empty) { setStatement += string.Format("SET @MANAGER = '{0}'\n", manager); }
			if (dm != string.Empty) { setStatement += string.Format("SET @DM = '{0}'\n", dm); }
			if (name != string.Empty) { setStatement += string.Format("SET @NAME = '{0}\n", name); }
			if (type != string.Empty) { setStatement += string.Format("SET @TYPE = '{0}'\n", type); }
			if (address != string.Empty) { setStatement += string.Format("SET @ADDRESS = '{0}'\n", address); }
			if (city != string.Empty) { setStatement += string.Format("SET @CITY = '{0}'\n", city); }
			if (state != string.Empty) { setStatement += string.Format("SET @STATE='{0}'\n", state); }
			if (zip != string.Empty) { setStatement += string.Format("SET @ZIP='{0}'\n", zip); }
			if (phone != string.Empty) { setStatement += string.Format("SET @PHONE='{0}'\n", phone); }
            if (ip != string.Empty) { setStatement += string.Format("SET @IP='{0}'\n", ip); }

			string query = string.Format("{0} \n {1} \n {2}",
				SQLSettings.Default._StoreSearchDeclare,
				setStatement,
				SQLSettings.Default._StoreSearch);
			Console.WriteLine(query);
			return Select(query);
		}

		static public DataTable dt_LastCategory()
		{
			SqlParameter p = new SqlParameter("@TECH", Environment.UserName.ToUpper());
            return Select(SQLSettings.Default._LastCategory, p);
		}

		static public DataTable ListTables()
		{
			return Select("SELECT Distinct TABLE_NAME FROM information_schema.TABLES");
		}



		/// <summary>
		/// executes select statement
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




		static public object DBNullIfEmpty(this string str)
		{
			return !String.IsNullOrEmpty(str) ? str : (object)DBNull.Value;
        }



		/* DELETE */

		/// <summary>
		/// clears the temporary computer table
		/// </summary>
		/// <returns>true on success</returns>
		static public bool b_ClearTempComputers()
		{
			string sql = "DELETE FROM [Test].[dbo].[Computers]";
			return Delete(sql);
		}

		/// <summary>
		/// executes delete statement
		/// </summary>
		/// <param name="deleteSQL">statment to execute</param>
		/// <returns>true on success</returns>
		public static bool Delete(string deleteSQL)
		{
			return Delete(deleteSQL, new List<SqlParameter>());
		}
		/// <summary>
		/// executes delete statement
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





		/* UPDATE */

		public static bool EditCalls_UpdateCall(
			string id, 
			string store, 
			string topic, 
			string details, 
			string type, 
			bool trax,
			string url)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@id", int.Parse(id)));
			paramList.Add(new SqlParameter("@store", int.Parse(store)));
			paramList.Add(new SqlParameter("@topic", topic));
			paramList.Add(new SqlParameter("@details", details));
			paramList.Add(new SqlParameter("@type", type));
			paramList.Add(new SqlParameter("@trax", trax));
			paramList.Add(new SqlParameter("@url", url));
            return Update(SQLSettings.Default._UpdateWrapUp, paramList);
		}
		

		/// <summary>
		/// updates the call information
		/// </summary>
		/// <param name="ID">call id</param>
		/// <param name="sCategory">the call's Category</param>
		/// <param name="Problem">the call's problem</param>
		/// <param name="Solution">the call's solution</param>
		/// <param name="Type">teh call's type (direction)</param>
		/// <returns>on success</returns>
		public static bool b_updateCallID(
			string ID,
			string Store,
			string Category,
			string Problem,
			string Solution,
			string Type)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store", Store));
			parameters.Add(new SqlParameter("@Category", Category));
			parameters.Add(new SqlParameter("@problem", Problem));
			parameters.Add(new SqlParameter("@solution", Solution));
			parameters.Add(new SqlParameter("@type", Type));
			parameters.Add(new SqlParameter("@ID", ID));

			string updateSQL = "UPDATE [Calls] SET [store] = @store, [Category] = @Category,[problem] = @problem,[solution] = @solution,[type] = @type WHERE [id] = @ID";
			return Update(updateSQL, parameters);
		}

		public static bool b_updateStoreInfo(
			string Store,
			string Manager,
			string MPID,
			string Address,
			string Email,
			string City,
			string DM,
			string Name,
			string Type,
			string State,
			string Zip,
			string TZ,
            string RM)
		{
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add(new SqlParameter("@store",Store));
			parameters.Add(new SqlParameter("@manager",Manager));
			parameters.Add(new SqlParameter("@mpid",MPID));
			parameters.Add(new SqlParameter("@address",Address));
			parameters.Add(new SqlParameter("@email",Email));
			parameters.Add(new SqlParameter("@city",City));
			parameters.Add(new SqlParameter("@dm", DM));
			parameters.Add(new SqlParameter("@name",Name));
			parameters.Add(new SqlParameter("@type",Type));
			parameters.Add(new SqlParameter("@state",State));
			parameters.Add(new SqlParameter("@zip", Zip));
			parameters.Add(new SqlParameter("@tz",TZ));
            parameters.Add(new SqlParameter("@rm", RM));

			string updateSQL = "UPDATE [STORES] SET [manager] = @manager,[MP] = @mpid,[address] = @address,[email] = @email,[city] = @city,[dm] = @dm, [RM] = @rm, [name] = @name,[type] = @type,[state] = @state,[zip] = @zip,[TZ] = @tz WHERE [store] = @store";
            return Update(updateSQL, parameters);
            

		}
        public static bool b_UpdatePhone(string phone,string store)
        {
            List<SqlParameter>parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@phone",phone));
            parameters.Add(new SqlParameter("@store",store));

            return Update(SQLSettings.Default._StoreInfoPhone, parameters);
        }

		/// <summary>
		/// Inserts Text area of info form into sql
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

		static public bool b_UsefulInfo_EditTabTitle(string oldName, string newName)
		{
			List<SqlParameter> paramList = new List<SqlParameter>();
			paramList.Add(new SqlParameter("@old", oldName));
			paramList.Add(new SqlParameter("@new", newName));
			string sql = "UPDATE [Info] SET [tab] = @new WHERE [tab] = @old";
			return Insert(sql, paramList);
		}


		/// <summary>
		/// Update a table's information
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


		/* USER STORED PROCEDURES */




        static public bool b_ExecuteQuery(string query, List<SqlParameter> paramList)
        {
            SqlConnection sqlConn = new SqlConnection(connString);

            try
            {
                sqlConn.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConn);
                sqlCommand.Parameters.AddRange(paramList.ToArray());
                return sqlCommand.ExecuteNonQuery() > 0 ? true : false;
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConn.Close();
            }
        }

	}
}

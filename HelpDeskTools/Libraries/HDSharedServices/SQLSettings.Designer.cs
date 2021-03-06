﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shared {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    public sealed partial class SQLSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static SQLSettings defaultInstance = ((SQLSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new SQLSettings())));
        
        public static SQLSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("rochdclogp01")]
        public string _ServerName {
            get {
                return ((string)(this["_ServerName"]));
            }
            set {
                this["_ServerName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("RetailHD")]
        public string _Database {
            get {
                return ((string)(this["_Database"]));
            }
            set {
                this["_Database"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("select\n\tcount([techID]) [Total]\nfrom\n\t[Calls]\n\tleft join \n\t\t[Technicians]\n\ton\n\t\t[" +
            "Calls].[techID] = [Technicians].[id]\nwhere\n\t[date] > dbo.StartOfDay() and\n\tlower" +
            "([type]) = \'in\'")]
        public string _TeamCallCount {
            get {
                return ((string)(this["_TeamCallCount"]));
            }
            set {
                this["_TeamCallCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DECLARE @STORE INT\nDECLARE @TYPE VARCHAR(50)\nDECLARE @DATE1 DATE\nDECLARE @DATE2 D" +
            "ATE\nDECLARE @CATEGORY VARCHAR(50)\nDECLARE @TOPIC VARCHAR(50)\nDECLARE @TECH VARCH" +
            "AR(50)\nDECLARE @DETAILS VARCHAR(2000)\nDECLARE @TRAX BIT\nDECLARE @URL VARCHAR(200" +
            "0)\n")]
        public string _HistoryDeclare {
            get {
                return ((string)(this["_HistoryDeclare"]));
            }
            set {
                this["_HistoryDeclare"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"SELECT
	TOP {0}
	[Calls].[id] as [ID],
	[Calls].[date] as [Date],
	CONVERT(DATE, [Calls].[date]) as [DateOnly],
	CONVERT(TIME, [Calls].[date]) as [Time],
	[Calls].[store] as [Store],
	[Technicians].[initials] as [Tech],
	[Categories].[category] as [Category],
	[Topics].[topic] as [Topic],
	[Calls].[details] as [Details],
	[Calls].[type] as [In/Out],
	[Calls].[trax] as [Trax],
	[Calls].[url] as [URL]
FROM
	[Calls]
	INNER JOIN
		[Technicians]
	ON
		[Calls].[techID] = [Technicians].[id]
	INNER JOIN
		[Topics]
	ON
		[Calls].[topID] = [Topics].[id]
	INNER JOIN
		[Categories]
	ON
		[Topics].[catID] = [Categories].[id]
WHERE
	(@STORE IS NULL OR ([store] = @STORE)) AND
	(@TYPE IS NULL OR ([type] = @TYPE)) AND
	(@DATE1 IS NULL OR (CONVERT(DATE,[date]) LIKE @DATE1)) AND
	(@CATEGORY IS NULL OR ([category] = @CATEGORY)) AND
	(@TOPIC IS NULL OR ([topic] = @TOPIC)) AND
	(@TECH IS NULL OR ([initials] = @TECH)) AND
	(@DETAILS IS NULL OR (LOWER([details]) LIKE '%'+LOWER(@DETAILS)+'%')) AND
	(@TRAX IS NULL OR ([trax] = @TRAX)) AND
	(@URL IS NULL OR ([url] = @URL))
ORDER BY
	[date]
DESC 
")]
        public string _HistorySearch {
            get {
                return ((string)(this["_HistorySearch"]));
            }
            set {
                this["_HistorySearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"SELECT
	[Calls].[id] as [ID],
	[Calls].[date] as [Date],
	CONVERT(DATE, [Calls].[date]) as [DateOnly],
	CONVERT(TIME, [Calls].[date]) as [Time],
	[Calls].[store] as [Store],
	[Technicians].[initials] as [Tech],
	[Categories].[category] as [Category],
	[Topics].[topic] as [Topic],
	[Calls].[details] as [Details],
	[Calls].[type] as [In/Out],
	[Calls].[trax] as [Trax],
	[Calls].[url] as [URL]
FROM
	[Calls]
	INNER JOIN
		[Technicians]
	ON
		[Calls].[techID] = [Technicians].[id]
	INNER JOIN
		[Topics]
	ON
		[Calls].[topID] = [Topics].[id]
	INNER JOIN
		[Categories]
	ON
		[Topics].[catID] = [Categories].[id]
WHERE
	(@STORE IS NULL OR ([store] = @STORE)) AND
	(@TYPE IS NULL OR ([type] = @TYPE)) AND
	(@DATE1 IS NULL OR (CONVERT(DATE,[date]) BETWEEN @DATE1 AND @DATE2)) AND
	(@CATEGORY IS NULL OR ([category] = @CATEGORY)) AND
	(@TOPIC IS NULL OR ([topic] = @TOPIC)) AND
	(@TECH IS NULL OR ([initials] = @TECH)) AND
	(@DETAILS IS NULL OR (LOWER([details]) LIKE '%'+LOWER(@DETAILS)+'%')) AND
	(@TRAX IS NULL OR ([trax] = @TRAX)) AND
	(@URL IS NULL OR ([url] = @URL))
ORDER BY
	[date]
DESC 
")]
        public string _HistorySearchRange {
            get {
                return ((string)(this["_HistorySearchRange"]));
            }
            set {
                this["_HistorySearchRange"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT TOP 1\n* FROM\n\t[Stores] as S\n\tfull join \n\t\t[Phones] as P\n\ton [S].[store] = " +
            "[P].[store]\nWHERE\n\t[S].[store] = @store\nORDER BY\n\t[P].[line]\n")]
        public string _StoreInfo {
            get {
                return ((string)(this["_StoreInfo"]));
            }
            set {
                this["_StoreInfo"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"SELECT
	TOP 1
	[Categories].[category]
FROM
	[Calls]
	INNER JOIN
		[Categories]
	ON
		[Calls].[catID] = [Categories].[id]
	INNER JOIN
		[Technicians]
	ON
		[Calls].[techID] = [Technicians].[id]
WHERE
	[Technicians].[technician] = @TECH
ORDER BY
	[Calls].[id]
DESC
")]
        public string _LastCategory {
            get {
                return ((string)(this["_LastCategory"]));
            }
            set {
                this["_LastCategory"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("GlobalHD")]
        public string _DatabaseGlobal {
            get {
                return ((string)(this["_DatabaseGlobal"]));
            }
            set {
                this["_DatabaseGlobal"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"DECLARE @TZ VARCHAR(50)
DECLARE @BAMS VARCHAR(50)
DECLARE @MP VARCHAR(50)
DECLARE @MANAGER VARCHAR(50)
DECLARE @DM VARCHAR(50)
DECLARE @NAME VARCHAR(50)
DECLARE @TYPE VARCHAR(50)
DECLARE @ADDRESS VARCHAR(50)
DECLARE @CITY VARCHAR(50)
DECLARE @STATE VARCHAR(50)
DECLARE @ZIP VARCHAR(50)
DECLARE @PHONE VARCHAR(50)
DECLARE @IP VARCHAR(50)")]
        public string _StoreSearchDeclare {
            get {
                return ((string)(this["_StoreSearchDeclare"]));
            }
            set {
                this["_StoreSearchDeclare"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nSELECT\r\n\t[Stores].[store],\r\n\t[TZ],\r\n\t[manager],\r\n\t[dm],\r\n\t[name],\r\n\t[type],\r\n\t[" +
            "address],\r\n\t[city],\r\n\t[state],\r\n\t[zip],\r\n\t[phone],\r\n\t[rank],\r\n\t[income]\r\nFROM\r\n\t" +
            "[Stores]\r\n\tinner join [Phones] on [Phones].store=[Stores].store\r\nWHERE\r\n\t(@TZ IS" +
            " NULL OR (LOWER([TZ]) = LOWER(@TZ))) AND\r\n\t(@BAMS IS NULL OR (LOWER([BAMS]) LIKE" +
            " \'%\'+LOWER(@BAMS)+\'%\')) AND\r\n\t(@MP IS NULL OR ([MP] = @MP)) AND\r\n\t(@MANAGER IS N" +
            "ULL OR (LOWER([manager]) LIKE \'%\'+LOWER(@MANAGER)+\'%\')) AND\r\n\t(@DM IS NULL OR (L" +
            "OWER([dm]) LIKE \'%\'+LOWER(@DM)+\'%\')) AND\r\n\t(@NAME IS NULL OR (LOWER([name]) LIKE" +
            " \'%\'+LOWER(@NAME)+\'%\')) AND\r\n\t(@TYPE IS NULL OR (LOWER([type]) LIKE \'%\'+LOWER(@T" +
            "YPE)+\'%\')) AND\r\n\t(@ADDRESS IS NULL OR (LOWER([address]) LIKE \'%\'+LOWER(@ADDRESS)" +
            "+\'%\')) AND\r\n\t(@CITY IS NULL OR (LOWER([city]) LIKE \'%\'+LOWER(@CITY)+\'%\')) AND\r\n\t" +
            "(@STATE IS NULL OR (LOWER([state]) = LOWER(@STATE))) AND\r\n\t(@ZIP IS NULL OR (LOW" +
            "ER([zip]) = LOWER(@ZIP))) AND\r\n\t(@PHONE IS NULL OR ([phone] = dbo.RemoveNonNumer" +
            "icCharacters(@PHONE))) AND\r\n\t(\r\n\t\t@IP IS NULL OR \r\n\t\tCONCAT([1st],\'.\',[2nd],\'.\'," +
            "[3rd],\'.\',[lan1]) LIKE \'%\'+@IP+\'%\' OR \r\n\t\tCONCAT([1st],\'.\',[2nd],\'.\',[3rd],\'.\',[" +
            "lan2]) LIKE \'%\'+@IP+\'%\' OR\r\n\t\tCONCAT([1st],\'.\',[2nd],\'.\',[3rd],\'.\',[lan3]) LIKE " +
            "\'%\'+@IP+\'%\' OR\r\n\t\tCONCAT([1st],\'.\',[2nd],\'.\',[3rd],\'.\',[lan4]) LIKE \'%\'+@IP+\'%\' " +
            "OR\r\n\t\tCONCAT([1st],\'.\',[2nd],\'.\',[3rd],\'.\',[gate1]) LIKE \'%\'+@IP+\'%\' OR\r\n\t\tCONCA" +
            "T([1st],\'.\',[2nd],\'.\',[3rd],\'.\',[gate2]) LIKE \'%\'+@IP+\'%\' OR\r\n\t\tCONCAT([1st],\'.\'" +
            ",[2nd],\'.\',[3rd],\'.\',[gate3]) LIKE \'%\'+@IP+\'%\' OR\r\n\t\tCONCAT([1st],\'.\',[2nd],\'.\'," +
            "[3rd],\'.\',[gate4]) LIKE \'%\'+@IP+\'%\'\r\n\t)\r\n")]
        public string _StoreSearch {
            get {
                return ((string)(this["_StoreSearch"]));
            }
            set {
                this["_StoreSearch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\nUPDATE \n\t[Phones] \nSET \n\t[phone] = @phone\nWHERE \n\t[store] = @store \nAND [line]=\'" +
            "1\'\n\nIF @@ROWCOUNT = 0\nBEGIN\n\tINSERT INTO \n\t\t[Phones] ([phone], [store])\n\tVALUES\n" +
            "\t\t(@phone, @store)\nEND\n")]
        public string _StoreInfoPhone {
            get {
                return ((string)(this["_StoreInfoPhone"]));
            }
            set {
                this["_StoreInfoPhone"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"select
	[Calls].[id] as [ID],
	[Calls].[store] as [Store],
	[Calls].[date] [Date],
	[Technicians].[initials] as [Tech],
	[Categories].[category] as [Category],
	[Topics].[topic] as [Topic],
	[Calls].[details] as [Details],
	[Calls].[type] as [In/Out],
	[Calls].[trax] as [Trax],
	[Calls].[url] as [URL]
from
	[Calls]
	left join
		[Topics] on [Calls].[topID] = [Topics].id
	left join
		[Categories] on [Topics].[catID] = [Categories].[id]
	left join
		[Technicians] on [Calls].[techID] = [Technicians].[id]
where
	[Calls].[store] = @store
order by
	[Calls].[date] desc

")]
        public string _RecentCallsByStore {
            get {
                return ((string)(this["_RecentCallsByStore"]));
            }
            set {
                this["_RecentCallsByStore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT \r\n\t[computer] \r\nFROM \r\n\t[Computers] \r\nWHERE \r\n\t[store] = @store")]
        public string _ComputersByStore {
            get {
                return ((string)(this["_ComputersByStore"]));
            }
            set {
                this["_ComputersByStore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("select \r\n\t[category], \r\n\t[topic], \r\n\t[mandatory] \r\nfrom \r\n\t[Topics] \r\n\tleft join " +
            "\r\n\t\t[Categories] \r\n\ton \r\n\t\t[Topics].[catID] = [Categories].[id]\r\nwhere\r\n\t[active" +
            "] = \'TRUE\'")]
        public string _CategoriesWithTopics {
            get {
                return ((string)(this["_CategoriesWithTopics"]));
            }
            set {
                this["_CategoriesWithTopics"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"insert into 
	[Calls] (
		[store], 
		[details], 
		[catID], 
		[topID], 
		[type], 
		[techID],
		[trax],
		[url]) 
values (
	@store, 
	@details, 
	(Select [id] from [Categories] where [category] = @category), 
	(select [id] from [Topics] where [topic] = @topic ), 
	@type, 
	(select [id] from [Technicians] where [technician] = @technician),
	@trax,
	@url
	)
")]
        public string _LogCall {
            get {
                return ((string)(this["_LogCall"]));
            }
            set {
                this["_LogCall"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("select\r\n\tcount([techID]) [Total]\r\nfrom\r\n\t[Calls]\r\n\tleft join \r\n\t\t[Technicians]\r\n\t" +
            "on\r\n\t\t[Calls].[techID] = [Technicians].[id]\r\nwhere\r\n\t[date] > dbo.StartOfDay() a" +
            "nd\r\n\tlower([Technicians].[technician]) = lower(@TECH) and\r\n\tlower([type]) = \'in\'" +
            "\r\n")]
        public string _UserCallCount {
            get {
                return ((string)(this["_UserCallCount"]));
            }
            set {
                this["_UserCallCount"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"update
	[Calls] 
set 
	[store] = @store, 
	[catID] = (select [catID] from [Topics] where topic = @topic), 
	[topID] = (select [id] from [Topics] where [topic] = @topic), 
	[details] = @details, 
	[type] = @type, 
	[trax] = @trax,
	[url] = @url
where 
	[Calls].[id] = @id
")]
        public string _UpdateWrapUp {
            get {
                return ((string)(this["_UpdateWrapUp"]));
            }
            set {
                this["_UpdateWrapUp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Insert into [Topics] ([topic], [catID], [active], [mandatory])\r\nvalues\r\n\t(@topic," +
            "\r\n\t(select [Categories].[id] from [Categories] where [category] = @category),\r\n\t" +
            "\'true\',\r\n\t@mandatory)\r\n")]
        public string _AddCallTopic {
            get {
                return ((string)(this["_AddCallTopic"]));
            }
            set {
                this["_AddCallTopic"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("SELECT \r\n\tp.[store]\r\nFROM \r\n\t[Phones] p\r\n\tINNER JOIN [Stores] s on p.store=s.stor" +
            "e\r\nWHERE \r\n\tp.[phone] LIKE @PHONE and s.[open]=1\r\n")]
        public string _StoreByPhone {
            get {
                return ((string)(this["_StoreByPhone"]));
            }
            set {
                this["_StoreByPhone"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"SELECT 
	Technicians.full_name AS Name, 
	Technicians.technician AS [login], 
	Technicians.id as ID, 
	CurrentStatus, 
	TimeStatusChanged, 
	Information1, 
	Information2 
FROM 
	AgentStatus 
	INNER JOIN 
		Technicians ON 
			AgentStatus.TechnicianID = Technicians.id
WHERE
	[CurrentStatus] != 'LOGOUT' AND
	[technician] != '{0}'")]
        public string _AgentStatus {
            get {
                return ((string)(this["_AgentStatus"]));
            }
            set {
                this["_AgentStatus"] = value;
            }
        }
    }
}

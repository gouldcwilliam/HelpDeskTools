﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PinPadReport.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<!DOCTYPE html><html><head>\r\n<style>\r\ntable, th, td {\r\nborder: 1px solid black;\r\n" +
            "border-collapse: collapse;\r\n}\r\nth, td {\r\npadding: 5px;\r\n}\r\n</style></head>\r\n<p>")]
        public string header {
            get {
                return ((string)(this["header"]));
            }
            set {
                this["header"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("</table></body></html>")]
        public string footer {
            get {
                return ((string)(this["footer"]));
            }
            set {
                this["footer"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("</p>\r\n<body><table style=\"width:100%\">\r\n<tr><th>Date</th><th>Total</th></tr>")]
        public string tableHead {
            get {
                return ((string)(this["tableHead"]));
            }
            set {
                this["tableHead"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string from {
            get {
                return ((string)(this["from"]));
            }
            set {
                this["from"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>chad.gould@wwwinc.com</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection to {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["to"]));
            }
            set {
                this["to"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"
SELECT 
	CONVERT(VARCHAR(10), DATEADD(day,@D,GETDATE()),120),
	COUNT([Calls].[store])
FROM 
	[Calls]
	INNER JOIN
		[Topics] AS [T] ON [T].[id] = [Calls].[topID]
WHERE
	[Calls].[date] > DATEADD(day,@D,GETDATE()) AND
	[Calls].[date] < DATEADD(day,@D+1,GETDATE()) AND
	[T].[topic] = 'Pin Pad'")]
        public string query_calls {
            get {
                return ((string)(this["query_calls"]));
            }
            set {
                this["query_calls"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Pin Pad Report")]
        public string subject {
            get {
                return ((string)(this["subject"]));
            }
            set {
                this["subject"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<tr><td>{0}</td><td>{1}</td></tr>")]
        public string row {
            get {
                return ((string)(this["row"]));
            }
            set {
                this["row"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nSELECT \r\n\tCount([Calls].[store])\r\nFROM \r\n\t[Calls]\r\n\tINNER JOIN\r\n\t\t[Topics] AS [" +
            "T] ON [T].[id] = [Calls].[topID]\r\nWHERE\r\n\t[Calls].[date] < DATEADD(day,-1,GETDAT" +
            "E()) AND\r\n\t[Calls].[date] > DATEADD(day,-8,GETDATE()) AND\r\n\t[T].[topic] = \'Pin P" +
            "ad\'\r\n")]
        public string query_count {
            get {
                return ((string)(this["query_count"]));
            }
            set {
                this["query_count"] = value;
            }
        }
    }
}

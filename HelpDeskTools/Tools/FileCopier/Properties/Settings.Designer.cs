﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileCopier.Properties {
    
    
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
        [global::System.Configuration.DefaultSettingValueAttribute("\r\n<!DOCTYPE html><html><head>\r\n<style>\r\ntable, th, td {\r\nborder: 1px solid black;" +
            "\r\nborder-collapse: collapse;\r\n}\r\nth, td {\r\npadding: 5px;\r\n}\r\n</style></head>\r\n<p" +
            ">")]
        public string _EmailHeader {
            get {
                return ((string)(this["_EmailHeader"]));
            }
            set {
                this["_EmailHeader"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("</p>\r\n<body><table style=\"width:100%\">\r\n<tr><th>Computer Name</th><th>Message</th" +
            "><th>File</th></tr>")]
        public string _EmailTableHead {
            get {
                return ((string)(this["_EmailTableHead"]));
            }
            set {
                this["_EmailTableHead"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<tr><td>{0}</td><td>{1}</td><td>{2}</td></tr>")]
        public string _EmailTableRow {
            get {
                return ((string)(this["_EmailTableRow"]));
            }
            set {
                this["_EmailTableRow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("</table></body></html>")]
        public string _EmailFooter {
            get {
                return ((string)(this["_EmailFooter"]));
            }
            set {
                this["_EmailFooter"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("chad.gould@wwwinc.com")]
        public string _To {
            get {
                return ((string)(this["_To"]));
            }
            set {
                this["_To"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("File Copier Results")]
        public string _Subject {
            get {
                return ((string)(this["_Subject"]));
            }
            set {
                this["_Subject"] = value;
            }
        }
    }
}

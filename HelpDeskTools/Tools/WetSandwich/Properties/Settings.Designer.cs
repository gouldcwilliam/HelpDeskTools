﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WetSandwich.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("retailhelpdesk@wwwinc.com")]
        public string from {
            get {
                return ((string)(this["from"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("chad.gould@wwwinc.com")]
        public string to {
            get {
                return ((string)(this["to"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Multi/RedIron/Verifone Check")]
        public string subject {
            get {
                return ((string)(this["subject"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\n<!DOCTYPE html><html><head>\r\n<style>\r\ntable, th, td {\r\nborder: 1px solid black;" +
            "\r\nborder-collapse: collapse;\r\n}\r\nth, td {\r\npadding: 5px;\r\n}\r\n</style></head>\r\n<p" +
            ">")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("</table></body></html>\r\n")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{" +
            "6}</td></tr>\r\n")]
        public string body {
            get {
                return ((string)(this["body"]));
            }
            set {
                this["body"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("</p>\r\n<body><table style=\"width:100%\">\r\n<tr><th>Computer Name</th><th>Multi</th><" +
            "th>RedIron</th><th>Verifone</th><th>POSBuild</th><th>RI XML</th><th>Notes</th></" +
            "tr>\r\n")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("Build1149")]
        public string buildVersion {
            get {
                return ((string)(this["buildVersion"]));
            }
            set {
                this["buildVersion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("402,403,404,545,546,544")]
        public string ignore {
            get {
                return ((string)(this["ignore"]));
            }
            set {
                this["ignore"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4.2.12.178")]
        public string multiVersion {
            get {
                return ((string)(this["multiVersion"]));
            }
            set {
                this["multiVersion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2.0.0.926")]
        public string riVersion {
            get {
                return ((string)(this["riVersion"]));
            }
            set {
                this["riVersion"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4.4.5-20151127")]
        public string vfVersion {
            get {
                return ((string)(this["vfVersion"]));
            }
            set {
                this["vfVersion"] = value;
            }
        }
    }
}

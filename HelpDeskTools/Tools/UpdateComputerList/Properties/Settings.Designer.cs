﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UpdateComputerList.Properties {
    
    
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
        [global::System.Configuration.DefaultSettingValueAttribute("rochdclogp01")]
        public string _serverName {
            get {
                return ((string)(this["_serverName"]));
            }
            set {
                this["_serverName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("RetailHD")]
        public string _dataBase {
            get {
                return ((string)(this["_dataBase"]));
            }
            set {
                this["_dataBase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("[RetailHD].[dbo].[Computers]")]
        public string _tableName {
            get {
                return ((string)(this["_tableName"]));
            }
            set {
                this["_tableName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nUPDATE \r\n\t[Stores] \r\nSET \r\n\t[open] = 0 \r\nWHERE \r\n\t[store] NOT IN ( \r\n\t\tSELECT [" +
            "S].[store] \r\n\t\tFROM [Stores] [S] \r\n\t\tJOIN [Computers] [C] ON [S].[store] = [C].[" +
            "store] \r\n\t) \r\n\tAND [store] = [store]\r\n\r\n\r\n")]
        public string _setClosedStores {
            get {
                return ((string)(this["_setClosedStores"]));
            }
            set {
                this["_setClosedStores"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nUPDATE \r\n\t[Stores] \r\nSET \r\n\t[open] = 1\r\n\r\n\r\n")]
        public string _setAllOpen {
            get {
                return ((string)(this["_setAllOpen"]));
            }
            set {
                this["_setAllOpen"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("[Specialists].[dbo].[Computers]")]
        public string _tableNamePOS {
            get {
                return ((string)(this["_tableNamePOS"]));
            }
            set {
                this["_tableNamePOS"] = value;
            }
        }
    }
}

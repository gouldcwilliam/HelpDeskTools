﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Retail_HD.Properties {
    
    
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
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool _ShowLoggedOutUsers {
            get {
                return ((bool)(this["_ShowLoggedOutUsers"]));
            }
            set {
                this["_ShowLoggedOutUsers"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool _ShowMeInAgentStatus {
            get {
                return ((bool)(this["_ShowMeInAgentStatus"]));
            }
            set {
                this["_ShowMeInAgentStatus"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool _EnableAutoReady {
            get {
                return ((bool)(this["_EnableAutoReady"]));
            }
            set {
                this["_EnableAutoReady"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool _LoginEnabled {
            get {
                return ((bool)(this["_LoginEnabled"]));
            }
            set {
                this["_LoginEnabled"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("20, 20")]
        public global::System.Drawing.Point _DrawingLocation {
            get {
                return ((global::System.Drawing.Point)(this["_DrawingLocation"]));
            }
            set {
                this["_DrawingLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("764, 477")]
        public global::System.Drawing.Size _DrawingSize {
            get {
                return ((global::System.Drawing.Size)(this["_DrawingSize"]));
            }
            set {
                this["_DrawingSize"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\\\\wwwint\\roc\\techtmp\\bergman\\Toolsmenu.bat")]
        public string _OldMenuPath {
            get {
                return ((string)(this["_OldMenuPath"]));
            }
            set {
                this["_OldMenuPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("4.2.12.161")]
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
        public string redIronVersion {
            get {
                return ((string)(this["redIronVersion"]));
            }
            set {
                this["redIronVersion"] = value;
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
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool _DisableCiscoDebug {
            get {
                return ((bool)(this["_DisableCiscoDebug"]));
            }
            set {
                this["_DisableCiscoDebug"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool _debugDisableLoginPrompt {
            get {
                return ((bool)(this["_debugDisableLoginPrompt"]));
            }
            set {
                this["_debugDisableLoginPrompt"] = value;
            }
        }
    }
}

﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CiscoFinesseNET {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Finesse : global::System.Configuration.ApplicationSettingsBase {
        
        private static Finesse defaultInstance = ((Finesse)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Finesse())));
        
        public static Finesse Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2015-03-01")]
        public global::System.DateTime LastLogSent {
            get {
                return ((global::System.DateTime)(this["LastLogSent"]));
            }
            set {
                this["LastLogSent"] = value;
            }
        }
    }
}

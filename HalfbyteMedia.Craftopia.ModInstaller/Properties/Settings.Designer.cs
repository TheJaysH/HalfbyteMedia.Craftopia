//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HalfbyteMedia.Craftopia.ModInstaller.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Craftopia")]
        public string DEFAULT_INSTALL_DIRECTORY {
            get {
                return ((string)(this["DEFAULT_INSTALL_DIRECTORY"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(".")]
        public string LOG_PATH {
            get {
                return ((string)(this["LOG_PATH"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>UWP Dumper|d|https://github.com/Wunkolo/UWPDumper/releases/download/6.9.2021/UWPDumper-x64.zip</string>
  <string>BepInEx|d|https://github.com/BepInEx/BepInEx/releases/download/v5.4.18/BepInEx_x64_5.4.18.0.zip</string>
  <string>Microsoft Visual C++ Redistributable|i|https://aka.ms/vs/17/release/vc_redist.x64.exe</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection FILE_DOWNLOADS {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FILE_DOWNLOADS"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("shell:appsFolder\\PocketpairInc.Craftopia_ad4psfrxyesvt!Game")]
        public string RUN_CRAFTOPIA {
            get {
                return ((string)(this["RUN_CRAFTOPIA"]));
            }
        }
    }
}

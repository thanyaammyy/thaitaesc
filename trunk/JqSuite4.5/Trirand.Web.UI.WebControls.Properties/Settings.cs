using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
namespace Trirand.Web.UI.WebControls.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0"), CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}
		[ApplicationScopedSetting, DefaultSettingValue("Data Source=.\\SQLEXPRESS;AttachDbFilename=|DataDirectory|\\NORTHWND.MDF;Integrated Security=True;User Instance=True"), SpecialSetting(SpecialSetting.ConnectionString), DebuggerNonUserCode]
		public string NORTHWNDConnectionString
		{
			get
			{
				return (string)this["NORTHWNDConnectionString"];
			}
		}
	}
}

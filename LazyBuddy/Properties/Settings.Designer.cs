using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace LazyBuddy.Properties
{
	// Token: 0x02000005 RID: 5
	[CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000003 RID: 3
		public static Settings Default
		{
			// Token: 0x06000011 RID: 17 RVA: 0x00002FE8 File Offset: 0x000011E8
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400000F RID: 15
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}

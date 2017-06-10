using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace LazyBuddy.Properties
{
	// Token: 0x02000004 RID: 4
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002F73 File Offset: 0x00001173
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			// Token: 0x0600000E RID: 14 RVA: 0x00002F80 File Offset: 0x00001180
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("LazyBuddy.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			// Token: 0x0600000F RID: 15 RVA: 0x00002FC8 File Offset: 0x000011C8
			get
			{
				return Resources.resourceCulture;
			}
			// Token: 0x06000010 RID: 16 RVA: 0x00002FDF File Offset: 0x000011DF
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400000D RID: 13
		private static ResourceManager resourceMan;

		// Token: 0x0400000E RID: 14
		private static CultureInfo resourceCulture;
	}
}

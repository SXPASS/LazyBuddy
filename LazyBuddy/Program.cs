using System;
using System.Windows.Forms;

namespace LazyBuddy
{
	// Token: 0x02000003 RID: 3
	internal static class Program
	{
		// Token: 0x0600000C RID: 12 RVA: 0x00002F58 File Offset: 0x00001158
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}

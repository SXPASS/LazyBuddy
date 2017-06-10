using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Fiddler;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace LazyBuddy
{
	// Token: 0x02000002 RID: 2
	public class Form1 : MetroForm
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Form1()
		{
			this.InitializeComponent();
			bool flag = this.LoadConfig() != null;
			if (flag)
			{
				string[] array = this.LoadConfig();
				string text = array[0];
				string text2 = array[1];
				string text3 = array[2];
				this.metroTextBox1.Text = text;
				this.metroTextBox2.Text = text2;
				this.metroTextBox3.Text = text3;
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000020CC File Offset: 0x000002CC
		public static bool InstallCertificate()
		{
			bool flag = !CertMaker.rootCertExists();
			bool result;
			if (flag)
			{
				bool flag2 = !CertMaker.createRootCert();
				if (flag2)
				{
					result = false;
					return result;
				}
				bool flag3 = !CertMaker.trustRootCert();
				if (flag3)
				{
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002110 File Offset: 0x00000310
		private string RandomASCIIString(int len)
		{
			char[] array = new char[len];
			string text = "¢¤¥§¶¼¾æð™š•ÆÁØêëùñð¢¤¥§¶¼¾æð™š•ÆÁØêëùñð¢¤¥§¶¼¾æð™š•ÆÁØêëùñð¢¤¥§¶¼¾æð™š•ÆÁØêëùñð";
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = text[this.rand.Next(text.Length)];
			}
			return new string(array);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002168 File Offset: 0x00000368
		private string RandomGUIDString(int len)
		{
			byte[] inArray = Guid.NewGuid().ToByteArray();
			string text = Convert.ToBase64String(inArray).Replace("=", "").Replace("+", "").Replace("/", "");
			bool flag = len == 0;
			string result;
			if (flag)
			{
				result = text;
			}
			else
			{
				bool flag2 = len > text.Length;
				if (flag2)
				{
					result = text;
				}
				else
				{
					result = text.Substring(0, len);
				}
			}
			return result;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000021E7 File Offset: 0x000003E7
		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text = this.RandomASCIIString(10) + this.RandomGUIDString(10) + this.RandomASCIIString(10);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002210 File Offset: 0x00000410
		private void metroButton1_Click(object sender, EventArgs e)
		{
			bool flag = string.IsNullOrWhiteSpace(this.metroTextBox1.Text) || string.IsNullOrWhiteSpace(this.metroTextBox2.Text) || string.IsNullOrWhiteSpace(this.metroTextBox3.Text);
			if (flag)
			{
				MessageBox.Show("Please input your username and password or select Eb Loader Path Correctly !");
			}
			else
			{
				this.SaveConfig(this.metroTextBox1.Text, this.metroTextBox2.Text, this.metroTextBox3.Text);
				this.metroButton1.Text = "LB Starting..";
				this.metroButton1.Enabled = false;
				byte[] bytes = new WebClient().DownloadData("https://leakod.com/auth/lazy/LazyBuddy.Core.bin");
				File.WriteAllBytes("LazyBuddy.Core.bin", bytes);
				Process.Start(new ProcessStartInfo("LazyBuddy.Core.bin")
				{
					Arguments = string.Concat(new string[]
					{
						this.metroTextBox1.Text,
						"|",
						this.metroTextBox2.Text,
						"|",
						this.metroTextBox3.Text
					}),
					UseShellExecute = false
				});
				Application.Exit();
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002338 File Offset: 0x00000538
		private bool SaveConfig(string user, string pass, string path)
		{
			bool result;
			try
			{
				string path2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LazyBuddy.ini");
				bool flag = File.Exists(path2);
				if (flag)
				{
					File.Delete(path2);
				}
				File.WriteAllLines(path2, new string[]
				{
					user,
					pass,
					path
				});
				result = true;
			}
			catch (Exception var_4_44)
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000023A4 File Offset: 0x000005A4
		private string[] LoadConfig()
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "LazyBuddy.ini");
			bool flag = !File.Exists(path);
			string[] result;
			if (flag)
			{
				result = null;
			}
			else
			{
				string[] array = File.ReadAllLines(path);
				bool flag2 = string.IsNullOrWhiteSpace(array[0]) || string.IsNullOrWhiteSpace(array[1]) || string.IsNullOrWhiteSpace(array[2]) || !File.Exists(array[2]);
				if (flag2)
				{
					result = null;
				}
				else
				{
					result = array;
				}
			}
			return result;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002418 File Offset: 0x00000618
		private void metroTextBox3_Click(object sender, EventArgs e)
		{
			bool flag = this.openFileDialog1.ShowDialog() == DialogResult.OK;
			if (flag)
			{
				this.metroTextBox3.Text = this.openFileDialog1.FileName;
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002454 File Offset: 0x00000654
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000248C File Offset: 0x0000068C
		private void InitializeComponent()
		{
			this.pictureBox1 = new PictureBox();
			this.metroLabel1 = new MetroLabel();
			this.metroButton1 = new MetroButton();
			this.label2 = new Label();
			this.label3 = new Label();
			this.metroTextBox1 = new MetroTextBox();
			this.metroTextBox2 = new MetroTextBox();
			this.label1 = new Label();
			this.metroTextBox3 = new MetroTextBox();
			this.openFileDialog1 = new OpenFileDialog();
			((ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox1.Location = new Point(0, 21);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new Size(474, 87);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.metroLabel1.AutoSize = true;
			this.metroLabel1.BackColor = Color.Black;
			this.metroLabel1.set_FontSize(2);
			this.metroLabel1.set_FontWeight(2);
			this.metroLabel1.ForeColor = Color.FromArgb(255, 128, 0);
			this.metroLabel1.Location = new Point(23, 59);
			this.metroLabel1.Name = "metroLabel1";
			this.metroLabel1.Size = new Size(148, 25);
			this.metroLabel1.set_Style(8);
			this.metroLabel1.TabIndex = 1;
			this.metroLabel1.Text = "LazyBudy Setup";
			this.metroLabel1.set_Theme(2);
			this.metroButton1.Location = new Point(23, 258);
			this.metroButton1.Name = "metroButton1";
			this.metroButton1.Size = new Size(425, 38);
			this.metroButton1.set_Style(8);
			this.metroButton1.TabIndex = 4;
			this.metroButton1.Text = "Login";
			this.metroButton1.set_Theme(2);
			this.metroButton1.set_UseSelectable(true);
			this.metroButton1.Click += new EventHandler(this.metroButton1_Click);
			this.label2.AutoSize = true;
			this.label2.ForeColor = Color.White;
			this.label2.Location = new Point(23, 137);
			this.label2.Name = "label2";
			this.label2.Size = new Size(61, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Username :";
			this.label3.AutoSize = true;
			this.label3.ForeColor = Color.White;
			this.label3.Location = new Point(23, 167);
			this.label3.Name = "label3";
			this.label3.Size = new Size(59, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Password :";
			this.metroTextBox1.get_CustomButton().set_Image(null);
			this.metroTextBox1.get_CustomButton().Location = new Point(334, 1);
			this.metroTextBox1.get_CustomButton().Name = "";
			this.metroTextBox1.get_CustomButton().Size = new Size(21, 21);
			this.metroTextBox1.get_CustomButton().set_Style(4);
			this.metroTextBox1.get_CustomButton().TabIndex = 1;
			this.metroTextBox1.get_CustomButton().set_Theme(1);
			this.metroTextBox1.get_CustomButton().set_UseSelectable(true);
			this.metroTextBox1.get_CustomButton().Visible = false;
			this.metroTextBox1.set_Lines(new string[0]);
			this.metroTextBox1.Location = new Point(91, 135);
			this.metroTextBox1.set_MaxLength(32767);
			this.metroTextBox1.Name = "metroTextBox1";
			this.metroTextBox1.set_PasswordChar('\0');
			this.metroTextBox1.set_ScrollBars(ScrollBars.None);
			this.metroTextBox1.set_SelectedText("");
			this.metroTextBox1.set_SelectionLength(0);
			this.metroTextBox1.set_SelectionStart(0);
			this.metroTextBox1.set_ShortcutsEnabled(true);
			this.metroTextBox1.Size = new Size(356, 23);
			this.metroTextBox1.TabIndex = 7;
			this.metroTextBox1.set_UseSelectable(true);
			this.metroTextBox1.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			this.metroTextBox1.set_WaterMarkFont(new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel));
			this.metroTextBox2.get_CustomButton().set_Image(null);
			this.metroTextBox2.get_CustomButton().Location = new Point(334, 1);
			this.metroTextBox2.get_CustomButton().Name = "";
			this.metroTextBox2.get_CustomButton().Size = new Size(21, 21);
			this.metroTextBox2.get_CustomButton().set_Style(4);
			this.metroTextBox2.get_CustomButton().TabIndex = 1;
			this.metroTextBox2.get_CustomButton().set_Theme(1);
			this.metroTextBox2.get_CustomButton().set_UseSelectable(true);
			this.metroTextBox2.get_CustomButton().Visible = false;
			this.metroTextBox2.set_Lines(new string[0]);
			this.metroTextBox2.Location = new Point(91, 166);
			this.metroTextBox2.set_MaxLength(32767);
			this.metroTextBox2.Name = "metroTextBox2";
			this.metroTextBox2.set_PasswordChar('●');
			this.metroTextBox2.set_ScrollBars(ScrollBars.None);
			this.metroTextBox2.set_SelectedText("");
			this.metroTextBox2.set_SelectionLength(0);
			this.metroTextBox2.set_SelectionStart(0);
			this.metroTextBox2.set_ShortcutsEnabled(true);
			this.metroTextBox2.Size = new Size(356, 23);
			this.metroTextBox2.TabIndex = 8;
			this.metroTextBox2.set_UseSelectable(true);
			this.metroTextBox2.set_UseSystemPasswordChar(true);
			this.metroTextBox2.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			this.metroTextBox2.set_WaterMarkFont(new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel));
			this.label1.AutoSize = true;
			this.label1.ForeColor = Color.White;
			this.label1.Location = new Point(14, 200);
			this.label1.Name = "label1";
			this.label1.Size = new Size(118, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Elobuddy.Loader Path :";
			this.metroTextBox3.get_CustomButton().set_Image(null);
			this.metroTextBox3.get_CustomButton().Location = new Point(290, 1);
			this.metroTextBox3.get_CustomButton().Name = "";
			this.metroTextBox3.get_CustomButton().Size = new Size(21, 21);
			this.metroTextBox3.get_CustomButton().set_Style(4);
			this.metroTextBox3.get_CustomButton().TabIndex = 1;
			this.metroTextBox3.get_CustomButton().set_Theme(1);
			this.metroTextBox3.get_CustomButton().set_UseSelectable(true);
			this.metroTextBox3.get_CustomButton().Visible = false;
			this.metroTextBox3.set_Lines(new string[0]);
			this.metroTextBox3.Location = new Point(135, 195);
			this.metroTextBox3.set_MaxLength(32767);
			this.metroTextBox3.Name = "metroTextBox3";
			this.metroTextBox3.set_PasswordChar('\0');
			this.metroTextBox3.set_PromptText("Click me and select EloBuddy.Loader.exe path");
			this.metroTextBox3.set_ReadOnly(true);
			this.metroTextBox3.set_ScrollBars(ScrollBars.None);
			this.metroTextBox3.set_SelectedText("");
			this.metroTextBox3.set_SelectionLength(0);
			this.metroTextBox3.set_SelectionStart(0);
			this.metroTextBox3.set_ShortcutsEnabled(true);
			this.metroTextBox3.Size = new Size(312, 23);
			this.metroTextBox3.TabIndex = 10;
			this.metroTextBox3.set_UseSelectable(true);
			this.metroTextBox3.set_WaterMark("Click me and select EloBuddy.Loader.exe path");
			this.metroTextBox3.set_WaterMarkColor(Color.FromArgb(109, 109, 109));
			this.metroTextBox3.set_WaterMarkFont(new Font("Segoe UI", 12f, FontStyle.Italic, GraphicsUnit.Pixel));
			this.metroTextBox3.Click += new EventHandler(this.metroTextBox3_Click);
			this.openFileDialog1.Filter = "EloBuddy Loader File|EloBuddy.Loader.exe";
			this.openFileDialog1.Title = "Select EloBuddy.Loader.exe";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(471, 329);
			base.Controls.Add(this.metroTextBox3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.metroTextBox2);
			base.Controls.Add(this.metroTextBox1);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.metroButton1);
			base.Controls.Add(this.metroLabel1);
			base.Controls.Add(this.pictureBox1);
			base.MaximizeBox = false;
			this.MaximumSize = new Size(471, 329);
			this.MinimumSize = new Size(471, 329);
			base.Name = "Form1";
			base.ShowIcon = false;
			base.set_Style(10);
			base.set_Theme(2);
			base.Load += new EventHandler(this.Form1_Load);
			((ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private Random rand = new Random();

		// Token: 0x04000002 RID: 2
		private IContainer components = null;

		// Token: 0x04000003 RID: 3
		private PictureBox pictureBox1;

		// Token: 0x04000004 RID: 4
		private MetroLabel metroLabel1;

		// Token: 0x04000005 RID: 5
		private MetroButton metroButton1;

		// Token: 0x04000006 RID: 6
		private Label label2;

		// Token: 0x04000007 RID: 7
		private Label label3;

		// Token: 0x04000008 RID: 8
		private MetroTextBox metroTextBox1;

		// Token: 0x04000009 RID: 9
		private MetroTextBox metroTextBox2;

		// Token: 0x0400000A RID: 10
		private Label label1;

		// Token: 0x0400000B RID: 11
		private MetroTextBox metroTextBox3;

		// Token: 0x0400000C RID: 12
		private OpenFileDialog openFileDialog1;
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;

namespace csc
{
	public partial class JSForm : BaseForm
	{
		public string Result
		{
			get
			{
				return tbResult.Text;
			}
		}
		public string Code
		{
			get
			{
				return tbCode.Text;
			}
			set
			{
				tbCode.Text = value;
			}
		}
		private string[] MathTable = new string[]
{
			"abs",
			"acos",
			"asin",
			"atan",
			"atan2",
			"ceil",
			"cos",
			"E",
			"exp",
			"floor",
			"LN2",
			"LN10",
			"log",
			"LOG2E",
			"LOG10E",
			"max",
			"min",
			"PI",
			"pow",
			"random",
			"round",
			"sin",
			"sqrt",
			"SQRT1_2",
			"SQRT2",
			"tan"
};
		public JSForm()
		{
			InitializeComponent();
			this.DialogResult = DialogResult.None;
			MakeMenu();
			MakeConMenu();
			btnClose.Click += (semder, e) => { this.DialogResult = DialogResult.Cancel; };
			btnOutput.Click += (semder, e) => { this.DialogResult = DialogResult.OK; };
			btnExec.Click += (semder, e) => { Execute(); };
		}
		// ***************************************************************
		public void InsertStr(string s)
		{
			string line = tbCode.Text;
			int sta = tbCode.SelectionStart;
			int len = tbCode.SelectionLength;
			if (len <= 0)
			{
				line = line.Insert(sta, s);
				tbCode.Text = line;
				tbCode.Select(sta + s.Length, 0);
			}
			else
			{
				line = line.Substring(0, sta) + s + line.Substring(sta + len);
				tbCode.Text = line;
				tbCode.Select(sta + s.Length, 0);
			}
		}
		// ***************************************************************
		public void MakeMenu()
		{
			this.SuspendLayout();
			this.menuStrip1.SuspendLayout();

			foreach (string s in MathTable)
			{
				ToolStripMenuItem menu = new ToolStripMenuItem();
				menu.Name = "Menu" + s;
				menu.Text = "Math." + s;
				menu.Click += (sender, e) =>
				{
					ToolStripMenuItem? menu = (ToolStripMenuItem?)sender;
					if (menu != null)
					{
						InsertStr(menu.Text);
					}
				};
				MathMenu.DropDownItems.Add(menu);
			}
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		// ***************************************************************
		public void MakeConMenu()
		{
			this.contextMenuStrip1.Items.Clear();
			foreach (string s in MathTable)
			{
				ToolStripMenuItem menu = new ToolStripMenuItem();
				menu.Name = "Menu" + s;
				menu.Text = "Math." + s;
				menu.Click += (sender, e) =>
				{
					ToolStripMenuItem? menu = (ToolStripMenuItem?)sender;
					if (menu != null)
					{
						InsertStr(menu.Text);
					}
				};
				this.contextMenuStrip1.Items.Add(menu);
			}

		}
		private void Execute()
		{
			string exp = tbCode.Text.Trim();
			if (exp != "")
			{
				string result = "";
				try
				{
					using (var engine = new V8ScriptEngine())
					{
						var obj = engine.Evaluate(exp);
						if (obj != null)
						{
							string? s = obj.ToString();
							if (s != null) result = s;
						}
					}
					tbResult.Text = result;
				}
				catch
				{
				}
			}
		}
		protected override void OnLoad(EventArgs e)
		{
			//設定ファイルの読み込み
			PrefFile pref = new PrefFile(this, "csc_TextFilDialog");
			pref.Load();
			Rectangle? rct = pref.GetBounds();
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			//設定ファイルの保存
			PrefFile pref = new PrefFile(this, "csc_TextFilDialog");
			pref.SetBounds();
			pref.Save();
		}
	}
}

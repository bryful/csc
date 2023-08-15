using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;
using System.Diagnostics;
namespace csc
{
	public partial class CCalc : BaseForm
	{
		public string ValueStr
		{
			get
			{
				if (lbError.Text == "")
				{
					return textBox1.Text.Trim();
				}
				else
				{
					return "";
				}

			}
			set
			{
				textBox1.Text = value.Trim();
				textBox1.Select(textBox1.Text.Length, 0);
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
		private List<string> UndoData = new List<string>();
		public CCalc()
		{
			InitializeComponent();
			MakeMenu();
			MakeConMenu();

			key10Pad1.Btn += (sender, e) =>
			{

				Key10Pad? kp = (Key10Pad?)sender;
				if (kp != null)
				{
					Debug.WriteLine("Padd" + e.Cmd);
					SetKey(e.Cmd);
				}

			};
		}
		// ***************************************************************
		private void MathMenu_Click(object? sender, EventArgs e)
		{
			if (sender == null) return;
			ToolStripMenuItem menu = (ToolStripMenuItem)sender;
			InsertStr(menu.Text);
			lbError.Text = "";
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
				menu.Click += MathMenu_Click;
				mathMenu.DropDownItems.Add(menu);
			}
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Return) || (e.KeyCode == Keys.Enter))
			{
				CalcExec();
			}
			else if ((e.Control == true) && (e.KeyCode == Keys.M))
			{
				ShowCMenu();
			}

		}
		public void MakeConMenu()
		{
			this.contextMenuStrip1.Items.Clear();
			foreach (string s in MathTable)
			{
				ToolStripMenuItem menu = new ToolStripMenuItem();
				menu.Name = "Menu" + s;
				menu.Text = "Math." + s;
				menu.Click += MathMenu_Click;
				this.contextMenuStrip1.Items.Add(menu);
			}

		}
		// ***************************************************************
		public void ShowCMenu()
		{
			this.contextMenuStrip1.Show(this.textBox1, new Point(this.textBox1.Width, this.textBox1.Height));

		}
		// ***************************************************************
		public void InsertStr(string s)
		{
			string line = textBox1.Text;
			int sta = textBox1.SelectionStart;
			int len = textBox1.SelectionLength;
			if (len <= 0)
			{
				line = line.Insert(sta, s);
				textBox1.Text = line;
				textBox1.Select(sta + s.Length, 0);
			}
			else
			{
				line = line.Substring(0, sta) + s + line.Substring(sta + len);
				textBox1.Text = line;
				textBox1.Select(sta + s.Length, 0);
			}
		}
		// ***************************************************************
		public void TextClear()
		{
			textBox1.Text = "";
		}
		// ***************************************************************
		public void BackSpace()
		{
			if (textBox1.Text.Length > 0)
			{
				string line = textBox1.Text;
				line = line.Substring(0, line.Length - 1);
				textBox1.Text = line;
				textBox1.Select(line.Length, 0);
			}
		}
		// ***************************************************************
		public void CalcExec()
		{
			string exp = textBox1.Text.Trim();
			if (exp != "")
			{
				bool ok = false;
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

					textBox1.Text = result;
					textBox1.Select(textBox1.Text.Length, 0);
					ok = true;
				}
				catch
				{
					lbError.Text = "errer!";
					ok = false;
				}
				if (ok)
				{
					UndoData.Add(exp);
				}
			}

		}
		public void Undo()
		{
			if (UndoData.Count > 0)
			{
				textBox1.Text = UndoData[UndoData.Count - 1];
				UndoData.RemoveAt(UndoData.Count - 1);
			}
		}
		private void SetKey(string s)
		{
			if (s == "&&") s = "&";
			if (s == "Sp") s = " ";
			if (s == "CLR")
			{
				TextClear();
			}
			else if (s == "BS")
			{
				BackSpace();


			}
			else if (s == "Ent")
			{
				CalcExec();
			}
			else
			{
				InsertStr(s);
			}

		}
		private void MenuUndo_Click(object sender, EventArgs e)
		{
			Undo();
		}


		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if (lbError.Text != "")
			{
				lbError.Text = "";
			}

		}
		public void CloseExec()
		{
			this.DialogResult = DialogResult.Cancel;
		}
		public void OutputAndClose()
		{
			//Clipboard.SetText(ValueStr);
			this.DialogResult = DialogResult.OK;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			CloseExec();
		}

		private void btnOutputAndClose_Click(object sender, EventArgs e)
		{
			OutputAndClose();
		}

		protected override void OnLoad(EventArgs e)
		{
			//設定ファイルの読み込み
			PrefFile pref = new PrefFile(this, "csc_Calc");
			pref.Load();
			object? pp = null;
			pp = pref.JsonFile.ValueAuto("Point", typeof(Point).Name);
			if (pp != null) this.Location = (Point)pp;
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			//設定ファイルの保存
			PrefFile pref = new PrefFile(this, "csc_Calc");
			pref.JsonFile.SetValue("Point", this.Location);
			pref.Save();
		}

	}

}

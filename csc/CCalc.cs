﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.CodeDom.Compiler;
using System.Reflection;
using BRY;
namespace csc
{
	public partial class CCalc : Form
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
		}
		// ***************************************************************
		private void MathMenu_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem menu = (ToolStripMenuItem)sender;
			InsertStr(menu.Text);
			lbError.Text = "";
		}
		// ***************************************************************
		public void MakeMenu()
        {
			this.SuspendLayout();
			this.menuStrip1.SuspendLayout();

			foreach(string s in MathTable)
            {
				ToolStripMenuItem menu = new ToolStripMenuItem();
				menu.Name = "Menu" + s;
				menu.Text = "Math."+s;
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
			if((e.KeyCode == Keys.Return)||(e.KeyCode == Keys.Enter))
            {
				CalcExec();
            }else if ((e.Control==true)&&(e.KeyCode==Keys.M))
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
			this.contextMenuStrip1.Show(this.textBox1, new Point(this.textBox1.Width,this.textBox1.Height));

		}
		// ***************************************************************
		public void InsertStr(string s)
		{
			string line = textBox1.Text;
			int sta = textBox1.SelectionStart;
			int len = textBox1.SelectionLength;
			if(len<=0)
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
			if (textBox1.Text.Length>0)
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
					JScriptEvaluator jscript = new JScriptEvaluator();
					result = jscript.Eval(exp);
					textBox1.Text = result;
					textBox1.Select(textBox1.Text.Length, 0);
					ok = true;
				}
				catch
				{
					lbError.Text = "errer!";
					ok = false;
				}
				if(ok)
				{
					UndoData.Add(exp);
				}
			}

		}
		public void Undo()
		{
			if(UndoData.Count>0)
			{
				textBox1.Text = UndoData[UndoData.Count - 1];
				UndoData.RemoveAt(UndoData.Count - 1);
			}
		}
		private void btnEnt_Click(object sender, EventArgs e)
		{
			CalcExec();
		}

		private void btnInsetStr_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			string s = btn.Text;
			if (s == "&&") s = "&";
			InsertStr(s);

		}

		private void btnSpace_Click(object sender, EventArgs e)
		{
			InsertStr(" ");
		}

		private void MenuUndo_Click(object sender, EventArgs e)
		{
			Undo();
		}

		private void btnBS_Click(object sender, EventArgs e)
		{
			BackSpace();
		}

		private void btnSLR_Click(object sender, EventArgs e)
		{
			TextClear();
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

		private void CCalc_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			JsonPref pref = new JsonPref("csc_CCalc");
			//Console.WriteLine(pref.FilePath);
			bool bb = false;
			if (pref.Load())
			{
				bool ok = false;
				Rectangle rct = pref.GetRect("Rect", out ok);
				if (ok)
				{
					foreach (Screen s in Screen.AllScreens)
					{
						Rectangle r = s.Bounds;
						if (JsonPref.IsInRect(r, rct))
						{
							bb = true;
							break;
						}
					}
					if (bb)
					{
						this.SetBounds(rct.Left, rct.Top, rct.Width, rct.Height);
					}
				}
			}
			if (bb == false)
			{
				Rectangle r = Screen.PrimaryScreen.Bounds;
				Point pp = new Point((r.Width - this.Width) / 2, (r.Height - this.Height) / 2);
				this.Location = pp;

			}
		}

		private void CCalc_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref("csc_CCalc");
			pref.SetRect("Rect", this.Bounds);
			pref.Save();
		}
	}
	public class JScriptEvaluator
	{
		//using System.CodeDom.Compiler;
		//using System.Reflection;
		// Microsoft.JScript を参照に追加

		private Assembly asm;
		private Type type;
		private object evalObject;
		public JScriptEvaluator()
		{
			PreCompile();
		}
		public string Eval(string exp)
		{
			return (string)type.InvokeMember("Eval", BindingFlags.InvokeMethod,
											  null, evalObject, new object[] { exp });
		}
		private void PreCompile()
		{
			string source =
				@"package JsEvaluator {
                     class Evaluator {
                         public function Eval(exp : String) : String {
                             return eval(exp);
                         }
                     }
                  }";
			CodeDomProvider provider = new Microsoft.JScript.JScriptCodeProvider();
			CompilerParameters cparams = new CompilerParameters();
			cparams.GenerateInMemory = true;
			CompilerResults cresults = provider.CompileAssemblyFromSource(cparams, source);
			asm = cresults.CompiledAssembly;
			type = asm.GetType("JsEvaluator.Evaluator");
			evalObject = Activator.CreateInstance(type);
		}
	}
}

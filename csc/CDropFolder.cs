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
using BRY;

namespace csc
{
	public partial class CDropFolder : Form
	{
		private string m_Folder = "";
		public string Folder { get { return m_Folder; } }
		public CDropFolder()
		{
			InitializeComponent();
			this.DialogResult = DialogResult.Cancel;
		}

		private void CDropFolder_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void CDropFolder_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			//ここでは単純にファイルをリストアップするだけ
			GetCommand(files);
		}
		public void GetCommand(string[] cmd)
		{
			m_Folder = "";
			string p = "";
			if (cmd.Length > 0)
			{
				foreach (string s in cmd)
				{
					if (Directory.Exists(s) == true)
					{
						p = s;
						break;
					}
					else if (File.Exists(s)==true)
					{
						p = Path.GetDirectoryName(s);
						break;
					}
				}
				if(p!="")
				{
					p = CUtil.PathToJSType(p);
					m_Folder = p;
					this.DialogResult = DialogResult.OK;
					Application.Exit();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			m_Folder = "";
			Application.Exit();
		}

		private void CDropFolder_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			JsonPref pref = new JsonPref("csc_DropFolder");
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
						if (JsonPref.IsInRect(r,rct))
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
			if(bb==false)
			{
				Rectangle r = Screen.PrimaryScreen.Bounds;
				Point pp = new Point((r.Width - this.Width) / 2, (r.Height - this.Height) / 2);
				this.Location = pp;

			}
		}

		private void CDropFolder_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref("csc_DropFolder");
			pref.SetRect("Rect", this.Bounds);
			pref.Save();
		}
	}
}

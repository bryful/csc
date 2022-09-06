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
			Application.Exit();
		}
	}
}

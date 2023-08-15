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
using System.Security.Cryptography;

namespace csc
{
	public partial class CDropFolder : BaseForm
	{
		private string m_Folder = "";
		public string Folder { get { return m_Folder; } }
		public CDropFolder()
		{
			InitializeComponent();
			this.DialogResult = DialogResult.Cancel;
			CancelButton = btnClose;

			btnClose.Click += (sender, e) =>
			{
				this.DialogResult = DialogResult.Cancel;
				m_Folder = "";
				Application.Exit();
			};
		}

		private void CDropFolder_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data == null) return;
			DragDropEffects d = DragDropEffects.None;
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
				if (files.Length > 0)
				{
					for (var i = 0; i < files.Length; i++)
					{
						if (Directory.Exists(files[i]))
						{
							d = DragDropEffects.All;
							break;
						}
					}
				}
			}
			e.Effect = d;
		}

		private void CDropFolder_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data != null)
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
				//ここでは単純にファイルをリストアップするだけ
				GetCommand(files);
			}
		}
		public void GetCommand(string[] cmd)
		{
			m_Folder = "";
			string? p = null;
			if (cmd.Length > 0)
			{
				foreach (string s in cmd)
				{
					if (Directory.Exists(s) == true)
					{
						p = s;
						break;
					}
					else if (File.Exists(s) == true)
					{
						p = Path.GetDirectoryName(s);
						break;
					}
				}
				if ((p != null) && (p != ""))
				{
					p = CUtil.PathToJSType(p);
					m_Folder = p;
					this.DialogResult = DialogResult.OK;
					Application.Exit();
				}
			}
		}

		private void CDropFolder_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			PrefFile pref = new PrefFile(this, "csc_DropFolder");
			pref.Load();
			Rectangle? rct = pref.GetBounds();

		}

		private void CDropFolder_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			PrefFile pref = new PrefFile(this, "csc_DropFolder");
			pref.SetBounds();
			pref.Save();
		}
	}
}

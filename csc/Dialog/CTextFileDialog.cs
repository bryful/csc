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
	public partial class CTextFileDialog : BaseForm
	{
		private string m_FileName = "";
		public string FileName { get { return m_FileName; } }
		// ***********************************************************************
		public string TextFile
		{
			get
			{
				return textBox1.Text;
			}
			set
			{
				textBox1.Text = value;
				textBox1.Select(0, 0);
			}
		}
		// ***********************************************************************
		public bool LoadFromFile(string p)
		{
			bool ret = false;
			try
			{
				p = CUtil.PathToWindowsType(p);
				if (File.Exists(p) == false)
				{
					textBox1.Text = p;
					textBox1.Select(0, 0);
					return ret;
				}
				string str = System.IO.File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
				textBox1.Text = str;
				textBox1.Select(0, 0);
				m_FileName = p;
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ***********************************************************************
		public bool SaveToFile(string p)
		{
			bool ret = false;
			try
			{
				p = CUtil.PathToWindowsType(p);
				System.IO.File.WriteAllText(p, textBox1.Text, Encoding.GetEncoding("utf-8"));
				m_FileName = p;
				ret = true;
			}
			catch
			{
				ret = false;
			}
			return ret;
		}
		// ***********************************************************************
		public bool SaveDlg(string p)
		{
			bool ret = false;
			SaveFileDialog dlg = new SaveFileDialog();
			try
			{
				dlg.Title = this.Text;
				if (p != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(p);
					dlg.FileName = Path.GetFileName(p);
				}
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = SaveToFile(dlg.FileName);
				}
			}
			catch
			{
				ret = false;
			}
			finally
			{
				dlg.Dispose();
			}
			return ret;
		}
		// ***********************************************************************
		public bool loadDlg(string p)
		{
			bool ret = false;
			OpenFileDialog dlg = new OpenFileDialog();
			try
			{
				dlg.Title = this.Text;
				if (p != "")
				{
					dlg.InitialDirectory = Path.GetDirectoryName(p);
					dlg.FileName = Path.GetFileName(p);
				}
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					ret = LoadFromFile(dlg.FileName);
				}
			}
			catch
			{
				ret = false;
			}
			finally
			{
				dlg.Dispose();
			}
			return ret;
		}
		// ***********************************************************************
		public bool Save()
		{
			bool ret = false;
			if (m_FileName != "")
			{
				ret = SaveToFile(m_FileName);
			}
			return ret;
		}
		// ***********************************************************************
		public void OutputAndClose()
		{
			this.DialogResult = DialogResult.OK;
		}
		public void CloseOnly()
		{
			this.DialogResult = DialogResult.Cancel;
		}
		// ***********************************************************************
		public CTextFileDialog()
		{
			InitializeComponent();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			loadDlg(m_FileName);
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (m_FileName != "")
			{
				SaveToFile(m_FileName);
			}
			else
			{
				SaveDlg(m_FileName);
			}
		}

		private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveDlg(m_FileName);
		}

		private void outputToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OutputAndClose();
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			CloseOnly();
		}

		private void CTextFileDialog_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			PrefFile pref = new PrefFile(this, "csc_TextFilDialog");
			pref.Load();
			Rectangle? rct = pref.GetBounds();
		}

		private void CTextFileDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			PrefFile pref = new PrefFile(this, "csc_TextFilDialog");
			pref.SetBounds();
			pref.Save();
		}
	}
}

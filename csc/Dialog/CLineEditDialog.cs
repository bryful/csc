using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csc
{
	public partial class CLineEditDialog : BaseForm
	{
		public string Line
		{
			get
			{
				return textBox1.Text.Trim();
			}
			set
			{
				textBox1.Text = value.Trim();
				textBox1.Select(0, 0);
			}
		}
		public string Caption
		{
			get { return label1.Text; }
			set { label1.Text = value; }
		}


		public CLineEditDialog()
		{
			InitializeComponent();
		}

		private void CLineEditDialog_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			PrefFile pref = new PrefFile(this, "csc_LineEdit");
			pref.Load();
			Rectangle? rct = pref.GetBounds();

		}

		private void CLineEditDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			PrefFile pref = new PrefFile(this, "csc_LineEdit");
			pref.SetBounds();
			pref.Save();

		}
	}
}

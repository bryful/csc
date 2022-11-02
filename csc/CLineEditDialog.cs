using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BRY;
namespace csc
{
	public partial class CLineEditDialog : Form
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
			JsonPref pref = new JsonPref("csc_LineEditDialog");
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

		private void CLineEditDialog_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref("csc_LineEditDialog");
			pref.SetRect("Rect", this.Bounds);
			pref.Save();

		}
	}
}

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
	public partial class CAlert : BaseForm
	{
		public CAlert()
		{
			InitializeComponent();
			AcceptButton = btnOK;
			btnOK.Click += (sender, e) =>
			{
				this.DialogResult = DialogResult.OK;
			};
		}
		public void SetHtml(string s)
		{
			webBrowser1.DocumentText = s;
		}
		// **********************************************************************
		// **********************************************************************
		public void ToCenter()
		{
			Rectangle r = Screen.PrimaryScreen.Bounds;
			Point pp = new Point((r.Width - this.Width) / 2, (r.Height - this.Height) / 2);
			this.Location = pp;
		}
		// **********************************************************************
		public bool LoadFromFile(string p)
		{
			bool ret = false;
			string p2 = CUtil.PathToWindowsType(p);
			if (File.Exists(p2) == true)
			{
				try { 
					PrefFile pf = new PrefFile(this, "csc_Alert");
					pf.Load();
					pf.GetBounds();
					Object? v = null;
					v = pf.JsonFile.ValueAuto("title",typeof(string).Name);
					if (v != null) { this.Text = (string)v; }
					v = pf.JsonFile.ValueAuto("html", typeof(string).Name);
					if (v != null) { webBrowser1.DocumentText = (string)v; }
					ret = true;
				}
				catch
				{
					ret = false;
				}
			}
			return ret;
		}
		// **********************************************************************
	}
}

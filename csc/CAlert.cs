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
using Codeplex.Data;

namespace csc
{
	public partial class CAlert : Form
	{
		public CAlert()
		{
			InitializeComponent();
		}
		public void SetHtml(string s)
		{
			webBrowser1.DocumentText = s;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}
		// **********************************************************************
		public bool GetCommand(string[] cmd)
		{
			bool ret = false;
			CArgs args = new CArgs(cmd);
			if(args.Mode == CSCMODE.Alert)
			{
				string[] sa = args.Plist();
				if (sa.Length > 0)
				{
					ret = LoadFromFile(sa[0]);
				}
			}
			return ret;
		}
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
				try
				{
					dynamic json = new DynamicJson();

					string str = File.ReadAllText(p2, Encoding.GetEncoding("utf-8"));
					str = str.Trim();
					if(str.Length<=3)
					{
						return ret;
					}
					if ((str[0]=='(')&& (str[str.Length-1] == ')'))
					{
						str = AEJson.FromAEJson(str);
					}
					json = DynamicJson.Parse(str);
					int w=-1;
					int h = -1;
					int x = -1;
					int y = -1;
					// ---
					string key = "width";
					if (json.IsDefined(key) == true){w = (int)json[key];}
					key = "height";
					if (json.IsDefined(key) == true){h = (int)json[key];}
					if((h!=-1)&&(w!=-1)){this.Size = new Size(w, h);}
					// ---
					key = "left";
					if (json.IsDefined(key) == true) { x = (int)json[key]; }
					key = "top";
					if (json.IsDefined(key) == true) { y = (int)json[key]; }
					if ((x != -1) && (y != -1)) { this.Location = new Point(x, y); } else { ToCenter(); }
					key = "title";
					string t = "";
					if (json.IsDefined(key) == true) {
						t = (string)json[key];
					}
					if(t!="")
					{
						this.Text = t;
					}

					key = "html";
					if (json.IsDefined(key) == true) 
					{
						string s = "";
						s = (string)json[key];
						webBrowser1.DocumentText = s;
					}
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

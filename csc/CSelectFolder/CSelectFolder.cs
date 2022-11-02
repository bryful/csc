using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csc
{
	public partial class CSelectFolder : Form
	{
		private string m_FileName="";
		public CSelectFolder()
		{
			InitializeComponent();
		}

		public string [] DriveList
		{
			get { return driveListBox1.Drives; }
			set { driveListBox1.Drives = value; }
		}
		public string FileName
		{
			get { return Path.Combine(dirFileListBox1.CurrentPath); }
			set
			{
				m_FileName = value;
			}
		}
		private static string GetFileSystemPath(Environment.SpecialFolder folder)
		{
			// パスを取得
			string path = String.Format(@"{0}\{1}",//\{2}
			  Environment.GetFolderPath(folder),  // ベース・パス
												  //Application.CompanyName,            // 会社名
			  Application.ProductName
			  );           // 製品名

			// パスのフォルダを作成
			lock (typeof(Application))
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
			return path;
		}
		private string PrefPath()
		{
			string p = GetFileSystemPath(Environment.SpecialFolder.ApplicationData);
			return Path.Combine(p, "csc_folderDialog.json");
		}
		public void SavePref()
		{
			dynamic jo = new DynamicJson();

			jo["width"] = this.Width;
			jo["height"] = this.Height;
			jo["s1"] = splitContainer1.SplitterDistance;
			jo["s2"] = splitContainer2.SplitterDistance;

			jo["drives"] = driveListBox1.Drives;
			jo["directoryName"] = dirFileListBox1.CurrentPath;

			string js = jo.ToString();

			File.WriteAllText(PrefPath(), js);
		}
		public void LoadPref()
		{
			string p = PrefPath();
			if (File.Exists(p) == false) return;

			string js = File.ReadAllText(p);
			if ((js == null) || (js == "")) return;

			dynamic jo = DynamicJson.Parse(js);
			if(jo == null) return;
			int w = 0;
			int h = 0;
			int s1 = 0;
			int s2 = 0;
			string key = "width";
			if (((DynamicJson)jo).IsDefined(key)) w = (int)jo[key];
			key = "height";
			if (((DynamicJson)jo).IsDefined(key)) h = (int)jo[key];
			if ((w > 0) && (h > 0)) { this.Size = new Size(w, h); }
			key = "s1";
			if (((DynamicJson)jo).IsDefined(key)) s1 = (int)jo[key];
			key = "s2";
			if (((DynamicJson)jo).IsDefined(key)) s2 = (int)jo[key];
			if ((s1 > 0) && (s2 > 0)) {
				splitContainer1.SplitterDistance = s1;
				splitContainer2.SplitterDistance = s2;
			}

			key = "drives";
			if (((DynamicJson)jo).IsDefined(key))
			{
				if (jo[key].IsArray)
				{
					string[] array = (string[])jo[key];
					driveListBox1.Drives = array;
				}
			}
			if (m_FileName == "")
			{
				key = "directoryName";
				if (((DynamicJson)jo).IsDefined(key))
				{
					string c = (string)jo[key];
					if ((c != null) && (c != "") && (Directory.Exists(c) == true))
					{
						DirectoryInfo di = new DirectoryInfo(c);
						directoryListBox1.SetCurrentParent(di);
					}

				}

			}
			MessageBox.Show("a");
		}
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			LoadPref();
			if(m_FileName != "")
			{
				DirectoryInfo di = new DirectoryInfo(m_FileName);
				if(di.Exists)
				{
					directoryListBox1.SetCurrentParent(di);
				}

			}
		}
		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			SavePref();
			base.OnFormClosed(e);
		}
	}
}

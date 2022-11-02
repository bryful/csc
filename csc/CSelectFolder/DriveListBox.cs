using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
namespace csc
{
	public enum DInfoType
	{
		None,
		Dir,
		File
	}

	public class DInfo
	{
		private DInfoType m_Type = DInfoType.None;
		public DInfoType DInfoType { get { return m_Type; } }
		private bool m_IsHidden =false;
		public bool IsHidden { get { return m_IsHidden; } }	
		public string FullName { get; set; }
		public string Caption = "";
		public string Name 
		{ 
			get
			{
				if (Caption == "")
				{
					return Path.GetFileName(FullName);
				}
				else
				{
					return Caption;
				}
			}
		}
		public char DriveLetter { get; set; }
		public string VolumeLabel { get; set; }
		public void Chk()
		{
			if(FullName!="")
			{
				if (FullName[0]!=DriveLetter)
				{
					FullName = DriveLetter + ":\\";
				}
			}
		}
		public DInfo(DirectoryInfo d)
		{
			m_Type = DInfoType.Dir;
			FullName = d.FullName;
			DriveLetter = d.FullName[0];
			try
			{
				VolumeLabel = (new DriveInfo(d.FullName)).VolumeLabel;
			}
			catch
			{
				VolumeLabel = "";
			}
			m_IsHidden = ((d.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden);
		}
		public DInfo(FileInfo f)
		{
			m_Type = DInfoType.File;
			FullName = f.FullName;
			DriveLetter = f.FullName[0];
			try
			{
				VolumeLabel = (new DriveInfo(f.FullName)).VolumeLabel;
			}
			catch
			{
				VolumeLabel = "";
			}
			m_IsHidden = ((f.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden);
		}
		public bool Exists
		{
			get
			{
				switch(m_Type)
				{
					case DInfoType.File:
						return File.Exists(FullName);
					case DInfoType.Dir:
						return Directory.Exists(FullName);
					default:
						return false;
				}
			}
		}
		public string Info
		{
			get { return DriveLetter + " (" + VolumeLabel + ")"; }
		}
	}
	public class DirChangedArg : EventArgs
	{
		public string Dir;
		public DirChangedArg(string v)
		{
			Dir = v;
		}
	}
	public partial class DriveListBox : ListBoxEX
	{
		private DInfo[] m_drives = new DInfo[0];
		public string[] Drives
		{
			get
			{
				string[] ret = new string[m_drives.Length];
				if(m_drives.Length>0)
				{
					for(int i = 0; i < m_drives.Length; i++)
					{
						ret[i] = m_drives[i].FullName;
					}
				}
				return ret;
			}
			set
			{
				if(value.Length>0)
				{
					for(int i=0; i<value.Length; i++)
					{
						DirectoryInfo d = new DirectoryInfo(value[i]);
						if (d.Exists == false) return;
						DInfo di = new DInfo(d);
						for (int j = 0; j < m_drives.Length;j++)
						{
							if (m_drives[j].DriveLetter==di.DriveLetter)
							{
								m_drives[j].FullName =di.FullName;
								break;
							}
						}
						for (int j = 0; j < m_drives.Length; j++) m_drives[i].Chk();
					}

				}
			}
		}
		public string DirectoryName
		{
			get 
			{
				int idx = SelectedIndex;
				if((idx>=0)&&(idx<m_drives.Length))
				{
					return m_drives[idx].FullName;
				}
				else
				{
					return "";			
				}
			}
			set
			{
				int idx = SetDirectoryName(value);
				if(idx>=0)
				{
					if (SelectedIndex != idx) SelectedIndex = idx;
				}
			}
		}
		private bool m_IsSelectedEvent = true;
		public int SetDirectoryName(string p)
		{
			int ret = -1;
			if (p == "") return ret;
			DirectoryInfo d = new DirectoryInfo(p);
			if (d.Exists == false) return ret;
			DInfo di = new DInfo(d);
			if (m_drives.Length > 0)
			{
				for (int i = 0; i < m_drives.Length; i++)
				{
					if (m_drives[i].DriveLetter == di.DriveLetter)
					{
						ret = i;
						m_drives[i] = di;
						if (SelectedIndex != i)
						{
							m_IsSelectedEvent = false;
							SelectedIndex = i;
							m_IsSelectedEvent = true;
						}
						break;
					}
				}
			}
			return ret;
		}
		public int Count
		{
			get { return m_drives.Length; }
		}
		public DriveListBox()
		{
		
			InitializeComponent();
		}
		
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			Listup();
		}
		
		private void Listup()
		{
			ManagementObject mo = new ManagementObject();

			string[] drives = Environment.GetLogicalDrives();
			List<DInfo> dirs = new List<DInfo>();
			foreach (string drive in drives)
			{
				DInfo di = new DInfo(new DirectoryInfo(drive));
				if(di.Exists)
				{
					dirs.Add(di);
				}
			}
			m_drives = dirs.ToArray();
			string[] caps = new string[Count];
			int idx = 0;
			foreach(DInfo d in m_drives)
			{
				caps[idx] = d.Info;
				idx++;
			}
			this.Items.Clear();
			this.Items.AddRange(caps);	
			if ((this.SelectedIndex < 0) && (m_drives.Length > 0)) this.SelectedIndex = 0;			
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			if(m_IsSelectedEvent==false) return;
			try
			{
				if ((SelectedIndex >= 0) && (SelectedIndex < m_drives.Length))
				{

					if (m_DirectoryListBox != null)
					{
						m_DirectoryListBox.SetCurrentPath(DirectoryName, false);
					}
				}
				else
				{
					base.OnSelectedIndexChanged(e);
				}
			}
			catch { }
		}

		private DirectoryListBox m_DirectoryListBox = null;
		public DirectoryListBox DirectoryListBox
		{
			get { return m_DirectoryListBox; }
			set
			{
				m_DirectoryListBox = value;
			}
		}
	
	}
}

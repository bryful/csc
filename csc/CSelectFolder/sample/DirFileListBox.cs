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
	public partial class DirFileListBox : ListBoxEX
	{
		public delegate void DirChangedHandler(object sender, DirChangedArg e);
		public event DirChangedHandler DirChanged;
		protected virtual void OnDirChanged(DirChangedArg e)
		{
			if (DirChanged != null)
			{
				DirChanged(this, e);
			}
		}
		private DirectoryInfo m_Current = new DirectoryInfo(Directory.GetCurrentDirectory());
		public DirectoryInfo Current
		{
			get { return m_Current; }
			set
			{
				if (m_Current.FullName != value.FullName)
				{
					m_Current = value;
					Listup();
				}
			}
		}
		public string CurrentPath
		{
			get { return m_Current.FullName; }
			set
			{
				if((value!=null)&&(value!=""))
				{
					Current = new DirectoryInfo(value);
				}
			}
		}

		private DInfo [] m_Items = new DInfo[0];

		public string SelectedDirName
		{
			get
			{
				if ((SelectedIndex >= 0) && (SelectedIndex < this.Items.Count))
				{
					return m_Items[SelectedIndex].Name;
				}
				else
				{
					return "";
				}
			}

			set
			{
				if(m_Items.Length>0)
				{
					int idx = -1;
					for(int i = 0; i < m_Items.Length; i++)
					{
						if (m_Items[i].Name == value)
						{
							idx = i;
							break;
						}
					}
					if(idx>=0)
					{
						if(SelectedIndex!=idx)
						{
							SelectedIndex = idx;
						}
					}
				}

			}
		}
		public DirFileListBox()
		{
			InitializeComponent();
			Listup();
		}
		private void Listup()
		{
			this.Items.Clear();
			m_Items = new DInfo[0];
			SelectedIndex = -1;
			if (m_Current.Exists == false) return;

			List<DInfo> lst = new List<DInfo>();
			IEnumerable<string> dirs = Directory.EnumerateDirectories(m_Current.FullName, "*", SearchOption.TopDirectoryOnly);
			foreach (string s in dirs)
			{
				if (s[0] == '.') continue;
				DirectoryInfo di = new DirectoryInfo(s);
				if ((di == null) || (di.Exists == false)) continue;
				if ((di.Attributes & FileAttributes.Hidden) != 0) continue;
				lst.Add(new DInfo(di));
			}
			IEnumerable<string> files = Directory.EnumerateFiles(m_Current.FullName, "*.aep", SearchOption.TopDirectoryOnly);
			foreach (string s in files)
			{
				FileInfo fi = new FileInfo(s);
				if ((fi == null) || (fi.Exists == false)) continue;
				if ((fi.Attributes & FileAttributes.Hidden) != 0) continue;
				lst.Add(new DInfo(fi));
			}
			if (lst.Count > 0)
			{
				m_Items = lst.ToArray();
				if (m_Items.Length > 0)
				{
					string[] itms = new string[m_Items.Length];
					int idx = 0;
					foreach (DInfo s in m_Items)
					{
						if(s.DInfoType == DInfoType.Dir)
						{
							itms[idx] = "<DIR> " + s.Name;
						}
						else
						{
							itms[idx] = "      " + s.Name;
						}
						idx++;
					}
					this.Items.AddRange(itms);
				}
			}
			if(m_CurrentTextBox != null)
			{
				m_CurrentTextBox.Text = m_Current.FullName;
			}
			if(m_TargetDir!=null)
			{
				m_TargetDir.Text = "";
			}
			OnDirChanged(new DirChangedArg(m_Current.FullName));
		}
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if ((SelectedIndex >= 0) && (SelectedIndex < this.Items.Count))
			{
				if(m_Items[SelectedIndex].DInfoType == DInfoType.Dir)
				{
					Current = new DirectoryInfo(m_Items[SelectedIndex].FullName);

				}
			}
			else
			{
				base.OnMouseDoubleClick(e);
			}
		}
		private Button m_RootBtn = null;
		public Button RootBtn
		{
			get { return m_RootBtn; }
			set
			{
				m_RootBtn = value;
				if(m_RootBtn !=null)
				{
					m_RootBtn.Click += M_RootBtn_Click;
				}
			}
		}

		private void M_RootBtn_Click(object sender, EventArgs e)
		{
			DirectoryInfo d = m_Current.Root;
			if(d !=null)
			{
				if((m_Current.FullName)!= (d.FullName))
				{
					Current = d;
				}
			}
		}
		private Button m_ParentBtn = null;
		public Button ParentBtn
		{
			get { return m_ParentBtn; }
			set
			{
				m_ParentBtn = value;
				if (m_ParentBtn != null)
				{
					m_ParentBtn.Click += M_ParentBtn_Click;
				}
			}
		}

		private void M_ParentBtn_Click(object sender, EventArgs e)
		{
			DirectoryInfo d = m_Current.Parent;
			if (d != null)
			{
				if ((m_Current.FullName) != (d.FullName))
				{
					Current = d;
				}
			}
		}
		private Button m_EntryBtn = null;
		public Button EntryBtn
		{
			get { return m_EntryBtn; }
			set
			{
				m_EntryBtn = value;
				if (m_EntryBtn != null)
				{
					m_EntryBtn.Click += M_EntryBtn_Click;
				}
			}
		}

		private void M_EntryBtn_Click(object sender, EventArgs e)
		{
			if ((SelectedIndex >= 0) && (SelectedIndex < m_Items.Length))
			{
				if(m_Items[SelectedIndex].DInfoType== DInfoType.Dir)
				{
					Current = new DirectoryInfo(m_Items[SelectedIndex].FullName);
				}

			}
		}

		private TextBox m_CurrentTextBox = null;
		public TextBox CurentTextBox
		{
			get { return m_CurrentTextBox; }
			set
			{
				m_CurrentTextBox = value;

			}
		}

		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			bool b = ((SelectedIndex >= 0) && (SelectedIndex < m_Items.Length));
			bool IsDir = false;
			if(b) IsDir = m_Items[SelectedIndex].DInfoType == DInfoType.Dir;
			if (m_EntryBtn!=null)
			{
				m_EntryBtn.Enabled = IsDir;
			}
			if (m_TargetDir != null)
			{
				if (IsDir)
				{
					m_TargetDir.Text = m_Items[SelectedIndex].Name;
				}
				else
				{
					m_TargetDir.Text = "";
				}
			}
			OnDirChanged(new DirChangedArg(SelectedDirName));
			base.OnSelectedIndexChanged(e);
		}
		private TextBox m_TargetDir = null;
		public TextBox TargetDir
		{
			get { return m_TargetDir; }
			set
			{
				m_TargetDir = value;
			}
		}
	}
}

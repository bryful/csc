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
	public partial class DirectoryListBox : ListBoxEX
	{
		/*
		public delegate void DirChangedHandler(object sender, DirChangedArg e);
		public event DirChangedHandler DirChanged;
		protected virtual void OnDirChanged(DirChangedArg e)
		{
			if (DirChanged != null)
			{
				DirChanged(this, e);
			}
		}
		*/
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
					if (m_Current.FullName != value)
					{
						Current = new DirectoryInfo(value);
					}
				}
			}
		}
		public void SetCurrentPath(string p,bool isE=true)
		{
			DirectoryInfo di = new DirectoryInfo(p);
			if(di.Exists)
			{
				m_Current = di;
				Listup(isE);
			}
		}

		private DInfo [] m_Items = new DInfo[0];


		public DirectoryListBox()
		{
			InitializeComponent();
			Listup();
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			Listup();
		}

		public void SetCurrentParent(DirectoryInfo di)
		{
			if (di.Parent == null) return;
			m_Current = di.Parent;
			Listup(false);
			if(m_Items.Length>0)
			{
				string n = di.Name;
				int cnt = 0;
				int idx = -1;
				foreach(DInfo d in m_Items)
				{
					if(d.Name==n)
					{
						idx = cnt;
						break;
					}
					cnt++;
				}
				if(idx>=0)
				{
					SelectedIndex = idx;
				}
			}
			if (m_DriveListBox != null)
			{
				if (m_DriveListBox.DirectoryName != CurrentPath)
				{
					m_DriveListBox.SetDirectoryName(CurrentPath);
				}
			}
		}
		private void Listup(bool IsEvent=true)
		{
			this.Items.Clear();
			m_Items = new DInfo[0];
			SelectedIndex = -1;
			if ((m_Current == null) || (m_Current.Exists == false))
			{
				return;
			}

			List<DInfo> lst = new List<DInfo>();
			DirectoryInfo prt = m_Current.Parent;
			if(prt!=null)
			{
				DInfo d = new DInfo(prt);
				d.Caption = "..\\";
				lst.Add(d);
			}
			IEnumerable<string> dirs = Directory.EnumerateDirectories(m_Current.FullName, "*", SearchOption.TopDirectoryOnly);
			foreach (string s in dirs)
			{
				if (s[0] == '.') continue;
				DirectoryInfo di = new DirectoryInfo(s);
				if ((di == null) || (di.Exists == false)) continue;
				if ((di.Attributes & FileAttributes.Hidden) != 0) continue;
				lst.Add(new DInfo(di));
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
						itms[idx] = s.Name;
						idx++;
					}
					this.Items.AddRange(itms);
				}
			}
			if (IsEvent)
			{
				if (m_DriveListBox != null)
				{
					if (m_DriveListBox.DirectoryName != m_Current.FullName)
					{
						m_DriveListBox.DirectoryName = m_Current.FullName;
					}
				}
				if (m_DirFileListBox != null)
				{
					if (m_DirFileListBox.CurrentPath != m_Current.FullName)
					{
						m_DirFileListBox.CurrentPath = m_Current.FullName;
					}
				}
			}
			if(m_DirectryTextBox!=null)
			{
				m_DirectryTextBox.Text = m_Current.FullName;
			}
			if(this.Items.Count >= 2)
			{
				SelectedIndex = 1;
			}
		}
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if ((SelectedIndex >= 0) && (SelectedIndex < this.Items.Count))
			{
				if(m_Items[SelectedIndex].DInfoType == DInfoType.Dir)
				{
					if (m_Items[SelectedIndex].Caption == "..\\")
					{
						SetCurrentParent(m_Current);
					}
					else
					{
						Current = new DirectoryInfo(m_Items[SelectedIndex].FullName);
					}
				}
			}
			else
			{
				base.OnMouseDoubleClick(e);
			}
		}
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			bool b = ((SelectedIndex >= 0) && (SelectedIndex < m_Items.Length));
			if((b)&&(m_DirFileListBox!=null))
			{
				if (m_Items[SelectedIndex].Caption != "..\\")
				{
					m_DirFileListBox.CurrentPath = m_Items[SelectedIndex].FullName;
				}
			}
			else
			{
				base.OnSelectedIndexChanged(e);
			}
		}
		private DirFileListBox m_DirFileListBox = null;
		public DirFileListBox DirFileListBox
		{
			get { return m_DirFileListBox; }
			set
			{
				m_DirFileListBox = value;
			}
		}

		private void M_DirFileListBox_DirChanged(object sender, DirChangedArg e)
		{
			if (e.Dir == "") return;
			string p = Path.GetDirectoryName(e.Dir);
			if((p!=null)&&(p!=""))
			{
				DirectoryInfo di = new DirectoryInfo(p);
				Current = di;
				string n = Path.GetFileName(e.Dir);
				if(m_Items.Length>0)
				{
					int idx = -1;
					for(int i=0; i< m_Items.Length;i++)
					{
						if (m_Items[i].Name==n)
						{
							idx = i;
							break;
						}
					}
					if (idx >= 0)
					{
						SelectedIndex = idx;
					}
				}
			}
		}
		private Button m_RootBtn = null;
		public Button RootBtn
		{
			get { return m_RootBtn; }
			set
			{
				m_RootBtn = value;
				if (m_RootBtn != null)
				{
					m_RootBtn.Click += M_RootBtn_Click;
				}
			}
		}

		private void M_RootBtn_Click(object sender, EventArgs e)
		{
			DirectoryInfo d = m_Current.Root;
			if (d != null)
			{
				if ((m_Current.FullName) != (d.FullName))
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
			SetCurrentParent(m_Current);
		}
		private DriveListBox m_DriveListBox = null;
		public DriveListBox DriveListBox
		{
			get { return m_DriveListBox; }
			set { m_DriveListBox = value; }
		}
		private TextBox m_DirectryTextBox = null;
		public TextBox DirectryTextBox
		{
			get { return m_DirectryTextBox; }
			set { m_DirectryTextBox = value; }
		}
	}
}

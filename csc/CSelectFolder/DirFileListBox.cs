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
				if ((m_Current==null)||(m_Current.FullName != value.FullName))
				{
					if(value.Parent!=null)
					{
						m_Current = value;
						Listup();
					}
					else
					{
						Clear();
					}
				}
			}
		}
		public string CurrentPath
		{
			get
			{
				if (m_Current == null)
				{
					return "";
				}
				else
				{
					return m_Current.FullName;
				}
			}
			set
			{
				if((value!=null)&&(value!=""))
				{
					Current = new DirectoryInfo(value);
				}
				else
				{
					Clear();
				}
			}
		}

		private DInfo [] m_Items = new DInfo[0];
		public void Clear()
		{
			m_Current = null;
			m_Items = new DInfo[0];
			this.Items.Clear();
			if (m_DirTextBox != null)
			{
				m_DirTextBox.Text = "";
			}
		}
		public DirFileListBox()
		{
			this.Items.Clear();
			InitializeComponent();
			Listup();
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			this.Items.Clear();
			Listup();
		}
		private void Listup(bool IsEvent=true)
		{
			if ((m_Current==null)||(m_Current.Exists == false))
			{
				Clear();
				return;
			}
			m_Items = new DInfo[0];
			this.Items.Clear();
			if (m_DirTextBox != null)
			{
				m_DirTextBox.Text = "";
			}
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
							itms[idx] = "<" + s.Name+">";
						}
						else
						{
							itms[idx] = " " + s.Name;
						}
						idx++;
					}
					this.Items.Clear();
					this.Items.AddRange(itms);
				}
			}
			if (IsEvent)
			{
				if (m_DirTextBox != null)
				{
					m_DirTextBox.Text = m_Current.FullName;
				}
				if (m_DirectoryListBox != null)
				{
					DirectoryInfo di = m_Current.Parent;
					if ((di != null) && (di.Exists))
					{
						if (m_DirectoryListBox.CurrentPath != di.FullName)
						{
							m_DirectoryListBox.Current = di;
						}
					}
				}
			}

		}
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if ((SelectedIndex >= 0) && (SelectedIndex < this.Items.Count))
			{
				if(m_Items[SelectedIndex].DInfoType == DInfoType.Dir)
				{
					if(m_DirectoryListBox!=null)
					{
						m_DirectoryListBox.SetCurrentParent(new DirectoryInfo(m_Items[SelectedIndex].FullName));
					}
				}
			}
			else
			{
				base.OnMouseDoubleClick(e);
			}
		}
		private TextBox m_DirTextBox = null;
		public TextBox DirTextBox
		{
			get { return m_DirTextBox; }
			set
			{
				m_DirTextBox = value;
			}
		}
		private DirectoryListBox m_DirectoryListBox = null;
		public DirectoryListBox DirectoryListBox
		{
			get { return m_DirectoryListBox; }
			set { m_DirectoryListBox = value; }
		}
	}
}

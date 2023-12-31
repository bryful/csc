﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
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
		private bool m_IsParetn = false;
		private bool m_IsDrive = false;
		public bool IsParetn { get { return m_IsParetn; } }
		private DInfoType m_Type = DInfoType.None;
		public DInfoType DInfoType { get { return m_Type; } }
		private bool m_IsHidden = false;
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
			if (FullName != "")
			{
				if (FullName[0] != DriveLetter)
				{
					FullName = DriveLetter + ":\\";
				}
			}
		}
		public DInfo(DirectoryInfo d, bool IsP = false, bool isDrive = false)
		{
			m_IsParetn = IsP;
			m_IsDrive = isDrive;
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
			m_IsDrive = isDrive;
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
				switch (m_Type)
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
		public Image IconImage()
		{
			if (m_IsDrive)
			{
				return IconUtility.FileAssociatedImage(FullName.Substring(0,3), false);
			}
			else
			{
				return IconUtility.FileAssociatedImage(FullName, false);
			}
		}
	}
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	struct SHFILEINFO
	{
		public IntPtr hIcon;
		public IntPtr iIcon;
		public uint dwAttributes;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
		public string szDisplayName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
		public string szTypeName;
	}
	// *********************************************************
	/// <summary>
	/// アイコン系ユーティリティクラス
	/// </summary>
	public class IconUtility
	{
		const uint SHGFI_LARGEICON = 0x00000000;
		const uint SHGFI_SMALLICON = 0x00000001;
		const uint SHGFI_USEFILEATTRIBUTES = 0x00000010;
		const uint SHGFI_ICON = 0x00000100;
		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool DestroyIcon(IntPtr hIcon);

		/// <summary>
		/// 指定したファイルパスに関連付けされたアイコンイメージを取得する。
		/// </summary>
		/// <remarks>
		/// このメソッドは、ファイルの存在チェックを行ない、指定されなかった第３パラメータの
		/// 値を決定する。
		/// </remarks>
		/// <param name="path">アイコンイメージ取得対象のファイルのパス</param>
		/// <param name="isLarge">大きいアイコンを取得するとき true、小さいアイコンを取得するとき false</param>
		/// <returns>取得されたアイコンのビットマップイメージを返す。</returns>
		public static Image FileAssociatedImage(string path, bool isLarge)
		{
			return FileAssociatedImage(path, isLarge, File.Exists(path));
		}
		/// <summary>
		/// 指定したファイルパスに関連付けされたアイコンイメージを取得する。
		/// </summary>
		/// <param name="path">アイコンイメージ取得対象のファイルのパス</param>
		/// <param name="isLarge">
		/// 大きいアイコンを取得するとき true、小さいアイコンを取得するとき false
		/// </param>
		/// <param name="isExist">
		/// ファイルが実在するときだけ動作させるとき true、実在しなくて動作させるとき false
		/// </param>
		/// <returns>取得されたアイコンのビットマップイメージを返す。</returns>
		public static Image FileAssociatedImage(string path, bool isLarge, bool isExist)
		{
			SHFILEINFO fileInfo = new SHFILEINFO();
			uint flags = SHGFI_ICON;
			if (!isLarge) flags |= SHGFI_SMALLICON;
			if (!isExist) flags |= SHGFI_USEFILEATTRIBUTES;
			try
			{
				SHGetFileInfo(path, 0x10, ref fileInfo, (uint)Marshal.SizeOf(fileInfo), flags);
				if (fileInfo.hIcon == IntPtr.Zero)
					return null;
				else
					return Icon.FromHandle(fileInfo.hIcon).ToBitmap();
			}
			finally
			{
				if (fileInfo.hIcon != IntPtr.Zero)
					DestroyIcon(fileInfo.hIcon);
			}
		}
	}
	public partial class ListBoxEX : ListBox
	{

		public List<DInfo> DInfoItems = new List<DInfo> ();
		public int Count
		{
			get { return DInfoItems.Count; }
		}
		public void AddRange(List<DInfo> lst, bool IsDrive= false)
		{
			string[] a = new string[lst.Count];
			for(int i=0; i< lst.Count;i++)
			{
				if (IsDrive)
				{
					a[i] = lst[i].Info;
				}
				else
				{
					a[i] = lst[i].Name;
				}
			}
			DInfoItems.Clear();
			DInfoItems.AddRange(lst);
			this.Items.Clear();
			this.Items.AddRange(a);
		}
		public void Clear()
		{
			this.Items.Clear();
			DInfoItems.Clear();
		}
		private Color m_SelectedColor=Color.FromArgb(200,200,200);
		public Color SelectedColor
		{
			get { return m_SelectedColor; }
			set { m_SelectedColor = value; }
		}
		public ListBoxEX()
		{
			InitializeComponent();
			this.DrawMode = DrawMode.OwnerDrawFixed;
			this.DrawItem += new DrawItemEventHandler(DrawItems);
			this.ItemHeight = 20;

		}

		private void DrawItems(object sender, System.Windows.Forms.DrawItemEventArgs e)
		{
			SolidBrush sb = new SolidBrush(this.BackColor);
			ListBoxEX lb = (ListBoxEX)sender;

			try
			{
				e.DrawBackground();
				//sb.Color = Color.Transparent;
				//e.Graphics.FillRectangle(sb, e.Bounds);

				if ((e.Index > -1) && (lb.Items.Count > 0))
				{
					if (DInfoItems[e.Index].IsParetn)
					{
						sb.Color = this.ForeColor;
						Rectangle r = new Rectangle(e.Bounds.Left, e.Bounds.Top, e.Bounds.Width - 16, e.Bounds.Height);
						e.Graphics.DrawString("../", e.Font, sb, r);
					}
					else
					{
						if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
						{
							sb.Color = m_SelectedColor;
							e.Graphics.FillRectangle(sb, e.Bounds);
						}
						if (DInfoItems.Count > e.Index)
						{
							Image Ii = DInfoItems[e.Index].IconImage();
							e.Graphics.DrawImage(Ii, e.Bounds.Left, e.Bounds.Top);
							Ii.Dispose();
						}
						//文字列の取得
						string txt = lb.Items[e.Index].ToString();
						if (txt.IndexOf("..\\") >= 0) txt = "<to Parent>";
						//文字列の描画
						sb.Color = this.ForeColor;
						Rectangle r = new Rectangle(e.Bounds.Left + 16, e.Bounds.Top, e.Bounds.Width - 16, e.Bounds.Height);
						e.Graphics.DrawString(txt, e.Font, sb, r);
					}
				}

			}
			finally
			{
				sb.Dispose();
			}
			//背景を描画する
		}
	}
}

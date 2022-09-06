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
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace csc
{
	class CWin
	{
		#region DllImport
		// トップレベルウィンドウを列挙する
		[DllImport("user32.dll")]
		private static extern bool EnumWindows(EnumWindowsDelegate lpEnumFunc, IntPtr lParam);

		// ウィンドウの表示状態を調べる(WS_VISIBLEスタイルを持つかを調べる)
		[DllImport("user32.dll")]
		private static extern bool IsWindowVisible(IntPtr hWnd);

		//ウィンドウのタイトルの長さを取得する
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowTextLength(IntPtr hWnd);

		// ウィンドウのタイトルバーのテキストを取得
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		// ウィンドウを作成したプロセスIDを取得
		//[DllImport("user32")]// 「.dll」なくても動いてた
		[DllImport("user32.dll")]
		private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

		// EnumWindowsから呼び出されるコールバック関数のデリゲート
		private delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lParam);

		[DllImport("user32.dll", SetLastError = true)]
		static extern int GetWindowLong(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll", SetLastError = true)]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
		[DllImport("User32.dll")]
		private static extern int SetForegroundWindow(IntPtr hWnd);
		#endregion

		// **********************************************************************************************************
		static public Process[] GetAEProcess()
		{
			Process [] ret = null;
			List<Process> lst = new List<Process>();
			foreach (Process p in Process.GetProcesses())
			{
				if (p.ProcessName == "AfterFX")
				{
					lst.Add(p);
				}
			}
			if (lst.Count>0)
			{
				ret = lst.ToArray();
			}
			return ret;
		}
		static private bool WaitForInputIdle(Process Proc)
		{
			bool ret = false;
			if (Proc != null)
			{
				ret = Proc.WaitForInputIdle();
			}
			return ret;
		}
		static public int SetForegroundWindow(Process Proc)
		{
			int ret = 0;
			if (Proc != null)
			{
				ret = SetForegroundWindow(Proc.MainWindowHandle);
			}
			return ret;

		}
		static public bool SetWindow(Process Proc,int p)
		{
			bool ret = false;
			if (Proc != null)
			{
				if (Proc.WaitForInputIdle())
				{
					ret = ShowWindow(Proc.MainWindowHandle, p);
				}
			}
			return ret;

		}

		static public void SetWindowAll(int p)
		{
			Process[] lst = GetAEProcess();
			if (lst.Length>0)
			{
				for ( int i= lst.Length-1; i>=0;i--)
				{
					SetWindow(lst[i], p);
					SetForegroundWindow(lst[i]);
				}
			}
		}
		static public void WindowMax()
		{
			SetWindowAll(3);
		}
		static public void WindowMin()
		{
			SetWindowAll(2);
		}
		static public void WindowNormal()
		{
			SetWindowAll(1);
		}
		static private string ProcInfo(Process ps)
		{
			string ret = "";
			ret += String.Format("id:{0}", ps.Id);
			ret += String.Format(",mainWindowTitle :\"{0}\"", ps.MainWindowTitle);
			ret += String.Format(",processName  :\"{0}\"", ps.ProcessName);
			ret += String.Format(",fileName  :\"{0}\"", ps.MainModule.FileName);

			ret = "({" + ret + "})";
			return ret;

		}
		static public string AEProcessList()
		{
			string ret = "";
			Process[] lst = GetAEProcess();

			if (lst.Length > 0)
			{
				for (int i = 0; i < lst.Length; i++)
				{
					if (ret != "") ret += ",";
					ret += ProcInfo(lst[i]);

				}
			}
			ret = "[" + ret + "]";
			return ret;
		}



		// **********************************************************************************************************

	}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;


namespace csc
{
	public class CClipboard
	{
		/// <summary>
		/// クリップボードのテキストを返す。
		/// </summary>
		/// <returns></returns>
		static public string FromClipboard()
		{
			string ret = "";
			if (Clipboard.ContainsText() == true)
			{
				ret = Clipboard.GetText();
			}
			return ret;
		}
		/// <summary>
		/// 指定したテキストファイルをクリップボードへ
		/// </summary>
		/// <param name="p">FileName</param>
		/// <returns>成功したらFileName。失敗したらEmpty</returns>
		static public string ToClipboardFromFile(string p)
		{
			string ret = "";
			string p2 = CUtil.PathToWindowsType(p);
			if (File.Exists(p2)==true)
			{
				try
				{
					string str = File.ReadAllText(p2, Encoding.GetEncoding("utf-8"));
					Clipboard.SetText(str);
					ret = p;
				}
				catch
				{
					ret = "";
				}
			}
			return ret;
		}
	}
}

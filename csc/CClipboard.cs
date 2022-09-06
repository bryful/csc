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
		static public string FromClipboard()
		{
			string ret = "";
			if (Clipboard.ContainsText() == true)
			{
				ret = Clipboard.GetText();
			}
			return ret;
		}
		static public bool ToClipboardFromFile(string p)
		{
			bool ret = false;
			p = CUtil.PathToWindowsType(p);
			if (File.Exists(p)==true)
			{
				try
				{
					string str = File.ReadAllText(p, Encoding.GetEncoding("utf-8"));
					Clipboard.SetText(str);
					ret = true;
				}
				catch
				{
					ret = false;
				}
			}
			return ret;
		}
	}
}

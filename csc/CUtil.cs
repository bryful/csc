using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csc
{
	public class CUtil
	{
		// ***********************************************************************
		static public string PathToWindowsType(string s)
		{
			string ret = s;
			if (s.Length > 3)
			{
				if ((s[0] == '/') && (s[2] == '/'))
				{
					s = s.Substring(1, 1).ToUpper() + ":" + s.Substring(2).Replace("/", "\\");
				}
			}
			return ret;
		}
		// ***********************************************************************
		static public string PathToJSType(string p)
		{
			string ret = p;
			if (ret.Length > 2)
			{
				if ((ret[1] == ':') && (ret[2] == '\\'))
				{
					ret = "/" + ret.Substring(0, 1).ToLower() + ret.Substring(2).Replace("\\", "/");

				}

			}
			return ret;
		}
	}
}

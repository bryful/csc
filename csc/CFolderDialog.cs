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
	public class CFolderDialog
	{
        // ***********************************************************************
        static private string chkPath(string s)
        {
            string ret = s;
            if (s.Length < 3)
            {
                return s;
            }
            if ((s[0] == '/') && (s[2] == '/'))
            {
                s = s.Substring(1, 1).ToUpper() + ":" + s.Substring(2).Replace("/", "\\");
            }
            return ret;
        }
        static private string ToJSPath(string p)
		{
            string ret = p;
            if (ret.Length > 2)
			{
                if((ret[1]==':')&& (ret[2] == '\\'))
				{
                    ret = "/" + ret.Substring(0, 1).ToLower() + ret.Substring(2).Replace("\\", "/");

				}

			}
            return ret;
		}
        static public string ShowDialog(string p)
		{
            string ret = "";
            p = chkPath(p);
            using (var ofd = new OpenFileDialog()
            {
                InitialDirectory = p,
                FileName = "Folder Selection",
                Filter = "Folder|.",
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ret = Path.GetDirectoryName(ofd.FileName);
                    if(ret!="")
					{
                        ret = ToJSPath(ret);
                    }
                }
            }
            return ret;
        }

    }
}

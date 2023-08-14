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
using System.Windows.Forms.VisualStyles;

namespace csc
{
	public class CFolderDialog
	{
        static public string ShowDialog(string p)
		{
            string ret = "";
            string p2 = CUtil.PathToWindowsType(p);
            using (var ofd = new OpenFileDialog()
            {
                InitialDirectory = p2,
                FileName = "Folder Selection",
                Filter = "Folder|.",
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string? s = Path.GetDirectoryName(ofd.FileName);
                    if((s!=null)&&(s!=""))
					{
                        ret = CUtil.PathToJSType(s);
                    }
                }
            }
            return ret;
        }
		static public string ShowSelectFolderDialog(string p)
		{
			string ret = "";
			string p2 = CUtil.PathToWindowsType(p);
			using (var ofd = new SelectFolder()
			{
				FileName = p2
			})
			{
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					ret = ofd.FileName;
					if (ret != "")
					{
						ret = CUtil.PathToJSType(ret);
					}
				}
			}
			return ret;
		}
	}



}

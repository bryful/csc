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
        static public string ShowDialog(string p)
		{
            string ret = "";
            p = CUtil.PathToWindowsType(p);
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
                        ret = CUtil.PathToJSType(ret);
                    }
                }
            }
            return ret;
        }

    }
}

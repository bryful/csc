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
    public class CMousePos
    {
        // **********************************
        static public string JSON()
        {
             Point pos = System.Windows.Forms.Cursor.Position;
            return "{"+ String.Format("\"x\":{0},\"y\":{1}", pos.X, pos.Y)+"}";
        }
        static public string ToSource()
        {
            Point pos = System.Windows.Forms.Cursor.Position;
            return "({" + String.Format("x:{0},y:{1}", pos.X, pos.Y) +"})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csc
{
	public partial class CLineEditDialog : Form
	{
		public string Line
		{
			get
			{
				return textBox1.Text.Trim();
			}
			set
			{
				textBox1.Text = value.Trim();
				textBox1.Select(0, 0);
			}
		}
		public string Caption
		{
			get { return label1.Text; }
			set { label1.Text = value; }
		}


		public CLineEditDialog()
		{
			InitializeComponent();
		}
	}
}

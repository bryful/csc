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
	public partial class ListBoxEX : ListBox
	{
		public List<DInfo> DInfoItems = new List<DInfo> ();
		public void AddRange(List<DInfo> lst)
		{
			DInfoItems.Clear();
			DInfoItems.AddRange (lst);
			string[] a = new string[DInfoItems.Count];
			for(int i=0; i<DInfoItems.Count;i++)
			{
				a[i] = DInfoItems[i].Name;
			}
			this.Items.Clear();
			this.Items.AddRange(a);
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

					if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
					{
						sb.Color = m_SelectedColor;
						e.Graphics.FillRectangle(sb, e.Bounds);
					}

					//文字列の取得
					string txt = lb.Items[e.Index].ToString();
					if (txt.IndexOf("..\\")>=0) txt = "<to Parent>";
					//文字列の描画
					sb.Color = this.ForeColor;
					Rectangle r = new Rectangle(e.Bounds.Left+16, e.Bounds.Top, e.Bounds.Width-16, e.Bounds.Height);
					e.Graphics.DrawString(txt, e.Font, sb, r);

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

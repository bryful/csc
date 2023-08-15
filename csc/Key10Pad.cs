using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace csc
{
	public partial class Key10Pad : Control
	{
		public delegate void BtnEventHandler(object sender, BtnEventArgs e);

		//イベントデリゲートの宣言
		[Category("KeyPad"),Browsable(true)]
		public event BtnEventHandler? Btn = null;

		protected virtual void OnBtn(BtnEventArgs e)
		{
			if (Btn != null)
			{
				Btn(this, e);
			}
		}
		private int m_BtnWidth = 50;
		private int m_BtnHeight = 35;
		private int m_BtnInter = 5;

		[Category("KeyPad"), Browsable(true)]
		public Control? ForcusItem 
		{
			get { return m_Btns[0].ForcusItem; }
			set
			{
				for (int i = 0; i < this.m_Btns.Length; i++)
				{
					m_Btns[i].ForcusItem = value;
				}
			}
		}

		private KeyBtn[] m_Btns = new KeyBtn[36];
		private string[] m_BtnCaptions = new string[]
		{
			"CLR","F","<<",">>","%","BS",
			"!",  "E","(" ,")", "^","/",
			"&&",  "D","7" ,"8", "9","*",
			"|",  "C","4" ,"5", "6","-",
			"0x", "B","1", "2", "3","+",
			"0b", "A","Sp","0", ".","Ent"
		};

		[Category("KeyPad"), Browsable(true)]
		public new Font Font
		{
			get { return base.Font; }
			set 
			{
				base.Font = value; 
				for(int i=0; i<this.m_Btns.Length; i++)
				{
					m_Btns[i].Font = value;
				}
			}
		}
		[Category("KeyPad"), Browsable(true)]
		public Size BtnSize
		{
			get { return m_Btns[0].Size; }
			set
			{
				m_BtnWidth = value.Width;
				m_BtnHeight = value.Height;
				ChkSize();
			}
		}
		[Category("KeyPad"), Browsable(true)]
		public int BtnInter
		{
			get { return m_BtnInter; }
			set
			{
				if (m_BtnInter != value)
				{
					m_BtnInter = value;
					ChkSize();
				}
			}
		}
		public void ChkSize()
		{
			for (int i = 0; i < m_Btns.Length; i++)
			{
				m_Btns[i].Size = new Size(m_BtnWidth, m_BtnHeight);
				int x = (i % 6) * (m_BtnWidth + m_BtnInter);
				int y = (i / 6) * (m_BtnHeight + m_BtnInter);
				m_Btns[i].Location = new Point(x, y);
			}
			this.MaximumSize = new Size(0, 0);
			this.MinimumSize = new Size(0, 0);
			this.Size = new Size(
			m_BtnWidth * 6 + m_BtnInter * 5,
			m_BtnHeight * 6 + m_BtnInter * 5
			);
			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;
		}
		public Key10Pad()
		{
			InitializeComponent();
			for(int i=0; i< m_Btns.Length;i++)
			{
				m_Btns[i] = new KeyBtn();
				m_Btns[i].Name = "btn" + m_BtnCaptions[i];
				m_Btns[i].Text = m_BtnCaptions[i];
				m_Btns[i].Size = new Size(m_BtnWidth, m_BtnHeight);
				int x = (i % 6) * (m_BtnWidth + m_BtnInter);
				int y = (i / 6) * (m_BtnHeight + m_BtnInter);
				m_Btns[i].Location = new Point(x, y);
				m_Btns[i].FlatStyle = FlatStyle.Flat;
				m_Btns[i].Btn += (sender, e) =>
				{
					KeyBtn? btn = (KeyBtn?)sender;
					if (btn != null)
					{
						Debug.WriteLine("Pad" +btn.Text);
						OnBtn(new BtnEventArgs(btn.Text));
					}
				};
				this.Controls.Add(m_Btns[i]);
			}
			this.Size = new Size(
				m_BtnWidth * 6 + m_BtnInter * 5,
				m_BtnHeight * 6 + m_BtnInter * 5
				);
			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

		}

		
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);

		}
	}
}

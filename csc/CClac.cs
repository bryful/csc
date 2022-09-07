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
	public enum CCalcMode
	{
		NORMAL=0,
		SecKoma
	}
	public enum Fps
	{
		Fps24 = 24,
		Fps30 = 30
	}

	public partial class CClac : Form
	{
		// *************************************************************
		private CCalcMode m_Mode = CCalcMode.NORMAL;
		// *************************************************************
		private double m_Result = 0;
		public double Result
		{
			get { return m_Result; }
		}
		// *************************************************************
		public CClac()
		{
			InitializeComponent();
			lbOpe.Text = "";
		}
		// *************************************************************
		private bool CalcGo()
		{
			bool ret = false;
			if (m_Mode==CCalcMode.NORMAL)
			{
				ret = true;
				if (tbInput.Text != "")
				{
					double b = double.Parse(tbInput.Text);
					switch (lbOpe.Text)
					{
						case "":
							m_Result = b;
							break;
						case "-":
							m_Result = m_Result - b;
							break;
						case "+":
							m_Result = m_Result + b;
							break;
						case "/":
							if (b != 0)
							{
								m_Result = m_Result / b;
							}
							else
							{
								ret = false;
							}
							break;
						case "*":
							m_Result = m_Result * b;
							break;
					}
				}

				tbResult.Text = String.Format("{0}", m_Result);
				tbInput.Text = "";
			}
			return ret;
		}
		// *************************************************************
		public void InputNum(string s)
		{
			string adds = "";
			string inp = tbInput.Text;
			switch(s)
			{
				case "0":
				case "1":
				case "2":
				case "3":
				case "4":
				case "5":
				case "6":
				case "7":
				case "8":
				case "9":
					adds = s;
					break;
				case "BS":
					if(inp!="")
					{
						inp = inp.Substring(0, inp.Length - 1);
						tbInput.Text = inp;
					}
					break;
				case "CLR":
				case "CLS":
					tbInput.Text = "";
					tbResult.Text = "";
					lbOpe.Text = "";
					m_Result = 0;

					break;
				case ".":
				case "秒":
					if ((inp.IndexOf(".")<0)&& (inp.IndexOf("秒") < 0))
					{
						adds = s;
					}
					break;
				/*
			case "-":
				if ((inp == "")|| (inp == "0"))
				{
					lbOpe.Text = s;
				}
				else
				{
					if (CalcGo())
					{
						lbOpe.Text = s;
					}
				}
				break;*/
				case "-":
				case "+":
				case "*":
				case "/":
					if(inp=="")
					{
						if(lbOpe.Text =="")
						{
							if ((s == "-") || (s == "+"))
							{
								lbOpe.Text = s;
							}
						}
						else
						{
							lbOpe.Text = s;
						}
					}
					else
					{
						if (CalcGo())
						{
							lbOpe.Text = s;
						}
					}
					break;
			}
			if (adds!="")
			{
				tbInput.Text = inp + adds;
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			InputNum(b.Text);
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			//base.OnKeyDown(e);
			tbInput.Text = String.Format("kc:{0}", e.KeyCode.ToString());

		}
	}
}

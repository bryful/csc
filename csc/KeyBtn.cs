using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Diagnostics;

namespace csc
{
	public partial class KeyBtn : Button
	{
		public delegate void BtnEventHandler(object sender, BtnEventArgs e);

		//イベントデリゲートの宣言
		public event BtnEventHandler? Btn = null;

		protected virtual void OnBtn(BtnEventArgs e)
		{
			if (Btn != null)
			{
				Btn(this, e);
			}
		}
		public Control? ForcusItem { get; set; } = null; 
		public KeyBtn()
		{
			InitializeComponent();
			this.Size = new Size(50, 40);
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			if(ForcusItem != null)
			{
				ForcusItem.Focus();
			}
		}
		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			Debug.WriteLine("key" + this.Text);

			OnBtn(new BtnEventArgs(this.Text));
			if (ForcusItem != null)
			{
				ForcusItem.Focus();
			}
		}
	}
	public class BtnEventArgs : EventArgs
	{
		public string Cmd = "";
		public BtnEventArgs()
		{

		}
		public BtnEventArgs(string s)
		{
			Cmd = s;
		}
	}
}

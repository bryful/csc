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
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.ApplicationServices;

namespace csc
{
	// ********************************************************************************************
	class Program
	{
		//**********************************************************************************
		static void Usage(CArgs opt)
		{
			string txt = "";
			txt += "[csc.exe] stsrem.callSystem command\r\n";

			for (int i= (int)CSCMODE.FromClipboard; i<CArgs.Params.Length;i++)
			{
				txt += "  csc -" + opt.Separator(i) + " or -"+ opt.Separator2(i) + "\t// " + CArgs.Params[i].Comment + "\r\n";
			}
			Console.WriteLine(txt);

		}
		//**********************************************************************************
		[STAThread]
		static void Main(string[] args)
		{
			CArgs opt = new CArgs(args);
			if((int)opt.Mode<(int)CSCMODE.FromClipboard)
			{
				Usage(opt);
				return;
			}
			switch (opt.Mode)
			{
				case CSCMODE.FromClipboard:
					Console.Write(CClipboard.FromClipboard());
					break;
				case CSCMODE.ToClipboardFromFile:
					string[] ps = opt.Plist();
					if(ps.Length>0)
					{
						for(int i=0; i<ps.Length;i++)
						{
							if (CClipboard.ToClipboardFromFile(ps[i])== ps[i])
							{
								Console.Write(ps[i]);
								break;
							}
						}
					}
					break;
				case CSCMODE.FolderDialog:
					string p = "";
					string[] sa2 = opt.Plist();
					if(sa2.Length>0)
					{
						p = sa2[0];
					}
					Console.Write(CFolderDialog.ShowDialog(p));
					break;
				case CSCMODE.DropFolder:
					CDropFolder df = new CDropFolder();
					try
					{
						if( df.ShowDialog()==DialogResult.OK)
						{
							Console.Write(df.Folder);
						}
					}
					finally
					{
						df.Dispose();
					}
					break;
				case CSCMODE.MousePos:
					Console.Write(CMousePos.ToSource());
					break;
				case CSCMODE.MousePosJson:
					Console.Write(CMousePos.JSON());
					break;
				case CSCMODE.WindowMax:
					CWindows.WindowMax();
					Console.Write("WinodwMax");
					break;
				case CSCMODE.WindowMin:
					CWindows.WindowMin();
					Console.Write("WinodwMin");
					break;
				case CSCMODE.WindowNormal:
					CWindows.WindowNormal();
					Console.Write("WinodwNormal");
					break;
				case CSCMODE.AEProcessList:
					Console.Write(CWindows.AEProcessList());
					break;
				case CSCMODE.LineEdit:
					CLineEditDialog dlg = new CLineEditDialog();
					try
					{
						string[] sa = opt.Plist();
						dlg.Line = "";
						dlg.Caption = "";

						if (sa.Length>0)
						{
							dlg.Line = sa[0];
							if(sa.Length>1)
							{
								dlg.Text = sa[1];
							}
							if (sa.Length > 2)
							{
								dlg.Caption = sa[2];
							}
						}
						if (dlg.ShowDialog() == DialogResult.OK)
						{
							Console.Write(dlg.Line);
						}
					}
					finally
					{
						dlg.Dispose();
					}

						break;
				case CSCMODE.TextFile:
					CTextFileDialog dlg2 = new CTextFileDialog();
					try
					{
						string[] sa = opt.Plist();
						if (sa.Length > 0)
						{
							dlg2.LoadFromFile(sa[0]);
							if (sa.Length > 1)
							{
								dlg2.Text = sa[1];
							}
						}
						if (dlg2.ShowDialog() == DialogResult.OK)
						{
							Console.Write(dlg2.TextFile);
						}
					}
					finally
					{
						dlg2.Dispose();
					}

					break;

				case CSCMODE.Calc:

					CCalc cc = new CCalc();
					try
					{
						string[] sa = opt.Plist();
						if(sa.Length>0)
						{
							cc.ValueStr = sa[0];
						}

						if (cc.ShowDialog()==DialogResult.OK)
						{

							Console.Write(cc.ValueStr);
						}
					}
					finally
					{
						cc.Dispose();
					}
					break;
				case CSCMODE.PCInfo:
					Console.Write(CWindows.PCInfo());
					break;
				case CSCMODE.Alert:
					CAlert ca = new CAlert();
					try
					{
						string[] sa = opt.Plist();
						if (sa.Length > 0)
						{
							if (ca.LoadFromFile(sa[0])==false)
							{
								string ss = "";
								foreach(string sss in sa)
								{
									if (ss != "") ss += "<br>";
									ss += sss;
								}
								ca.SetHtml(ss);
								ca.ToCenter();
							}
							if (ca.ShowDialog() == DialogResult.OK)
							{
							}
						}

					}
					finally
					{
						ca.Dispose();
					}

					break;
				default:
					Usage(opt);
					break;
			}

		}
		//**********************************************************************************
	}
}

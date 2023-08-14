namespace csc
{
	internal static class Program
	{
		//**********************************************************************************
		static void Usage(CArgs opt)
		{
			string txt = "";
			txt += "[csc.exe] system.callSystem command\r\n";

			for (int i = (int)CSCMODE.FromClipboard; i < CArgs.Params.Length; i++)
			{
				txt += "  csc -" + opt.Separator(i) + " or -" + opt.Separator2(i) + "\t// " + CArgs.Params[i].Comment + "\r\n";
			}
			Console.WriteLine(txt);

		}
		[STAThread]
		static void Main(string[] args)
		{
			CArgs opt = new CArgs(args);
			if ((int)opt.Mode < (int)CSCMODE.FromClipboard)
			{
				Usage(opt);
				return;
			}
			string [] ps = opt.Plist();
			switch (opt.Mode)
			{
				case CSCMODE.FromClipboard:
					Console.Write(CClipboard.FromClipboard());
					break;
				case CSCMODE.ToClipboardFromFile:
					if (ps.Length > 0)
					{
						for (int i = 0; i < ps.Length; i++)
						{
							if (CClipboard.ToClipboardFromFile(ps[i]) == ps[i])
							{
								Console.Write(ps[i]);
								break;
							}
						}
					}
					break;
				case CSCMODE.ToClipboard:
					string c = "";
					for (int i = 0; i < args.Length; i++)
					{
						if ((args[i][0] == '-') || (args[i][0] == '/'))
						{
							string a = args[i].Substring(1).ToLower();
							if ((a == "toclipboard") || (a == "toclip")) continue;
						}
						if (c != "") c = c + "";
						c += args[i];
					}
					Clipboard.SetText(c);
					break;
				
				case CSCMODE.FolderDialog:
					string p = "";
					if (ps.Length > 0)
					{
						p = ps[0];
					}
					Console.Write(CFolderDialog.ShowSelectFolderDialog(p));
					break;
				
				
				case CSCMODE.DropFolder:
					using (CDropFolder df = new CDropFolder())
					{
						if (df.ShowDialog() == DialogResult.OK)
						{
							Console.Write(df.Folder);
						}
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
						dlg.Line = "";
						dlg.Caption = "";

						if (ps.Length > 0)
						{
							dlg.Line = ps[0];
							if (ps.Length > 1)
							{
								dlg.Text = ps[1];
							}
							if (ps.Length > 2)
							{
								dlg.Caption = ps[2];
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
					using (CTextFileDialog dlg2 = new CTextFileDialog())
					{
						if (ps.Length > 0)
						{
							dlg2.LoadFromFile(ps[0]);
							if (ps.Length > 1)
							{
								dlg2.Text = ps[1];
							}
						}
						if (dlg2.ShowDialog() == DialogResult.OK)
						{
							Console.Write(dlg2.TextFile);
						}
					}

					break;
				case CSCMODE.Calc:

					using (CCalc cc = new CCalc())
					{
						if (ps.Length > 0)
						{
							cc.ValueStr = ps[0];
						}

						if (cc.ShowDialog() == DialogResult.OK)
						{

							Console.Write(cc.ValueStr);
						}

					}
					break;
				case CSCMODE.PCInfo:
					Console.Write(CWindows.PCInfo());
					break;
				case CSCMODE.Alert:
					using (CAlert ca = new CAlert())
					{
						if (ps.Length > 0)
						{
							if (ca.LoadFromFile(ps[0]) == false)
							{
								string ss = "";
								foreach (string sss in ps)
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
					break;
				case CSCMODE.JavaScript:

					using (JSForm js = new JSForm())
					{
						if (ps.Length > 0)
						{
							js.Code = ps[0];
						}

						if (js.ShowDialog() == DialogResult.OK)
						{

							Console.Write(js.Result);
						}

					}
					break;
				case CSCMODE.CPPl:
					AE_CPPl cppl = new AE_CPPl();
					string ret = "0";
					if (ps.Length > 0)
					{
						cppl.FileName = ps[0];
						ret = $"{cppl.CPPl_Size}";
					}
					Console.Write(ret);
					break;
				case CSCMODE.CPPlFix:
					AE_CPPl cppl3 = new AE_CPPl();
					string ret3 = "false";
					if (ps.Length > 0)
					{
						cppl3.FileName = ps[0];
						if(cppl3.FileName!="")
						{
							if (cppl3.Export(ps[1]))
							{
								ret3 = "true";
							}
						}
					}
					Console.Write(ret3);
					break;
				case CSCMODE.KillAerender:
					int idx = CWindows.KillAerender();
					Console.Write($"{idx}"); 
					break;
				default:
					Usage(opt);
					break;
			}

		}
	}
}
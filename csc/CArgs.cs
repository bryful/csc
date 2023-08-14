using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csc
{
	public enum CSCMODE
	{
		None = 0,
		Help1,
		Help2,
		FromClipboard,
		ToClipboardFromFile,
		ToClipboard,
		FolderDialog,
		DropFolder,
		MousePos,
		MousePosJson,
		WindowMax,
		WindowMin,
		WindowNormal,
		AEProcessList,
		LineEdit,
		TextFile,
		PCInfo,
		Alert,
		Calc,
		JavaScript,
		CPPl,
		CPPlFix,
		KillAerender,
		Count
	}
	public class Param
	{
		public string m_Separator = "";
		public string Separator { get { return m_Separator; } }
		public string m_Separator2 = "";
		public string Separator2 { get { return m_Separator2; } }
		public string m_Comment ="";
		public string Comment { get { return m_Comment; } }
		public Param(string sepa, string sepa2, string cmt)
		{
			m_Separator = sepa;
			m_Separator2 = sepa2;
			m_Comment = cmt;
		}

	}

	public class CArgs
	{
		string[] m_args = new string[0];
		// ********************************************************************
		private CSCMODE m_Mode = CSCMODE.None;
		public CSCMODE Mode { get { return m_Mode; } }
		private int m_SepaLength = 0;
		private int m_SepaLength2 = 0;
		// ********************************************************************
		static public Param[] Params = new Param[]
		{
			new Param("","","Help表示"),
			new Param("Help","H","Help表示"),
			new Param("?","？","Help表示"),
			new Param("FromClipboard","clip","クリップボードのテキストを出力。"),
			new Param("ToClipboardFromFile","clipFile","テキストファイル(UTF-8)をクリップボードへ"),
			new Param("ToClipboard","toclip","引数を全部クリップボードへ"),
			new Param("FolderDialog","fd","フォルダ選択ダイアログ"),
			new Param("DropFolder","dd","D&Dでフォルダを選択"),
			new Param("MousePos","mp","マウスカーソルの座標を出力。toSource形式 ({x:100,y:100})"),
			new Param("MousePosJson","mpj","マウスカーソルの座標を出力。JSON形式 {\"x\":100,\"y\":100}"),
			new Param("WindowMax","wmax","AEのウィンドウを最大化"),
			new Param("WindowMin","wmin","AEのウィンドウを最小化"),
			new Param("WindowNormal","wn","AEのウィンドウを通常化"),
			new Param("AEProcessList","aps","起動しているAEのプロセス情報。配列のtoSource形式"),
			new Param("LineEdit","le","1行のテキスト編集"),
			new Param("TextFile","tf","テキストファイル編集 csc -tf ファイルパス <タイトル名>"),
			new Param("PCInfo","pi","PC情報"),
			new Param("Alert","at","アラート表示"),
			new Param("Calc","cc","計算機"),
			new Param("JavaScript","js","JavaScript解析"),
			new Param("CPPl","cp","CPPlサイズ　byteサイズ文字列が返り値"),
			new Param("CPPlFix","cpf","CPPl削除 : csc -cpf \"[元Path]\" \"[変換後Path]\""),
			new Param("KillAerender","kr","aerender強制終了 : csc -kr")
		};
		// ********************************************************************
		private string SP(string s,int mx)
		{
			string ret = s;
			int slen = s.Length;
			if(slen < mx)
			{
				for(int i=0; i<mx- slen; i++)
				{
					ret += " "; 
				}
			}
			return ret;
		}
		// ********************************************************************
		public string Separator(int idx)
		{
			return SP(Params[idx].Separator, m_SepaLength);
		}
		public string Separator2(int idx)
		{
			return SP(Params[idx].Separator2, m_SepaLength2);
		}
		// ********************************************************************
		private string GetOption(string[] args,int idx)
		{
			string ret = "";
			if (args.Length <= 0) return ret;
			int cnt = 0;
			for (int i=0; i< args.Length;i++)
			{
				if ((args[i][0] == '/') || (args[i][0] == '-'))
				{
					if (cnt == idx)
					{
						ret = args[i].Substring(1);
						break;
					}
					cnt++;
				}

			}
			return ret;
		}
		// ********************************************************************
		public string [] Plist()
		{
			string [] ret = new string[0];
			if(m_args.Length>1)
			{
				List<string> lst = new List<string>();
				for(int i=1; i< m_args.Length;i++)
				{
					if ((m_args[i][0]!='/')&& (m_args[i][0] != '_'))
					{
						lst.Add(m_args[i]);
					}
				}
				if(lst.Count>0)
				{
					ret = lst.ToArray();
				}
			}
			return ret;
		}
		// ********************************************************************
		public CArgs(string[] args)
		{
			m_SepaLength = 0;
			m_SepaLength2 = 0;
			for (int i = 0; i < Params.Length; i++)
			{
				if (m_SepaLength < Params[i].Separator.Length)
				{
					m_SepaLength = Params[i].Separator.Length;
				}
				if (m_SepaLength2 < Params[i].Separator2.Length)
				{
					m_SepaLength2 = Params[i].Separator2.Length;
				}
			}

			if (args.Length <= 0) return;
			m_args = args;
			string opt = GetOption(args, 0).ToLower();

			m_Mode = CSCMODE.None;
			for (int i=0; i< Params.Length;i++)
			{
				if((opt == Params[i].Separator.ToLower())|| (opt == Params[i].Separator2.ToLower()))
				{
					m_Mode = (CSCMODE)i;
					break;
				}
			}


		}
		// ********************************************************************
	}
}

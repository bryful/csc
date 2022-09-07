// **********************************************
// csc.exeを呼び出すためのライブラリー
/*
    CSC.run("-clip");
    こんな感じに簡単に呼び出せます。

    CSC.run("-FolderDialg",Folder.myDocuments);
    パスは文字列かFile/Folderオブジェクトを引数にします。

    csc.exeの場所は以下の関数を呼び出せば設定されます。
        useScriptsFolder();　を実行でScriptsフォルダー
        useScriptUI_Folder();　を実行でScriptUI Panelsフォルダー
        useJsxFolder();　を実行で実行しているスクリプトファイルと同じ場所

    その他の場所に置きたい時は
        CSC.setCscExeFile(パス);
    で設定。

*/
CSC = {};
// **********************************************
(function(me){
    var error = false;
    var scriptsFolder = null;
    var cscExeFile = null;
    var cscExe = "csc.exe";
    // *****************************
    function setCscExeFile(f)
    {
        var ret = false;
        if (f instanceof File){
            cscExeFile  = f;
            ret = true;
        } else if (typeof(f)=="string")
        {
            cscExeFile  = new File(f);
            ret = true;
        }
        ret = cscExeFile.exists;
        return ret;
    }
    CSC.setCscExeFile = setCscExeFile;
    // *****************************
    // スクリプトフォルダを獲得
    function getScriptsFolder()
    {
        var afterFXFile =
            new File(BridgeTalk.getAppPath(BridgeTalk.appName));
        scriptsFolder =
         new Folder(afterFXFile.parent.fullName + "/Scripts");
    }
    CSC.getScriptsFolder = getScriptsFolder;
    // *****************************
    // csc.exeの場所をScriptsフォルダとする
    function useScriptsFolder()
    {
        getScriptsFolder();
        cscExeFile = new File(scriptsFolder.fillName+"/"+cscExe);
    }
    CSC.useScriptsFolder = useScriptsFolder;
    // *****************************
    // csc.exeの場所をScriptsUI Panelsフォルダとする
    function useScriptUI_Folder()
    {
        getScriptsFolder();
        try{
            var p = scriptsFolder.fullName+"/ScriptUI Panels/" +cscExe;
            cscExeFile = new File(p);
        }catch(e){
            alert(e.toString());
        }
    }
    CSC.useScriptUI_Folder = useScriptUI_Folder;
    // *****************************
    // csc.exeの場所を実行スクリプトファイルと同じとする。
    function useJsxFolder()
    {
        var jsxF = new Folder(new File(File.decode($.fileName)).parent.fullName);
        cscExeFile = new  File(jsxF.fullName+"/"+cscExe);
    }
    CSC.useJsxFolder = useJsxFolder;
    // *****************************
    //実行。引数を忘れずに
    function run()
    {
        function WS(s){return "\"" + s + "\"";}
        function SP(){return " ";}
        function isUseSP(s)
        {
            var ret = false;
            if(s.length>0)
            {
                for (var i=0; i<s.length;i++)
                {
                    if (s[i]==" ")
                    {
                        ret = true;
                        break;
                    }
                }
            }
            return ret;
        }
        var ret = "";
        error = false;
        try{
            if (cscExeFile.exists==false){
                alert(cscExeFile.fullName + "\r\nがありません");
                return ret;
            }
            if(arguments.length<=0) {
                alert("引数が必要です");
                return ret;
            }
            if ( (typeof(arguments[0])=="string")||(arguments[0][0]!="/")&&(arguments[0][0]!="-"))
            {
                alert("セレクターに-か/が付いていません");
                return ret;
            }
        }catch(e){
            alert(e.toString());
        }

        try{
            error = true;
            var cmd = WS(cscExeFile.fsName)+ " ";
            cmd += arguments[0];
            var ss = "";
            if (arguments.length>1)
            {
                for ( var i=1;i<arguments.length;i++)
                {
                    if ((arguments[i] instanceof File)||(arguments[i] instanceof Folder))
                    {
                        ss += " " + WS(arguments[i].fsName);
                    }else if (isUseSP(arguments[i])==true)
                    {
                        ss += " " + WS(arguments[i]);
                    }else{
                        ss += " " +arguments[i];
                    }
                }
            }
            cmd += ss;
            ret = system.callSystem(cmd);
        }catch(e){
            ret = "error:" + e.toString();
            error = false;
        }
        // ヘルプが表示されたらerror;

        if (ret.indexOf("[csc.exe] stsrem.callSystem")==0)
        {
            ret = "";
        }
        return ret;
    }
    CSC.run = run;
    // *****************************
    //初期化スタートアップ関数
    function startup()
    {
        scriptsFolder = null;
        cscExeFile = null;
        //useScriptsFolder();
        useScriptUI_Folder();
        //useJsxFolder();
    }
    startup();
    // *****************************
})(this);

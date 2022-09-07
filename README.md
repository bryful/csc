# csc.exe
After Effectsのスクリプトの<b>system.callSystem()</b>から呼び出すコマンドです。<br>
<br>
今までいっぱい作ってましたがいっぱいあると管理が面倒だったので、一つにまとめてしまおうと思い作ったものです。

## Usage

```
[csc.exe] stsrem.callSystem command
  csc -FromClipboard       or -clip    	// クリップボードのテキストを出力。
  csc -ToClipboardFromFile or -clipFile	// テキストファイル(UTF-8)をクリップボードへ
  csc -FolderDialg         or -fd      	// フォルダ選択ダイアログ
  csc -DropFolder          or -dd      	// D&Dでフォルダを選択
  csc -MousePos            or -mp      	// マウスカーソルの座標を出力。toSource形式 ({x:100,y:100})
  csc -MousePosJson        or -mpj     	// マウスカーソルの座標を出力。JSON形式 {"x":100,"y":100}
  csc -WindowMax           or -wmax    	// AEのウィンドウを最大化
  csc -WindowMin           or -wmin    	// AEのウィンドウを最小化
  csc -WindowNormal        or -wn      	// AEのウィンドウを通常化
  csc -AEProcessList       or -aps     	// 起動しているAEのプロセス情報。配列のtoSource形式
  csc -LineEdit            or -le      	// 1行のテキスト編集
  csc -TextFile            or -tf      	// テキストファイル編集



```
基本的に、第一引数が機能のセパレータで、その後に細かいパラメータが指定できます。

### <b>csc.exeのインストール先</b>
基本的にどこでもいいですが、使い易さを考えるとスクリプトファイルと同じフォルダに入れると良いでしょう。

以下のコードでスクリプトフォルダのFolderオブジェクトを獲得できます。
```
// AEのパスからScriptsフォルダを獲得
var afterFXFile = new File(BridgeTalk.getAppPath(BridgeTalk.appName));
var ScriptsFolder = new Folder(afterFXFile.parent.fsName + "/Scripts");

// 実行しているスクリプトファイルのフォルダを獲得
var jsxFolder = new Folder(new File(File.decode($.fileName)).parent);
```
### <b>csc.exeの実行</b>
system.callSystemで呼び出す時はWindows形式のパスで呼び出す必要があります。ただし、引数でcscに与えるパスはjs形式でもWindows形式でも構いません。
```
function WS(s){return "\"" + s + "\"";}
function SP(){return " ";}

var cscPath = ScriptsFolder.fsName + "\\csc.exe";
var sepa = "-clipFile";
var arg1 = "/c/test.txt"; // "C:\\test.txt" でもいい
var cmd = WS(cscPath) + SP() + sepa + SP() + WS(arg1);
system.callSystem(cmd);
```
上記のコードがcsc.exeの呼び出しになります。
<hr>
<br>

### <b>csc.exeの返り値</b>
各コマンド毎に必ず文字列を標準出力へ返します。空の文字列(Empty)が返された時はエラーとなります。<br>
"[csc.exe] stsrem.callSystem command"で始まる文字列の場合はヘルプ表示になります。

詳細なドキュメントは完成したら作るつもりです。<br>

### <b>CSC.jsx</b>
スクリプトから簡単に呼び出せるライブラリを作りました。<br>
run関数にセパレータ、次に引数を入れて実行です。
```
CSC.run("-clip");
CSC.run("-clipFile","/c/test.txt");
CSC.run("-clipFile",new File("/c/test.txt"));
```

## command References
<hr>

### <b>csc -FromClipboard or -clip</b>
クリップボードにあるテキストデータを出力します。
```
var result = system.callSystem("csc -clip");
alert(result); // クリップボードの内容
```
<hr>

### <b>csc -ToClipboardFromFile or -clipFile</b>
指定されたテキストファイルをクリップボードへ取り込みます。
```
system.callSystem("csc -clipFile /c/test.txt");
```
<hr>

### <b>csc -FolderDialg or -fd</b>
フォルダ選択ダイアログを表示します。
引数にデフォルトのパスを指定できます。
```
var defpath = "/e/TestFolder
var result system.callSystem("csc -fd \"" + defpath + "\")";
alert(result); //フォルダのパス文字列
```




## License
This software is released under the MIT License, see LICENSE.

## Authors

bry-ful(Hiroshi Furuhashi)<br>
twitter:[bryful](https://twitter.com/bryful)<br>
bryful@gmail.com<br>

# References

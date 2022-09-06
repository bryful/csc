# csc.exe  
After Effectsのスクリプトの<b>system.callSystem()</b>から呼び出すコマンドです。<br>


## Usage

```
[csc.exe] stsrem.callSystem command
  csc -FromClipboard       or -clip    	// クリップボードのテキストを出力。
  csc -ToClipboardFromFile or -clipFile	// テキストファイル(UTF-8)をクリップボードへ
  csc -FolderDialg         or -fd      	// フォルダ選択ダイアログ
  csc -MousePos            or -mp      	// マウスカーソルの座標を出力。toSource形式 ({x:100,y:100})
  csc -MousePosJson        or -mpj     	// マウスカーソルの座標を出力。JSON形式 {"x":100,"y":100}
  csc -WindowMax           or -wmax    	// AEのウィンドウを最大化
  csc -WindowMin           or -wmin    	// AEのウィンドウを最小化
  csc -WindowNormal        or -wn      	// AEのウィンドウを通常化
  csc -AEProcessList       or -aps     	// 起動しているAEのプロセス情報。配列のtoSource形式
  csc -LineEdit            or -le      	// 1行のテキスト編集
  csc -TextFile            or -tf      	// テキストファイル編集。
  csc -calc                or -c       	// 電卓を表示 ！未実装
  csc -SecCalc             or -sc      	// 秒数電卓を表示 ！未実装

```

詳細なドキュメントは完成したら作るつもりです。<br>

## License
This software is released under the MIT License, see LICENSE. 

## Authors

bry-ful(Hiroshi Furuhashi)  
twitter:[bryful](https://twitter.com/bryful)  
bryful@gmail.com  

# References

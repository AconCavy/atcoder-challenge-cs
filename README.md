# AtCoder Tasks

AtCoderで解いた問題のプログラム (C#, .NET Core) を保存するためのリポジトリです．

## 実行環境

.NET Core 3.1.x

## テンプレートのインストール

[AconCavy/CompetitiveProgrammingTemplateCSharp](https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp)をインストールします．

## プロジェクトの作成

Windowsの場合は `atcoder.bat`， Mac OSまたはLinuxの場合は `atcoder.sh` をプロジェクト名とともに実行すると，プロジェクトが作成され，コンテストサイトが開きます．

```
./atcoder.bat ABC177
```

```
./atcoder.sh ABC177
```

## Task の追加

Windowsの場合は `add-task.bat`，Mac OSまたはLinuxの場合は `add-task.sh` をタスク名とともに実行すると，`Tasks` と `Tests` の下にそれぞれテンプレートファイルを生成されます．
`(root)/ABC177` の場合に，以下のように実行すると，`(root)/ABC177/Tasks/E.cs` と `(root)/ABC177/Tests/ETests.cs` がそれぞれ生成されます．

```
../add-task.bat E
```

```
../add-task.sh E
```

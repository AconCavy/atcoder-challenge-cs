# AtCoder Tasks

AtCoderで解いた問題のプログラム (C#, .NET Core) を保存するためのリポジトリです．

## 実行環境

.NET Core 3.1.x

## テンプレートのインストール

次の .NET Core プロジェクト / アイテムテンプレートをインストールします．

- `AtCoderTemplate`
- `SolverTemplate`
- `TestsTemplate`

```
dotnet new -i ./Templates/SolverTemplate
dotnet new -i ./Templates/TestsTemplate
dotnet new -i ./Templates/AtCoderTemplate
```

### Windows

`atcoder-inst.bat` を実行すると3つのテンプレートがインストールされます．

## テンプレートのアンインストール

上記のテンプレートをアンインストールします．

```
dotnet new -u ./Templates/SolverTemplate
dotnet new -u ./Templates/TestsTemplate
dotnet new -u ./Templates/AtCoderTemplate
```

### Windows

`atcoder-uninst.bat` を実行すると3つのテンプレートがアンインストールされます．

## プロジェクトの作成


### Windows

`atcoder.bat` をプロジェクト名とともにコンソール上で実行することでプロジェクトが作成され，コンテストサイトが開きます．

```
./atcodet.bat ABC177
```

## タスクのテスト

タスクごとにテストが生成されるので，`input` と `output`に入出力を記述します．

```
public void TestMethod1()
{
    var input = @"Foo"; // Here
    var output = @"FooBar"; // Here
    Tester.InOutTest(() => Tasks.A.Solve()input, output);
}
```

小数点以下の誤差許容がある場合は，10の指数表記を引数に追加できます．

```
public void TestMethod1()
{
    var input = @"5"; // Here
    var output = @"2.50000000"; // Here
    Tester.InOutTest(() => Tasks.B.Solve()input, output, -6); // 誤差10e-6まで許容
}
```

問題の `Solve` メソッド内に実装を書きます．
```
public class A
{
    static void Main(string[] args)
    {
        var sw = new StreamWriter(ConsoleOpenStandardOutput()) { AutoFlush =false };
        Console.SetOut(sw);
        Solve();
        Console.Out.Flush();
    }
    public static void Solve()
    {
        var S = Console.ReadLine();
        Console.WriteLine(S + "Bar");
    }
}
```

`dotnet test` コマンドでソリューションをテストします．

```
dotnet test
```

## プロジェクトの個別実行

`Tasks.csproj` でスタートアッププロジェクトを指定します．

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <StartupObject>Tasks.A</StartupObject>
    <!-- <StartupObject>Tasks.B</StartupObject> -->
    <!-- <StartupObject>Tasks.C</StartupObject> -->
    <!-- <StartupObject>Tasks.D</StartupObject> -->
  </PropertyGroup>

</Project>

```

`dotnet run` コマンドでプロジェクト指定オプションを付けてプロジェクトを実行します．

```
dotnet run -p ./Tasks/Tasks.csproj
```

## Task の追加

`E` を追加する場合は下記コマンドを実行します．

```
dotnet new atcsolver -n E -o ./Tasks
dotnet new atctests -n E -o ./Tests
```

### Windows

`add-task.bat` にタスク名とともに実行することで，`./Tasks` と `./Tests` 以下にそれぞれテンプレートを生成できます．
カレントが `ABC177` の場合は以下のように実行すると，`ABC177/Tasks` と `ABC177/Tests` 内にそれぞれ生成されます．

```
../add-task.bat E
```

## 備考

テンプレートの更新により，一部プロジェクトでは古いテンプレートプロジェクト構成のまま放置している場合があります．

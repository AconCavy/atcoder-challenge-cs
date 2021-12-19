# Overview

The repository is C# solutions submitted for AtCoder.

## Environment

.NET Core 3.1

## Install Templates

Install [AconCavy/CompetitiveProgrammingTemplateCSharp](https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp).

You can use `install.cmd` or `install.sh`.

## Create Project

Create a project using the script with `new` command.

```sh
# Windows
./atcoder.cmd new ABC177

# macOS or Linux
./atcoder.sh new ABC177
```

In the example, the dotnet solution named `ABC177` that contains `Task` and `Test` projects will be created.

## Create Solver Items

Create solver items using the script with `add` command.

```sh
# Windows
./atcoder.cmd add ABC177 E

# macOS or Linux
./atcoder.sh add ABC177 E
```

In the example, `Task/E.cs` and `Test/ETests.cs` will be created in `ABC177` solution.

# Overview

The repository for C# solutions submitted to AtCoder.

## Environment

.NET Core 3.1.x

## Install templates

Installs [AconCavy/CompetitiveProgrammingTemplateCSharp](https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp).

## Create project

Creates base project with a project name using the `atcoder.bat` on Windows, the `atcoder.sh` on Mac Os or Linux.
After that, the specified contest web site will be opened.

### Windows

```sh
./atcoder.bat ABC177
```

### Mac OS or Linux

```sh
./atcoder.sh ABC177
```

## Append task

Creates solver items with a task name under the `Tasks` and the `Tests` using the `add-task.bat` on Windows, the `add-task.sh` on Mac Os or Linux.

For example, `(root)/ABC177/Tasks/E.cs` and `(root)/ABC177/Tests/ETests.cs` will be created if the current directory is `(root)/ABC177`.

### Windows

```sh
../add-task.bat E
```

### Mac OS or Linux

```sh
../add-task.sh E
```

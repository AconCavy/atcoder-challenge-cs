# Overview

The repository is C# solutions submitted for AtCoder.

## Environment

.NET Core 3.1

## Install Templates

Install [AconCavy/cp-template-csharp](https://github.com/AconCavy/cp-template-csharp).

You can use `install.cmd` or `install.sh`.

## Create Project

Create a new project using `atcoder.cmd` or `atcoder.sh` script.  
`ABCxxx`, `ARCxxx`, and `AGCxxx` projects will be created under `ABC`, `ARC`, and `AGC` directory.  
Other projects will be created under the `atcoder-csharp` root directory.

```sh
# Windows
./atcoder.cmd ABC000

# macOS or Linux
./atcoder.sh ABC000
```

## Create Solver file

Create a new solver file using `atcoder.cmd` or `atcoder.sh` script.  
A solver file with the specified task name will be created under the specified project by adding a name to the second argument.

```sh
# Windows
./atcoder.cmd ABC000 E

# macOS or Linux
./atcoder.sh ABC000 E
```

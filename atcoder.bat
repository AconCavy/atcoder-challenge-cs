@echo off
if "%~1"=="" (
    echo Need sln name
    exit /b
)
set SLN=%~1
start https://atcoder.jp/contests/%SLN%
dotnet new atcoder -n %SLN%
code -n . ./%SLN%/Tests/TestA.cs ./%SLN%/A/Program.cs ./%SLN%/Tests/TestB.cs ./%SLN%/B/Program.cs ./%SLN%/Tests/TestC.cs ./%SLN%/C/Program.cs ./%SLN%/Tests/TestD.cs ./%SLN%/D/Program.cs

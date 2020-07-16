@echo off
if "%~1"=="" (
    echo Need sln name
    exit /b
)
set SLN=%~1
start https://atcoder.jp/contests/%SLN%
dotnet new atcoder -n %SLN%
code -n . ./%SLN%/Tests/ATests.cs ./%SLN%/Tasks/A.cs ./%SLN%/Tests/BTests.cs ./%SLN%/Tasks/B.cs ./%SLN%/Tests/CTests.cs ./%SLN%/Tasks/C.cs ./%SLN%/Tests/DTests.cs ./%SLN%/Tasks/D.cs

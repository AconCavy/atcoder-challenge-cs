@echo off
if "%~1"=="" (
    echo Need sln name
    exit /b
)
set SLN=%~1

dotnet new atcoder -n %SLN%
dotnet new atcsolver -n A -o ./%SLN%/Tasks
dotnet new atctests -n A -o ./%SLN%/Tests
dotnet new atcsolver -n B -o ./%SLN%/Tasks
dotnet new atctests -n B -o ./%SLN%/Tests
dotnet new atcsolver -n C -o ./%SLN%/Tasks
dotnet new atctests -n C -o ./%SLN%/Tests
dotnet new atcsolver -n D -o ./%SLN%/Tasks
dotnet new atctests -n D -o ./%SLN%/Tests

start https://atcoder.jp/contests/%SLN%
code -n . ./%SLN%/Tests/ATests.cs ./%SLN%/Tasks/A.cs ./%SLN%/Tests/BTests.cs ./%SLN%/Tasks/B.cs ./%SLN%/Tests/CTests.cs ./%SLN%/Tasks/C.cs ./%SLN%/Tests/DTests.cs ./%SLN%/Tasks/D.cs

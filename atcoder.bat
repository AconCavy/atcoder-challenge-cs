@echo off
if "%~1"=="" (
    echo Need sln name
    exit /b
)
set SLN=%~1
start https://atcoder.jp/contests/%SLN%
dotnet new atcoder -n %SLN%
code -n .
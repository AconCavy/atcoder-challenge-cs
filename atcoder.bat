@echo off
if "%~1"=="" (
    echo Need sln name
    exit /b
)
set SLN=%~1
dotnet new atcoder -n %SLN%
cd %SLN%
dotnet restore
code .
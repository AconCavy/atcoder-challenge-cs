@echo off
if "%~1"=="" (
    echo Need task name
    exit /b
)
set TASK=%~1

dotnet new atcsolver -n %TASK%
dotnet sln add ./%TASK%/%TASK%.csproj
dotnet new atctests -n %TASK% -o ./Tests
dotnet add ./Tests/Tests.csproj reference ./%TASK%/%TASK%.csproj
code ./%TASK%/Program.cs
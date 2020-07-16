@echo off
if "%~1"=="" (
    echo Need task name
    exit /b
)
set TASK=%~1

dotnet new atcsolver -n %TASK% -o ./Tasks
dotnet new atctests -n %TASK% -o ./Tests
code ./Tests/%TASK%Tests.cs ./Tasks/%TASK%.cs
@echo off
if "%~1"=="" (
    echo option requires a task name as an argument
    exit /b
)
set TASK=%~1

dotnet new cpsolver -n %TASK% -o .\Tasks
dotnet new cptests -n %TASK% -o .\Tests
code .\Tests\%TASK%Tests.cs .\Tasks\%TASK%.cs

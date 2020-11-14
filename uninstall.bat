@echo off

set DIR=%~dp0

dotnet new -u %DIR%Templates\SolverTemplate
dotnet new -u %DIR%Templates\TestsTemplate
dotnet new -u %DIR%Templates\AtCoderTemplate
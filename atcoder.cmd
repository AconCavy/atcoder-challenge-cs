@echo off
if "%~1"=="" (
    echo option requires a sln name as an argument
    exit /b
)
set SLN=%~1

dotnet new cpproj -n %SLN% -f netcoreapp3.1
dotnet new cpsolver -n A -o .\%SLN%\Tasks
dotnet new cptests -n A -o .\%SLN%\Tests
dotnet new cpsolver -n B -o .\%SLN%\Tasks
dotnet new cptests -n B -o .\%SLN%\Tests
dotnet new cpsolver -n C -o .\%SLN%\Tasks
dotnet new cptests -n C -o .\%SLN%\Tests
dotnet new cpsolver -n D -o .\%SLN%\Tasks
dotnet new cptests -n D -o .\%SLN%\Tests

start https://atcoder.jp/contests/%SLN%
code -n . .\%SLN%\Tests\ATests.cs .\%SLN%\Tasks\A.cs .\%SLN%\Tests\BTests.cs .\%SLN%\Tasks\B.cs .\%SLN%\Tests\CTests.cs .\%SLN%\Tasks\C.cs .\%SLN%\Tests\DTests.cs .\%SLN%\Tasks\D.cs

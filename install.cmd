@echo off

set TEMPLATE_VERSION=3.0.1
set PACKAGE=AconCavy.CompetitiveProgramming.Templates.%TEMPLATE_VERSION%.nupkg
set URI=https://github.com/AconCavy/cp-template-csharp/releases/download/v%TEMPLATE_VERSION%/%PACKAGE%
set OUTPUT_DIR=tmp
set PACKAGE_PATH=./%OUTPUT_DIR%/%PACKAGE%

mkdir %OUTPUT_DIR%
powershell -Command "Invoke-WebRequest -Uri %URI% -OutFile %PACKAGE_PATH%"
dotnet new -i %PACKAGE_PATH%

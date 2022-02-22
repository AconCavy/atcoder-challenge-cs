@echo off

set TEMPLATE_VERSION=1.2.1
set OUTPUT_DIR=tmp

powershell -Command "New-Item %OUTPUT_DIR% -ItemType directory; Invoke-WebRequest -Uri https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp/releases/download/v%TEMPLATE_VERSION%/AconCavy.CompetitiveProgramming.Templates.%TEMPLATE_VERSION%.nupkg -OutFile ./tmp/AconCavy.CompetitiveProgramming.Templates.%TEMPLATE_VERSION%.nupkg; dotnet new -i ./%OUTPUT_DIR%/AconCavy.CompetitiveProgramming.Templates.%TEMPLATE_VERSION%.nupkg"
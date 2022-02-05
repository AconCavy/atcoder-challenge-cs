@echo off

set TEMPLATEVERSION=1.2.0

powershell -Command "New-Item tmp -ItemType directory; Invoke-WebRequest -Uri https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp/releases/download/v%TEMPLATEVERSION%/AconCavy.CompetitiveProgramming.Templates.%TEMPLATEVERSION%.nupkg -OutFile ./tmp/AconCavy.CompetitiveProgramming.Templates.%TEMPLATEVERSION%.nupkg; dotnet new -i ./tmp/AconCavy.CompetitiveProgramming.Templates.%TEMPLATEVERSION%.nupkg"
$templateVersion = "1.0.0"

Invoke-WebRequest -Uri "https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp/releases/download/v$templateVersion/AconCavy.CompetitiveProgramming.Templates.$templateVersion.nupkg" -OutFile "./tmp/AconCavy.CompetitiveProgramming.Templates.$templateVersion.nupkg"
dotnet new -i "./tmp/AconCavy.CompetitiveProgramming.Templates.$templateVersion.nupkg"

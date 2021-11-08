#!/bin/bash

TEMPLATEVERSION="1.0.0"

wget https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp/releases/download/v$TEMPLATEVERSION/AconCavy.CompetitiveProgramming.Templates.$TEMPLATEVERSION.nupkg -O tmp/AconCavy.CompetitiveProgramming.Templates.$TEMPLATEVERSION.nupkg
dotnet new -i tmp/AconCavy.CompetitiveProgramming.Templates.$TEMPLATEVERSION.nupkg

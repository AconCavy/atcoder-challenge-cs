#!/bin/bash

TEMPLATE_VERSION="1.2.1"
OUTPUT_DIR="tmp"

mkdir $OUTPUT_DIR
curl -L https://github.com/AconCavy/CompetitiveProgrammingTemplateCSharp/releases/download/v$TEMPLATE_VERSION/AconCavy.CompetitiveProgramming.Templates.$TEMPLATE_VERSION.nupkg -o ./$OUTPUT_DIR/AconCavy.CompetitiveProgramming.Templates.$TEMPLATE_VERSION.nupkg
dotnet new -i ./$OUTPUT_DIR/AconCavy.CompetitiveProgramming.Templates.$TEMPLATE_VERSION.nupkg

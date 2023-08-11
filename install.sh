#!/bin/bash

TEMPLATE_VERSION="3.0.1"
PACKAGE="AconCavy.CompetitiveProgramming.Templates.$TEMPLATE_VERSION.nupkg"
URI="https://github.com/AconCavy/cp-template-csharp/releases/download/v$TEMPLATE_VERSION/$PACKAGE"
OUTPUT_DIR="tmp"
PACKAGE_PATH="./$OUTPUT_DIR/$PACKAGE"

mkdir $OUTPUT_DIR
curl -L $URI -o $PACKAGE_PATH
dotnet new -i $PACKAGE_PATH

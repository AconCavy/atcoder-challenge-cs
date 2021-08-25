#!/bin/sh

if [ $# != 1 ]; then
    echo option requires a sln name as an argument
    exit 1
fi

SLN=$1

dotnet new cpproj -n $SLN -f netcoreapp3.1
dotnet new cpsolver -n A -o ./$SLN/Tasks
dotnet new cptests -n A -o ./$SLN/Tests
dotnet new cpsolver -n B -o ./$SLN/Tasks
dotnet new cptests -n B -o ./$SLN/Tests
dotnet new cpsolver -n C -o ./$SLN/Tasks
dotnet new cptests -n C -o ./$SLN/Tests
dotnet new cpsolver -n D -o ./$SLN/Tasks
dotnet new cptests -n D -o ./$SLN/Tests

case "$(uname -s)" in
    Darwin) open https://atcoder.jp/contests/$SLN ;;
    Linux) xdg-open https://atcoder.jp/contests/$SLN ;;
esac

code -n . ./$SLN/Tasks/Tasks.csproj ./$SLN/Tests/ATests.cs ./$SLN/Tasks/A.cs ./$SLN/Tests/BTests.cs ./$SLN/Tasks/B.cs ./$SLN/Tests/CTests.cs ./$SLN/Tasks/C.cs ./$SLN/Tests/DTests.cs ./$SLN/Tasks/D.cs

#!/bin/sh

if [ $# != 1 ]; then
    echo option requires a task name as an argument
    exit 1
fi

TASK=$1

dotnet new cpsolver -n $TASK -o ./Tasks
dotnet new cptests -n $TASK -o ./Tests
code ./Tests/${TASK}Tests.cs ./Tasks/${TASK}.cs

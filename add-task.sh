#!/bin/sh

if [ $# != 1 ]; then
    echo option requires a task name as an argument
    exit 1
fi

TASK=$1

dotnet new atcsolver -n $TASK -o ./Tasks
dotnet new atctests -n $TASK -o ./Tests
code ./Tests/$1Tests.cs ./Tasks/$1.cs
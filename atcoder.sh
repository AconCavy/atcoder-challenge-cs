#!/bin/bash

function help {
    echo "new: Create a new solution by the specified name."
    echo "add: Add a new task and test to the specified solution."
}

function add {
    if [ -z $1 ]; then
        echo The option requires a solution name as an argument.
        exit 1
    fi

    if [ -z $2 ]; then
        echo The option requires a task name as an argument.
        exit 1
    fi

    if [ $# != 2 ]; then
        echo The options are only a solution name and a task name as an argument.
        exit 1
    fi

    SLN=$1
    TASK=$2

    dotnet new cpsolver -n $TASK -o ./${SLN}/Tasks
    dotnet new cptests -n $TASK -o ./${SLN}/Tests
    code -n . ./${SLN}/Tests/${TASK}Tests.cs ./${SLN}/Tasks/${TASK}.cs
}

function new {
    if [ -z $1 ]; then
        echo The option requires a solution name as an argument.
        exit 1
    fi

    SLN=$1

    add $SLN A
    add $SLN B
    add $SLN C
    add $SLN D

    case "$(uname -s)" in
        Darwin) open https://atcoder.jp/contests/$SLN ;;
        Linux) $BROWSER https://atcoder.jp/contests/$SLN ;;
    esac
}

case $1 in
    help) help;;
    add) add $2 $3;;
    new) new $2;;
    *) help;;
esac

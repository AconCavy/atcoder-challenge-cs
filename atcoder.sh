#!/bin/bash

function help {
  echo "Usage: atcoder.sh [project-name]                Create a new project."
  echo "Usage: atcoder.sh [project-name] [task-name]    Create a new task to the project."
}

function task {
  PROJECT_PATH=$1
  TASK=$2
  OUTPUT_FILE=$PROJECT_PATH/$TASK.cs

  if [ -e $OUTPUT_FILE ]; then
    echo "$OUTPUT_FILE is already exist. Skip creating the file."
    return
  fi

  echo "Create $OUTPUT_FILE."
  dotnet new cpsolver -n $TASK -o $PROJECT_PATH
  code -n . $OUTPUT_FILE
}

function project {
  PROJECT_PATH=$1
  PROJECT=$2
  TARGET_FRAMEWORK=net7

  if [ -e $PROJECT_PATH ]; then
    echo "$PROJECT_PATH is already exist. Skip creating the project."
    return
  fi

  echo "Create $PROJECT to $PROJECT_PATH".
  dotnet new cpproj -n $PROJECT -f $TARGET_FRAMEWORK -o $PROJECT_PATH

  for p in A B C D E F; do
    task $PROJECT_PATH $p
  done

  code -n . $PROJECT_PATH/$PROJECT.csproj $PROJECT_PATH/Tests.cs

  case "$(uname -s)" in
    Darwin) open https://atcoder.jp/contests/$PROJECT ;;
    Linux) $BROWSER https://atcoder.jp/contests/$PROJECT ;;
  esac
}

PROJECT=$1
TASK=$2

if [ -z $PROJECT ] || [ $PROJECT = "help" ]; then
  help
  exit 0
fi

OUTPUT=$(cd $(dirname $0); pwd)
CONTENT_TYPE=${PROJECT:0:3}

if [[ $CONTENT_TYPE =~ A[BGR]C ]]; then
  OUTPUT=$OUTPUT/$CONTENT_TYPE
fi

if [ ! -d $OUTPUT ]; then
  mkdir $OUTPUT
fi

PROJECT_PATH=$OUTPUT/$PROJECT

if [ -z $TASK ]; then
  project $PROJECT_PATH $PROJECT
else
  task $PROJECT_PATH $TASK
fi

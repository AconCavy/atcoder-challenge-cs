@echo off

call :"%~1" %~2 %~3
exit /b

:""
:"help"
    echo new: Create a new solution by the specified name.
    echo add: Add a new task and test to the specified solution.
    exit /b

:"add"
    setlocal
    set SLN=%~1
    set TASK=%~2

    if "%SLN%"=="" (
        echo The option requires a solution name as an argument.
        exit /b
    )

    if "%TASK%"=="" (
        echo The option requires a task name as an argument.
        exit /b
    )

    call dotnet new cpsolver -n %TASK% -o .\%SLN%
    call code -n . .\%SLN%\%TASK%.cs
    endlocal
    exit /b

:"new"
    setlocal
    set SLN=%~1
    if "%SLN%"=="" (
        echo option requires a solution name as an argument.
        exit /b
    )

    call dotnet new cpproj -n %SLN% -f netcoreapp3.1
    call code -n . .\%SLN%\Tests.cs
    call :"add" %SLN% A
    call :"add" %SLN% B
    call :"add" %SLN% C
    call :"add" %SLN% D

    start https://atcoder.jp/contests/%SLN%
    endlocal
    exit /b

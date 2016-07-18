@Echo off
cls
echo [%time:~,8%] start install UVNC
pause
IF EXIST "%ProgramFiles(x86)%"( CALL :I64 ) ELSE ( CALL :I86 )
Echo looc wath do
pause
EXIT

:I64
echo [%time:~,8%] RUN 64 isntall version
pause
GOTO :EOF

:I86
echo [%time:~,8%] RUN 86 isntall version
Pause
GOTO :EOF 

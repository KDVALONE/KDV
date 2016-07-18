Echo off
cls
netsh advfirewall firewall show rule name="TCP5800"
set e1=%ERRORLEVEL%
IF %e1%==0 (CALL :Œ ) else (Echo NOT EXIST)
echo ANSWER [%e1%]
pause

:Œ  
echo OK (goto test)
echo OK2 (goto next command test)
GOTO :EOF
:: создаем папку в Programm Files, помещаем туда батник, добавляем правило для автозагрузки, запускаем батник после перезагрузки.
@Echo off
cls
Echo make dir md Program Files\TESTBAT\"
md "%SystemDrive%\Program Files\TESTBAT\"
set e=%ERRORLEVEL%
IF e==0 ( Echo OK ) else ( Echo NO )
pause

Echo copy batch file "ECHOTEST.bat" to dir Program Files\TESTBAT\"
copy "%~d0%~p0\ECHOTEST.bat" "%SystemDrive%\Program Files\TESTBAT\" /y
set e=%ERRORLEVEL%
IF e==0 ( Echo OK ) else ( Echo NO )
pause

set DISTR=%SystemDrive%\Program Files\TESTBAT\ECHOTEST.bat
set PARAM=/silent /sp- 

REG ADD "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" /v ECHOTESTBAT /t REG_SZ /d "%DISTR% %PARAM% " /f
set e=%ERRORLEVEL%
IF e==0 ( Echo OK ) else ( Echo NO )
pause
exit
::-------------дальше код ECHOTEST.bat который должен лежать там же где и батник RunBatAfterTest.bat
::::  @Echo off
::::  cls
::::  Echo ECHOTEST.bat autorun after reset PC was succes
::::  pause
::::  
::::  Echo delete dir with batch file
::::  del "%SystemDrive%\Program Files\TESTBAT\"
::::  
::::  
::::  
::::  
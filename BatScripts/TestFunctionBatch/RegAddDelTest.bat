::добавить/удалить ветку из реестра
@Echo off
cls
::::Echo add string to REG
::::pause
:::: добавляем ветку  реестра с для запуска батфайла с параметрами тихо, от имения аддмина.
::::set DISTR=%SystemDrive%\Program Files\TESTBAT\ECHOTEST.bat
::::set PARAM=/silent /sp- 
::::REG ADD "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" /v ECHOTESTBAT /t REG_SZ /d "%DISTR% %PARAM% " /f


::удаляем ветку реестра.
Echo delete string of REG
pause
REG delete "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" /v ECHOTESTBAT /f

exit

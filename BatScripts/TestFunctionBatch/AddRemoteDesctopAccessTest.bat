:: разрешаем удаленный доступ к ПК, для разрешения правим реестр.
@Echo off
cls
Echo add Remote Desctop Access
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server" /v fDenyTSConnections /t REG_DWORD /d 0 /f
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo rename error )
pause
exit

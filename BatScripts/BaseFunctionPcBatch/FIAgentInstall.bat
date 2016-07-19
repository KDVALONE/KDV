:: Установка FI agenta для инвентаризации пк
@echo off
cls



Echo firewall rule 62354
netsh advfirewall firewall add rule name="FI" dir=in action=allow protocol=TCP localport=62354
set e=%ERRORLEVEL%
IF %e%==0 ( Echo :OK ) else ( Echo NO )

Echo firewall icmpv4
netsh advfirewall firewall add rule name="All ICMP V4" protocol=icmpv4:any,any dir=in action=allow
set e=%ERRORLEVEL%
IF %e%==0 ( Echo :OK ) else ( Echo NO )

Echo install FI Agent

IF EXIST "%ProgramFiles(x86)%" ( CALL :FI64 ) else ( CALL :FI86 )
Echo FIA AGENT INSATLL

pause
exit


:FI64
Echo Start FIA x64
start /wait "" "%~d0%~p0distr\FIA64.exe" /S /acceptlicense /server="http://192.168.62.2/glpi/plugins/fusioninventory/" /add-firewall-exception
set e=%ERRORLEVEL%
IF %e%==0 ( Echo :OK ) else ( Echo NO )

Echo Run perl FIA x64
cd "C:\Program Files\FusionInventory-Agent\perl\bin"
perl fusioninventory-agent
set e=%ERRORLEVEL%
IF %e%==0 ( Echo OK ) else ( Echo NO )
pause
GOTO :EOF

:FI86
Echo Start FIA x86
start /wait "" "%~d0%~p0distr\FIA86.exe" /S /acceptlicense /server="http://192.168.62.2/glpi/plugins/fusioninventory/" /add-firewall-exception
set e=%ERRORLEVEL%
IF %e%==0 ( Echo OK ) else ( Echo NO )

Echo Run perl FIA x86
cd "C:\Program Files\FusionInventory-Agent\perl\bin"
perl fusioninventory-agent
set e=%ERRORLEVEL%
IF %e%==0 ( Echo OK ) else ( Echo NO )
pause
GOTO :EOF
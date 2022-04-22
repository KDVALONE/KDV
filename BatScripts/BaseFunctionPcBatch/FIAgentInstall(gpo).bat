:: Установка FI agenta для инвентаризации пк через гпо
:: 1 проверяем есть ли папка с установленным FIA, если нет то подключаемся к public монтируя как локальный диск и запускаем установку. Если есть то батник закрывается.
:: 1.2 проверяем есть ли папка с установленным FIA,если нет то подключаемся к public,и запускаем установку. Если есть то батник закрывается.
:: v.1.2  от 14.03.17
@echo off
cls

IF EXIST "%systemdrive%"\progra~1\FusionInventory-Agent (
EXIT
) else (
goto :NEXT1
)
 
:NEXT1
:: call PUBLIC DISC
::set SERVER=192.168.0.199
::set FOLDER=Public
::net use p: \\%SERVER%\%FOLDER%
::call PUBLIC DISC cancel

:: install FI Agent
IF EXIST "%ProgramFiles(x86)%" ( CALL :FI64 ) else ( CALL :FI86 )
:: FIA AGENT INSATLL COMPLITED


EXIT


:FI64
Echo Start FIA x64
::start /wait "" "%~d0%~p0distr\FIA64.exe" /S /acceptlicense /server="http://192.168.62.2/glpi/plugins/fusioninventory/" /add-firewall-exception
start /wait "" "\\192.168.0.199\Public\FIABAT\FIA64.exe" /S /acceptlicense /server="http://192.168.62.2/glpi/plugins/fusioninventory/" /add-firewall-exception
set e=%ERRORLEVEL%
IF %e%==0 ( Echo :OK ) else ( Echo NO )

Echo Run perl FIA x64
cd "C:\Program Files\FusionInventory-Agent\perl\bin"
perl fusioninventory-agent
set e=%ERRORLEVEL%
IF %e%==0 ( Echo OK ) else ( Echo NO )
::net use p: \\%SERVER%\%FOLDER% /delete
GOTO :EOF

:FI86
Echo Start FIA x86
start /wait "" "\\192.168.0.199\Public\FIABAT\FIA86.exe" /S /acceptlicense /server="http://192.168.62.2/glpi/plugins/fusioninventory/" /add-firewall-exception
set e=%ERRORLEVEL%
IF %e%==0 ( Echo OK ) else ( Echo NO )

Echo Run perl FIA x86
cd "C:\Program Files\FusionInventory-Agent\perl\bin"
perl fusioninventory-agent
set e=%ERRORLEVEL%
IF %e%==0 ( Echo OK ) else ( Echo NO )
::net use p: \\%SERVER%\%FOLDER% /delete
GOTO :EOF

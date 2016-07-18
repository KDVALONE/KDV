::v0.59  19.07.16
:: для корректного отображения крилицы в CMD batch файл нужно сохранить в OEM 866
@echo off
cls
:: заголовок окна
TITLE UVNC BATFILE SILENT INSTALL
::далее и после каждого действия используется код вывода сообщения об успешном выполненнии или нет.
::%ERRORLEVEL% равен 0 если успешно выполнена комманда выше, и 1 если не удачно. 


::---------------------------------Rename PC ----------------------------------------------------
Echo Enter new pc name:
Set /P PCNAME=""
wmic computersystem where name="%computername%" call rename "%PCNAME%"
cls
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo new pc name is %PCNAME% ) else ( Echo NO )
pause
::---------------------------------Rename PC cancel----------------------------------------------


::---------------------------------Remote Desctop Access-----------------------------------------
:::: разрешаем удаленный доступ к ПК, для разрешения правим реестр.
Echo on Remote Desctop Access
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server" /v fDenyTSConnections /t REG_DWORD /d 0 /f
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )
::---------------------------------Remote Desctop Access cancel-----------------------------------
  
  
::---------------------------------Remote Assistance ---------------------------------------------
::Включаем удаленный помощьник , для доступа правим реестр
Echo on Remote Assistance
reg add "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Terminal Server" /v fAllowToGetHelp /t REG_DWORD /d 1 /f 
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else (Echo NO )
::---------------------------------Remote Assistance cancel---------------------------------------


::---------------------------------add to Domain-------------------------------------------------
:TODMN
Echo Add PC to Domain: gb1.korolev.local (Y/N)? 
Set /p TDMN=""
if %TDMN%==y () else ()
:: вызов утилиты wmic /интерактивный режим выкл(при выкл.режиме после выполнени¤ одной команды wmic, управление возвращаетс¤ к cls windows (PROMT))).
:: система где "имя пк" вызвать метод JoinDomainOrWorkgroup (заведения в домен),с параметрами точка хода=1 (если 1 то к домену, строки нет - к раб.группе),
:: Name="имя домена/рабочей группы", имя пользователья домена с правами присоединения, пароль.  
wmic /interactive:off ComputerSystem Where "name = '%computername%'" call JoinDomainOrWorkgroup FJoinOptions=1 Name="my.domain.com" UserName="admin@my.domain.com"  Password="123" 
:: по умолчанию в cls отобразитьс¤ instance_PARMETRS value=0 (где 0 успех)
pause
::---------------------------------add to Domain cancel------------------------------------------

::---------Создаем правило для входящего TCP порта 5900,5800-------------------------------------
Echo [%time:~,8%] addfirewall rule UTP "VNCTCP59005800"
netsh advfirewall firewall add rule name="VNCTCP59005800" dir=in action=allow protocol=TCP localport=5900,5800
::Ниже типовой код вызова функции отображения информации об выполненнии, и занесения его в лог файл (создается при запуске бат)
set e1=%ERRORLEVEL%
IF %e1%==0 ( CALL :OK ) else ( CALL :NO )
Echo advfirewall rule TCP %YN% >> LogBatIsntall.txt
::------------------------------------TCP cancel-------------------------------------------------


::------------------------------------UDP порта 5900,5800 ---------------------------------------
Echo [%time:~,8%] addfirewall rule UDP "VNCUDP59005800"
netsh advfirewall firewall add rule name="VNCUDP59005800 " dir=in action=allow protocol=UDP localport=5900,5800
set e2=%ERRORLEVEL%
IF %e2%==0 ( CALL :OK ) else ( CALL :NO )
Echo advfirewall rule UDP %YN% >> LogBatIsntall.txt
::-----------------------------------UDP cancel--------------------------------------------------


::------------------------------Cоздаем правило для ICMPv4-(бат Коли)----------------------------
Echo [%time:~,8%] add firewall rule ICMP v4
netsh advfirewall firewall add rule name="All ICMP V4" protocol=icmpv4:any,any dir=in action=allow
set e3=%ERRORLEVEL%
IF %e3%==0 ( CALL :OK ) else ( CALL :NO )
Echo advfirewall rule ICMPv4 %YN% >> LogBatIsntall.txt
::-----------------------------------------ICMPv4 cancel------------------------------------------


::---------------------------------Kill winvnc task-----------------------------------------------
:: останавливаем службу UVNC, процесс WinVNC (Исполняемый фаил, дающий доступ к удленному рабочему столу.),
:: удаляем UVNC (Если до этого была установлена.) 

::принудительно завершить процесс winvnc дождавшись выполенния (wait)
Echo [%time:~,8%] kill task WINVNC
start /wait taskkill /f /im winvnc*
set e4=%ERRORLEVEL%
IF %e4%==0 ( CALL :OK ) else ( CALL :NO )
Echo kill task winvnc %YN% >> LogBatIsntall.txt
::------------------------------KIll WINVNC cancel------------------------------------------------


::------------------------------остановить службу UVNC--------------------------------------------
Echo [%time:~,8%] stop UVNC_service
net stop uvnc_service
set e5=%ERRORLEVEL%
IF %e5%==0 ( CALL :OK ) else ( CALL :NO )
Echo stop uvnc_service %YN% >> LogBatIsntall.txt
::--------------------------------stop uvnc cancel------------------------------------------------


::--------------------------------Delete dir ultravnc---------------------------------------------
:: Если существует каталог с путем "системный диск"\Program Files(из-за пробелов пишем: первая папка имеющее первые 6 букв в названии. т.е. progra~1)\UltraVNC
:: то удаляем директорию /удалить все папки внутри /скрытно
:: проверка на errorlevel не работает (всегда выдает 0)
Echo [%time:~,8%] delete directory "ultravnc"
IF EXIST "%systemdrive%"\progra~1\ultravnc ( rd %systemdrive%\progra~1\ultravnc /s /q )
Echo delete directory "ultravnc" - SСRIPT DONT SEARCH THIS RESULT, LETER MUST DEBAG >> LogBatIsntall.txt
::--------------------------------Delete dir ultravnc cancel----------------------------


::--------------------------------Delete dir uvncbvba ---------------------------------- 
:: проверка на errorlevel не работает (всегда выдает 0)
Echo [%time:~,8%] delete directory "uvncbvba"
IF EXIST "%systemdrive%"\progra~1\uvncbvba ( rd %systemdrive%\progra~1\uvncbvba /s /q )
Echo delete directory "uvncbvba" - SСRIPT DONT SEARCH THIS RESULT, LETER MUST DEBAG >> LogBatIsntall.txt
::--------------------------------Delete dir uvncbvba cancel---------------------------------- 


::--------------------------------Delete dir "uvnc bvba" ------------------------------------- 
Echo [%time:~,8%] delete directory "uvnc bvba"
Set DIR=uvnc bvba
IF EXIST "%systemdrive%"\progra~1\"%DIR%" ( rd %systemdrive%\progra~1\"%DIR%" /s /q )
Echo delete directory "uvnc bvba" - SСRIPT DONT SEARCH THIS RESULT, LETER MUST DEBAG >> LogBatIsntall.txt
::--------------------------------Delete dir "uvnc bvba" cancel-------------------------------- 


::--------------------------------Start install UVNC ------------------------------------------ 
echo [%time:~,8%] start install UVNC
IF EXIST "%ProgramFiles(x86)%" ( CALL :INSTUVNC64 ) else ( CALL :INSTUVNC86 )
::---------------------------------Start instal UVNC cancel------------------------------------


::по умолчанию UVNC работает сразу после установки, убиваем процесс, копируем наcтройки в папку с прогой, включаем (попробовать taskkill.exe)
::---------------------------kill task WINVNC--------------------------------------------------
Echo [%time:~,8%] kill task WINVNC
start /wait taskkill /f /im winvnc*
set e10=%ERRORLEVEL%
IF %e10%==0 ( CALL :OK ) else ( CALL :NO )
Echo kill task WINVNC %YN% >> LogBatIsntall.txt
::---------------------------kill task WINVNC cancel--------------------------------------------


::---------------------------stop service UVNC -------------------------------------------------
Echo [%time:~,8%] stop service UVNC
net stop uvnc_service
set e11=%ERRORLEVEL%
IF %e11%==0 ( CALL :OK ) else ( CALL :NO )
Echo stop service UVNC %YN% >> LogBatIsntall.txt
::---------------------------stop service UVNC cancel-------------------------------------------


::----------------------------Copy .ini to core dir UVNC ----------------------------------------
::Копируем .ini файл с параметрами запуска в директрорию с программой
Echo copy .INI seting file to directory
Set DIR2="uvnc bvba"
copy "%~d0%~p0distr\ultravnc.ini" "%SystemDrive%\progra~1\"%DIR2%"\UltraVNC\" /y
set e12=%ERRORLEVEL%
IF %e12%==0 ( CALL :OK ) else ( CALL :NO )
Echo copy .INI seting file to directory %YN% >> LogBatIsntall.txt
::----------------------------Copy .ini to core dir UVNC cancel----------------------------------


::-----------------------------start UVNC service------------------------------------------------
:: запускаем службу UVNC
Echo start UVNC service
net start uvnc_service
set e13=%ERRORLEVEL%
IF %e13%==0 ( CALL :OK ) else ( CALL :NO )
Echo start UVNC service %YN% >> LogBatIsntall.txt
::-----------------------------start UVNC service cancel-----------------------------------------

pause

EXIT


:: В функции INSTUVNC64 запускаем установку UVNC в зависимости от архитектуры виндовс, в режиме пропуска подтверждения установки (/sp-)
:: с параметрами из лог файла, в скрытном режиме , по надобности с перезагрузкой без подтверждения /verysilent
:INSTUVNC64
echo [%time:~,8%] UVNC64 running intsall...
start /wait "" "%~d0%~p0distr\UVNC64.exe" /sp- /LOADINF="%~d0%~p0distr\uvnclog.log" /verysilent
set e8=%ERRORLEVEL%
IF %e8%==0 ( CALL :OK ) else ( CALL :NO )
Echo start install UVNC64 %YN% >> LogBatIsntall.txt
GOTO :EOF

:: В функции INSTUVNC86 запускаем установку UVNC в зависимости от архитектуры виндовс, в режиме пропуска подтверждения установки (/sp-)
:: с параметрами из лог файла, в скрытном режиме , по надобности с перезагрузкой без подтверждения /verysilent
:INSTUVNC86
echo [%time:~,8%] UVNC32 running install...
start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /LOADINF="%~d0%~p0distr\uvnclog.log" /verysilent
set e9=%ERRORLEVEL%
IF %e9%==0 ( CALL :OK ) else ( CALL :NO )
Echo start install UVNC32 %YN% >> LogBatIsntall.txt
GOTO :EOF

::В функции OK просиходит вывод сообщения на экран , запись значения в переменную YN (для полседующей записи в файл) потом возврат к моменту вызова
:OK
Echo OK
SET YN=-OK
GOTO :EOF

::В функции NO просиходит вывод сообщения на экран , запись значения в переменную YN (для полседующей записи в файл), потом возврат к моменту вызова
:NO
Echo NO 
SET YN=-NOT/ERROR
GOTO :EOF

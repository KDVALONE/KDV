::v0.70  19.07.16
:: для корректного отображения крилицы в CMD batch файл нужно сохранить в OEM 866
@echo off
cls
:: заголовок окна
TITLE IT BATCH FILE SILENT INSTALL
::далее и после каждого действия используется код вывода сообщения об успешном выполненнии или нет.
::%ERRORLEVEL% равен 0 если успешно выполнена комманда выше, и 1 если не удачно. 


::---------------------------------Rename PC ----------------------------------------------------
Echo You PC name:"%computername%"
Echo Enter new PC name:
Set /P PCNAME=""
wmic computersystem where name="%computername%" call rename "%PCNAME%"
cls
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo new pc name is %PCNAME% ) else ( Echo NO )
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
IF errorlevel==0 ( Echo OK ) else ( Echo NO )
::---------------------------------Remote Assistance cancel---------------------------------------


::---------------------------------add to Domain-------------------------------------------------
::
:QTODMN
Echo Add PC to Domain: gb1.korolev.local (Y/N)? 
Set /p TDMN=""
if %TDMN%==y ( GOTO :ADDTODMN ) else ( GOTO :TODMN )
:TODMN
if %TDMN%==Y ( GOTO :ADDTODMN ) else ( GOTO :NTODMN )
:NTODMN
if %TDMN%==n ( GOTO :NOTADDTODMN ) else ( GOTO :NTODMN2 )
:NTODMN2
if %TDMN%==N ( GOTO :NOTADDTODMN ) else ( GOTO :INCORRECT )
:INCORRECT
Echo incorrected symbol, please enter Y or N 
GOTO :QTODMN
:ADDTODMN
Echo Enter domain admin user ( example: User777 ):
Set /p admin=""
Echo Enter domain admin user password:
Set /p PSWD=""
:: вызов утилиты wmic /интерактивный режим выкл(при выкл.режиме после выполнения одной команды wmic, управление возвращается к cls windows (PROMT))).
:: система где "имя пк" вызвать метод JoinDomainOrWorkgroup (заведения в домен),с параметрами точка хода=1 (если 1 то к домену, строки нет - к раб.группе),
:: Name="имя домена/рабочей группы", имя пользователья домена с правами присоединения, пароль.  
wmic /interactive:off ComputerSystem Where "name = '%computername%'" call JoinDomainOrWorkgroup FJoinOptions=1 Name="gb1.korolev.local" UserName="%admin%@gb1.korolev.local"  Password="%PSWD%" 
:: по умолчанию в cls отобразиться instance_PARMETRS value=0 (где 0 успех)
Echo ******************************************************************************
Echo IF "instance_PARMETRS value=0" (see top, before) , PC add to domain successful

:: (!!!непонятно как отработать возварщаемо значение для повторной попытки ввода  домен, errorlevel здесь всегда 0!!!)
:NOTADDTODMN
::---------------------------------add to Domain cancel------------------------------------------

::---------Создаем правило для входящего TCP порта 5900,5800-------------------------------------
Echo [%time:~,8%] addfirewall rule UTP "VNCTCP59005800"
netsh advfirewall firewall add rule name="VNCTCP59005800" dir=in action=allow protocol=TCP localport=5900,5800
::Ниже типовой код вызова функции отображения информации об выполненнии, и занесения его в лог файл (создается при запуске бат)
set e1=%ERRORLEVEL%
IF %e1%==0 ( CALL :OK ) else ( CALL :NO )
::------------------------------------TCP cancel-------------------------------------------------


::------------------------------------UDP порта 5900,5800 ---------------------------------------
Echo [%time:~,8%] addfirewall rule UDP "VNCUDP59005800"
netsh advfirewall firewall add rule name="VNCUDP59005800 " dir=in action=allow protocol=UDP localport=5900,5800
set e2=%ERRORLEVEL%
IF %e2%==0 ( CALL :OK ) else ( CALL :NO )
::-----------------------------------UDP cancel --------------------------------------------------


::------------------------------Cоздаем правило для ICMPv4-(бат Коли)----------------------------
Echo [%time:~,8%] add firewall rule ICMP v4
netsh advfirewall firewall add rule name="All ICMP V4" protocol=icmpv4:any,any dir=in action=allow
set e3=%ERRORLEVEL%
IF %e3%==0 ( CALL :OK ) else ( CALL :NO )
::-----------------------------------------ICMPv4 cancel------------------------------------------


::---------------------------------Kill winvnc task-----------------------------------------------
:: останавливаем службу UVNC, процесс WinVNC (Исполняемый фаил, дающий доступ к удленному рабочему столу.),
:: удаляем UVNC (Если до этого была установлена.) 

::принудительно завершить процесс winvnc дождавшись выполенния (wait)
Echo [%time:~,8%] kill task WINVNC
start /wait taskkill /f /im winvnc*
set e4=%ERRORLEVEL%
IF %e4%==0 ( CALL :OK ) else ( CALL :NO )
::------------------------------KIll WINVNC cancel------------------------------------------------


::------------------------------остановить службу UVNC--------------------------------------------
Echo [%time:~,8%] stop UVNC_service
net stop uvnc_service
set e5=%ERRORLEVEL%
IF %e5%==0 ( CALL :OK ) else ( CALL :NO )
::--------------------------------stop uvnc cancel------------------------------------------------


::--------------------------------Delete dir ultravnc---------------------------------------------
:: Если существует каталог с путем "системный диск"\Program Files(из-за пробелов пишем: первая папка имеющее первые 6 букв в названии. т.е. progra~1)\UltraVNC
:: то удаляем директорию /удалить все папки внутри /скрытно
:: проверка на errorlevel не работает (всегда выдает 0)
Echo [%time:~,8%] delete directory "ultravnc"
IF EXIST "%systemdrive%"\progra~1\ultravnc ( rd %systemdrive%\progra~1\ultravnc /s /q )
::--------------------------------Delete dir ultravnc cancel----------------------------


::--------------------------------Delete dir uvncbvba ---------------------------------- 
:: проверка на errorlevel не работает (всегда выдает 0)
Echo [%time:~,8%] delete directory "uvncbvba"
IF EXIST "%systemdrive%"\progra~1\uvncbvba ( rd %systemdrive%\progra~1\uvncbvba /s /q )
::--------------------------------Delete dir uvncbvba cancel---------------------------------- 


::--------------------------------Delete dir "uvnc bvba" ------------------------------------- 
Echo [%time:~,8%] delete directory "uvnc bvba"
Set DIR=uvnc bvba
IF EXIST "%systemdrive%"\progra~1\"%DIR%" ( rd %systemdrive%\progra~1\"%DIR%" /s /q )
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
::---------------------------kill task WINVNC cancel--------------------------------------------


::---------------------------stop service UVNC -------------------------------------------------
Echo [%time:~,8%] stop service UVNC
net stop uvnc_service
set e11=%ERRORLEVEL%
IF %e11%==0 ( CALL :OK ) else ( CALL :NO )
::---------------------------stop service UVNC cancel-------------------------------------------


::----------------------------Copy .ini to core dir UVNC ----------------------------------------
::Копируем .ini файл с параметрами запуска в директрорию с программой
Echo copy .INI seting file to directory
Set DIR2="uvnc bvba"
copy "%~d0%~p0distr\ultravnc.ini" "%SystemDrive%\progra~1\"%DIR2%"\UltraVNC\" /y
set e12=%ERRORLEVEL%
IF %e12%==0 ( CALL :OK ) else ( CALL :NO )
::----------------------------Copy .ini to core dir UVNC cancel----------------------------------


::-----------------------------start UVNC service------------------------------------------------
:: запускаем службу UVNC
Echo start UVNC service
net start uvnc_service
set e13=%ERRORLEVEL%
IF %e13%==0 ( CALL :OK ) else ( CALL :NO )
::-----------------------------start UVNC service cancel-----------------------------------------

::---------Создаем правило для входящего TCP порта 62354-----------------------------------------
:: Создаем правило для FI
Echo [%time:~,8%] addfirewall rule UTP "FI62354"
netsh advfirewall firewall add rule name="FI" dir=in action=allow protocol=TCP localport=62354
set e14=%ERRORLEVEL%
IF %e14%==0 ( CALL :OK ) else ( CALL :NO )
::------------------------------------TCP 62354 cancel--------------------------------------------


::------------------------------------install FI agent---------------------------------------------
::КОД Коли, РАЗОБРАТЬ, начинаем устновку FI
Echo stаrt install Fusion inventory Agent
IF EXIST "%ProgramFiles(x86)%" ( cd "C:\Program Files\FusionInventory-Agent\perl\bin") else ( cd "C:\Program Files\FusionInventory-Agent\perl\bin")
perl fusioninventory-agent
::------------------------------------install FI cancel---------------------------------------------


::-------------------------------------install BG INFO ---------------------------------------------
Echo copy install BGinfo
Echo create dir 
md "%SystemDrive%\Program Files\BGInfo\"

Echo copy distrib BGINFO
copy "%~d0%~p0distr\BGInfo\" "%SystemDrive%\Program Files\BGInfo\" /y
:: устанавливаем, ждем выполнения, с параметром таймера 0 (тоесть выполнение при запусе моментально)
Echo BGinfo install
start /wait "" "%SystemDrive%\Program Files\BGInfo\Bginfo.exe" /silent /timer:0

set e17=%ERRORLEVEL%
IF %e17%==0 ( Echo :OK ) else ( Echo NO )
:: создаем запись в реестре для авторана.
set proga=%SystemDrive%\Program Files\BGInfo\Bginfo.exe
REG ADD "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" /v BGINFO /t REG_SZ /d "%proga% /timer:0" /f
set e17=%ERRORLEVEL%
IF %e17%==0 ( Echo :OK ) else ( Echo NO )

::-------------------------------------install BG INFO ---------------------------------------------

pause

EXIT


:: В функции INSTUVNC64 запускаем установку UVNC в зависимости от архитектуры виндовс, в режиме пропуска подтверждения установки (/sp-)
:: с параметрами из лог файла, в скрытном режиме , по надобности с перезагрузкой без подтверждения /verysilent
:INSTUVNC64
echo [%time:~,8%] UVNC64 running intsall...
start /wait "" "%~d0%~p0distr\UVNC64.exe" /sp- /LOADINF="%~d0%~p0distr\uvnclog.log" /verysilent
set e8=%ERRORLEVEL%
IF %e8%==0 ( CALL :OK ) else ( CALL :NO )
GOTO :EOF

:: В функции INSTUVNC86 запускаем установку UVNC в зависимости от архитектуры виндовс, в режиме пропуска подтверждения установки (/sp-)
:: с параметрами из лог файла, в скрытном режиме , по надобности с перезагрузкой без подтверждения /verysilent
:INSTUVNC86
echo [%time:~,8%] UVNC32 running install...
start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /LOADINF="%~d0%~p0distr\uvnclog.log" /verysilent
set e9=%ERRORLEVEL%
IF %e9%==0 ( CALL :OK ) else ( CALL :NO )
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

::v0.40  11.06.16
:: для корректного отображения крилицы в CMD batch файл нужно сохранить в OEM 866
@echo off
cls
:: заголовок окна
TITLE UVNC BATFILE SILENT INSTALL

::далее и после каждого действия используется код вывода сообщения об успешном выполненнии или нет.
::%ERRORLEVEL% равен 0 если успешно выполнена комманда выше, и 1 если не удачно. 
::Создаем правило для входящего TCP/UDP порта 5900,5800 
Echo [%time:~,8%] addfirewall rule UTP "VNCTCP59005800"
netsh advfirewall firewall add rule name="VNCTCP59005800 " dir=in action=allow protocol=TCP localport=5900,5800
set e1=%ERRORLEVEL%
IF e1==0 (Echo OK) ELSE ( Echo error )

Echo [%time:~,8%] addfirewall rule UDP "VNCUDP59005800"
netsh advfirewall firewall add rule name="VNCUDP59005800 " dir=in action=allow protocol=UDP localport=5900,5800
set e2=%ERRORLEVEL%
IF e2==0 (Echo OK) ELSE ( Echo error ) 

::Cоздаем правило для ICMP (бат Коли)!!!!!!!!!!!!!!!!!!!!!
Echo [%time:~,8%] add firewall rule ICMP v4
netsh advfirewall firewall add rule name="All ICMP V4" protocol=icmpv4:any,any dir=in action=allow
set e3=%ERRORLEVEL%
IF e3==0 (Echo OK) ELSE ( Echo error )

:: останавливаем службу UVNC, процесс WinVNC (Исполняемый фаил, дающий доступ к удленному рабочему столу.),
:: удаляем UVNC (Если до этого была установлена.) 

::принудительно завершить процесс wnvinc дождавшись выполенния (wait)
Echo [%time:~,8%] stop task WINVNC
start /wait taskkill /f /im winvnc*
set e4=%ERRORLEVEL%
IF e4==0 (Echo OK) ELSE ( Echo error )

::остановить службу UVNC
Echo [%time:~,8%] stop UVNC_service
net stop uvnc_service
set e5=%ERRORLEVEL%
IF e5==0 (Echo OK) ELSE ( Echo error )

:: Если существует каталог с путем "системный диск"\Program Files(из-за пробелов пишем: первая папка имеющее первые 6 букв в названии. т.е. progra~1)\UltraVNC
:: то удаляем директорию /удалить все папки внутри /скрытно
Echo [%time:~,8%] delete directory "ultravnc"
IF EXIST "%systemdrive%"\progra~1\ultravnc ( rd %systemdrive%\progra~1\ultravnc /s /q )
set e6=%ERRORLEVEL%
IF e6==0 (Echo OK) ELSE ( Echo error )

Echo [%time:~,8%] delete directory "uvncbat"
IF EXIST "%systemdrive%"\progra~1\uvncbvba ( rd %systemdrive%\progra~1\uvncbvba /s /q )
set e7=%ERRORLEVEL%
IF e7==0 (Echo OK) ELSE ( Echo error )

echo [%time:~,8%] start install UVNC

:: запускаем установку UVNC в зависимости от архитектуры виндовс, в режиме пропуска подтверждения установки (/sp-)
::  с параметрами из лог файла, в скрытном режиме , по надобности с перезагрузкой без подтверждения /verysilent 
IF EXIST "%ProgramFiles(x86)%" ( echo [%time:~,8%] UVNC64 running intsall... 
start /wait "" "%~d0%~p0distr\UVNC64.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent ) ELSE ( echo [%time:~,8%] UVNC32 running install...
start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent )
set e8=%ERRORLEVEL%
IF e8==0 (Echo OK) ELSE ( Echo error )

::по умолчанию UVNC работает сразу после установки, убиваем процесс, копируем наcтройки в папку с прогой, включаем
Echo [%time:~,8%] Restart task and service to start UVNC
Echo [%time:~,8%] stop task WINVNC
start /wait taskkill /f /im winvnc*
set e9=%ERRORLEVEL%
IF e9==0 (Echo OK) ELSE ( Echo error )

Echo [%time:~,8%] stop service UVNC
net stop uvnc_service
set e10=%ERRORLEVEL%
IF e10==0 (Echo OK) ELSE ( Echo error )

::Копируем .ini файл с параметрами запуска в директрорию с программой
Echo copy .INI seting file to directory 
copy "%~d0%~p0distr\UltraVNC.ini" "%SystemDrive%\progra~1\ultravnc\" /y
set e11=%ERRORLEVEL%
IF e11==0 (Echo OK) ELSE ( Echo error )

:: запускаем службу UVNC
Echo start UVNC service
net start uvnc_service
set e12=%ERRORLEVEL%
IF e12==0 (Echo OK) ELSE ( Echo error )

pause

EXIT
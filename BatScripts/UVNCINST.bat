@echo off
cls
:: заголовок окна
TITLE UVNC BATFILE SILENT INSTALL
::Создаем правило для входящего TCP/UDP порта 5900,5800 
netsh advfirewall firewall add rule name="VNCTCP59005800 " dir=in action=allow protocol=TCP localport=5900,5800
netsh advfirewall firewall add rule name="VNCUDP59005800 " dir=in action=allow protocol=UDP localport=5900,5800

::Cоздаем правило для ICMP (бат Коли)!!!!!!!!!!!!!!!!!!!!!
netsh advfirewall firewall add rule name="All ICMP V4" protocol=icmpv4:any,any dir=in action=allow

:: останавливаем службу UVNC, процесс WinVNC (Исполняемый фаил, дающий доступ к удленному рабочему столу.),
:: удаляем UVNC (Если до этого была установлена.) 

::принудительно завершить процесс wnvinc дождавшись выполенния (wait)
start /wait taskkill /f /im winvnc*
net stop uvnc_service

:: Если существует каталог с путем "системный диск"\Program Files(из-за пробелов пишем: первая папка имеющее первые 6 букв в названии. т.е. progra~1)\UltraVNC
:: то удаляем директорию /удалить все папки внутри /скрытно
IF EXIST "%systemdrive%"\progra~1\ultravnc ( rd %systemdrive%\progra~1\ultravnc /s /q )
IF EXIST "%systemdrive%"\progra~1\uvncbvba ( rd %systemdrive%\progra~1\uvncbvba /s /q )

echo [%time:~,8%] start install UVNC

:: запускаем установку UVNC в зависимости от архитектуры виндовс, в режиме пропуска подтверждения установки (/sp-)
::  с параметрами из лог файла, в скрытном режиме , по надобности с перезагрузкой без подтверждения /verysilent 
IF EXIST "%ProgramFiles(x86)%" ( echo UVNC64 running intsall... 
start /wait "" "%~d0%~p0distr\UVNC64.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent / ) ELSE (
echo UVNC32 running install...
start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent)

echo [%time:~,8%] UVNC INSTALL COMPLETE

::по умолчанию UVNC работает сразу после установки, убиваем процесс, копируем натройки в папку с прогой, включаем
start /wait taskkill /f /im winvnc*
net stop uvnc_service

copy "%~d0%~p0distr\UltraVNC.ini" "%SystemDrive%\progra~1\ultravnc\" /y
net start uvnc_service

echo [%time~,8%] UVNC INSTALL SUCCESS !=)
pause

EXIT
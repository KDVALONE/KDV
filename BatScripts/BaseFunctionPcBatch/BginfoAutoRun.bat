@Echo off
:: Копируем bginfo в каталог, добавляем в автозапуск для обновления показателей c параметром обновления 0 сеунд (моментально.)
cls
Echo copy install BGinfo
Echo create dir 
md "%SystemDrive%\Program Files\BGInfo\"
Echo copy distrib BGINFO
copy "%~d0%~p0distr\BGInfo\" "%SystemDrive%\Program Files\BGInfo\" /y
Echo BGinfo install
start /wait "" "%SystemDrive%\Program Files\BGInfo\Bginfo.exe" /silent /timer:0

set e=%ERRORLEVEL%
IF %e%==0 ( Echo :OK ) else ( Echo NO )

set proga=%SystemDrive%\Program Files\BGInfo\Bginfo.exe
REG ADD "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" /v BGINFO /t REG_SZ /d "%proga% /timer:0" /f
set e=%ERRORLEVEL%
IF %e%==0 ( Echo :OK ) else ( Echo NO )
pause
exit
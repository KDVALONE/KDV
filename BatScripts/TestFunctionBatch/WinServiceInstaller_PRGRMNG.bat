:: Удаление самописной службы виндовс. ЗАПУСКАТЬ ОТ АДМИНА!
:: Использую утилиту InstallUtil  

@echo off
cls
:: заголовок окна
Title "MY CUSTOM MetaninWinService"

:: если errorlevel = 0 то ОК, любой другой ошибка

Echo Starting instal MetaninWinService with InstllUtill.exe ...

:: путь к утилите ,  предполагается что батник лежит рядом с файлом  решения .sln, далее путь до установщика утилиты
"%SystemDrive%\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "%~d0%~p0\MetanintWinService\bin\Debug\MetanintWinService.exe"

echo errorlevel %errorlevel%
pause

::запуск службы
Echo Starting MetaninWinService...
net start MetaninWinService
echo errorlevel %errorlevel%
pause
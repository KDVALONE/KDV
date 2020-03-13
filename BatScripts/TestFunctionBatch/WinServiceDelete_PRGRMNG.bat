:: Удаление самописной службы виндовс. ЗАПУСКАТЬ ОТ АДМИНА!
:: Использую утилиту InstallUtil  

@echo off
cls
:: заголовок окна
Title "MY CUSTOM MetaninWinService"

:: если errorlevel = 0 то ОК, любой другой ошибка

:: Проверяем чтоб была остановлена
Echo Stopping MetaninWinService...

net stop MetaninWinService
echo errorlevel %errorlevel%
pause


Echo Starting delete service MetaninWinService  with InstllUtill.exe
:: путь к утилите   /u - флаг удаления путь к экзешнику утилиты, предполагается что батник лежит рядом с файлом  решения .sln, далее путь до установщика утилиты
"%SystemDrive%\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "/u" "%~d0%~p0\MetanintWinService\bin\Debug\MetanintWinService.exe"

echo errorlevel %errorlevel%
pause


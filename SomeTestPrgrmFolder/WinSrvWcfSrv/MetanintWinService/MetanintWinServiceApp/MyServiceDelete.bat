@echo off
cls
:: заголовок окна
Title "MY CUSTOM MetaninWinService"

Echo Stopping MetaninWinService...
net stop MetaninWinService
echo errorlevel %errorlevel%
pause


Echo Starting delete service MetaninWinService  with InstllUtill.exe
"%SystemDrive%\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "/u" "%~d0%~p0\MetanintWinService\bin\Debug\MetanintWinService.exe"

:: если errorlevel = 0 то ОК, любой другой нет ок =))
echo errorlevel %errorlevel%
pause


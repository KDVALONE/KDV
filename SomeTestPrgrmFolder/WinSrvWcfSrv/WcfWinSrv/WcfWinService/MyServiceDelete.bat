@echo off
cls
:: заголовок окна
Title "MY CUSTOM MathWinService"

Echo Stopping MathWinService...
net stop MathWinService
echo errorlevel %errorlevel%
pause


Echo Starting delete MathWinService with InstllUtill.exe

"%SystemDrive%\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "/u" "%~d0%~p0\MathWindowsServiceHost\bin\Debug\MathWindowsServiceHost.exe"
:: если errorlevel = 0 то ОК, любой другой нет ок =))
echo errorlevel %errorlevel%
pause


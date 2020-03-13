@echo off
cls
:: заголовок окна
Title "MY CUSTOM MathWinService"

Echo Starting instal MathWinService with InstllUtill.exe

"%SystemDrive%\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "%~d0%~p0\MathWindowsServiceHost\bin\Debug\MathWindowsServiceHost.exe"

:: если errorlevel = 0 то ОК, любой другой нет ок =))
echo errorlevel %errorlevel%
pause

Echo Starting MathWinService...
net start MathWinService
echo errorlevel %errorlevel%
pause
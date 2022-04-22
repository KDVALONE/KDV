@echo off
cls
:: заголовок окна
Title "MY CUSTOM WcfHelloWorldWindowsServiceHost"

Echo Starting instal services with InstllUtill.exe

"%SystemDrive%\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "%~d0%~p0\WcfHelloWorldWindowsServiceHost\bin\Debug\WcfHelloWorldWindowsServiceHost.exe"

:: если errorlevel = 0 то ОК, любой другой нет ок =))
echo errorlevel %errorlevel%
pause

Echo Starting WcfHelloWorldWindowsServiceHost...
net start HelloWorldWcfToWinSrv1
echo errorlevel %errorlevel%
pause
@echo off
cls
:: заголовок окна
Title "MY CUSTOM WcfHelloWorldWindowsServiceHost

Echo Stopping HelloWorldWcfToWinSrv1...
net stop HelloWorldWcfToWinSrv1
echo errorlevel %errorlevel%
pause


Echo Starting delete services with InstllUtill.exe

"%SystemDrive%\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" "/u" "%~d0%~p0\WcfHelloWorldWindowsServiceHost\bin\Debug\WcfHelloWorldWindowsServiceHost.exe"
:: если errorlevel = 0 то ОК, любой другой нет ок =))
echo errorlevel %errorlevel%
pause


:: Остановка виндовс службы
@echo off
cls
:: заголовок окна
Title "MY CUSTOM MetaninWinService"

Echo Stopping MetaninWinService...
net stop MetaninWinService
echo errorlevel %errorlevel%
pause
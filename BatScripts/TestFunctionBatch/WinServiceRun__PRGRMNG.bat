:: Запуск виндовс службы
@echo off
cls
:: заголовок окна
Title "MY CUSTOM MetaninWinService"


Echo Starting MetaninWinService...
net start MetaninWinService
echo errorlevel %errorlevel%
pause
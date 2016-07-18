:: v1.0   от 18.07.2016
:: завершаем процесс winvnc* (не работает)
@Echo off
cls
Echo kill task winvnc*
pause
start /wait taskkill /f /im winvnc*
Echo kill task winvnc*

pause
exit
:: v1.0   от 18.07.2016
:: останавливаем службу/запускаем службу
@Echo off
cls
Echo Stop "uvnc_service"
pause
net start uvnc_service
::net stop uvnc_service
Echo Stop/Start "uvnc_service"

pause
exit
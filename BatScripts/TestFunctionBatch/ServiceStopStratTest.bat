:: v1.0   �� 18.07.2016
:: ������������� ������/��������� ������
@Echo off
cls
Echo Stop "uvnc_service"
pause
net start uvnc_service
::net stop uvnc_service
Echo Stop/Start "uvnc_service"

pause
exit
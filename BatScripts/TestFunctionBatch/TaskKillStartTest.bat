:: v1.0   �� 18.07.2016
:: ��������� ������� winvnc* (�� ��������)
@Echo off
cls
Echo kill task winvnc*
pause
start /wait taskkill /f /im winvnc*
Echo kill task winvnc*

pause
exit
:: v1.0   �� 18.07.2016
:: �������� ���� � ����������
@Echo off
cls
Echo copy file in directory
Echo copy .INI seting file to directory 
copy "%~d0%~p0distr\UltraVNC.txt" "%SystemDrive%\progra~1\uvnc bvba\" /y
set e12=%ERRORLEVEL%
Echo %e12% 

pause
exit
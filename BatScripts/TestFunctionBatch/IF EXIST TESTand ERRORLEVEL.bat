Echo off
cls

netsh advfirewall firewall show rule name="VNCUDP59005800 " 
::errorlevel=%ERRORLEVEL%
Echo errorlevel=%ERRORLEVEL%
set x=%ERRORLEVEL%
pause
netsh advfirewall firewall show rule name="VNCUDP59005800 Не существует" 
::errorlevel=%ERRORLEVEL%%
Echo errorlevel=%ERRORLEVEL%
set y=%ERRORLEVEL%
::netsh advfirewall firewall show rule name="VNCUDP59005800 "
pause
IF %ERRORLEVEL%==1 (echo errorlevel = 1121) Else (echo errorlevel = 0)
Echo [%x%],[%y%]
pause
 
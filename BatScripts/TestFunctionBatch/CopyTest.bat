@Echo off
:: 
:: копируем файл в директорию
cls 
Set DIR2="uvnc bvba"
Echo copy .ini file to dir uvnc_bvba
copy "%~d0%~p0distr\ultravnc.ini" "%SystemDrive%\progra~1\"%DIR2%"\UltraVNC\" /y


Echo copy will be done 
pause
Echo 
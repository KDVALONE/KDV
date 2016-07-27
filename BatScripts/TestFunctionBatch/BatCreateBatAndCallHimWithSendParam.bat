
::create new batch file with sended code custom variables  and call him, 
@Echo off
cls
Echo add some string of code (example: Echo hello!)
Set /p code=""

Echo create new batch file
pause

Echo Echo off >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo cls >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo %code% >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo Echo CREATEDTESTBAT.bat will start success >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo pause >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo exit >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo Call new CREATEDTESTBAT.bat
pause
Call "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
exit

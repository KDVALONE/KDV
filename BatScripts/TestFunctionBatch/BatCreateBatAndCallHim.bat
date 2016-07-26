
:: באע פאיכ סמחהאוע באעפאיכ ג ןנמדנאללפאיכסו גûחûגגאוע ודמ
@Echo off
cls
Echo create new batch file
pause
Echo Echo off >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo cls >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo Echo CREATEDTESTBAT.bat will start success >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo pause >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo exit >> "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
Echo Call new CREATEDTESTBAT.bat
pause
Call "%SystemDrive%\Program Files\CREATEDTESTBAT.bat"
exit

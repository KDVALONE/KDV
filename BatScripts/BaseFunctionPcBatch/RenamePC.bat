:: v1.0  15.07.2016
Echo off
cls
::Переименование ПК через бат файл.
Echo Enter new pc name:
Set /P PCNAME=""
wmic computersystem where name="%computername%" call rename "%PCNAME%"
cls
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo new pc name is %PCNAME% ) else ( Echo rename error )
pause
exit
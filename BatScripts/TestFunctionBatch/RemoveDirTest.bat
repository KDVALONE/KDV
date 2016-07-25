@Echo off
:: удалить директорию "uvnc bvba" если есть, по пути системный диск/програмфайлс. чтоб работало uvnc bvba в переменную
cls
Echo [%time:~,8%] delete directory "uvnc"
Set DIR=uvnc bvba
IF EXIST "%systemdrive%"\progra~1\"%DIR%" ( rd %systemdrive%\progra~1\"%DIR%" /s /q ) else ( Echo not uvnc bvba  found )
set e6=%ERRORLEVEL%
IF %e6%==0 ( CALL :OK 
) else ( 
CALL :NO )
Echo delete directory "uvnc bvba" %YN% 
pause
exit
::В функции OK просиходи вывод сообщения на экран , запись значения в переменную YN (для полседующей записи в файл) потом возврат к моменту вызова
:OK
Echo OK
SET YN=-OK
GOTO :EOF

::В функции NO просиходи вывод сообщения на экран , запись значения в переменную YN (для полседующей записи в файл), потом возврат к моменту вызова
:NO
Echo NO 
SET YN=-NOT/ERROR
GOTO :EOF
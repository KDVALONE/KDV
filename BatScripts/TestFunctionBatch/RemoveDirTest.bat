@Echo off
:: ������� ���������� "uvnc bvba" ���� ����, �� ���� ��������� ����/������������. ���� �������� uvnc bvba � ����������
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
::� ������� OK ��������� ����� ��������� �� ����� , ������ �������� � ���������� YN (��� ����������� ������ � ����) ����� ������� � ������� ������
:OK
Echo OK
SET YN=-OK
GOTO :EOF

::� ������� NO ��������� ����� ��������� �� ����� , ������ �������� � ���������� YN (��� ����������� ������ � ����), ����� ������� � ������� ������
:NO
Echo NO 
SET YN=-NOT/ERROR
GOTO :EOF
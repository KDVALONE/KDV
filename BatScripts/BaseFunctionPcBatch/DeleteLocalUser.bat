
::�������� ��������, ��� ���� �� �������� ������������ �������� net user test_user /DELETE,
::�� ��� ����� ����� ������� ������� ��� ������� �� ���� %USERS%\test_user\ ���� ������������� ��� �������� � �������.
Echo Add new administrato user
set ADMINNAME=its12
set ADMINPASS=1024-Old
::?��������� ������ ����������� /���� ������� ����뤤 ������ 
net user %ADMINNAME% /delete 
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )
pause

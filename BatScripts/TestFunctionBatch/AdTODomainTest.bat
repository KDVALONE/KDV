@Echo off
cls
Echo Enter domain admin user ( example: User777 ):
Set /p admin=""
Echo Enter domain admin user password:
Set /p PSWD=""
:: ����� ������� wmic /������������� ����� ����(��� ����.������ ����� ���������� ����� ������� wmic, ���������� ������������ � cls windows (PROMT))).
:: ������� ��� "��� ��" ������� ����� JoinDomainOrWorkgroup (��������� � �����),� ����������� ����� ����=1 (���� 1 �� � ������, ������ ��� - � ���.������),
:: Name="��� ������/������� ������", ��� ������������� ������ � ������� �������������, ������.  
wmic /interactive:off ComputerSystem Where "name = '%computername%'" call JoinDomainOrWorkgroup FJoinOptions=1 Name="gb1.korolev.local" UserName="%admin%@gb1.korolev.local"  Password="%PSWD%" 
::Echo "%errorlevel%"
::If ReturnValue==1355 ( echo ok ) else ( Echo no )

::(��������� ��� ���������� ����������� �������� ��� ��������� ������� �����  �����, errorlevel ����� ������ 0)
pause
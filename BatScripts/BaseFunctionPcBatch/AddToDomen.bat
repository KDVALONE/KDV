:: v0.12  �� 17.07.2016
@Echo off
cls
:: ����� ������� wmic /������������� ����� ����(��� ����.������ ����� ���������� ����� ������� wmic, ���������� ������������ � cls windows (PROMT))).
:: ������� ��� "��� ��" ������� ����� JoinDomainOrWorkgroup (��������� � �����),� ����������� ����������=1 (���� 1 �� � ������, ������ ��� - � ���.������),
:: Name="��� ������/������� ������", ��� ������������� ������ � ������� �������������, ������.  
wmic /interactive:off ComputerSystem Where "name = '%computername%'" call JoinDomainOrWorkgroup FJoinOptions=1 Name="my.domain.com" UserName="admin@my.domain.com"  Password="123" 
:: �� ��������� � cls ������������ instance_PARMETRS value=0 (��� 0 �����)
pause
exit
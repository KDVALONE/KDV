:: ��������� ������������ � ��������� � �������
@Echo off
cls
Echo Add to REG rule
:: ���� ����� �����  ��������:
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v DefaultPassword /t REG_SZ /d "1024-Old " /f
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v AutoAdminLogon /t REG_SZ /d "1" /f
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v DefaultUserName /t REG_SZ /d "its" /f

pause
exit
:: ���� ����� �����  ��������:
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v DefaultPassword /t REG_SZ /d "1024-Old " /f
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v AutoAdminLogon /t REG_SZ /d "1" /f
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v DefaultUserName /t REG_SZ /d "its" /f



______________________________


1. ���� -> ��������� -> ������� ������ regedit � ������� ��.
2. ������� ��������� ����� �������:
���: �������� ���� ���
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WindowsNT\CurrentVersion\Winlogon

REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v DefaultPassword /t REG_SZ /d "1024-Old " /f
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v AutoAdminLogon /t REG_SZ /d "1" /f
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v DefaultUserName /t REG_SZ /d "its" /f

3. ������ �������� �������� DefaultUserName (���� ������ ��������� ���, �� �������� ��������� �������� � ���� ������), ������� ���� ��� ������������ � ������� ������ OK.
4. ������ �������� �������� DefaultPassword, ������� � ���� ��������� ���� ������ � ������� ������ OK.
5. ������ �������� �������� AutoAdminLogon, ������� � ���� �������� ����� 1 � ������� ������ OK.

����������. � ������ ���� ��������� �������� ������ ������ ������������� ���� ������� �� ����� ��������, ���������� ������� �������������� ������ ������ �������� �������� ����� � �����:
� ������� � �����
���: �������� ���� ���
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon
��������� AutoAdminLogon ���������� �������� 1
��������� DefaultUserName ���������� �������� ������ ����� ������������ ��� �������� ������������ �������������� ���� � �������
��������� DefaultDomainName ���������� �������� ������ ����� ������ ��� �����
��������� DefaultPassword ���������� �������� ������ ������ ������������ ��� �������� ������������ �������������� ���� � �������
���� ������ ���� ��������� ���, �� ��� ����� �������, ��� ���� ���������� ��� ��������� (REG_SZ)
::���������� ������� ���� � ������ :p �� ������ 192.168.0.0\SetevayaPapka\
@Echo off
cls 
set SERVER=192.168.0.0
set FOLDER=SetevayaPapka
net use p: \\%SERVER%\%FOLDER%

:: ��������� ������� ���� 
net use p: \\%SERVER%\%FOLDER% /delete
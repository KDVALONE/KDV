Echo off
cls
:: ��������� ��������� UVNC � ����������� �� ����������� �������, � ������ �������� ������������� ��������� (/sp-)
::  � ����������� �� ��� �����, � �������� ������ , �� ���������� � ������������� ��� ������������� /verysilent 
echo [%time:~,8%] start install UVNC
pause
IF EXIST "%ProgramFiles(x86)%" ( CALL :INSTUVNC64) else ( CALL :INSTUVNC86)

:INSTUVNC64
echo [%time:~,8%] UVNC64 running intsall... 
start /wait "" "%~d0%~p0distr\UVNC64.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent 
GOTO :EOF

:INSTUVNC86
echo [%time:~,8%] UVNC32 running install...
start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent 
GOTO :EOF
set e8=%ERRORLEVEL%
IF %e8%==0 (CALL :OK) else ( CALL :NO)
Echo start install UVNC %YN% >> LogBatIsntall.txt

::� ������� OK ��������� ����� ��������� �� ����� , ������ �������� � ���������� YN (��� ����������� ������ � ����) ����� ������� � ������� ������
:OK
Echo OK
SET YN=-��
GOTO :EOF

::� ������� NO ��������� ����� ��������� �� ����� , ������ �������� � ���������� YN (��� ����������� ������ � ����), ����� ������� � ������� ������
:NO
Echo NO 
SET YN=-NOT/ERROR
GOTO :EOF


Echo TEST INSTAL UVNC WAS OK 
Pause
@echo off
cls
:: ��������� ����
TITLE UVNC BATFILE SILENT INSTALL
::������� �ࠢ��� ��� �室�饣� TCP/UDP ���� 5900,5800 
netsh advfirewall firewall add rule name="VNCTCP59005800 " dir=in action=allow protocol=TCP localport=5900,5800
netsh advfirewall firewall add rule name="VNCUDP59005800 " dir=in action=allow protocol=UDP localport=5900,5800

::C������ �ࠢ��� ��� ICMP (��� ����)!!!!!!!!!!!!!!!!!!!!!
netsh advfirewall firewall add rule name="All ICMP V4" protocol=icmpv4:any,any dir=in action=allow

:: ��⠭�������� �㦡� UVNC, ����� WinVNC (�ᯮ��塞� 䠨�, ���騩 ����� � 㤫������ ࠡ�祬� �⮫�.),
:: 㤠�塞 UVNC (�᫨ �� �⮣� �뫠 ��⠭������.) 

::�ਭ㤨⥫쭮 �������� ����� wnvinc ��������� �믮������ (wait)
start /wait taskkill /f /im winvnc*
net stop uvnc_service

:: �᫨ ������� ��⠫�� � ��⥬ "��⥬�� ���"\Program Files(��-�� �஡���� ��襬: ��ࢠ� ����� ����饥 ���� 6 �㪢 � ��������. �.�. progra~1)\UltraVNC
:: � 㤠�塞 ��४��� /㤠���� �� ����� ����� /���⭮
IF EXIST "%systemdrive%"\progra~1\ultravnc ( rd %systemdrive%\progra~1\ultravnc /s /q )
IF EXIST "%systemdrive%"\progra~1\uvncbvba ( rd %systemdrive%\progra~1\uvncbvba /s /q )

echo [%time:~,8%] start install UVNC

:: ����᪠�� ��⠭���� UVNC � ����ᨬ��� �� ���⥪���� �������, � ०��� �ய�᪠ ���⢥ত���� ��⠭���� (/sp-)
::  � ��ࠬ��ࠬ� �� ��� 䠩��, � ���⭮� ०��� , �� ��������� � ��१���㧪�� ��� ���⢥ত���� /verysilent 
IF EXIST "%ProgramFiles(x86)%" ( echo UVNC64 running intsall... 
start /wait "" "%~d0%~p0distr\UVNC64.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent / ) ELSE (
echo UVNC32 running install...
start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /loadinf= "%~d0%~p0distr\vnclog.log" /verysilent)

echo [%time:~,8%] UVNC INSTALL COMPLETE

::�� 㬮�砭�� UVNC ࠡ�⠥� �ࠧ� ��᫥ ��⠭����, 㡨���� �����, �����㥬 ���ன�� � ����� � �ண��, ����砥�
start /wait taskkill /f /im winvnc*
net stop uvnc_service

copy "%~d0%~p0distr\UltraVNC.ini" "%SystemDrive%\progra~1\ultravnc\" /y
net start uvnc_service

echo [%time~,8%] UVNC INSTALL SUCCESS !=)
pause

EXIT
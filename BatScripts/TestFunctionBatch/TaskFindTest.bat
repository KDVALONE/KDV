:: ���� ������, ��������� ��������� ��� �� �������� errorlevel (0-��������, 1-���) 
@Echo off
cls
Echo Find run task "cmd.exe"
::�������� �����.
tasklist /FI "IMAGENAME eq cmd.exe" | find "cmd.exe" 
� ����� ������������ errorlevel 
::--------------------------
pause
exit
:: �������� �� ��� �����������, � ����� ������� ����� � call
:: ���� ������ -  ������ �����, ���� ��� ����� 11 �� ������� ������ 2 ���������, ���������� � ����������� :some � �������� ������,
:: ��������� ����� ����� ������ :some (GOTO :EOF), ������� 4�� ���������, ��������� if/else  ������� ��������� ���������. ���� ���� �� ����� �� 11
@Echo off
cls
Echo Enter to test number 11:
set /p var=""
if %var%==11  ( Echo var=11 test one message
Echo var=11 test two message
call :some
:: ����� ������� ����� :some � :notsome � �����,����� ����� Exit ����������� ���������. ����� ����.
Echo var=11 test four message 
) else ( 
Echo var not=11 test one message
Echo var not=11 test two message
call :notsome
Echo var not=11 test four message
)
Echo NO MORE MESSAGE 
pause
exit

:some
Echo var=11 test three message
GOTO :EOF

:notsome
Echo var not=11 test tree message
GOTO :EOF


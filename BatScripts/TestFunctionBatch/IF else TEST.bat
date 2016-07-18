:: проверка иф элс конструкций, а также нюансов работ с call
:: ТЕСТ ЗАДАЧА -  ввести число, если оно равно 11 то вывести подряд 2 сообщения, обратиться в конструкцию :some и вывесьти третье,
:: вернуться сразу после вызова :some (GOTO :EOF), вывести 4ое сообщение, закончить if/else  вывести финальное сообщение. тоже если не число не 11
@Echo off
cls
Echo Enter to test number 11:
set /p var=""
if %var%==11  ( Echo var=11 test one message
Echo var=11 test two message
call :some
:: нужно ставить метки :some и :notsome в конце,после метки Exit завершающей программу. иначе бага.
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


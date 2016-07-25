@Echo off
::C помощью оператора GOTO и IF ELSE проверяем на соответствие вводимых символов, для подтверждения Y и N
cls
:QTODMN
Echo Add PC to Domain: gb1.korolev.local (Y/N)? 
Set /p TDMN=""
if %TDMN%==y ( GOTO :ADDTODMN ) else ( GOTO :TODMN )
:TODMN
if %TDMN%==Y ( GOTO :ADDTODMN ) else ( GOTO :NTODMN )
:NTODMN
if %TDMN%==n ( GOTO :NOTADDTODMN ) else ( GOTO :NTODMN2 )
:NTODMN2
if %TDMN%==N ( GOTO :NOTADDTODMN ) else ( GOTO :INCORRECT )
:INCORRECT
Echo incorrected symbol, please enter Y or N 
GOTO :QTODMN

:ADDTODMN
   ECHO ADDTODMN OK
   GOTO :JUMP
:NOTADDTODMN
 ECHO NOTADDTODMN OK   
:JUMP   
   Pause
   Exit
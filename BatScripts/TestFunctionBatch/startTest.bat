@Echo off
:: Установка программы с парамметром /SAVEINF для создания  файл-лога установки
:: Установка программы с парамметром /LOADINF для загрузки параметров установки из файл-лога
cls
Echo start install UVNC86
::start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /SAVEINF="%~d0%~p0distr\uvnc86log.log"
start /wait "" "%~d0%~p0distr\UVNC86.exe" /sp- /LOADINF="%~d0%~p0distr\uvnc86log.log" /verysilent
Echo start will be done 
pause
Echo 
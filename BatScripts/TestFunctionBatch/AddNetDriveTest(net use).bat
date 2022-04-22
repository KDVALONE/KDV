::подключить сетевой диск с именем :p по адресу 192.168.0.0\SetevayaPapka\
@Echo off
cls 
set SERVER=192.168.0.0
set FOLDER=SetevayaPapka
net use p: \\%SERVER%\%FOLDER%

:: отключаем сетевой диск 
net use p: \\%SERVER%\%FOLDER% /delete
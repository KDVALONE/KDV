:: Смена кодировки резултаты отличаются смотря в каком формате изначально сохранен файл, Если в UTF-8 то сработает 3 вариант
:: если в ANSI то 1й
@Echo off
cls
chcp 1251
Echo привет 1251
pause
chcp 866
Echo привет 866
pause
chcp 65001
Echo привет UTF-8
pause
:: перезагрузка ПК
@Echo off
cls
Echo PC will be Reboot now press any key
pause
::запуск утилиты, перезагрузка (для выключения -s) таймер до выполнения 00 сек.
shutdown.exe -r -t 00

exit
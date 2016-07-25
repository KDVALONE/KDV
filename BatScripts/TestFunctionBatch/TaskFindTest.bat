:: ищем задачу, проверяем запущенна она по значению errorlevel (0-запущена, 1-нет) 
@Echo off
cls
Echo Find run task "cmd.exe"
::отладить потом.
tasklist /FI "IMAGENAME eq cmd.exe" | find "cmd.exe" 
и далее обрабатывать errorlevel 
::--------------------------
pause
exit
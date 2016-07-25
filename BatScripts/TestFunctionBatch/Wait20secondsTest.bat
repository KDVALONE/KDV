@Echo off
cls
Echo After 20 second show next message 
::рекомендуемый многими "костыльный" способ подождать 20 сек, пропинговав самого себя без вывода результата.
ping 127.0.0.1 -n 20 > nul 
Echo 20 seconds later
pause
exit
@Echo off
cls
Echo rename local User ADMINISTRATOR, to ITS
pause
chcp 65001
wmic useraccount where name='Администратор' rename ITS
set e=%errorlevel%
Echo e = %e%, if e=0 is OK!
pause
exit
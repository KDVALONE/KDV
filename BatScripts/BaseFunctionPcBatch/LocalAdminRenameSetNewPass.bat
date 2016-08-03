@Echo off
cls
Echo rename local User ADMINISTRATOR, to ITS, 
pause
chcp 65001
::время пароля не ограничено
wmic path Win32_UserAccount where Name='Администратор' set PasswordExpires=false

wmic useraccount where name='Администратор' rename ITS

net user ITS 1024-Old
set e=%errorlevel%
Echo e = %e%, if e=0 is OK!
pause
exit
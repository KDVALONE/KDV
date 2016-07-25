:: —крипт переименовани¤ существующей уч. записи
@Echo off
cls

::Set /p NUSER=""
::IF NUSER=="" ( 
::echo new loacal user name not enter
::GOTO :ELUSER
:: ) else (
::echo ок User Name is %NUSER%
:: )

::--------------------------------
::Set AUSER1="Admin"
::Set AUSER2="ADMIN"
::Set AUSER3="admin"
::Set AUSER4="Administrator"
::Set AUSER5="ADMINISTRATOR"
::Set AUSER6="administrator"
::IF AUSER1 
::-----------------------------------


::-------------------------------------------
::ќтображает название группы локальных админов ищ¤ ее по ее сиду.
::Echo Show Admin GROUP  
::WMIC Group Where "SID = 'S-1-5-32-544'" Get Name
::-------------------------------------------
::-----------------------------------------------
::”станавливает срок действи¤ парол¤ неограничен
::Echo Set to password unlimited time
::wmic UserAccount WHERE Name="User-1" Set PasswordExpires=FALSE
::переименование
::Echo Rename account
::wmic UserAccount where "Name='јдминистратор'" call rename "123"
::-----------------------------------------------
Echo Add new administrato user
set ADMINNAME=its11
set ADMINPASS=1024-Old
::ƒобавление нового пользовател¤ /срок действи¤ парол¤¤ всегда 
net user %ADMINNAME% %ADMINPASS% /add /expires:never /fullname:%ADMINNAME%
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )
pause

:: ќбновление свойств пользовател¤
echo Update admin user settings
wmic Win32_Useraccount WHERE Name=%ADMINNAME% Set PasswordExpires=false /nointeractive
::UserAccount 
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )
::аналог кода
::wmic path Win32_Useraccount where Name='%user_name%' set   passwordexpires=false /nointeractive
pause

echo Add to Administrator group rus
::ƒобавление в группу "јдминистраторы"
net localgroup "Администраторы""%ADMINNAME%" /add
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )

echo Add to Administrator group eng
net localgroup "Administrators""%ADMINNAME%" /add
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )


pause
Echo THE END
pause 
exit

net localgroup "PowerUsersGroupName""MemberName"/add
pause
exit
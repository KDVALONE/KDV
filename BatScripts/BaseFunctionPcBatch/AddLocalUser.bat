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

echo Add to Administrator group eng
net localgroup "Administrators" "%ADMINNAME%" /add
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )

echo Add to Administrator group rus
chcp 65001
net localgroup "Администраторы" "%ADMINNAME%" /add
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )

pause
Echo THE END
pause 
exit

::net localgroup "PowerUsersGroupName""MemberName"/add
pause
exit
:: АВТО ЗАХОД ПОСЛЕ  РЕСТАРТА:
1. Пуск -> Выполнить -> введите коману regedit и нажмите ОК.
2. Найдите следующую ветвь реестра:
Код: Выделить весь код
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WindowsNT\CurrentVersion\Winlogon
3. Дважды щелкните параметр DefaultUserName (если такого параметра нет, то создайте Строковый параметр с этим именем), введите свое имя пользователя и нажмите кнопку OK.
4. Дважды щелкните параметр DefaultPassword, введите в поле «Значение» свой пароль и нажмите кнопку OK.
5. Дважды щелкните параметр AutoAdminLogon, введите в поле Значение число 1 и нажмите кнопку OK.

Примечание. В случае если компьютер является членом домена перечисленные выше способы не будут работать, необходимо немного модифицировать второй способ прописав значения входа в домен:
В реестре в ветви
Код: Выделить весь код
HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon
параметру AutoAdminLogon установите значение 1
параметру DefaultUserName установите значение равное имени пользователя для которого настраиваете автоматический вход в систему
параметру DefaultDomainName установите значение равное имени домена для входа
параметру DefaultPassword установите значение равное паролю пользователя для которого настраиваете автоматический вход в систему
Если какого либо параметра нет, то его нужно создать, для всех параметров тип Строковый (REG_SZ)
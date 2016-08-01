
::Обратите внимание, что если вы удаляете пользователя командой net user test_user /DELETE,
::то вам нужно будет вручную удалить его каталог по пути %USERS%\test_user\ либо предусмотреть его удаление в скрипте.
Echo Add new administrato user
set ADMINNAME=its12
set ADMINPASS=1024-Old
::?обавление нового пользовател¤ /срок действи¤ парол¤¤ всегда 
net user %ADMINNAME% /delete 
Set errorlevel=%ERRORLEVEL%
IF errorlevel==0 ( Echo OK ) else ( Echo NO )
pause

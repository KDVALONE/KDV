@Echo off
cls
Echo Enter domain admin user ( example: User777 ):
Set /p admin=""
Echo Enter domain admin user password:
Set /p PSWD=""
:: вызов утилиты wmic /интерактивный режим выкл(при выкл.режиме после выполнения одной команды wmic, управление возвращается к cls windows (PROMT))).
:: система где "имя пк" вызвать метод JoinDomainOrWorkgroup (заведения в домен),с параметрами точка хода=1 (если 1 то к домену, строки нет - к раб.группе),
:: Name="имя домена/рабочей группы", имя пользователья домена с правами присоединения, пароль.  
wmic /interactive:off ComputerSystem Where "name = '%computername%'" call JoinDomainOrWorkgroup FJoinOptions=1 Name="gb1.korolev.local" UserName="%admin%@gb1.korolev.local"  Password="%PSWD%" 
::Echo "%errorlevel%"
::If ReturnValue==1355 ( echo ok ) else ( Echo no )

::(непонятно как отработать возварщаемо значение для повторной попытки ввода  домен, errorlevel здесь всегда 0)
pause
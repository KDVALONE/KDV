:: v0.12  от 17.07.2016
@Echo off
cls
:: вызов утилиты wmic /интерактивный режим выкл(при выкл.режиме после выполнения одной команды wmic, управление возвращается к cls windows (PROMT))).
:: система где "имя пк" вызвать метод JoinDomainOrWorkgroup (заведения в домен),с параметрами точкаВхода=1 (если 1 то к домену, строки нет - к раб.группе),
:: Name="Имя домена/рабочей группы", имя пользователья домена с правами присоединения, пароль.  
wmic /interactive:off ComputerSystem Where "name = '%computername%'" call JoinDomainOrWorkgroup FJoinOptions=1 Name="my.domain.com" UserName="admin@my.domain.com"  Password="123" 
:: по умолчанию в cls отобразиться instance_PARMETRS value=0 (где 0 успех)
pause
exit
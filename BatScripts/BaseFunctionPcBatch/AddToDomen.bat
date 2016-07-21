:: v0.13  от 17.07.2016
:: НАЧАТЬ УЖЕ ПОЛЬХЗОВАТЬСЯ POWER SHELL ДЛЯ таких ВЕЩЕЙ.
@Echo off
cls
Echo USER NAME (example:USER777)
Set /p USER=""
Echo PASSWORD:
Set /p PASS=""
:: вызов утилиты wmic /интерактивный режим выкл(при выкл.режиме после выполнени¤ одной команды wmic, управление возвращаетс¤ к cls windows (PROMT))).
:: система где "им¤ пк" вызвать метод JoinDomainOrWorkgroup (заведени¤ в домен),с параметрами точкавхода=1 (если 1 то к домену(Не работает, советуют указывать 3), строки нет - к раб.группе),
:: Name="Имя домена/рабочей группы", имя пользователья домена с правами присоединения, пароль.  
wmic /interactive:off ComputerSystem Where "name = '%computername%'" call JoinDomainOrWorkgroup FJoinOptions=3 Name="gb1.korolev.local" UserName="%USER%@gb1.korolev.local"  Password="%PASS%" 
:: по умолчанию в cls отобразитьс¤ instance_PARMETRS value=0 (где 0 успех)
pause
exit
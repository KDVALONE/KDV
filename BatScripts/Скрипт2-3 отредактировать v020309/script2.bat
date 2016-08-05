@Echo off 
cls 
Режим вывода команд на экран (ECHO) отключен.
::-------------------delete autoran script2 in reestr -------------
REG delete "HKLM\SOFTWARE\Microsoft\Windows\CurrentVersion\Run" /v SCRIPT2 /f 
::-------------------delete autoran script2 in reestr (cancel)-------------
Режим вывода команд на экран (ECHO) отключен.
::-------------------install FIA part2 on script2 -------------
[10:49:20] install FIAgent 
start /wait "" "C:\itsprogfolder\FIAinstall\FIA64.exe" /S /acceptlicense /server="http://192.168.62.2/glpi/plugins/fusioninventory/" /add-firewall-exception 
cd "C:\Program Files\FusionInventory-Agent\perl\bin" 
perl fusioninventory-agent 
e=0 
IF e==0 ( Echo OK ) else ( Echo NO ) 
::-------------------install FIA part2 on script2 (cancel)-------------
Режим вывода команд на экран (ECHO) отключен.
::-----------------------------DeleteAutoEnerAfterRestart--------------------------- 
REG Delete "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v DefaultPassword REG_SZ /f 
REG ADD "HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon" /v AutoAdminLogon /t REG_SZ /d "0" /f 
::-----------------------------DeleteAutoEnerAfterRestart(cancel)--------------------------- 
::-----------------------------ADD to domain part2--------------------------- 
Add to domain part 2 
set pcname1=P1-39-TESTBAT
wmic /interactive:off ComputerSystem Where "name = ''" call JoinDomainOrWorkgroup FJoinOptions=3 Name="gb1.korolev.local" UserName="User02@gb1.korolev.local"  Password="Qwer 1234" 
::-------------------ADD to domain part2 (cancel)-------------

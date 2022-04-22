SELECT @@SERVERNAME AS 'Server Name', Host_name() HostName;  
Go

sp_dropserver "DESKTOP-BDMB12E\SQLEXPRESS";
Go
sp_addserver "DMITRIY\SQLEXPRESS", local;
GO


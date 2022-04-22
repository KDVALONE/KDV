use RoboCallMedsi

-- ������ ���� ��������
/*
update Tasks
set ExecuteFlag = 0 where ExecuteFlag = 1;
*/
go

--*****������ ������ ��������� � �������������� ������� TASK �������� �� ������ .

use RoboCallMedsi
go

Delete  from Tasks
go

DBCC CHECKIDENT ('Tasks', RESEED, 100)
go

DECLARE @cnt INT = 0;
-- ��� ��������� ���-�� �������
DECLARE @maxSeedCnt INT = 1011;

WHILE @cnt < @maxSeedCnt
BEGIN
	INSERT [dbo].[Tasks] ( [Phone], [MinCallDateTime], [BaseDateTime], [Surname], [GivenName], [Patronym], [PatientId], [BirthDate], [Gender], [IsVip], [IsEnglish], [NeedsAssistance], [ContactSurname], [ContactGivenName], [ContactPatronym], [OrgId], [TriesCount], [ReadForProcessing], [ExecuteFlag], [Attributes], [OrgAttributes]) 
	VALUES ( N'9268583525', CAST(N'2020-09-22T10:01:00.000' AS DateTime), CAST(N'2020-09-23T09:00:00.000' AS DateTime), N'���������', N'�������', N'������������', 5150807, CAST(N'1996-10-21T00:00:00.000' AS DateTime), 1, 0, 0, 0, N'', N'', N'', N'��_1', 1, 0, 0, 0, 30)
	
   
   SET @cnt = @cnt + 1;
END;

PRINT 'Done simulated FOR LOOP on TechOnTheNet.com';
GO

------**************

/*
-- �������� N ����� � ��������� ����������
DECLARE @cnt INT = 0;

WHILE @cnt < 60
BEGIN
	INSERT [dbo].[Tasks] ( [Phone], [MinCallDateTime], [BaseDateTime], [Surname], [GivenName], [Patronym], [PatientId], [BirthDate], [Gender], [IsVip], [IsEnglish], [NeedsAssistance], [ContactSurname], [ContactGivenName], [ContactPatronym], [OrgId], [TriesCount], [ReadForProcessing], [ExecuteFlag], [Attributes], [OrgAttributes]) 
	VALUES ( N'9268583525', CAST(N'2020-09-04T10:01:00.000' AS DateTime), CAST(N'2020-09-05T09:00:00.000' AS DateTime), N'���������', N'�������', N'������������', 5150807, CAST(N'1996-10-21T00:00:00.000' AS DateTime), 1, 0, 0, 0, N'', N'', N'', N'��_1', 1, 0, 0, 0, 30)
	  
   SET @cnt = @cnt + 1;
END;

PRINT 'Done simulated FOR LOOP on TechOnTheNet.com';
GO
/*


--������� ��� ���������
/*
Delete  from Tasks
*/

/*
--������ ������� �������� IDENTITY �������
SELECT IDENT_CURRENT( 'Tasks' ) 

--������ ������ �������� IDENTITY �������
SELECT IDENT_SEED ( 'Tasks' )  

--�������� ������� � ��������� �������� ID � ��������������� ���������.
DBCC CHECKIDENT ('Tasks', RESEED, 0)

*/
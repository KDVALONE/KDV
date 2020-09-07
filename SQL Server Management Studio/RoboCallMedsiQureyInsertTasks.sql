use RoboCallMedsi

-- убрать флаг исполнно
/*
update Tasks
set ExecuteFlag = 0 where ExecuteFlag = 1;
*/
go


-- Добавить N строк
DECLARE @cnt INT = 0;

WHILE @cnt < 500
BEGIN
	INSERT [dbo].[Tasks] ( [Phone], [MinCallDateTime], [BaseDateTime], [Surname], [GivenName], [Patronym], [PatientId], [BirthDate], [Gender], [IsVip], [IsEnglish], [NeedsAssistance], [ContactSurname], [ContactGivenName], [ContactPatronym], [OrgId], [TriesCount], [ReadForProcessing], [ExecuteFlag], [Attributes], [OrgAttributes]) 
	VALUES ( N'9268583525', CAST(N'2020-09-04T10:01:00.000' AS DateTime), CAST(N'2020-09-05T09:00:00.000' AS DateTime), N'Купряшкин', N'Дмитрий', N'Владимирович', 5150807, CAST(N'1996-10-21T00:00:00.000' AS DateTime), 1, 0, 0, 0, N'', N'', N'', N'КБ_1', 1, 0, 0, 0, 30)
	
   
   SET @cnt = @cnt + 1;
END;

PRINT 'Done simulated FOR LOOP on TechOnTheNet.com';
GO

--Удалить все значекния
/*
Delete  from Tasks
*/

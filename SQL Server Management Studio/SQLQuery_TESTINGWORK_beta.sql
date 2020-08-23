
USE [TESTS_DEST]
/*********************************ЗАДАНИЕ 1**********************************/

/*	скопировать информацию о группах прав доступа и их командах, сохранив содержимое групп,
	а также содержимое таблицы Objects, также сохраняя права доступа.*/

 BEGIN TRANSACTION
--1: Копируем данные из таблицы AccessGroup в новую, с измененным PK (1000+50)
INSERT INTO [AccessGroups] ([Guid], [Name],[TypeID],[Temporary],[SystemType])
     SELECT [Guid], [Name],[TypeID],[Temporary],[SystemType] 
       FROM [TESTS_SOURCE].[dbo].[AccessGroups]; 
GO


--2: Копируем данные из таблицы AccessGroupCommand в новую, с учетом изменного GroupID 
INSERT INTO [AccessGroupCommands] ([CommandID], [GroupID], [Enable])
SELECT   AGC.[CommandID], nAG.[PK], AGC.[Enable]
FROM [TESTS_SOURCE].[dbo].[AccessGroups] as oAG, [AccessGroups] as nAG, [TESTS_SOURCE].[dbo].[AccessGroupCommands] as AGC
WHERE oAG.[Guid] LIKE nAG.[Guid]
AND oAG.[PK] LIKE AGC.[GroupID] 
ORDER BY AGC.[CommandID]
GO

--3: Копируем данные из таблицы Objects в новую, с учетом изменного AccessGroupID
INSERT INTO [Objects] ([ObjectID], [AccessGroupID],[Name],[Guid])
SELECT    oBJ.[ObjectID] as ObjectID, nAG.[PK] as AccessGroupID, oBJ.[Name] as Name, obj.[Guid] as Guid
FROM [TESTS_SOURCE].[dbo].[AccessGroups] as oAG, [AccessGroups] as nAG, [TESTS_SOURCE].[dbo].[Objects] as oBJ 
WHERE oAG.[Guid] LIKE nAG.[Guid]
AND oAG.[PK] LIKE oBJ.[AccessGroupID] 
ORDER BY oBJ.[PK] 
GO

COMMIT TRANSACTION

/*********************************ЗАДАНИЕ 2**********************************/
 BEGIN TRANSACTION
/*  После выполнения тестового задания №1 требуется исправить ситуацию с избыточностью групп прав доступа,
	т.е. заменить все идентичные по командам группы прав доступа, которые были созданы для объектов списка п.3,
	на первые подходящие группы. При этом требуется удалить лишние группы и их команды из таблиц 
	
	Далее необходимо преобразовать временные группы в постоянные (указав значение колонки Temporary равным 0 
	и задав какое-то название группы вместо пустой строки). */


	/* Функция для конкатенации занчений Id комманд, к сожалению string_agg() в MSSSQL SRV2008 отсутсвует, вроде  */
	GO
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO

	CREATE FUNCTION [dbo].[concatStrCommandId] ( @id INT)
		RETURNS VARCHAR(MAX) AS 
		BEGIN
			DECLARE @valConcat VARCHAR(MAX) ;
				SET @valConcat = '' ;

			 SELECT @valConcat = @valConcat + CONVERT(varchar(max), tAGC.[CommandID] ) + ','
			   FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
			  WHERE tAGC.[GroupID]  = @id ;
			 RETURN @valConcat
		END


		
	/* Функция для конкатенации занчений Enable у комманд, к сожалению string_agg() в MSSSQL SRV 2008 отсутсвует, вроде */
	GO
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO

	CREATE FUNCTION [dbo].[concatStrComandEnable] ( @id INT )
	RETURNS VARCHAR(MAX) AS 
	BEGIN
		DECLARE @valConcat VARCHAR(MAX) ;
			SET @valConcat = '' ;

		 SELECT @valConcat = @valConcat + CONVERT(varchar(max), tAGC.[Enable] ) + ','
		  FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
		 WHERE tAGC.[GroupID]  = @id ;
		RETURN @valConcat
	END


	/* ХП для апдейта Обьектов и присвоения им необходимых групп*/
	GO
	CREATE PROCEDURE  [dbo].UpdateObjectGroups_TESTDEST

	AS
		DECLARE @TableCount INT, @j INT
		DECLARE @StatisticCommandTable Table (Id INT IDENTITY NOT NULL, GroupId INT, CommandIds VARCHAR(MAX), CommandEnables VARCHAR(MAX) ) 
		DECLARE @CommandDubles Table (Id INT IDENTITY NOT NULL, GroupId INT, CommandIds VARCHAR(MAX), CommandEnables VARCHAR(MAX) )
		DECLARE @GroupIdOld Table (Id INT IDENTITY NOT NULL, GroupId INT )
		DECLARE @GroupIdNew Table (Id INT IDENTITY NOT NULL, GroupId INT )

	BEGIN
	
		/*Получить табличную переменную со списком групп и коммандам*/		
		INSERT INTO @StatisticCommandTable 
			 SELECT tAGC.[GroupID],
			        dbo.concatStrCommandId ([tAGC].[GroupID]),
					dbo.concatStrComandEnable ([tAGC].[GroupID])
			   FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
		   GROUP BY tAGC.[GroupID]
		

		/*Получить список список групп и комманд дублекатов*/	
		INSERT INTO @CommandDubles 
			 SELECT  GroupId, CommandIds, CommandEnables 
			   FROM ( 
				      SELECT st.CommandIds as cId , CommandEnables as cEnables
                        FROM @StatisticCommandTable as st 
					GROUP BY st.CommandIds, st.CommandEnables
					  HAVING COUNT(*) > 1 
				    ) E
	          JOIN @StatisticCommandTable C ON C.CommandIds = E.cId  AND C.CommandEnables = E.cEnables		


	     /* Получить список старых GroupId которые требуется заменить*/
	     INSERT INTO @GroupIdOld 
			  SELECT cd.GroupId 
				FROM @CommandDubles as cd, @CommandDubles as v
			   WHERE cd.CommandIds = v.CommandIds 
				 AND cd.CommandEnables = v.CommandEnables
				 AND cd.GroupId > v.GroupID


		/* Получить список новых GroupId на которые требуется заменить*/
	     INSERT INTO @GroupIdNew
			  SELECT cd.GroupId 
				FROM @CommandDubles as cd, @CommandDubles as v
			   WHERE cd.CommandIds = v.CommandIds 
				 AND cd.CommandEnables = v.CommandEnables
				 AND cd.GroupId < v.GroupID

				 SET @TableCount =  (SELECT Count(t.Id) FROM @GroupIdOld as t)
				 SET @j = 0


		/* Обновить таблицу Object новыми значениями*/
		WHILE (@j < @TableCount)
			BEGIN

			/*Обновить таблицу Object новыми значениями*/
				UPDATE [TESTS_DEST].[dbo].[Objects] 
				   SET AccessGroupID = tNew.GroupId
				  FROM @GroupIdNew as tNew, @GroupIdOld as tOld
				 WHERE [TESTS_DEST].[dbo].[Objects].AccessGroupID = tOld.GroupId AND tOld.Id = @j + 1 AND tNew.Id = @j + 1

			SET @j = @j + 1
		   
			END;

		    /* Удалить группы дублеры из AccessGroups */
			DELETE FROM AccessGroups 
				  WHERE AccessGroups.PK IN (SELECT GroupId FROM @GroupIdOld ) 
			
	END;
	

	 GO
	 EXEC UpdateObjectGroups_TESTDEST

	COMMIT TRANSACTION



	BEGIN TRANSACTION

    /* ХП для перевода временных групп в постоянные и просвоении имени*/
	GO
	CREATE PROCEDURE  [dbo].ChangingTempGroupToStatic_TESTDEST
	
	AS
		DECLARE @TableCount INT, @i INT
	    DECLARE @GroupTemp Table (Id INT IDENTITY NOT NULL, GroupId INT )

		BEGIN
		   
		INSERT INTO @GroupTemp 
		     SELECT ag.PK 
		       FROM AccessGroups as ag 
			  WHERE Temporary = 1

		   SET @TableCount =  (SELECT Count(t.Id) FROM @GroupTemp  as t)
		   SET @i = 0

			  WHILE (@i < @TableCount)

				BEGIN
				
					   /* перевести временные таблицы в постоянные и дать имя*/
					   UPDATE AccessGroups
						  SET Temporary = 0 , Name = 'castom group_'+ CONVERT( VARCHAR(max), @i+1 )  
						 FROM @GroupTemp as t
						WHERE [TESTS_DEST].[dbo].[AccessGroups].PK = t.GroupId AND  t.Id = @i+1

						  SET @i = @i + 1
				END;
			END;

			GO
	        EXEC  ChangingTempGroupToStatic_TESTDEST

COMMIT TRANSACTION

   

	 
	 

	SELECT * FROM [AccessGroups] 
	SELECT * FROM [Objects]


	--DROP PROCEDURE UpdateObjectGroups_TESTDEST		
	--DROP PROCEDURE ChangingTempGroupToStatic_TESTDEST				
	
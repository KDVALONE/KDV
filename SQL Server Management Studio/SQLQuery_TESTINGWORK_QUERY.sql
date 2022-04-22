

--USE [TESTS_DEST]
--USE [TESTS_SOURCE]
--GO

USE [TESTS_DEST]
/*скопировать информацию о группах прав доступа и их командах, сохранив содержимое групп,
 а также содержимое таблицы Objects, также сохраняя права доступа.*/


 --SELECT * FROM TESTS_SOURCE.dbo.AccessGroupCommands
 --SELECT * FROM TESTS_DEST.dbo.AccessGroupCommands

 --SELECT * FROM TESTS_DEST.dbo.Objects
 --GO


 --2:
--ALTER TABLE [AccessGroupCommands] NOCHECK CONSTRAINT ALL  
--INSERT INTO [AccessGroupCommands] ([CommandID], [GroupID], [Enable])
--     SELECT [CommandID], [GroupID], [Enable] 
--       FROM [TESTS_SOURCE].[dbo].[AccessGroupCommands] ; 
--GO  
--ALTER TABLE [AccessGroupCommands] WITH NOCHECK CHECK CONSTRAINT ALL

 --1:
--INSERT INTO [AccessGroups] ([Guid], [Name],[TypeID],[Temporary],[SystemType])
--     SELECT [Guid], [Name],[TypeID],[Temporary],[SystemType] 
--       FROM [TESTS_SOURCE].[dbo].[AccessGroups] ; 
--GO

--INSERT INTO [Objects] ([ObjectID],[Name],[Guid])
--     SELECT [ObjectID],[Name],[Guid]
--       FROM [TESTS_SOURCE].[dbo].[Objects] ; 
--GO  
--************************
 --1: Копируем данные из таблицы AccessGroup в новую, с измененным PK (1000+50)
--INSERT INTO [AccessGroups] ([Guid], [Name],[TypeID],[Temporary],[SystemType])
--     SELECT [Guid], [Name],[TypeID],[Temporary],[SystemType] 
--       FROM [TESTS_SOURCE].[dbo].[AccessGroups] ; 
--GO

--2:
--SELECT * FROM AccessGroups
--GO

--SELECT * FROM [TESTS_SOURCE].[dbo].[AccessGroups]
--GO


--SELECT oAG.[PK] as OriginPK , nAG.[PK]  as newPK , AGC.[CommandID] as CommandID, AGC.[Enable] as Enable  -- сравнение
--SELECT nAG.[PK]  as newPK , AGC.[CommandID] as CommandID, AGC.[Enable] as Enable

--INSERT INTO [AccessGroupCommands] ([CommandID], [GroupID], [Enable])
----SELECT   AGC.[CommandID] as CommandID, nAG.[PK]  as newPK , AGC.[Enable] as Enable
--SELECT   AGC.[CommandID], nAG.[PK], AGC.[Enable]
--FROM [TESTS_SOURCE].[dbo].[AccessGroups] as oAG, [AccessGroups] as nAG, [TESTS_SOURCE].[dbo].[AccessGroupCommands] as AGC
--WHERE oAG.[Guid] LIKE nAG.[Guid]
--AND oAG.[PK] LIKE AGC.[GroupID] 
--ORDER BY AGC.[CommandID]
--GO

---***

--SELECT   oBJ.[PK] as PK, oBJ.[ObjectID] as ObjectID, nAG.[PK] as AccessGroupID, oBJ.[Name] as Name, obj.[Guid] as Guid
--INSERT INTO [Objects] ([ObjectID], [AccessGroupID],[Name],[Guid])
--SELECT    oBJ.[ObjectID] as ObjectID, nAG.[PK] as AccessGroupID, oBJ.[Name] as Name, obj.[Guid] as Guid
--FROM [TESTS_SOURCE].[dbo].[AccessGroups] as oAG, [AccessGroups] as nAG, [TESTS_SOURCE].[dbo].[Objects] as oBJ 
--WHERE oAG.[Guid] LIKE nAG.[Guid]
--AND oAG.[PK] LIKE oBJ.[AccessGroupID] 
--ORDER BY oBJ.[PK] 
--GO


-------Здание 2---**************
----После выполнения тестового задания №1 требуется исправить ситуацию с избыточностью групп прав доступа,
---- т.е. заменить все идентичные по командам группы прав доступа, которые были созданы для объектов списка п.3,
----на первые подходящие группы. При этом требуется удалить лишние группы и их команды из таблиц, 


--Получить все созданные для обьектов группы
--SELECT tAG.[PK],tAG.[Guid],tAG.[Name],tAG.[TypeID],tAG.[Temporary],tAG.[SystemType]
--FROM [TESTS_DEST].[dbo].[AccessGroups]as tAG, [TESTS_DEST].[dbo].[Objects] as tOBJ
--WHERE tAG.[PK] LIKE tOBJ.[AccessGroupID]
--GO


----Получить все созданные для обьектов группы,  для которых созданны комманды
--   SELECT tAG.[PK],tAG.[Guid],tAG.[Name],tAG.[TypeID],tAG.[Temporary],tAG.[SystemType],tAGC.[CommandID] 
--     FROM [TESTS_DEST].[dbo].[AccessGroups]as tAG, [TESTS_DEST].[dbo].[Objects] as tOBJ,[TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--	WHERE tAG.[PK] LIKE tOBJ.[AccessGroupID] 
--	  AND tAG.[PK] LIKE tAGC.[GroupID]
--GO
 -- на выходе мы получим список в котором совпадают группы 
-- 2050 и 2100 по коммандам (6,3,1), 
-- 2000 и 1950 по коммандам (5,6,1),
-- 2200 и 2150 по коммандам (5,6,7,8)
-- а так же группу
-- 1900 с коммандами (1,5,7) - которая не совпадает не с одной группой


----Получить все созданные для обьектов группы, для которых созданны комманды
 --  SELECT tAG.[PK],tAG.[Guid],tAG.[Name],tAG.[TypeID],tAG.[Temporary],tAG.[SystemType],tAGC.[CommandID] 
 --    FROM [TESTS_DEST].[dbo].[AccessGroups]as tAG, [TESTS_DEST].[dbo].[Objects] as tOBJ,[TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
	--WHERE tAG.[PK] LIKE tOBJ.[AccessGroupID] 
	--  AND tAG.[PK] LIKE tAGC.[GroupID]

	
 --SELECT  tAG.[PK],tAG.[Guid],tAG.[Name],tAG.[TypeID],tAG.[Temporary],tAG.[SystemType]
 --  FROM  [TESTS_DEST].[dbo].[AccessGroups]as tAG


   --SELECT *
   --FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
 

--   WITH cte AS ( SELECT KafedraID, STRING_AGG(id, ',') WITHIN GROUP (ORDER BY id) ids
--              FROM Descipline
--              GROUP BY KafedraID )
--SELECT * FROM cte ORDER BY KafedraID;
--GO



-------*************** Убирание дублей групп
--GO
--CREATE FUNCTION dbo.concatStr ( @c INT )
--RETURNS VARCHAR(MAX) AS BEGIN
--DECLARE @p VARCHAR(MAX) ;
--       SET @p = '' ;
--    SELECT @p = @p + CONVERT(varchar(max), tAGC.[CommandID] ) + ','
--      FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--     WHERE tAGC.[GroupID]  = @c ;
--RETURN @p
--END

--GO
------Удаление функции, если что
----DROP FUNCTION dbo.concatStr

/*SELECT * FROM Descipline ORDER BY KafedraID, id;
WITH cte_1 AS (SELECT KafedraID, dbo.concatStr( KafedraID ) IDS
             FROM Descipline
		 GROUP BY KafedraID)*/ -- удалить, пример


		 
------ Функция конкатенации ENABLE
--GO
--CREATE FUNCTION dbo.concatStrEnable ( @c INT )
--RETURNS VARCHAR(MAX) AS BEGIN
--DECLARE @p VARCHAR(MAX) ;
--       SET @p = '' ;
--    SELECT @p = @p + CONVERT(varchar(max), tAGC.[Enable] ) + ','
--      FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--     WHERE tAGC.[GroupID]  = @c ;
--RETURN @p
--END

-----Отобразить по ID группы все команды и разрешения -- Временный запрос, не использовать
--GO
--		SELECT tAGC.CommandID, tAGC.GroupID,tAGC.Enable
--	    FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC 
--		WHERE tAGC.[GroupID] = 1650
--		ORDER BY GroupID, CommandID,Enable
		
--GO
-- Получить все группы с одинаковыми коммандами
--SELECT * FROM [TESTS_DEST].[dbo].[AccessGroupCommands]   ORDER BY GroupID, CommandID,Enable;
--WITH cte_1 AS (SELECT tAGC.[GroupID], dbo.concatStr( [tAGC].[GroupID] ) IDS, dbo.concatStrEnable( [tAGC].[GroupID]) as Enable
--             FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--		 GROUP BY tAGC.[GroupID]/*, [tAGC].[Enable]*/ )
--		 Select* from cte_1 -- использовать только для отображения

--- Удалить дубли из таблицы tAGC
--DELETE tAGC
--FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--JOIN cte_1 cte1 ON [tAGC].[GroupID] = cte1.GroupID
--JOIN cte_1  cte2 ON cte1.IDS = cte2.IDS AND cte1.GroupID > cte2.GroupID AND cte1.ENABLE = cte2.ENABLE  
--SELECT * FROM [TESTS_DEST].[dbo].[AccessGroupCommands] AS tAGC ORDER BY tAGC.[GroupID], tAGC.[CommandID],tAGC.[Enable];
--GO
-----

--- Получить id групп которые теперь без комманд tAGC
 --SELECT  tAG.PK ,  tAG.Name ,tAG.Temporary
 --FROM  [TESTS_DEST].[dbo].[AccessGroups] as tAG, [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
 --WHERE tAG.PK != tAGC.GroupID
 --GROUP BY tAG.PK  ,  tAG.Name ,tAG.Temporary
 --ORDER BY tAG.PK 
 --GO

 ----___________________________________ВСПОМОГАТЕЛЬНЫЕ______________________

 /* !!!!!  Временный запрос, отображает все комманды и их статус и ID группы*/
----SELECT * FROM [TESTS_DEST].[dbo].[AccessGroupCommands]   ORDER BY GroupID, CommandID,Enable;
----GO

/* !!!!!! Удаление функции, если что */
----DROP FUNCTION dbo.concatStr
---GO

/* !!!!!! Отобразить по ID группы все команды и разрешения -- Временный запрос, не использовать */
--GO
--		SELECT tAGC.CommandID, tAGC.GroupID,tAGC.Enable
--	    FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC 
--		WHERE tAGC.[GroupID] = 1650
--		ORDER BY GroupID, CommandID,Enable


---- ______________________________________________________________________-*/



--*************************************************************************************
/*------------------------ДОП ИНФА!! ПРЕПРОВЕРИТЬ!-------------------------*/

 
 ---- У Группы 1650 по умолчанию нет комманд


/*-------------------------------------------------------------------------*/
--***************************************************************************************

 -------Здание 2---**************(В САМОМ НИЗУ Я ВСЕ СДЕЛАЛ КАК НУЖНО!!)
----После выполнения тестового задания №1 требуется исправить ситуацию с избыточностью групп прав доступа,
---- т.е. заменить все идентичные по командам группы прав доступа, которые были созданы для объектов списка п.3,
----на первые подходящие группы. При этом требуется удалить лишние группы и их команды из таблиц 

 -----************************************************
 -----Задание 2, суммируем наработки
 -----************************************************

 ------------------(ВАЖНО!!!)
 ------ Для UPDATE таблицы использвоать ХРАНИМУЮ ПРОЦЕДУРУ, так как нельзя обновть таблицу на группу результатов возвращаемого
 ------значения, ни на прямую, не из функции. Только условием черех ХП 


-- /*Функция конкатенации комманд в группе*/
-- GO
--CREATE FUNCTION dbo.concatStr ( @c INT )
--RETURNS VARCHAR(MAX) AS BEGIN
--DECLARE @p VARCHAR(MAX) ;
--       SET @p = '' ;
--    SELECT @p = @p + CONVERT(varchar(max), tAGC.[CommandID] ) + ','
--      FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--     WHERE tAGC.[GroupID]  = @c ;
--RETURN @p
--END
--GO

--/*Функция конкатенации значений ENABLE в группам*/
--GO
--CREATE FUNCTION dbo.concatStrEnable ( @c INT )
--RETURNS VARCHAR(MAX) AS BEGIN
--DECLARE @p VARCHAR(MAX) ;
--       SET @p = '' ;
--    SELECT @p = @p + CONVERT(varchar(max), tAGC.[Enable] ) + ','
--      FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--     WHERE tAGC.[GroupID]  = @c ;
--RETURN @p
--END
--GO


/* 1. Получить временную таблицу со списком групп и коммандам*/
--GO
--WITH cte_1 AS (SELECT tAGC.[GroupID], dbo.concatStr( [tAGC].[GroupID] ) IDS, dbo.concatStrEnable( [tAGC].[GroupID]) as Enable
--             FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--			 --WHERE tAGC.[GroupID]
--		 GROUP BY tAGC.[GroupID]
--		 )
--		 Select* from cte_1 -- использовать только для отображения


/*Получить временную таблицу со списком групп и коммандам (Тоже самое что и 1, но во временной постоянной таблице)*/
--SELECT tAGC.[GroupID], dbo.concatStr( [tAGC].[GroupID] ) IDS, dbo.concatStrEnable( [tAGC].[GroupID]) as Enable
--	into  #TemporaryStatisticTable
--    FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--GROUP BY tAGC.[GroupID]

/*отобразить результаты из времнной таблицы  #TemporaryStatisticTableTemp - она чисто на время работы, содержит в себе изначальнный список
всех Получить временную таблицу со списком групп и коммандам  */
--SELECT * FROM  #TemporaryStatisticTableTemp 
/*отобразить результаты из времнной таблицы  #TemporaryStatisticTable  */
--SELECT * FROM  #TemporaryStatisticTable 

---------------------SELECT * FROM  [TESTS_DEST].[dbo].[AccessGroups] -- получить информацию о группах.(удалить временное.)
/*2. Поиск дублей по двум полям (Enable и номер команды)*/

	--		SELECT IDS, GroupID, Enable 
	--		--into  #TemporaryDoubles
	--		FROM ( 
	--			  SELECT IDS as IDS2, Enable as Enable2
 --                 FROM #TemporaryStatisticTable 
 --                 GROUP BY IDS, Enable
 --                 HAVING COUNT(*) > 1 ) E
 --JOIN #TemporaryStatisticTable C ON C.IDS = E.IDS2  AND C.Enable = E.Enable2


 ---DROP TABLE [dbo].#TemporaryDoubles --- удалить временную таблицу
 --SELECT * FROM  #TemporaryDoubles  ---получение значений из временной таблицы где хранятся дубли


 --SELECT * FROM #TempObjTable  -- отоброзить все из обджектов



 ----- Выдает значение дублей подлежащих Оставить! (НОВЫЕ)
  --      SELECT t.IDS, t.GroupID, t.Enable   
		------into  #TemporaryDoublesToDelete
		--from #TemporaryDoubles t, #TemporaryDoubles v
		--WHERE t.IDS = v.IDS 
		--AND t.Enable = v.Enable
		--AND t.GroupID < v.GroupID


		-- --- Выдает значение дублей которые нужно Заменить!(СТАРЫЕ)
	 --   SELECT t.IDS, t.GroupID, t.Enable 
		------into  #TemporaryDoublesToSave
		--from #TemporaryDoubles t, #TemporaryDoubles v
		--WHERE t.IDS = v.IDS 
		--AND t.Enable = v.Enable
		--AND t.GroupID > v.GroupID
		
	---	Select * from cte11




		--- пример UPDATE TABLE
--WITH cte AS (SELECT * FROM @x)  
--UPDATE x -- cte is referenced by the alias.  
--SET Value = y.Value  
--FROM cte AS x  -- cte is assigned an alias.  
--INNER JOIN @y AS y ON y.ID = x.ID;  
--SELECT * FROM @x;  
--GO  


     ----Поиск дублей по двум полям (Enable и номер команды) оформленный во временное представление тоже что и 2
	--		WITH cte13 (IDS, GroupID, Enable) AS ( SELECT IDS, GroupID, Enable 
	--		---into  #TemporaryDoubles
	--		FROM ( 
	--			  SELECT IDS as IDS2, Enable as Enable2
 --                 FROM #TemporaryStatisticTable 
 --                 GROUP BY IDS, Enable
 --                 HAVING COUNT(*) > 1 ) E
 --JOIN #TemporaryStatisticTable C ON C.IDS = E.IDS2  AND C.Enable = E.Enable2)
 ------Select * from cte13

 


--UPDATE Objects 
--SET AccessGroupID =  td.GroupID
--From cte13 AS x , #TemporaryDoublesToDelete as td , #TemporaryDoublesToSave as ts
--WHERE x.GroupID = ts.IDS  AND   AccessGroupID  =  td.IDS ....

--t.IDS, t.GroupID, t.Enable   from #TemporaryDoubles t, #TemporaryDoubles v
--		WHERE t.IDS = v.IDS 
--		AND t.Enable = v.Enable
--		AND t.GroupID < v.GroupID


-- Попытаться сделать таблицу с IDS оригинальных групп, и столбцом оспоставимых им групп
--SELECT * FROM #TemporaryStatisticTable oc_product_image p1, oc_product_image p2 WHERE p1.product_image_id < p2.product_image_id AND p1.product_id = p2.product_id




--VVVVVVV


--UPDATE Table4
--   SET tNumb = s.Number
--  FROM Table3 as s
--  WHERE s.Number = (SELECT ts.Number From  #TempToSave as ts
--							   INNER JOIN Table3 as t
--								    ON ts.Number = t.Number AND ts.Value = t.Value ) -- Удалить, пример

-- пытаюсь обновить значения в #TempObjTable на основе двух таблиц #TemporaryDoublesToDelete и  #TemporaryDoublesToSave

--SELECT * FROM #TemporaryDoublesToSave
--SELECT * FROM #TemporaryDoublesToDelete

--	Update #TempObjTable 
--	    SET x.AccessGroupID = s.AccessGroupID
--		FROM #TemporaryDoublesToSave as s,#TempObjTable as x
--		WHERE x.AccessGroupID = (SELECT t.GroupID FROM #TemporaryDoublesToDelete as t)

--		SELECT * FROM #TempObjTable WHERE s.AccessGroupID
--	    SET AccessGroupID =  s.AccessGroupID
--		FROM #TemporaryDoublesToSave as s
--		WHERE AccessGroupID = (SELECT t.GroupID FROM #TemporaryDoublesToDelete as t)





		 /* ЛЕНКА***************************НА проработку**************************************/


----1. Твой код см. выше "Получить временную таблицу со списком групп и коммандам" но с сохранением во временную таблицу into  #TemporaryStatistic5
--SELECT tAGC.[GroupID], dbo.concatStr( [tAGC].[GroupID] ) IDS, dbo.concatStrEnable( [tAGC].[GroupID]) as Enable
--	into  #TemporaryStatistic5
--    FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--GROUP BY tAGC.[GroupID]

----2. Поиск дублей по двум полям (Enable и номер команды)
----https://hd.zp.ua/mysql-poisk-dublikatov-v-tablitse-po-neskolkim-polyam/
--SELECT * FROM ( 
--				  SELECT IDS, Enable
--                  FROM #TemporaryStatistic5
--                  GROUP BY IDS, Enable
--                  HAVING COUNT(*) > 1 ) E
--JOIN #TemporaryStatistic5 C ON C.IDS = E.IDS  AND C.Enable = E.Enable

-------3. Твой код "Удалить дубли из таблицы tAGC"
--DELETE tAGC
--OUTPUT Deleted.* -- Для выведения информайции об удаленных AccessGroup
--FROM #TemporaryStatistic5 as tAGC
--JOIN #TemporaryStatistic5 cte1 ON [tAGC].[GroupID] = cte1.GroupID
--JOIN #TemporaryStatistic5  cte2 ON cte1.IDS = cte2.IDS AND cte1.GroupID > cte2.GroupID AND cte1.ENABLE = cte2.ENABLE  

--SELECT * FROM #TemporaryStatistic5 AS tAGC ORDER BY tAGC.[GroupID], tAGC.IDS,tAGC.[Enable];
--GO

----4. Служебный код "Удаление временной таблицы и очищение всех таблиц от данных (чтобы не выдавал ошибку пр повторном создании)"
--	DROP TABLE [dbo].#TemporaryStatistic5
--	GO

	----------ЛЕНКА КОНЕЦ **************************************************************************************

----- Удалить дубли из таблицы tAGC
--SELECT * 
--FROM [TESTS_DEST].[dbo].[AccessGroupCommands] as tAGC
--JOIN cte_1 cte1 ON [tAGC].[GroupID] = cte1.GroupID
--JOIN cte_1  cte2 ON cte1.IDS = cte2.IDS AND cte1.GroupID > cte2.GroupID AND cte1.ENABLE = cte2.ENABLE  
--SELECT * FROM [TESTS_DEST].[dbo].[AccessGroupCommands] AS tAGC ORDER BY tAGC.[GroupID], tAGC.[CommandID],tAGC.[Enable];
--GO
/*******/
--select GroupID, IDS, Enable
--from cte_1
--where 
--group by  GroupID, IDS, Enable having count(*)>1

GO


/************************************************
***********************************************
************************************************/
/*********************************ЗАДАНИЕ 2, сделанное так ак нужно!!**********************************/

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


		
	/*Функция для конкатенации занчений Enable у комманд, к сожалению string_agg() в MSSSQL SRV 2008 отсутсвует, вроде */
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

	--!!!!!!!!
	/* ХП для апдейта Обьектов и присвоения им необходимых групп*/
	GO
	CREATE PROCEDURE  UpdateObjectGroups_TESTDEST

	AS
		DECLARE @TableCount INT, @I INT
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


	     /*Получить список старых GroupId которые требуется заменить*/
	     INSERT INTO @GroupIdOld 
			  SELECT cd.GroupId 
				FROM @CommandDubles as cd, @CommandDubles as v
			   WHERE cd.CommandIds = v.CommandIds 
				 AND cd.CommandEnables = v.CommandEnables
				 AND cd.GroupId > v.GroupID

				 SELECT* FROM @GroupIdOld --!!

		/*Получить список новых GroupId на которые требуется заменить*/
	     INSERT INTO @GroupIdNew
			  SELECT cd.GroupId 
				FROM @CommandDubles as cd, @CommandDubles as v
			   WHERE cd.CommandIds = v.CommandIds 
				 AND cd.CommandEnables = v.CommandEnables
				 AND cd.GroupId < v.GroupID

				 SET @TableCount =  (SELECT Count(t.Id) FROM @GroupIdOld as t)
				 SET @I = 0


		/*Обновить таблицу Object новыми значениями*/
		WHILE (@I < @TableCount)
			BEGIN

			/*Обновить таблицу Object новыми значениями*/
				UPDATE [TESTS_DEST].[dbo].[Objects] 
				   SET AccessGroupID = tNew.GroupId
				  FROM @GroupIdNew as tNew, @GroupIdOld as tOld
				 WHERE [TESTS_DEST].[dbo].[Objects].AccessGroupID = tOld.GroupId AND tOld.Id = @I + 1 AND tNew.Id = @I + 1

			SET @I = @I + 1
		   
			END;

		    /*Удалить группы дублеры из AccessGroups */
			DELETE FROM AccessGroups 
				  WHERE AccessGroups.PK IN (SELECT GroupId FROM @GroupIdOld ) 
			
	END;
	
	


    /*ХП для перевода временных групп в постоянные и просвоении имени*/
	GO
	CREATE PROCEDURE  ChangingTempGroupToStatic_TESTDEST
	
	AS
		DECLARE @TableCount INT, @I INT
	    DECLARE @GroupTemp Table (Id INT IDENTITY NOT NULL, GroupId INT )

		BEGIN
		   
		INSERT INTO @GroupTemp 
		     SELECT ag.PK 
		       FROM AccessGroups as ag 
			  WHERE Temporary = 1

		   SET @TableCount =  (SELECT Count(t.Id) FROM @GroupTemp  as t)
		   SET @I = 0

			  WHILE (@I < @TableCount)

				BEGIN
				
					   /* перевести временные таблицы в постоянные и дать имя*/
					   UPDATE AccessGroups
						  SET Temporary = 0 , Name = 'castom group_'+ CONVERT( VARCHAR(max), @I+1 )  
						 FROM @GroupTemp as t
						WHERE [TESTS_DEST].[dbo].[AccessGroups].PK = t.GroupId AND  t.Id = @I+1

						  SET @I = @I + 1

				END;

			END;



   

	GO
	EXEC UpdateObjectGroups_TESTDEST
	
	
	 GO
	EXEC  ChangingTempGroupToStatic_TESTDEST


	SELECT * FROM [AccessGroups] 
	SELECT * FROM [Objects]

	SELECT * FROM AccessGroups

	--Удалить процедуру
	DROP PROCEDURE UpdateObjectGroups_TESTDEST		
	DROP PROCEDURE ChangingTempGroupToStatic_TESTDEST				
	
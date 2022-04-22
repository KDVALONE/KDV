USE [TEST_SIMPLE_DB]
GO


--SELECT *
--  FROM Kafedra
--  INNER Join Descipline
--  ON Descipline.KafedraID LIKE Kafedra.ID
--  GO

---**
--SELECT * FROM Descipline ORDER BY KafedraID, id;

--WITH cte AS ( SELECT KafedraID, STRING_AGG(id, ',') WITHIN GROUP (ORDER BY id) ids
--              FROM Descipline
--              GROUP BY KafedraID )
--SELECT * FROM cte ORDER BY KafedraID;
----**


  --SELECT *
  --  FROM Kafedra
  -- WHERE ID LIKE (SELECT Kafedra.ID FROM Kafedra WHERE Kafedra.Name LIKE 'A')
  -- GO

  --SELECT *
  --FROM Kafedra
  --WHERE Kafedra.ID LIKE 
  --(SELECT KafedraID
  --FROM Kafedra
  --INNER Join Descipline
  --ON Descipline.KafedraID LIKE Kafedra.ID)

--  GO

--CREATE FUNCTION dbo.concatStr ( @c INT )
--RETURNS VARCHAR(MAX) AS BEGIN
--DECLARE @p VARCHAR(MAX) ;
--       SET @p = '' ;
--    SELECT @p = @p + CONVERT(varchar(max), Id) + ','
--      FROM Descipline 
--     WHERE KafedraID = @c ;
--RETURN @p
--END

--GO
--SELECT * FROM Descipline ORDER BY KafedraID, id;
--WITH cte_1 AS (SELECT KafedraID, dbo.concatStr( KafedraID ) IDS
--             FROM Descipline
--		 GROUP BY KafedraID)
--		 Select* from cte_1
		
--------SELECT * FROM ct2e ORDER BY KafedraID

--DELETE Descipline
--FROM Descipline
--JOIN cte_1 cte1 ON Descipline.KafedraID=cte1.KafedraID
--JOIN cte_1  cte2 ON cte1.ids = cte2.ids AND cte1.KafedraID > cte2.KafedraID;
--SELECT * FROM Descipline ORDER BY KafedraID, id;
-- GO


-----------------------------------
--GO
SELECT * FROM  Table1 ;--- ќтобразить содержимое Table1



-- создать временную таблицу где бы отображались бы все Alkatel
--WITH cte_ModelsToSubstitude (MODELS1 ,NAMES1 ,MODELSOLD) AS (SELECT t2.Model as MODELS, t2.Name as NAMES ,
--			(SELECT t.Model as MODELSOLD
--             FROM Table1 as t
--			 WHERE t.Name = 'Alkatel' 
--		     ) as MODELSOLD
--             FROM Table1 as t2 , Table1 as t
--			 WHERE t2.Name = 'Samsung' 
--		 ) 

---- создать временное предстваление и вывести все модели которые называютс€ так же как и у ALKATEL
WITH cte_ModelsToSubstitude (MODELS1 ,NAMES1) AS (
			SELECT t2.Model as MODELS, t2.Name as NAMES 
			FROM Table1 as t2 
			WHERE t2.Model IN (SELECT t.Model as MODELSOLD
             FROM Table1 as t
			 WHERE t.Name = 'Alkatel' 
		     ) 
		 ) 
Select* from cte_ModelsToSubstitude -- использовать только дл€ отображени€



--	UPDATE Table2
--	SET Model = t.[MODELS]
--	from  #cte_ModelsToSubstitude AS t
--	INNER JOIN Table2 as y ON y.Model 
--where t.tovar = v.tovar

--and t.id > v.id


--- ѕытаюсь обновить Table2 Name на Iphone где Model соответсвует cte_ModelsToSubstitude 
 --UPDATE Table2
 --   SET Name = Name +('Updated to Iphone')
 --  FROM Table2
 -- --Where Name = (Select NAMES FROM cte_ModelsToSubstitude )
 -- WHERE Name = 'Iphone'

 -- SELECT * FROM Table2


 		--- пример UPDATE TABLE
--WITH cte AS (SELECT * FROM @x)  
--UPDATE x -- cte is referenced by the alias.  
--SET Value = y.Value  
--FROM cte AS x  -- cte is assigned an alias.  
--INNER JOIN @y AS y ON y.ID = x.ID;  
--SELECT * FROM @x;  
--GO  

---- ѕробую хранимую процедуру
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO

--ALTER PROCEDURE [dbo].[sprocAddSymbols] @symbol NVARCHAR(10)

--AS 

--BEGIN

--    DECLARE @symbolCheck NVARCHAR(10)
--    DECLARE @statusCheck NVARCHAR(10)

--    SET @symbolCheck = (SELECT Symbol FROM tblSymbolsMain WHERE Symbol = @symbol)
--    SET @statusCheck = (SELECT SymbolStatus FROM tblSymbolsMain WHERE Symbol = @symbol)

--    IF (@symbolCheck IS NOT NULL AND @statusCheck = 'Inactive')
--    BEGIN
--        UPDATE tblSymbolsMain
--        SET SymbolStatus = 'Active'
--        WHERE Symbol = @symbol
--    END
--    ELSE
--    BEGIN
--        INSERT INTO tblSymbolsMain (Symbol, DateAdded, Status)
--        VALUES (@symbol, GETDATE(), 'Active')
--    END

--END

--____________________________________________________

SELECT *  FROM Table4

SELECT *  FROM Table3

GO


SELECT t3.Number as NUMBER, t3.Value as VALUE  FROM Table3 as t3 GROUP BY Value,Number HAVING COUNT(*) = 1

JOIN #TemporaryStatisticTable C ON C.IDS = E.IDS2  AND C.Enable = E.Enable2

 ----- ¬ыдает значение дублей подлежащих удалению
        SELECT  t.Number as Number, t.Value as Value   
		--into  #TempToDel
		from Table3 t, Table3 v
		WHERE t.Value = v.Value
		AND t.Number > v.Number
		---DROP TABLE [dbo].#TempToDel --- удалить временную таблицу
		


 ----- ¬ыдает значение дублей  которые нужно оставить
         SELECT  t.Number as Number, t.Value as Value   
		--into  #TempToSave
		from Table3 t, Table3 v
		WHERE t.Value = v.Value
		AND t.Number < v.Number
		---DROP TABLE [dbo].#TempToDel --- удалить временную таблицу

--UPDATE x -- cte is referenced by the alias.  
--SET Value = y.Value  
--FROM cte AS x  -- cte is assigned an alias.  
--INNER JOIN @y AS y ON y.ID = x.ID;  
--SELECT * FROM @x;  
--GO  
-------
-- --UPDATE Table2
-- --   SET Name = Name +('Updated to Iphone')
-- --  FROM Table2
-- -- --Where Name = (Select NAMES FROM cte_ModelsToSubstitude )
-- -- WHERE Name = 'Iphone'




--- что то рабоатет, Select да, но не так как нужно.

UPDATE Table4
   SET tNumb = s.Number
  FROM Table3 as s
  WHERE s.Number = (SELECT ts.Number From  #TempToSave as ts
							   INNER JOIN Table3 as t
								    ON ts.Number = t.Number AND ts.Value = t.Value )
  AND
  from dbo.GL gl
     inner join #n1 n1 on gl.sku = n1.sku




	 --- почти работает, просто шпора
	 --UPDATE Table4
  -- SET tNumb = s.Number
  --FROM Table3 as s
  --WHERE s.Number = (SELECT ts.Number From  #TempToSave as ts
		--					   INNER JOIN Table3 as t
		--						    ON ts.Number = t.Number AND ts.Value = t.Value )
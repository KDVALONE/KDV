Use[JOIN_TRENING]

	 /*Для наглядности я буду использовать только 3 строки из Table1 и  3 строки Table2 
	          Table1					 Table2 
		 (ID = 101,102,103)       (ID = 204,105,106)
	    (ValueT1 = A1,B1,С1)  и  (ValueT2 = D2,E2,F2)
	 */

	 /*вывести все значения Table1 где ID < 104 */
     SELECT t1.ID, t1.ValueT1 FROM Table1 as t1 WHERE t1.ID < 104

	 /*JOIN  - тоже что и CROSS JOIN и INNER JOIN, INNER опускается. 
	 соединить к каждой сроке Table1 по каждому значению Table2 
	 неиспользованные строки не добавляются
	 */
     SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 


	  /*LEFT JOIN  - тоже что и LEFT OUTER JOIN, OUTER опускается.
	  К каждой строке в Table1 приставить каждое значение из Table2
	  ключевое, выводятся все значения из Table1, и все значения Table2, 
	  где нет соответсвия условию ставитсья NULL (добавляются «неиспользованные» строки) для Table2
	  */
      SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    LEFT JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 

	  /*RIGHT JOIN  - тоже что и RIGHT OUTER JOIN, OUTER опускается.
	  К каждой строке в Table2 приставить каждое значение из Table1
	  ключевое, выводятся все значения из Table2, и все значения Table1, 
	  где нет соответсвия условию ставитсья NULL (добавляются «неиспользованные» строки) для Table1
	  */
      SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    RIGHT JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 

	  /*FULL OUTER JOIN  - К каждой строке в Table1 приставить каждое значение из Table2
	  ключевое, выводятся все значения из Table1, и все значения Table1, 
	  где нет соответсвия условию ставитсья NULL (добавляются «неиспользованные» строки) для Table1 и Table2*/
      SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    FULL OUTER JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 

	/* есть еще UNION ALL*/




	/***************************************************************************************************************/

    /*Код для тренировки, на основе задачи*/
	SELECT * FROM Table1 WHERE ID IN (SELECT t.ID FROM Table1 as t WHERE ID = 103 OR ID = 105 OR ID = 106   )

	PRINT 'СОЗДАЮ ПРЕДСТАВЛЕНИЕ ';
	GO

	CREATE VIEW MyView AS SELECT t2.ValueT2 as Val FROM Table2 as t2 WHERE ID > 203 

	GO

	PRINT 'СОЗДАЮ ТАБЛИЧНУЮ ПЕРЕМЕННУЮ'; -- переменные живут только в рамках одного пакета GO
	DECLARE @variable Table (Value varchar(max))
	INSERT INTO @variable  SELECT ValueT1 FROM Table1 as t Where ID < 104
	
	PRINT 'ДОБАВЛЯЮ ДАННЫЕ В ПРЕДСТАВЛЕНИЕ'; 
	INSERT INTO @variable SELECT ValueT1 FROM Table1 as t Where ID > 103
	
	PRINT 'ВЫЗЫВАЮ ДАННЫЕ ИЗ ТАБЛИЧНОЙ ПЕРЕМЕННОЙ ';
	SELECT * FROM @variable

	
	SELECT * FROM MyView

	GO -- ниже новый пакет, @variable удаляется, так как действует только в рамках 1 пакета

	PRINT 'ВЫЗЫВАЮ ДАННЫЕ ИЗ ПРЕДСТАВЛЕНИЯ ';
	SELECT * FROM MyView
	PRINT 'ДРОПАЮ ПРЕДСТАВЛЕНИЕ ';
	DROP VIEW MyView
	

	GO
		PRINT 'СОЗДАЮ ХРАНИМУЮ ПРОЦЕДУРУ'
	/* Хранимая процедура, которая апдейтит значения Таблицы1 с ID = 103, ID = 105, ID = 106  на  значения Таблицы2 с ID > 203 
	   Ожидаемый вывод из Table1: A1,B1,D2,D1,E2,F2, Хранимая процедура может апдейтить таблицы, функция нет  */
	GO
	CREATE PROCEDURE  MyProcedureUPDT 
		-- @SomeValue INT -- Это входные параметры, если стребуется передать что то, передать таблицу, вроде нельзя
	AS
		DECLARE @CountVal INT, @I INT
		DECLARE @VTableDonorId Table (Id INT IDENTITY, Ids INT,   Value VARCHAR(MAX) ) 
	    DECLARE @VTablePatientId Table (Id INT IDENTITY, Ids INT, Value VARCHAR(MAX) ) 
		
	
	BEGIN
	
	    
		INSERT INTO @VTableDonorId SELECT t2.ID, t2.ValueT2 FROM Table2 as t2 WHERE t2.ID > 203 
		INSERT INTO @VTablePatientId SELECT t1.ID, t1.ValueT1 FROM Table1 as t1 WHERE ID = 103 OR ID = 105 OR ID = 106  
	    SET @CountVal =  (SELECT Count(td.Value) FROM @VTableDonorID as td)
		SET @I = 0
		
		Select * FROM @VTableDonorId 

		
		WHILE (@I < @CountVal)
			BEGIN
				UPDATE Table1 
				   SET ValueT1 = td.Value
				  FROM @VTableDonorId as td, @VTablePatientId as tp
				 WHERE Table1.ID = tp.Ids AND tp.Id = @I + 1 AND td.Id = @I + 1


			SET @I = @I + 1
		 END;
		 PRINT 'ОСНОВНОЙ ЦИКЛ ВЫПОЛНИЛСЯ'
		 SELECT * FROM Table1
	END;
	GO

	EXEC MyProcedureUPDT

	GO

	/*Удаление необходимых строк из Table1 , если изменить ValueT1: A1 на A2 и С1 = С2, то эти строки удаляться. */
	DELETE FROM Table1
	       WHERE ValueT1 IN (SELECT ValueT2 FROM Table2 ) 
     
	  SELECT * FROM Table1
	  SELECT * FROM Table2





	DROP PROCEDURE MyProcedureUPDT


	/*Для удобства, создание, воостановление, апдейт Table1 */
	DROP TABLE Table1
	CREATE TABLE Table1
(
	ID INT IDENTITY(101,1) PRIMARY KEY,
	ValueT1 NVARCHAR(30) NOT NULL
);

     PRINT 'ВСТАВЛЯЮ НОВЫЕ ЗНАЧЕНИЯ'
	INSERT INTO Table1
	VALUES
	('A1'),
	('B1'),
	('C1'),
	('D1'),
	('E1'),
	('F1')
	GO

	 PRINT 'ВОССТАНАВЛИВАЮ ЗНАЧЕНИЕ TABLE1'
	 UPDATE Table1
	    SET ValueT1 = 'A1'
	  WHERE Table1.ID = 101	
	 UPDATE Table1
	    SET ValueT1 = 'B1'
	  WHERE Table1.ID = 102	
	 UPDATE Table1
	    SET ValueT1 = 'C1'
      WHERE Table1.ID = 103	
	 UPDATE Table1
	    SET ValueT1 = 'D1'
      WHERE Table1.ID = 104
	 UPDATE Table1
	    SET ValueT1 = 'E1'
      WHERE Table1.ID = 105	
	 UPDATE Table1
	    SET ValueT1 = 'F1'
      WHERE Table1.ID = 106	
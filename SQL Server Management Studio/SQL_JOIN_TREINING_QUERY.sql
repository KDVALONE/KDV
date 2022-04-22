Use[JOIN_TRENING]

	 /*��� ����������� � ���� ������������ ������ 3 ������ �� Table1 �  3 ������ Table2 
	          Table1					 Table2 
		 (ID = 101,102,103)       (ID = 204,105,106)
	    (ValueT1 = A1,B1,�1)  �  (ValueT2 = D2,E2,F2)
	 */

	 /*������� ��� �������� Table1 ��� ID < 104 */
     SELECT t1.ID, t1.ValueT1 FROM Table1 as t1 WHERE t1.ID < 104

	 /*JOIN  - ���� ��� � CROSS JOIN � INNER JOIN, INNER ����������. 
	 ��������� � ������ ����� Table1 �� ������� �������� Table2 
	 ���������������� ������ �� �����������
	 */
     SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 


	  /*LEFT JOIN  - ���� ��� � LEFT OUTER JOIN, OUTER ����������.
	  � ������ ������ � Table1 ���������� ������ �������� �� Table2
	  ��������, ��������� ��� �������� �� Table1, � ��� �������� Table2, 
	  ��� ��� ����������� ������� ��������� NULL (����������� ����������������� ������) ��� Table2
	  */
      SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    LEFT JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 

	  /*RIGHT JOIN  - ���� ��� � RIGHT OUTER JOIN, OUTER ����������.
	  � ������ ������ � Table2 ���������� ������ �������� �� Table1
	  ��������, ��������� ��� �������� �� Table2, � ��� �������� Table1, 
	  ��� ��� ����������� ������� ��������� NULL (����������� ����������������� ������) ��� Table1
	  */
      SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    RIGHT JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 

	  /*FULL OUTER JOIN  - � ������ ������ � Table1 ���������� ������ �������� �� Table2
	  ��������, ��������� ��� �������� �� Table1, � ��� �������� Table1, 
	  ��� ��� ����������� ������� ��������� NULL (����������� ����������������� ������) ��� Table1 � Table2*/
      SELECT t1.ID, t1.ValueT1,t2.ValueT2  FROM Table1 as t1
				    FULL OUTER JOIN Table2 as t2
					ON  t1.ID < 104 AND t2.ID > 203 

	/* ���� ��� UNION ALL*/




	/***************************************************************************************************************/

    /*��� ��� ����������, �� ������ ������*/
	SELECT * FROM Table1 WHERE ID IN (SELECT t.ID FROM Table1 as t WHERE ID = 103 OR ID = 105 OR ID = 106   )

	PRINT '������ ������������� ';
	GO

	CREATE VIEW MyView AS SELECT t2.ValueT2 as Val FROM Table2 as t2 WHERE ID > 203 

	GO

	PRINT '������ ��������� ����������'; -- ���������� ����� ������ � ������ ������ ������ GO
	DECLARE @variable Table (Value varchar(max))
	INSERT INTO @variable  SELECT ValueT1 FROM Table1 as t Where ID < 104
	
	PRINT '�������� ������ � �������������'; 
	INSERT INTO @variable SELECT ValueT1 FROM Table1 as t Where ID > 103
	
	PRINT '������� ������ �� ��������� ���������� ';
	SELECT * FROM @variable

	
	SELECT * FROM MyView

	GO -- ���� ����� �����, @variable ���������, ��� ��� ��������� ������ � ������ 1 ������

	PRINT '������� ������ �� ������������� ';
	SELECT * FROM MyView
	PRINT '������ ������������� ';
	DROP VIEW MyView
	

	GO
		PRINT '������ �������� ���������'
	/* �������� ���������, ������� �������� �������� �������1 � ID = 103, ID = 105, ID = 106  ��  �������� �������2 � ID > 203 
	   ��������� ����� �� Table1: A1,B1,D2,D1,E2,F2, �������� ��������� ����� ��������� �������, ������� ���  */
	GO
	CREATE PROCEDURE  MyProcedureUPDT 
		-- @SomeValue INT -- ��� ������� ���������, ���� ���������� �������� ��� ��, �������� �������, ����� ������
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
		 PRINT '�������� ���� ����������'
		 SELECT * FROM Table1
	END;
	GO

	EXEC MyProcedureUPDT

	GO

	/*�������� ����������� ����� �� Table1 , ���� �������� ValueT1: A1 �� A2 � �1 = �2, �� ��� ������ ���������. */
	DELETE FROM Table1
	       WHERE ValueT1 IN (SELECT ValueT2 FROM Table2 ) 
     
	  SELECT * FROM Table1
	  SELECT * FROM Table2





	DROP PROCEDURE MyProcedureUPDT


	/*��� ��������, ��������, ��������������, ������ Table1 */
	DROP TABLE Table1
	CREATE TABLE Table1
(
	ID INT IDENTITY(101,1) PRIMARY KEY,
	ValueT1 NVARCHAR(30) NOT NULL
);

     PRINT '�������� ����� ��������'
	INSERT INTO Table1
	VALUES
	('A1'),
	('B1'),
	('C1'),
	('D1'),
	('E1'),
	('F1')
	GO

	 PRINT '�������������� �������� TABLE1'
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
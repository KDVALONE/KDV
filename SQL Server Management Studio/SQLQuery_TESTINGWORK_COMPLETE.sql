
USE [TESTS_DEST]
/*********************************������� 1**********************************/

/*	����������� ���������� � ������� ���� ������� � �� ��������, �������� ���������� �����,
	� ����� ���������� ������� Objects, ����� �������� ����� �������.*/

 BEGIN TRANSACTION
--1: �������� ������ �� ������� AccessGroup � �����, � ���������� PK (1000+50)
INSERT INTO TESTS_DEST.dbo.AccessGroups (Guid, Name, TypeID, Temporary, SystemType)
     SELECT ag.Guid, ag.Name, ag.TypeID, ag.Temporary,ag.SystemType 
       FROM TESTS_SOURCE.dbo.AccessGroups as ag; 
GO 



--2: �������� ������ �� ������� AccessGroupCommand � �����, � ������ ��������� GroupID 
INSERT INTO TESTS_DEST.dbo.AccessGroupCommands (CommandID, GroupID, Enable)
     SELECT agc.CommandID, nag.PK, agc.Enable
       FROM TESTS_SOURCE.dbo.AccessGroups as oag, AccessGroups as nag, TESTS_SOURCE.dbo.AccessGroupCommands as agc
      WHERE oag.Guid LIKE nag.Guid
        AND oag.PK LIKE agc.GroupID 
   ORDER BY agc.CommandID
GO

--3: �������� ������ �� ������� Objects � �����, � ������ ��������� AccessGroupID
INSERT INTO TESTS_DEST.dbo.Objects  (ObjectID, AccessGroupID, Name, Guid)
     SELECT o.ObjectID as ObjectID, nag.PK as AccessGroupID, o.Name as Name, o.Guid as Guid
       FROM TESTS_SOURCE.dbo.AccessGroups as oag, AccessGroups as nag, TESTS_SOURCE.dbo.Objects as o 
      WHERE oag.Guid LIKE nag.Guid
        AND oag.PK LIKE o.AccessGroupID 
      ORDER BY o.PK 
GO

COMMIT TRANSACTION

/*********************************������� 2**********************************/
 BEGIN TRANSACTION
/*  ����� ���������� ��������� ������� �1 ��������� ��������� �������� � ������������� ����� ���� �������,
	�.�. �������� ��� ���������� �� �������� ������ ���� �������, ������� ���� ������� ��� �������� ������ �.3,
	�� ������ ���������� ������. ��� ���� ��������� ������� ������ ������ � �� ������� �� ������ 
	
	����� ���������� ������������� ��������� ������ � ���������� (������ �������� ������� Temporary ������ 0 
	� ����� �����-�� �������� ������ ������ ������ ������). */


	/* ������� ��� ������������ �������� Id �������, � ��������� string_agg() � MSSSQL SRV2008 ����������, �����  */
	GO
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO

	CREATE FUNCTION dbo.concatStrCommandId ( @id INT)
		    RETURNS VARCHAR(MAX) AS 
		BEGIN
			DECLARE @valConcat VARCHAR(MAX) ;
				SET @valConcat = '' ;

			 SELECT @valConcat = @valConcat + CONVERT(varchar(max), agc.[CommandID] ) + ','
			   FROM TESTS_DEST.dbo.AccessGroupCommands as agc
			  WHERE agc.GroupID  = @id ;
			 RETURN @valConcat
		END
    GO

		
	/* ������� ��� ������������ �������� Enable � �������, � ��������� string_agg() � MSSSQL SRV 2008 ����������, ����� */
	GO
	SET ANSI_NULLS ON
	GO
	SET QUOTED_IDENTIFIER ON
	GO

	CREATE FUNCTION dbo.concatStrComandEnable ( @id INT )
	        RETURNS VARCHAR(MAX) AS 
	
		BEGIN
			DECLARE @valConcat VARCHAR(MAX) ;
				SET @valConcat = '' ;

			 SELECT @valConcat = @valConcat + CONVERT(varchar(max), agc.[Enable] ) + ','
			   FROM TESTS_DEST.dbo.AccessGroupCommands as agc
			  WHERE agc.GroupID = @id ;
			 RETURN @valConcat
		END


	/* �� ��� ������� �������� � ���������� �� ����������� �����*/
	GO
	CREATE PROCEDURE  dbo.UpdateObjectGroups_TESTDEST

	AS
		DECLARE @TableCount INT, @j INT
		DECLARE @StatisticCommandTable Table (Id INT IDENTITY NOT NULL, GroupId INT, CommandIds VARCHAR(MAX), CommandEnables VARCHAR(MAX) ) 
		DECLARE @CommandDubles Table (Id INT IDENTITY NOT NULL, GroupId INT, CommandIds VARCHAR(MAX), CommandEnables VARCHAR(MAX) )
		DECLARE @GroupIdOld Table (Id INT IDENTITY NOT NULL, GroupId INT )
		DECLARE @GroupIdNew Table (Id INT IDENTITY NOT NULL, GroupId INT )

	BEGIN
	
		/*�������� ��������� ���������� �� ������� ����� � ���������*/		
		INSERT INTO @StatisticCommandTable 
			 SELECT agc.GroupID,
			        dbo.concatStrCommandId (agc.GroupID),
					dbo.concatStrComandEnable (agc.GroupID)
			   FROM TESTS_DEST.dbo.[AccessGroupCommands] as agc
		   GROUP BY agc.GroupID
		

		/*�������� ������ ������ ����� � ������� ����������*/	
		INSERT INTO @CommandDubles 
			 SELECT GroupId, CommandIds, CommandEnables 
			   FROM ( 
				      SELECT st.CommandIds as cId , CommandEnables as cEnables
                        FROM @StatisticCommandTable as st 
					GROUP BY st.CommandIds, st.CommandEnables
					  HAVING COUNT(*) > 1 
				    ) E
	          JOIN @StatisticCommandTable C ON C.CommandIds = E.cId  AND C.CommandEnables = E.cEnables		


	     /* �������� ������ ������ GroupId ������� ��������� ��������*/
	     INSERT INTO @GroupIdOld 
			  SELECT cd.GroupId 
				FROM @CommandDubles as cd, @CommandDubles as v
			   WHERE cd.CommandIds = v.CommandIds 
				 AND cd.CommandEnables = v.CommandEnables
				 AND cd.GroupId > v.GroupID


		/* �������� ������ ����� GroupId �� ������� ��������� ��������*/
	     INSERT INTO @GroupIdNew
			  SELECT cd.GroupId 
				FROM @CommandDubles as cd, @CommandDubles as v
			   WHERE cd.CommandIds = v.CommandIds 
				 AND cd.CommandEnables = v.CommandEnables
				 AND cd.GroupId < v.GroupID

				 SET @TableCount =  (SELECT Count(t.Id) FROM @GroupIdOld as t)
				 SET @j = 0
				 

		/* �������� ������� Object ������ ����������*/
		WHILE (@j < @TableCount)
			BEGIN

			/*�������� ������� Object ������ ����������*/
				UPDATE TESTS_DEST.dbo.Objects 
				   SET AccessGroupID = tnew.GroupId
				  FROM @GroupIdNew as tnew, @GroupIdOld as told
				 WHERE TESTS_DEST.dbo.Objects.AccessGroupID = told.GroupId AND told.Id = @j + 1 AND tnew.Id = @j + 1

				 SET @j = @j + 1
		   
			END;


		    /* ������� ������ ������� �� AccessGroups */
			 DELETE FROM TESTS_DEST.dbo.AccessGroups 
				   WHERE AccessGroups.PK IN (SELECT GroupId FROM @GroupIdOld ) 
			

	END;
	
	 
	 GO
			   EXEC UpdateObjectGroups_TESTDEST
	 DROP PROCEDURE UpdateObjectGroups_TESTDEST
	 COMMIT TRANSACTION
	
	

	BEGIN TRANSACTION

    /* �� ��� �������� ��������� ����� � ���������� � ���������� �����*/
	GO
	CREATE PROCEDURE  dbo.ChangingTempGroupToStatic_TESTDEST
	
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
				
					   /* ��������� ��������� ������� � ���������� � ���� ���*/
					   UPDATE TESTS_DEST.dbo.AccessGroups
						  SET Temporary = 0 , Name = 'castom group_'+ CONVERT( VARCHAR(max), @i+1 )  
						 FROM @GroupTemp as t
						WHERE TESTS_DEST.dbo.AccessGroups.PK = t.GroupId AND  t.Id = @i+1

						  SET @i = @i + 1
				   END;

		END;

		GO	  
	    EXEC  ChangingTempGroupToStatic_TESTDEST
		

COMMIT TRANSACTION

   DROP PROCEDURE ChangingTempGroupToStatic_TESTDEST 


	SELECT * FROM TESTS_DEST.dbo.AccessGroups 
	SELECT * FROM TESTS_DEST.dbo.Objects  

		
	
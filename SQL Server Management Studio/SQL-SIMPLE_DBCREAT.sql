/**/


 ----Удаление БД
 USE [master]
 DROP DATABASE TEST_SIMPLE_DB;
 GO
 ----******************************

----Создание БД
 USE [master]
 CREATE DATABASE TEST_SIMPLE_DB;
 GO
 USE [TEST_SIMPLE_DB];
 GO

CREATE TABLE Kafedra
(
    ID INT IDENTITY(11,1) PRIMARY KEY,
    Name NVARCHAR(30) NOT NULL
);
GO

CREATE TABLE Descipline
(
    Id INT NOt NULL,
	KafedraID INT,
	Name NVARCHAR(30) NOT NULL
	--CONSTRAINT FK_Desciplines_To_Kafedras FOREIGN KEY (KafedraID)  REFERENCES Kafedra (ID)
);
  GO

INSERT INTO Kafedra
VALUES
('A'),
('B'),
('C'),
('D'),
('E'),
('F')
GO

INSERT INTO Descipline
VALUES
(1,11,'Math'),
(1,12,'Math'),
(2,15,'Eng'),
(2,16,'Eng'),
(3,13,'Bio'),
(3,14,'Bio'),
(3,15,'Bio'),
(4,11,'Muse'),
(4,12,'Muse'),
(5,13,'Rus'),
(5,14,'Rus'),
(5,15,'Rus')
GO

ALTER TABLE Descipline
ADD CONSTRAINT FK_Desciplines_To_Kafedras FOREIGN KEY (KafedraID)  REFERENCES Kafedra (ID)
----------------	--CONSTRAINT PK_Desciplines PRIMARY KEY NONCLUSTERED (Id)
	

GO


-------------------------------ТУТ я добавид пару идентичных таблиц для тработки Table1 и Table2


CREATE TABLE Table1
(
    ID INT IDENTITY(6000,1) PRIMARY KEY,
	Model INT ,
    Name NVARCHAR(30) NOT NULL
);
GO
CREATE TABLE Table2
(
     ID INT IDENTITY(7000,1) PRIMARY KEY,
	 Model INT, 
     Name NVARCHAR(30) NOT NULL
);
GO

INSERT INTO Table1
VALUES
(101,'Samsung'),
(102,'Samsung'),
(103,'Samsung'),
(104,'Samsung'),
(105,'Samsung'),
(201,'Iphone'),
(201,'Iphone'),
(201,'Iphone'),
(202,'Iphone'),
(202,'Iphone'),
(203,'Iphone'),
(301,'Nokia'),
(101,'Huawei'),
(401,'Huawei'),
(401,'Huawei'),
(201,'Alkatel'),
(202,'Alkatel'),
(203,'Alkatel'),
(204,'Alkatel'),
(205,'Alkatel'),
(501,'Mi'),
(504,'Mi'),
(505,'Mi'),
(503,'Mi'),
(502,'Mi')


GO

INSERT INTO Table2
VALUES
(101,'Samsung'),
(102,'Samsung'),
(103,'Samsung'),
(104,'Samsung'),
(105,'Samsung'),
(201,'Iphone'),
(201,'Iphone'),
(201,'Iphone'),
(202,'Iphone'),
(202,'Iphone'),
(203,'Iphone'),
(301,'Nokia'),
(101,'Huawei'),
(401,'Huawei'),
(401,'Huawei'),
(201,'Alkatel'),
(202,'Alkatel'),
(203,'Alkatel'),
(204,'Alkatel'),
(205,'Alkatel'),
(501,'Mi'),
(504,'Mi'),
(505,'Mi'),
(503,'Mi'),
(502,'Mi')
GO

----DROP TABLE Table1,Table2


--------------- Создание таблиц аналогичных тестовому заданию
CREATE TABLE Table3
(
    ID INT IDENTITY PRIMARY KEY,
	Number INT ,
    Value  INT NOT NULL
);
GO
CREATE TABLE Table4
(
     ID INT IDENTITY PRIMARY KEY,
	 tNumb INT, 
     Name NVARCHAR(30) NOT NULL
);
GO

INSERT INTO Table3
VALUES
(492,120),(403,120),(496,110),(495,110),(493,110),(631,130),(702,130),(404,130),(501,140)

INSERT INTO Table4
VALUES
(492,'Some1'),(493,'Some2'),(495,'Some3'),(496,'Some4'),(404,'Some5'),(405,'Some6')


----DROP TABLE Table3,Table4
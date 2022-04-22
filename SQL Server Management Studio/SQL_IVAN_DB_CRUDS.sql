
/* 

Итак, есть задача:

Есть три таблица Objetc, VALTODEL и VALTOSAVE.

В Objetc есть объекты, у них есть поле AccessGroupID, 

В Таблице VALTODEL в поле VALTODEL.GROUPID находятся номера которые нужно заменить в Object.AccessGroupID
на соответсвующие им номера VALTOSAVE.GROUPID, соответсвие устанавливается по полям IDS и ENABLE из таблиц VALTOSAVE и VALTODEL


Целевая платформа MS SQL SERVER 2008, так что могут некоторые современные штуки не работать из коробки.
*/

----USE [master]
----DROP DATABASE IVAN_DB
USE [master]
CREATE DATABASE IVAN_DB
USE [IVAN_DB]

/*Таблица содержащяя старые GROUPID  подлежащих замене в OBJECT*/
CREATE TABLE VALTODEL
(
    ID INT IDENTITY PRIMARY KEY NOT NULL,
    IDS NVARCHAR(max) NOT NULL,
	GROUPID INT,
	ENABLE NVARCHAR(max) NOT NULL
);

/*Таблица содержащяя новые GROUPID  для замены в  OBJECT*/
CREATE TABLE VALTOSAVE
(
    ID INT IDENTITY PRIMARY KEY NOT NULL,
    IDS NVARCHAR(max) NOT NULL,
	GROUPID INT,
	ENABLE NVARCHAR(max) NOT NULL
);

/*Таблица в которой нужно заменить те AccessGroupID которые соостветствуют VALTODEL.GROUPID  
на новые из таблицы VALTOSAVE.GROUPID  */
CREATE TABLE OBJCT
(
    ID INT IDENTITY PRIMARY KEY NOT NULL,
    ObjctID INT,
	AccessGroupID INT,
	Name NVARCHAR(max)
);

/*Таблица со всеми значениями, просто чтоб удобнее было
*/
CREATE TABLE FULLTABLE  
(
    ID INT IDENTITY PRIMARY KEY NOT NULL,
    IDS NVARCHAR(max) NOT NULL,
	GROUPID INT,
	ENABLE NVARCHAR(max) NOT NULL
);



INSERT INTO FULLTABLE
VALUES
('1,3,6,',  2050, '1,1,1,'),
('1,3,6,',  1850, '1,1,1,'),
('1,5,7,',  1900, '1,1,1,'),
('1,5,7,',  1800, '1,1,1,'),
('1,6,7,',  1950, '1,1,1,'),
('1,6,7,',  2000, '1,1,1,'),
('5,6,7,8,',2150, '1,0,1,1'),
('5,6,7,8', 2200, '1,0,1,1,')


INSERT INTO OBJCT
VALUES
(1,1900,'Объкет001'),
(1,1950,'Объкет002'),
(1,2000,'Объкет003'),
(1,2050,'Объкет004'),
(1,2100,'Объкет005'),
(1,2150,'Объкет006'),
(1,2200,'Объкет007')



INSERT INTO VALTOSAVE
VALUES
('1,3,6,',  1850, '1,1,1,'),
('1,5,7,',  1800, '1,1,1,'),
('1,6,7,',  1950, '1,1,1,'),
('5,6,7,8,',2150, '1,0,1,1')


INSERT INTO VALTODEL
VALUES
('1,3,6,',  2050, '1,1,1,'),
('1,5,7,',  1900, '1,1,1,'),
('1,6,7,',  2000, '1,1,1,'),
('5,6,7,8', 2200, '1,0,1,1,')




---


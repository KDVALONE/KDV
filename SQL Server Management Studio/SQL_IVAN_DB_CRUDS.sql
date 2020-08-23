
/* 

����, ���� ������:

���� ��� ������� Objetc, VALTODEL � VALTOSAVE.

� Objetc ���� �������, � ��� ���� ���� AccessGroupID, 

� ������� VALTODEL � ���� VALTODEL.GROUPID ��������� ������ ������� ����� �������� � Object.AccessGroupID
�� �������������� �� ������ VALTOSAVE.GROUPID, ����������� ��������������� �� ����� IDS � ENABLE �� ������ VALTOSAVE � VALTODEL


������� ��������� MS SQL SERVER 2008, ��� ��� ����� ��������� ����������� ����� �� �������� �� �������.
*/

----USE [master]
----DROP DATABASE IVAN_DB
USE [master]
CREATE DATABASE IVAN_DB
USE [IVAN_DB]

/*������� ���������� ������ GROUPID  ���������� ������ � OBJECT*/
CREATE TABLE VALTODEL
(
    ID INT IDENTITY PRIMARY KEY NOT NULL,
    IDS NVARCHAR(max) NOT NULL,
	GROUPID INT,
	ENABLE NVARCHAR(max) NOT NULL
);

/*������� ���������� ����� GROUPID  ��� ������ �  OBJECT*/
CREATE TABLE VALTOSAVE
(
    ID INT IDENTITY PRIMARY KEY NOT NULL,
    IDS NVARCHAR(max) NOT NULL,
	GROUPID INT,
	ENABLE NVARCHAR(max) NOT NULL
);

/*������� � ������� ����� �������� �� AccessGroupID ������� �������������� VALTODEL.GROUPID  
�� ����� �� ������� VALTOSAVE.GROUPID  */
CREATE TABLE OBJCT
(
    ID INT IDENTITY PRIMARY KEY NOT NULL,
    ObjctID INT,
	AccessGroupID INT,
	Name NVARCHAR(max)
);

/*������� �� ����� ����������, ������ ���� ������� ����
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
(1,1900,'������001'),
(1,1950,'������002'),
(1,2000,'������003'),
(1,2050,'������004'),
(1,2100,'������005'),
(1,2150,'������006'),
(1,2200,'������007')



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


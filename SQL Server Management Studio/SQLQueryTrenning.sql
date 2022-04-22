-- Создаем БД магзина InternetShopDB
CREATE DATABASE InternetShopDB
COLLATE Cyrillic_General_CI_AS
GO
-- Создаем таблицы в БД.
-- Microsoft Не рекомендует использовать NULL, так как усложняет выполнение запроса.
CREATE TABLE Customers
(
 ID int NOT NULL IDENTITY,
 FName nvarchar(20) NULL,
 MName nvarchar(20) NULL,
 LName nvarchar(20) NULL,
 [Address] nvarchar(50) NULL,
 City nvarchar(20) NULL,
 Phone char(12) NULL,
 DateInSystem date DEFAULT GETDATE()
)
GO
--- 24.054.2019 SQL TRENING ITVDN https://www.youtube.com/watch?v=Xux3_o2bImY

--- 1. CREATED DATA BASE 

CREATE DATABASE InternetShopDB
COLLATE Cyrillic_General_CI_AS
GO
-- Нужно, если после удаления БД и создания заного, пишет что таблицы в бд уже созданны
USE InternetShopDB
GO

--- 2. CREATED TABLES TO DATA BASE
--- Infomration about customers

CREATE TABLE Customers
(
	ID int NOT NULL IDENTITY,
	FName nvarchar(20) NULL,
	MName nvarchar(20) NULL,
	LName nvarchar(20) Null,
	[Address] nvarchar(50) Null,
	City nvarchar(20) Null,
	Phone char(12) Null,
	DateInSystem date DEFAULT GETDATE()
)
GO

--- Infomration about Employeers
CREATE TABLE Employees
(
	ID int NOT NULL IDENTITY,
	FName nvarchar(20) NOT NULL,
	MName nvarchar(20) NULL,
	LName nvarchar(20) NOT NULL,
	Post nvarchar(25) NOT NULL,
	Salary money NOT NULL,
	PriorSalary money NULL
)
GO
--- Personal information of Employeer
CREATE TABLE EmployeesInfo
(
	ID int NOT NULL,
	MaritalStatus varchar(10) NOT NULL,
	BirthDate date NOT NULL,
	[Address] nvarchar(50) NOT NULL,
	Phone char(12) NOT NULL
)
GO

--- Information about Product

CREATE TABLE Products
(
   ID int NOT NULL IDENTITY,
   Name nvarchar(50) NOT NULL,
)
GO

--- Extended information about Product

CREATE TABLE ProductsDetails
(
   ID int NOT NULL,
   Color nchar(20) Null,
   [Description] nvarchar(max) Null,
)
GO

--- Rest of products on Stocks

CREATE TABLE Stocks
(
	ProductID int NOT NULL,
	Qty int DEFAULT 0
)
GO

--- Information about Orders

CREATE TABLE Orders
(
 ID int NOT NULL IDENTITY,
 CustomerID int NULL,
 EmployeeID int NULL,
 OrderDate date DEFAULT GETDATE()
)
GO

--- Extended information about Order

CREATE TABLE OrderDetails
(
	OrderID int NOT NULL,
	LineItem int NOT NULL,
	ProductID int NULL,
	Qty int NOT NULL,
	Price money NOT NULL,
	TotalPrice AS CONVERT(money, Qty*Price) -- bad practic, but for example
)
GO

--- 3. Establishing link for Tables, that this https://youtu.be/Xux3_o2bImY?t=796
--- Set Foregin and Primary Keys for Tables

ALTER TABLE Customers
ADD
PRIMARY KEY(ID)
GO

ALTER TABLE Employees
ADD
PRIMARY KEY (ID) 
GO

ALTER TABLE EmployeesInfo
ADD
UNIQUE(ID)
GO

ALTER TABLE EmployeesInfo
ADD
FOREIGN KEY (ID) REFERENCES Employees (ID)
	ON DELETE CASCADE -- cascade delete, if delete value on Employees, will deleted values on EmployeesInfo
GO

ALTER TABLE Products
ADD
PRIMARY KEY(ID)
GO

ALTER TABLE ProductsDetails
ADD
UNIQUE (ID)
GO

ALTER TABLE ProductsDetails
ADD
FOREIGN KEY (ID) REFERENCES Products (ID)
	ON DELETE CASCADE 
GO

ALTER TABLE Stocks
ADD
UNIQUE (ProductID)
GO

ALTER TABLE Stocks
ADD
FOREIGN KEY (ProductID) REFERENCES Products (ID)
	ON DELETE CASCADE 
GO

ALTER TABLE Orders
ADD
PRIMARY KEY(ID)
GO

ALTER TABLE Orders
ADD
FOREIGN KEY (CustomerID) REFERENCES Customers (ID)
	ON DELETE SET NULL -- какскадное удаление не нужно, так как нам не нужно потерять заказ, просто бедет занчение NULL
GO

ALTER TABLE Orders
ADD
FOREIGN KEY (EmployeeID) REFERENCES Employees (ID)
	ON DELETE SET NULL -- при удалении сотрудника, мы не потеряем сам заказ
GO

ALTER TABLE OrderDetails
ADD
PRIMARY KEY(OrderID, LineItem)
GO

ALTER TABLE OrderDetails
ADD
FOREIGN KEY(OrderID) REFERENCES Orders(ID)
	ON DELETE CASCADE
GO

ALTER TABLE OrderDetails
ADD
FOREIGN KEY(ProductID) REFERENCES Products(ID)
	ON DELETE SET NULL
GO

--- 4. CREATED USERS LIMITING
/*
 1) LIMITING TO CORRECT SETING PHONE NUMBER
 2) LIMITING TO EMPLOYEES HAS ONLY FROM 18-to 50 OLD
 3) LIMITING TO FICKSATION OF ORDER FORM SHOP OPENNING DATE TO CURRENT DATE (SHOP OPPENING 90 DAYS AGO)
 4) LIMITING TO COLUMN MARITALSATUS (MARIED, UNMARIED)
 5) LIMITING TO REGISTRATION DATE TO CUSTOMER FORM SHOP OPENNING DATE TO CURRENT DATE (SHOP OPPENING 90 DAYS AGO)
 6) LIMITING TO EMPLOYEERS SALARY CANT BE APPER THAN PRIORSALARY
 7) LIMITING TO STOCK THAT THEY CANT BE NEGATIVE
*/

-- 1)
ALTER TABLE Customers
ADD
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO
			
ALTER TABLE EmployeesInfo
ADD
CHECK (Phone LIKE '([0-9][0-9][0-9])[0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
GO

-- 2)
ALTER TABLE EmployeesInfo
ADD
CHECK (BirthDate BETWEEN DATEADD(YEAR, -50, GETDATE()) AND DATEADD(YEAR, -18, GETDATE()))
GO

-- 3)
ALTER TABLE Orders
ADD
CHECK(OrderDate >= DATEADD(DAY, -90, GETDATE()) AND OrderDAte <=GETDATE())
GO

-- 4)
ALTER TABLE EmployeesInfo
ADD
CHECK(MaritalStatus IN ('Женат','Не женат','Замужем','Не замужем'))
GO

-- 5)
ALTER TABLE Customers
ADD
CHECK (DateInSystem >= DATEADD(DAY, - 90, GETDATE()) AND DateInSystem <= GETDATE())
GO

-- 6)
ALTER TABLE Employees
ADD
CHECK (Salary > PriorSalary)
GO

-- 7)
ALTER TABLE Stocks
ADD
CHECK (Qty >= 0) -- Qty is Quantity
GO

-- 5. SET VALUES TO TABLES

INSERT Customers
(FName, MName, LName, [Address], City, Phone, DateInSystem)
VALUES
('Виктор', 'Викторович', 'Прокопенко', 'Руденко 21а, 137', 'Тернополь','(063)4569385', DATEADD(DAY, -85, GETDATE())),
('Антон', 'Олегович', 'Курк', 'Бажова 77', 'Киев','(093)1416433', DATEADD(DAY, -85, GETDATE())),
('Оксана', 'Владимировна', 'Десятова', 'Бажана 6, 22', 'Киев','(068)0989367', DATEADD(DAY, -85, GETDATE())),
('Антонина', 'Дмитриевна', 'Шевченко', 'Мышуги 25', 'Львов','(098)4569111', DATEADD(DAY, -65, GETDATE())),
('Анатолий', 'Петрович', 'Дмитров', 'Дружнова 15', 'Львов','(068)2229325', DATEADD(DAY, -45, GETDATE())),
('Иван', 'Иванович', 'Кобзар', 'Ковпака 24, 17', 'Киев','(063)1119311', DATEADD(DAY, -45, GETDATE())),
('Виктор', 'Олегович', 'Грачь', 'Лесная 21', 'Тернополь','(068)4569344', DATEADD(DAY, -35, GETDATE())),
('Ольга', 'Алексеевна', 'Буткова', 'Дорожная 77, 99', 'Николаев','(050)4569255', DATEADD(DAY, -25, GETDATE())),
('Алина', 'Михайловна', 'Мелова', 'Контрактна 20', 'Николаев','(050)4539333', DATEADD(DAY, -15, GETDATE())),
('Михаил', 'Андреевич', 'Савицкий', 'Медовая 1', 'Киев','(063)9999380', DATEADD(DAY, -5, GETDATE()));
GO

INSERT Employees 
(FName, MName, LName, Post, Salary, PriorSalary)
VALUES
('Анатолий', 'Владимирович', 'Десятов', 'Главный директор', 2000, 300),
('Андрей', 'Антонович', 'Зарицкий','Менеджер', 700, 150),
('Олег', 'Артемович','Сурков', 'Менеджер по продажам', 500, 150),
('Максим', 'Иванович','Рудаков', 'Менеджер по продажам', 500, 50),
('Ирина', 'Михайловна','Макар', 'Менеджер', 700, 150),
('Юлия','Борисовна','Таран', 'Менеджер по продажам', 750, 150);
GO

--потому что серверу надо знать, что за дата скрывается за литералами типа 01.02.2015,
--это 1ое февраля или 2ое января. 
--можно передавать "в конверте" (convert), указав формат передаваемого, 
--можно использовать языконезависимый формат типа 20150102,
--если это все не сделано, сервер считает, что формат соответствует принятому в языке сессии. 
--поэтому лучше всего от языка не зависеть. 
--в гугле искать на sql server language-independent format
SET LANGUAGE us_english
GO

INSERT EmployeesInfo  ----- {{{{{{{{{{{{{{{{{{{{{{{
(ID, MaritalStatus,BirthDate, [Address], Phone) 
VALUES
(1,'Не женат', '08/15/1970', 'Викторская 16/7','(067)4564489'),
(2,'Женат', '09/09/1985', 'Малинская 15','(050)0564585'),
(3,'Не женат', '12/11/1990', 'Победы 16, 145','(068)4560409'),
(4,'Не женат', '01/11/1988', 'Антоновка 11','(066)4664466'),
(5,'Замужем', '08/08/1990', 'Руденко 10, 7','(093)4334493'),
(6,'ЗАмужем', '01/08/1994', 'Просвещения 7','(063)4114141');
GO


INSERT Products
(Name)
VALUES
('Ноутбук Asus D435'),
('Ноутбук HP Pavilion 15-p032er'),
('Ноутбук Dell Inspiron 5555'),
('Нетбук Acer Aspire ES1'),
('Нетбук Lenovo Flex 10'),
('Нетбук Dell Inspiron 3147'),
('Смартфон Samsung Galaxy S6 SS 32GB'),
('Смартфон Apple iPhone 6'),
('Фотоаппарат Cannon PowerShot SX400'),
('Телевизор LG 55LBP631V');
GO

INSERT ProductsDetails
(ID, Color,[Description])
VALUES
(1,'Черный',' Описание товара '),
(2,'Серый',' Описание товара '),
(3,'Черный',' Описание товара '),
(4,'Черный',' Описание товара '),
(5,'Черный',' Описание товара '),
(6,'Черный',' Описание товара '),
(7,'Белый',' Описание товара '),
(8,'Черный',' Описание товара '),
(9,'Черный',' Описание товара '),
(10,'Черный',' Описание товара ');
GO

INSERT Stocks
(ProductID,Qty)
VALUES
(1,20),
(2,10),
(3,7),
(4,8),
(5,9),
(6,5),
(7,12),
(8,54),
(9,8),
(10,7);
GO

INSERT Orders
(CustomerID, EmployeeID, OrderDate)
VALUES
(1,3, DATEADD(DAY, -85, GETDATE())),
(2,6, DATEADD(DAY, -85, GETDATE())),
(3,4, DATEADD(DAY, -85, GETDATE())),
(3,NULL, DATEADD(DAY, -75, GETDATE())),
(2,3, DATEADD(DAY, -65, GETDATE())),
(4,6, DATEADD(DAY, -65, GETDATE())),
(1,3, DATEADD(DAY, -55, GETDATE())),
(5,3, DATEADD(DAY, -45, GETDATE())),
(6,3, DATEADD(DAY, -45, GETDATE())),
(1,4, DATEADD(DAY, -45, GETDATE())),
(2,NULL, DATEADD(DAY, -45, GETDATE())),
(7,3, DATEADD(DAY, -35, GETDATE())),
(6,4, DATEADD(DAY, -35, GETDATE())),
(3,NULL, DATEADD(DAY, -35, GETDATE())),
(5,6, DATEADD(DAY, -35, GETDATE())),
(8,3, DATEADD(DAY, -25, GETDATE())),
(5,4, DATEADD(DAY, -25, GETDATE())),
(7,4, DATEADD(DAY, -25, GETDATE())),
(7,3, DATEADD(DAY, -15, GETDATE())),
(9,3, DATEADD(DAY, -15, GETDATE())),
(8,4, DATEADD(DAY, -15, GETDATE())),
(10,NULL, DATEADD(DAY, -15, GETDATE())),
(11,3, DATEADD(DAY, -5, GETDATE())),
(10,4, DATEADD(DAY, -5, GETDATE()));
GO

INSERT OrderDetails
(OrderID,LineItem,ProductID,Qty, Price)
VALUES
(1,1,1,1,295),
(2,1,2,1,445),
(2,2,6,1,450),
(3,1,4,1,450),
(3,1,4,1,422),
(3,2,9,4,218),
(4,1,7,1,450),
(5,1,9,1,220),
(6,1,8,1,550), 
(7,1,8,2,550),-- отсюда и ниже стало влом, наклепал рандомных значений
(8,1,9,1,222),
(8,1,5,1,289),
(9,1,3,1,518),
(10,1,9,1,222),
(11,1,6,1,451),
(12,1,10,3,600),
(13,1,7,2,452),
(13,1,7,1,452),
(22,2,2,1,450),
(23,1,1,3,300),
(23,2,2,1,450),
(23,3,3,1,525),
(23,4,6,2,420),
(24,1,6,4,450);
GO

SELECT * FROM Customers
SELECT * FROM Employees
SELECT * FROM Stocks
SELECT * FROM EmployeesInfo
SELECT * FROM Orders
SELECT * FROM Products
SELECT * FROM ProductsDetails
SELECT * FROM OrderDetails
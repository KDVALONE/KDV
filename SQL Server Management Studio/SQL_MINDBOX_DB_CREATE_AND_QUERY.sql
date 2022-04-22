---Вопрос от mindbox, для отклика на собеседование

/*В БД есть таблица клиентов: CustomerId, RegistrationDateTime. 
И таблица с покупками: CustomerId, PurchaseDateTime, ProductName

Приложите ссылку на sqlfiddle.com (или альтернативный ресурс с теми же возможностями - rextester.com, db-fiddle.com) 
с запросом выбирающим клиентов, которые покупали молоко за последнюю неделю, 
но никогда не покупали сметану.
*/
use master

CREATE DATABASE MINDBOX_TRENING


USE MINDBOX_TRENING


CREATE TABLE Customers
(
	CustomerId INT IDENTITY(1,1) PRIMARY KEY,
	RegistrationDateTime DateTime NOT NULL
);

CREATE TABLE Purchases
(
	CustomerId INT NOT NULL,
	PurchaseDateTime DateTime NOT NULL,
	ProductName NVARCHAR (30) NOT NULL,
	FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId) ON DELETE CASCADE
);


INSERT Customers
VALUES 
('20180313 18:45:01'), --1 сметана
('20200124 16:15:01'), --2 сметана, молоко
('20200221 02:11:01'), --3 молоко +
('20200312 04:13:01'), --4 сметана
('20130305 19:33:01'), --5 сметана, молоко
('20200314 22:01:01'), --6 молоко +
('20200314 22:01:01')  --7 молоко месяц назад



INSERT INTO Purchases
VALUES
(1,'20200427 01:22:01','cream'),
(2,'20200427 18:15:01','cream'),
(2,'20200427 18:15:01','milk'),
(3,'20200426 13:10:01','milk'),
(4,'20200311 11:50:01','cream'),
(5,'20200126 12:20:01','cream'),
(5,'20200426 11:34:01','milk'),
(6,'20200425 17:14:01','milk'),
(7,'20200325 15:15:01','milk')
GO



-- 1 Получить список тех кто совершил покупку молока в течении недели (2,3,5,6)
-- 2 получить список тех кто свершил покупку сметнаны из тех кто купил молоко (2,5)
-- 3 отобразить список 1 кроме ткех кто есть в списке 2 (3,6)

SELECT * FROM  Purchases as p

-- 1 Получить список тех кто совершил покупку молока в течении недели (2,3,5,6)
SELECT * FROM  Purchases as p
		WHERE p.PurchaseDateTime >= DATEADD(day,-7, GETDATE()) AND p.ProductName ='milk' 

--2 получить список тех кто свершил покупку сметнаны из тех кто купил молоко (2,5)
SELECT * FROM  Purchases as p
		WHERE p.ProductName ='cream' 
								  AND p.CustomerId IN 
								  (SELECT p.CustomerId FROM  Purchases as p
								    WHERE p.PurchaseDateTime >= DATEADD(day,-7, GETDATE()) AND p.ProductName ='milk' ) 

--Мой вариант (3,6)
 SELECT * FROM Purchases as p
         WHERE p.CustomerId IN (SELECT p.CustomerId FROM  Purchases as p
							   WHERE p.PurchaseDateTime >= DATEADD(day,-7, GETDATE()) AND p.ProductName ='milk' )
    	   AND p.CustomerId NOT IN ( SELECT p.CustomerId FROM  Purchases as p
									  WHERE p.ProductName ='cream' 
								        AND p.CustomerId IN 
												  (SELECT p.CustomerId FROM  Purchases as p
													WHERE p.PurchaseDateTime >= DATEADD(day,-7, GETDATE()) AND p.ProductName ='milk' ))


--Вариант Лены (3,6) ЛУЧШИЙ
		SELECT DISTINCT * FROM  Purchases as p
		         WHERE p.PurchaseDateTime >= DATEADD(day,-7, GETDATE()) 
				   AND p.ProductName ='milk' 
				   AND NOT CustomerId = ANY 
										(  SELECT p1.CustomerId FROM  Purchases as p1
											WHERE p1.ProductName = 'cream')


---*********
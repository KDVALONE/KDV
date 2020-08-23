-- ================================================
----Хранимая пороцедура для IVANDB
---- ================================================
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
---- =============================================
---- Author:		<Author,,Name>
---- Create date: <Create Date,,>
---- Description:	<Description,,>
---- =============================================
CREATE PROCEDURE UpdateObject


		
		@val INT	
AS
BEGIN
	SET NOCOUNT ON;
    -- Insert statements for procedure here

	SELECT @val =(SELECT IDS FROM VALTODEL as d)
    
	SELECT * FROM @val




END
GO



--CREATE PROCEDURE AddProduct
--	@name NVARCHAR(20),
--	@manufacturer NVARCHAR(20),
--	@count INT,
--	@price MONEY
--AS
--INSERT INTO Products(ProductName, Manufacturer, ProductCount, Price) 
--VALUES(@name, @manufacturer, @count, @price)
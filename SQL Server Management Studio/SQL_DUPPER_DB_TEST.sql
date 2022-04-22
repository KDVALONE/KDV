 /*
 БД ДЛЯ Duppera, тест чтоб потренироваться обращаться к ХП.
 Dupper легковесная штука типа Entity FW
 */
 
 /*Создание БД и заполнение тестовыми занчениями */
 USE [master]
 /* DROP DATABASE [DUPPER_DB_TEST]*/

 CREATE DATABASE DUPPER_DB_TEST;
 GO
 USE [DUPPER_DB_TEST];
 GO

 
 CREATE TABLE Cheque
(
       cheque_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
   cheque_number nvarchar(50),
			summ money,
        discount money,
        articles nvarchar(max)
);



INSERT INTO Cheque (cheque_number,summ,discount,articles)
VALUES
('300',15,2,'some1;some1;some1'),
('400',25,12,'some2;some2;some2'),
('500',35,22,'some3;some3;some3'),
('600',45,32,'some4;some4;some4'),
('700',65,42,'some5;some5;some5'),
('800',75,52,'some6;some6;some6'),
('900',85,62,'some7;some7;some7'),
('1000',95,72,'some8;some8;some8'),
('1100',105,82,'some9;some9;some9')
GO


 

/*Хранимые процедуры */

/* Процедура возвращающая N последниз значений*/
GO
	CREATE PROCEDURE  dbo.get_cheques_pack ( @pack_size INTEGER )
				  AS
			   BEGIN
		/*Вообще косяк, так как cheque_number varchar то сортировка по нему не совсем корректна, был бы integer все было бы ок.
		но для нашей задачи сойдет
		 */
    	Select  TOP (@pack_size) *  From Cheque ORDER BY cheque_number 
	END;
GO
 


 /* Процедура помещающая новый чек в Таблицу*/
	CREATE PROCEDURE  dbo.save_cheques (  @cheque_id UNIQUEIDENTIFIER,
									  @cheque_number nvarchar(50),
										       @summ money,
										   @discount money,
										   @articles nvarchar(max) )
				  AS
			   BEGIN
					INSERT INTO Cheque (cheque_id, cheque_number, summ, discount, articles)
						 VALUES (@cheque_id, @cheque_number, @summ, @discount, @articles)
	END;
	GO

	 EXEC  dbo.get_cheques_pack @pack_size = 3;
  /*DROP PROCEDURE dbo.get_cheques_pack */


 /*!!!
 Тут есть нюанс @cheque_id является UNIQUEIDENTIFIER, и чтоб вот напрямую в него засовывать значения нужно передавать не varchar
  как у меня в параметре, а кстовать varchar к UNIQUEIDENTIFIER. Ниже код каста. 
  но вообще я не буду пока его пользовать.
 
  @str LIKE REPLICATE('[0-9A-F]',8)+REPLICATE('-'+REPLICATE('[0-9A-F]',4),4))+REPLICATE('[0-9A-F]',8)*/

  EXEC dbo.save_cheques @cheque_id = 'T8BDF04D-AAF8-4F12-A3A5-4FDBAAE7930K', 
					@cheque_number = '1200', 
							 @summ = 115, 
						 @discount = 92,
						 @articles = 'some10;some10;some10'
  /* DROP PROCEDURE dbo.save_cheques */

   Select * From Cheque order by summ desc -- для проверки

   Select * From Cheque	 -- для проверки
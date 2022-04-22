/*В базе данных MS SQL Server есть статьи и тэги. 
Одной статье может соответствовать много тэгов, а тэгу — много статей. 
Напишите SQL запрос для выбора всех пар «Тема статьи – тэг». 
Если у статьи нет тэгов, то её тема всё равно должна выводиться.*/

use master

CREATE DATABASE MINDBOX_TESTDB_CR_QR

CREATE TABLE TAG
(
	id INT NOT NULL ,
	tag NVARCHAR (30) NOT NULL,
	PRIMARY KEY (id)

);
CREATE TABLE LITER
(
	id INT NOT NULL ,
	liter NVARCHAR (30) NOT NULL,
	PRIMARY KEY (id)

);
CREATE TABLE LITER_TAG
(
	id INT NOT NULL ,
	liter_id INT NOT NULL ,
	tag_id INT NOT NULL 
	PRIMARY KEY (id)
);


INSERT TAG
VALUES 
(101,'TAG_1'),
(102,'TAG_2'),
(103,'TAG_3'), 
(104,'TAG_4') 


INSERT INTO LITER
VALUES
(201,'LIT_4'),
(202,'LIT_3'),
(203,'LIT_2'),
(204,'LIT_1')


INSERT INTO LITER_TAG
VALUES
(301,201,101 ),
(302,201,103 ),
(303,201,104 ),
(304,202,101 ),
(305,203,103 ),
(306,203,104 )
GO

ALTER TABLE LITER_TAG 
ADD CONSTRAINT tag_id_fk_constraint 
FOREIGN KEY (tag_id) REFERENCES TAG (id)
ON UPDATE CASCADE ON DELETE CASCADE;

ALTER TABLE LITER_TAG 
ADD CONSTRAINT lit_id_fk_constraint 
FOREIGN KEY (liter_id) REFERENCES LITER (id)
ON UPDATE CASCADE ON DELETE CASCADE;

GO

SELECT * FROM LITER_TAG

	  SELECT LITER.liter, TAG.tag 
      from LITER_TAG
      FULL join LITER on LITER.id=LITER_TAG.liter_id 
      LEFT join TAG on TAG.id=LITER_TAG.tag_id
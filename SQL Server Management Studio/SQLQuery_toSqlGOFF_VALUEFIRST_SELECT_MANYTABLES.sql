-- Запросы (Многотабличные) к БД BD_SQLGOFF_VALUEFIRST, из приложения А, SQL Complete Reference 3th. e. (2017) Глава7
USE BD_SQLGOFF_VALUEFIRST
GO

--Join - обьединение и получение информации из разных таблиц

--Вывести список всех служащих с городами и регионами, в которых они работают.
--(Обращение предок-потомок. ПК(предок,OFFICES.OFFICE) -- ВК(потомок,SALESREPS.REP_OFFICE))
	SELECT NAME,CITY, REGION
	  FROM SALESREPS,OFFICES
	 WHERE REP_OFFICE = OFFICE;
	GO

--Вывести список офисов с именами и должностями их руководителей
	SELECT CITY, NAME,TITLE
	  FROM OFFICES, SALESREPS
	 WHERE MGR = EMPL_NUM;
	GO
	-- тоже но с помощью JOIN
	SELECT CITY, NAME,TITLE
	  FROM OFFICES JOIN SALESREPS
	    ON MGR = EMPL_NUM;
	GO

-- Перечислить офисы, план продаж котрых превышает $600 000
	SELECT CITY, NAME, TITLE
	  FROM OFFICES JOIN SALESREPS
	    ON MGR = EMPL_NUM
	 WHERE TARGET > 600000.00;
	GO
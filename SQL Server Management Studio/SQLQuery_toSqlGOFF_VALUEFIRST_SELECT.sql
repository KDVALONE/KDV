-- Запросы к БД BD_SQLGOFF_VALUEFIRST, из приложения А, SQL Complete Reference 3th. e. (2017)
USE BD_SQLGOFF_VALUEFIRST
GO

SELECT CITY, TARGET, SALES 
FROM OFFICES;
GO

SELECT CITY,TARGET, SALES
FROM OFFICES
WHERE REGION = 'Eastern';
GO

SELECT CITY,TARGET, SALES
FROM OFFICES
WHERE REGION = 'Eastern' 
AND  SALES > TARGET
ORDER BY CITY;
GO

-- вывести список имен, офисов и дат всех служащих(salesreps)
SELECT NAME, REP_OFFICE, HIRE_DATE 
  FROM SALESREPS;
GO

SELECT NAME, QUOTA, SALES 
  FROM SALESREPS
 WHERE EMPL_NUM = 107;
GO

--AVG - Среднее значение
-- среднее значение фактических обьемов продаж по всем служащим
SELECT AVG(SALES) 
  FROM SALESREPS;
GO

 -- Список имен и дат приема на работу всех служащих, фактический обьем продаж которых превышает $500 000
 SELECT NAME, HIRE_DATE 
   FROM SALESREPS
  WHERE SALES > 500000.00;
 GO

  -- Выдать для каждого офиса список городов, регионов и сумм, на которые был перевыполнен/недовыполнен план по продажам.
  SELECT CITY, REGION, (SALES-TARGET)
    FROM OFFICES;
GO

 -- Константы
 -- выдать список обьемов продаж для каждого города.(Используя константы - с помощью них мы вводим в выводимый результат значение)
 SELECT CITY,'has sales of',SALES
   FROM OFFICES;
 GO

-- DISTINCT - отсортировать без повторений
-- выдать список идентификаторов всех менеджеров офиса (избежать повторений идентификаторов если менеджер работает в нескольких офисах)
SELECT DISTINCT MGR
  FROM OFFICES;
  GO
 
 SELECT NAME,EMPL_NUM, HIRE_DATE
   FROM  SALESREPS
  WHERE EMPL_NUM <> 107;
  -- WHERE EMPL_NUM <> 107; -- тоже что и EMPL_NUM != 107;
 GO

 --BETWEEN - значение между
 -- Найти все заказы, сделанные в последнем квартале 2007 года.
 SELECT ORDER_NUM, ORDER_DATE, MFR, PRODUCT, AMOUNT
   FROM ORDERS
  WHERE ORDER_DATE BETWEEN '2007-10-31' and '2007-12-31';
  GO

  -- IN - указать несколько зачений поиска, указать только те которые является членами данного множества
  -- NOT IN - указать несколько зачений поиска, указать только те которые не является членами данного множества
  -- Найти все заказы, сделанные служащими номер 107,109,101,103
  SELECT ORDER_NUM, REP, AMOUNT
    FROM ORDERS
   WHERE REP IN (107,109,101,103);
   --  WHERE REP NOT IN (107,109,101,103);
  GO

  --- Добавить запросы про LIKE, IS, ORDERBY, DESC, UNION, 

  -- LIKE - проверка на соответствие некому шаблону состоящей из строки содержащей подстановочные символы
  -- NOT LIKE - проверка на не соответствие некому шаблону
  -- % - подстановочный символ, поиск до пробела на проверку совпадения строки из нуля или более символов
  -- $ -символ пропуска, если нужно вывести значения столбца имеющих символ % в написании, то перед ним должен стоять знак $
  SELECT COMPANY, CREDIT_LIMIT
    FROM CUSTOMERS
   WHERE COMPANY LIKE 'Smith% Corp';
  
  -- _ - подстановочный символ, если не известен какой то символ, то на месте _ может стоять любой символ
  SELECT COMPANY, CREDIT_LIMIT
    FROM CUSTOMERS
   WHERE COMPANY LIKE 'J_P%';
  GO

   -- IS проверка на NULL, возваращает true, false, null. REP_OFFICE = NULL - так выдаст ошибку.С 'ничто' сравнивать нельзя.
   -- IS NOT проверка на не NULL, возваращает true, false, null.
   -- найти служащих за которым не были закреплены офисы. 
   SELECT NAME
     FROM SALESREPS
    WHERE REP_OFFICE IS NULL;
  GO

  -- OR - оператор используется для обьединения двух условий отбора, из которых либо одно, либо другое, либо оба должны быть верными
  -- AND - оператор И
  -- AND NOT - не соответствие обоим условиям.
  -- Вывести всех служащих у которых обьем продаж меньше планового или меньше $300 000.
  SELECT NAME,QUOTA, SALES
    FROM SALESREPS
   WHERE SALES < QUOTA
      OR SALES < '300000';
  GO

  -- Найти всех служащих которые:
  -- Работают в В Денвере, Нью-Йорке или Чикаго
  -- или не имеют менеджера и были приняты на работу после июня 2006
  -- или у которых продажи превысили плановый обьем но не превысили $600 000
  SELECT NAME, HIRE_DATE, QUOTA, SALES 
    FROM SALESREPS
   WHERE (REP_OFFICE IN (22,11,12))
      OR (MANAGER IS NULL AND HIRE_DATE >= '2006-07-01')
	  OR (SALES > QUOTA  AND NOT SALES > '600000');
  GO

  -- ORDER BY - сортировка запроса, по умолчанию по возрастанию (Верхняя строка наименьшее значение.)
  -- DESC - сортировка запроса, по убыванию (Верхняя строка наибольшее значение.)
  -- ASC -сортировка запроса, по возрастанию, но обычно не пишут, так как она и так по умолчанию по возрастанию.
  -- Вывести список офисов, отсортированных по фактическим обьемам продаж в порядке убывания
  SELECT CITY, REGION, SALES
    FROM OFFICES
	ORDER BY SALES DESC;
  GO

  -- UNION - обьединение запросов, выводит обьединенную таблицу из двух запросов, выводя таблицу UNION 
  -- по умолчанию(в отличии от SELECT где нужен DISTINCT) удаляет повторы.
  -- ORDER BY нельзя приминить после первого SELECT ноп можно после последнего.
  -- Вывести список всех товаров, цена которых превышает $2000, или которых было заказано более чем на $30 000 за один раз,
  -- список отсортировать по наименованию производителя и номеру товара.
  SELECT MFR_ID, PRODUCT_ID
    FROM PRODUCTS
   WHERE PRICE > '2000' 
   UNION
   SELECT DISTINCT MFR, PRODUCT
    FROM ORDERS
   WHERE AMOUNT > '30000'
ORDER BY 1,2;
  GO
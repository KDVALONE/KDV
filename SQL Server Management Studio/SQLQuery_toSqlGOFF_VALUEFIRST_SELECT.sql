-- ������� � �� BD_SQLGOFF_VALUEFIRST, �� ���������� �, SQL Complete Reference 3th. e. (2017)
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

-- ������� ������ ����, ������ � ��� ���� ��������(salesreps)
SELECT NAME, REP_OFFICE, HIRE_DATE 
  FROM SALESREPS;
GO

SELECT NAME, QUOTA, SALES 
  FROM SALESREPS
 WHERE EMPL_NUM = 107;
GO

--AVG - ������� ��������
-- ������� �������� ����������� ������� ������ �� ���� ��������
SELECT AVG(SALES) 
  FROM SALESREPS;
GO

 -- ������ ���� � ��� ������ �� ������ ���� ��������, ����������� ����� ������ ������� ��������� $500 000
 SELECT NAME, HIRE_DATE 
   FROM SALESREPS
  WHERE SALES > 500000.00;
 GO

  -- ������ ��� ������� ����� ������ �������, �������� � ����, �� ������� ��� ������������/������������ ���� �� ��������.
  SELECT CITY, REGION, (SALES-TARGET)
    FROM OFFICES;
GO

 -- ���������
 -- ������ ������ ������� ������ ��� ������� ������.(��������� ��������� - � ������� ��� �� ������ � ��������� ��������� ��������)
 SELECT CITY,'has sales of',SALES
   FROM OFFICES;
 GO

-- DISTINCT - ������������� ��� ����������
-- ������ ������ ��������������� ���� ���������� ����� (�������� ���������� ��������������� ���� �������� �������� � ���������� ������)
SELECT DISTINCT MGR
  FROM OFFICES;
  GO
 
 SELECT NAME,EMPL_NUM, HIRE_DATE
   FROM  SALESREPS
  WHERE EMPL_NUM <> 107;
  -- WHERE EMPL_NUM <> 107; -- ���� ��� � EMPL_NUM != 107;
 GO

 --BETWEEN - �������� �����
 -- ����� ��� ������, ��������� � ��������� �������� 2007 ����.
 SELECT ORDER_NUM, ORDER_DATE, MFR, PRODUCT, AMOUNT
   FROM ORDERS
  WHERE ORDER_DATE BETWEEN '2007-10-31' and '2007-12-31';
  GO

  -- IN - ������� ��������� ������� ������, ������� ������ �� ������� �������� ������� ������� ���������
  -- NOT IN - ������� ��������� ������� ������, ������� ������ �� ������� �� �������� ������� ������� ���������
  -- ����� ��� ������, ��������� ��������� ����� 107,109,101,103
  SELECT ORDER_NUM, REP, AMOUNT
    FROM ORDERS
   WHERE REP IN (107,109,101,103);
   --  WHERE REP NOT IN (107,109,101,103);
  GO

  --- �������� ������� ��� LIKE, IS, ORDERBY, DESC, UNION, 

  -- LIKE - �������� �� ������������ ������ ������� ��������� �� ������ ���������� �������������� �������
  -- NOT LIKE - �������� �� �� ������������ ������ �������
  -- % - �������������� ������, ����� �� ������� �� �������� ���������� ������ �� ���� ��� ����� ��������
  -- $ -������ ��������, ���� ����� ������� �������� ������� ������� ������ % � ���������, �� ����� ��� ������ ������ ���� $
  SELECT COMPANY, CREDIT_LIMIT
    FROM CUSTOMERS
   WHERE COMPANY LIKE 'Smith% Corp';
  
  -- _ - �������������� ������, ���� �� �������� ����� �� ������, �� �� ����� _ ����� ������ ����� ������
  SELECT COMPANY, CREDIT_LIMIT
    FROM CUSTOMERS
   WHERE COMPANY LIKE 'J_P%';
  GO

   -- IS �������� �� NULL, ����������� true, false, null. REP_OFFICE = NULL - ��� ������ ������.� '�����' ���������� ������.
   -- IS NOT �������� �� �� NULL, ����������� true, false, null.
   -- ����� �������� �� ������� �� ���� ���������� �����. 
   SELECT NAME
     FROM SALESREPS
    WHERE REP_OFFICE IS NULL;
  GO

  -- OR - �������� ������������ ��� ����������� ���� ������� ������, �� ������� ���� ����, ���� ������, ���� ��� ������ ���� �������
  -- AND - �������� �
  -- AND NOT - �� ������������ ����� ��������.
  -- ������� ���� �������� � ������� ����� ������ ������ ��������� ��� ������ $300 000.
  SELECT NAME,QUOTA, SALES
    FROM SALESREPS
   WHERE SALES < QUOTA
      OR SALES < '300000';
  GO

  -- ����� ���� �������� �������:
  -- �������� � � �������, ���-����� ��� ������
  -- ��� �� ����� ��������� � ���� ������� �� ������ ����� ���� 2006
  -- ��� � ������� ������� ��������� �������� ����� �� �� ��������� $600 000
  SELECT NAME, HIRE_DATE, QUOTA, SALES 
    FROM SALESREPS
   WHERE (REP_OFFICE IN (22,11,12))
      OR (MANAGER IS NULL AND HIRE_DATE >= '2006-07-01')
	  OR (SALES > QUOTA  AND NOT SALES > '600000');
  GO

  -- ORDER BY - ���������� �������, �� ��������� �� ����������� (������� ������ ���������� ��������.)
  -- DESC - ���������� �������, �� �������� (������� ������ ���������� ��������.)
  -- ASC -���������� �������, �� �����������, �� ������ �� �����, ��� ��� ��� � ��� �� ��������� �� �����������.
  -- ������� ������ ������, ��������������� �� ����������� ������� ������ � ������� ��������
  SELECT CITY, REGION, SALES
    FROM OFFICES
	ORDER BY SALES DESC;
  GO

  -- UNION - ����������� ��������, ������� ������������ ������� �� ���� ��������, ������ ������� UNION 
  -- �� ���������(� ������� �� SELECT ��� ����� DISTINCT) ������� �������.
  -- ORDER BY ������ ��������� ����� ������� SELECT ��� ����� ����� ����������.
  -- ������� ������ ���� �������, ���� ������� ��������� $2000, ��� ������� ���� �������� ����� ��� �� $30 000 �� ���� ���,
  -- ������ ������������� �� ������������ ������������� � ������ ������.
  SELECT MFR_ID, PRODUCT_ID
    FROM PRODUCTS
   WHERE PRICE > '2000' 
   UNION
   SELECT DISTINCT MFR, PRODUCT
    FROM ORDERS
   WHERE AMOUNT > '30000'
ORDER BY 1,2;
  GO
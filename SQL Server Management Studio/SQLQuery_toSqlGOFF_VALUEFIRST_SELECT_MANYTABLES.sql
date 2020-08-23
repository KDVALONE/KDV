-- ������� (��������������) � �� BD_SQLGOFF_VALUEFIRST, �� ���������� �, SQL Complete Reference 3th. e. (2017) �����7
USE BD_SQLGOFF_VALUEFIRST
GO

--Join - ����������� � ��������� ���������� �� ������ ������

--������� ������ ���� �������� � �������� � ���������, � ������� ��� ��������.
--(��������� ������-�������. ��(������,OFFICES.OFFICE) -- ��(�������,SALESREPS.REP_OFFICE))
	SELECT NAME,CITY, REGION
	  FROM SALESREPS,OFFICES
	 WHERE REP_OFFICE = OFFICE;
	GO

--������� ������ ������ � ������� � ����������� �� �������������
	SELECT CITY, NAME,TITLE
	  FROM OFFICES, SALESREPS
	 WHERE MGR = EMPL_NUM;
	GO
	-- ���� �� � ������� JOIN
	SELECT CITY, NAME,TITLE
	  FROM OFFICES JOIN SALESREPS
	    ON MGR = EMPL_NUM;
	GO

-- ����������� �����, ���� ������ ������ ��������� $600 000
	SELECT CITY, NAME, TITLE
	  FROM OFFICES JOIN SALESREPS
	    ON MGR = EMPL_NUM
	 WHERE TARGET > 600000.00;
	GO
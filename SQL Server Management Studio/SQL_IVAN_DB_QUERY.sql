---������� � IVAN_DB


use IVAN_DB

SELECT * FROM FULLTABLE
SELECT * FROM VALTODEL
SELECT * FROM VALTOSAVE
SELECT * FROM OBJCT

-- ������ ��������� ������� OBJECT
/*SELECT *INTO OBJECT_TEMP_OLD FROM OBJCT*/
/*DROP TABLE OBJECT_TEMP_OLD -- �������� */
SELECT * FROM OBJECT_TEMP_OLD

/*SELECT *INTO OBJECT_TEMP_CNG FROM OBJCT   */
/*DROP TABLE OBJECT_TEMP_CNG -- �������� */
SELECT * FROM OBJECT_TEMP_CNG


--/*������ ����������, �������*/
--	UPDATE o
--	SET Name  = Name + 'UPD'
--	FROM OBJECT_TEMP as o
--	WHERE o.Name = '������001'


    UPDATE o
	SET Name  = Name + 'UPD'
	FROM OBJECT_TEMP_CNG as o
	WHERE o.Name = '������001'

	/*���� ���� �����, ����� �������, ������ ��� ��������*/
	DROP TABLE OBJECT_TEMP_CNG
	SELECT *INTO OBJECT_TEMP_CNG FROM OBJCT

	SELECT * FROM OBJECT_TEMP_CNG

	SELECT * FROM VALTODEL

	/*������ ���������� ����������, �������*/
	--UPDATE o
 --   SET Name = Name + 'UPD'
 --   FROM OBJECT_TEMP_CNG as o,VALTODEL as d
 --   WHERE o.AccessGroupID IN (SELECT d.GROUPID FROM VALTODEL as d )

 	--- � ������, ���� �� �������� ���������
	UPDATE o
    SET o.AccessGroupID = d1.GROUPID, o.Name = '(UPD)' + o.Name
    FROM OBJECT_TEMP_CNG as o,(SELECT d.GROUPID FROM VALTODEL as d ) as d1
    WHERE o.AccessGroupID IN (SELECT d.GROUPID FROM VALTODEL as d )


 UPDATE o
    SET o.AccessGroupID = del.GROUPID, o.Name = '(UPD)' + o.Name
    FROM (SELECT GROUPID  FROM VALTODEL) as del,OBJECT_TEMP_CNG as o
    WHERE o.AccessGroupID IN (SELECT d.GROUPID FROM VALTODEL as d )




	--	UPDATE Table2
--	SET Model = t.[MODELS]
--	from  #cte_ModelsToSubstitude AS t
--	INNER JOIN Table2 as y ON y.Model 
--where t.tovar = v.tovar

--and t.id > v.id



--������, �� �� �����
--SELECT d.GROUPID as ID_OLD , s.GROUPID as ID_NEW
--FROM VALTODEL as d, VALTOSAVE as s
--WHERE d.IDS IN
--    (SELECT IDS
--     FROM VALTODEL) AND
--	 d.ENABLE IN (SELECT ENABLE 
--				  FROM VALTOSAVE);
--GO

/*
'Say?n Rabia Avc?,
55. Ya??n?z? kutlar, bu do?um g�n�n�zde sizlere 1.000
TL hediye �eki vermekten mutluluk duyar?z.
G�zel g�nlerde harcaman?z dile?iyle...'
*/
DECLARE @MONTH AS INT
DECLARE @DAY AS INT
SET @MONTH =DATEPART(MONTH,GETDATE())
SET @DAY =DATEPART(DAY,GETDATE())
DECLARE @NAME AS VARCHAR(100)
DECLARE @SURNAME AS VARCHAR(100)
DECLARE @NAMESURNAME AS VARCHAR(100)
DECLARE @BIRTHDATE AS DATE
DECLARE @AGE AS INT

SELECT TOP 1 @NAME=NAME_,@SURNAME=SURNAME,@BIRTHDATE=BIRTHDATE  
FROM LAB03
WHERE DATEPART(MONTH,BIRTHDATE)=@MONTH 
AND DATEPART(DAY,BIRTHDATE) =@DAY 
ORDER BY NEWID()

SET @NAMESURNAME=@NAME+' '+@SURNAME
SET @AGE=DATEDIFF(YEAR,@BIRTHDATE,GETDATE())

DECLARE @MSG AS VARCHAR(1000)
SET @MSG='Say?n '+@NAMESURNAME+',
'+CONVERT(VARCHAR,@AGE)+'. Ya??n?z? kutlar, bu do?um g�n�n�zde sizlere 1.000
TL hediye �eki vermekten mutluluk duyar?z.
G�zel g�nlerde harcaman?z dile?iyle...'

SELECT @NAME NAME_,@SURNAME SURNAME,@BIRTHDATE,@NAMESURNAME NAMESURNAME,@AGE AGE,@MSG MSG
PRINT @MSG 

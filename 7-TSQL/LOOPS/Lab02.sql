
--SELECT * FROM CUSTOMERS
DECLARE @NAME AS VARCHAR(100)
DECLARE @SURNAME AS VARCHAR(100)
DECLARE @NAMESURNAME AS VARCHAR(100)
DECLARE @GENDER AS VARCHAR(1)
DECLARE @BIRTHDATE DATE
DECLARE @CITY VARCHAR(100)
DECLARE @RAND AS INT

SELECT TOP 1 @NAME=NAME_,@GENDER=GENDER FROM NAMES ORDER BY NEWID()
SELECT TOP 1 @SURNAME=SURNAME FROM SURNAMES ORDER BY NEWID()
SET @NAMESURNAME=@NAME+' '+@SURNAME
SELECT TOP 1 @CITY=CITY FROM CITIES ORDER BY NEWID()

SET @RAND=RAND()*365*50
SET @BIRTHDATE=DATEADD(DAY,@RAND,'1950-01-01')

--SELECT @NAME NAME_,@SURNAME SURNAME,@GENDER GENDER,@NAMESURNAME NAMESURNAME,@CITY CITY,@BIRTHDATE BIRTHDATE 
INSERT INTO CUSTOMERS (NAME_,SURNAME,GENDER,NAMESURNAME,CITY,BIRTHDATE)
VALUES (@NAME,@SURNAME,@GENDER,@NAMESURNAME,@CITY,@BIRTHDATE)
GO 10000 
--SELECT * FROM CUSTOMERS 



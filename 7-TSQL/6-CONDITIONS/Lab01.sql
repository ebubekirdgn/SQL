DECLARE @CITY AS VARCHAR(100) 
DECLARE @MONTH AS INT=3
DECLARE @BEGDATE AS DATE 
DECLARE @ENDDATE AS DATE 

IF @CITY IS NULL 
	SET @CITY='%'

IF (@BEGDATE IS NULL AND @ENDDATE IS NULL)
BEGIN
	SET @BEGDATE =DATEFROMPARTS(2022,@MONTH,1)
	SET @ENDDATE=DATEADD(MONTH,1,@BEGDATE)
END
 
SELECT 
DATEPART(MONTH,DATE_) MONTH_,
CITY,SUM(TOTALPRICE) TOTALPRICE
FROM SALES 
WHERE CITY LIKE @CITY 
AND DATE_ BETWEEN @BEGDATE AND @ENDDATE

GROUP BY DATEPART(MONTH,DATE_),CITY
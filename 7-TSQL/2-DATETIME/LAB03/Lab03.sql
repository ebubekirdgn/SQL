SELECT 
ID,NAME_,SURNAME,BIRTHDATE,
DATEPART(YEAR,BIRTHDATE) YEAR_,TELNR1
FROM LAB03
WHERE 
TELNR1 LIKE '%'+DATENAME(YEAR,BIRTHDATE)+'%'

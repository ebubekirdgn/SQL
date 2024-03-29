CREATE VIEW VWLASTORDERS
AS
SELECT 
C.CITY SEHIR ,
LASTORDER.NAMESURNAME SONMUSTERI,
LASTORDER.DATE_ SONSIPARIS_TARIHI,
LASTORDER.TOTALPRICE TUTAR
FROM CITIES C
CROSS APPLY 
(SELECT TOP 1 U.NAMESURNAME,O.DATE_,O.TOTALPRICE FROM ORDERS O
JOIN USERS U ON U.ID=O.USERID 
JOIN ADDRESS A ON A.ID =O.ADDRESSID
WHERE A.CITYID =C.ID 
ORDER BY O.DATE_ DESC ) LASTORDER



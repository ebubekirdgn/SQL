SELECT SEHIR , SUM(TUTAR) FROM VWORDERS
WHERE BOLGE='KARADENÝZ'
GROUP BY SEHIR

SELECT *FROM VWORDERS
SELECT 
	DATEPART(HOUR,CreationDate) SAAT,
	COUNT(*) YORUMSAYISI
FROM LAB08
GROUP BY DATEPART(HOUR,CreationDate)
ORDER BY 1
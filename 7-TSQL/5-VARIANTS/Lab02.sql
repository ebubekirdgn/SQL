/*
Datetime türünde DT isimli bir de?i?ken tan?mlay?n?z.
Bu de?i?kene ‘2022-06-24 12:56:21’ de?erini atay?n?z.
Date türünde D isimli bir de?i?ken tan?mlay?n?z.
D de?i?kenine DT yi atay?n?z.
Time türünde T isimli bir de?i?ken tan?mlay?n?z.
T de?i?kenine DT yi atay?n?z.
Varchar türünde DSTR isimli bir de?i?ken tan?mlay?n?z.
DSTR de?i?kenine D’nin tarih k?sm?n? atay?n?z.
Varchar türünde TSTR isimli bir de?i?ken tan?mlay?n?z.
TSTR de?i?kenine T’nin saat k?sm?n? atay?n?z.
Olu?turulan tüm de?i?kenleri Select ile çekiniz.
*/

DECLARE @DT AS DATETIME
DECLARE @D AS DATE
DECLARE @T AS TIME
DECLARE @DSTR AS VARCHAR(30)
DECLARE @TSTR AS VARCHAR(30)

SET @DT='2022-06-24 12:56:21'
SET @D=@DT 
SET @T=@DT 
SET @DSTR=CONVERT(VARCHAR,@DT,104) 
SET @TSTR=CONVERT(VARCHAR,@DT,108) 

SELECT @DT DT ,@D D,@T T,@DSTR DSTR ,@TSTR TSTR
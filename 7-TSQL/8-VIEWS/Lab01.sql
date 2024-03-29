ALTER VIEW VWORDERS 
AS
SELECT 
 O.ID ORDERID,O.DATE_ TARIH , 
 CASE 
	WHEN MONTH(O.DATE_) =1 THEN '01.Ock'
	WHEN MONTH(O.DATE_) =2 THEN '02.�bt'
	WHEN MONTH(O.DATE_) =3 THEN '03.Mart'
	WHEN MONTH(O.DATE_) =4 THEN '04.Nis'
	WHEN MONTH(O.DATE_) =5 THEN '05.May'
	WHEN MONTH(O.DATE_) =6 THEN '06.Haz'
	WHEN MONTH(O.DATE_) =7 THEN '07.Tem'
	WHEN MONTH(O.DATE_) =8 THEN '08.Agu'
	WHEN MONTH(O.DATE_) =9 THEN '09.Eyl'
	WHEN MONTH(O.DATE_) =10 THEN '10.Eki'
	WHEN MONTH(O.DATE_) =11 THEN '11.Kas'
	WHEN MONTH(O.DATE_) =12 THEN '12.Ara'
	END AS AY,

 U.USERNAME_ KULLANICI,U.NAMESURNAME ADSOYAD , U.GENDER CINSIYET,U.BIRTHDATE DOGUMTARIHI,
 C.REGION BOLGE,C.CITY SEHIR,T.TOWN ILCE,D.DISTRICT SEMT,A.ADDRESSTEXT ACIKADRES,
 I.ITEMCODE URUNKODU,I.ITEMNAME URUNADI, I.BRAND MARKA,I.CATEGORY1 KATEGORI1,I.CATEGORY2 KATEGORI2,I.CATEGORY3 KATEGORI3,
 I.UNITPRICE URUNBIRIMFIYATI,OD.AMOUNT MIKTAR ,OD.UNITPRICE BIRIMFIYAT , OD.LINETOTAL TUTAR
FROM ORDERS O 
JOIN ORDERDETAILS OD ON OD.ORDERID = O.ID
JOIN ITEMS I ON I.ID = OD.ORDERID
JOIN USERS U ON U.ID = O.USERID
JOIN ADDRESS A ON A.ID = O.ADDRESSID
JOIN CITIES C ON C.ID = A.CITYID
JOIN TOWNS T ON T.ID = A.TOWNID
JOIN DISTRICTS D ON D.ID =A.DISTRICTID
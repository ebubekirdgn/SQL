

![alt text](https://github.com/ebubekirdgn/SQL/blob/main/Northwind-database-structure.png?raw=true)


-- SELECT ANSII

* Alias Kullanilarak istenilen alanlarin cekilmesi <br>
    ``` 
    select ContactName Adi, CompanyName SirketAdi,City Sehir  from Customers
* Alias Olmadan<br>
    ```
    select ContactName,CompanyName,City  from Customers
* Filtreleme Komutu<br>
   ```
     Select * from Customers where City = 'London'
* case insensitive yani buyuk kucuk harf duyarsız her turlu calisir.<br>
   ``` 
     sEleCt * from Products where CategoryID = 1 or CategoryID = 3
     sEleCt * from Products where CategoryID = 1 and  UnitPrice >= 30
* Butun urunleri ProductName'e gore siralama a -> z ye dogru (artan sekilde sirala demek -> asc) <br>
  ```
     Select * from Products order by ProductName  
* Once CategoryId ye gore sonra ProductName gore siralama<br>
  ``` 
    Select * from Products order by CategoryID, ProductName 
* Azalan sekilde siralama -> descending.z -> a diye sıralar.En pahali urunden ucuza dogru sıralar.<br>
  ``` Select * from Products order by UnitPrice desc 
      Select * from Products  where  CategoryID=1 order by UnitPrice desc
* Products tablosunda kac adet veri var onu bulmak icin <br>
  ``` 
     Select count(*) from Products 
* Products tablosunda CategoryId'si 2 olan kac adet urun var<br>
   ``` 
     Select count(*) from Products where CategoryID = 2 
* Hangi kategoride kac adet urun var ? Not : group by da yildiz kullanılmaz.<br>
   ``` 
     Select CategoryID,count(*) KategoriyeAitVeriSayisi from  Products group by CategoryID
* Kategori icinde 10 tane urunden az olan urunlerin sayisini verme<br>
   ```
   Select CategoryID,count(*) KategoriyeAitVeriSayisi from Products where UnitPrice>20 group by CategoryID  having count(*) <10
* Products tablosundan CategoryId'ye ait bilgilerinde Kategori tablosundan cekilip tek tabloda gosterilmesi<br>
   ```
   Select * from Products inner join Categories on Products.CategoryID = Categories.CategoryID
* Products tablosundan CategoryId'ye ait Kategori ismini ve Product tablosundaki belirli alanlarin getirilmesi<br>
   ```
  Select Products.ProductID,Products.ProductName,Products.UnitPrice, Categories.CategoryName from Products inner join Categories on Products.CategoryID = Categories.CategoryID 
> C#'ta bu ozellige DTO(Data Transformation Object) denmektedir.Yani istenilen alanlarin cekilmesi<br>
> Innerjoin = Sadece iki tabloda eslesen dataları cekmemizi saglar.<br>  
* Solda (Products) olup , sagda (Order Details) olmayanlari getir.<br>
   ```
   Select * from Products p left join [Order Details] od on p.ProductId = od.ProductID
* Sadece sana ozel indirim yapılmak istenip boyle olan kisileri bulmak icin (Siparisi olmayan kullanıcılar gibi)<br>
   ```
    Select * from Customers c left join Orders o  on c.CustomerID = o.CustomerID where o.CustomerID is null

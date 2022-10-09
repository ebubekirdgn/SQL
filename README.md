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

* Products tablosunda CategoryId'si 2 olan kac adet urun var <br>
 ```
     Select count(*) from Products where CategoryID = 2 
* Hangi kategoride kac adet urun var ?

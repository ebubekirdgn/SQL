-- SELECT ANSII

* Alias Kullanilarak istenilen alanlarin cekilmesi <br>
    ``` select ContactName Adi, CompanyName SirketAdi,City Sehir  from Customers```

* Alias Olmadan<br>
    ```select ContactName,CompanyName,City  from Customers```

* Filtreleme Komutu<br>
   ```Select * from Customers where City = 'London' ```
   
* case insensitive yani buyuk kucuk harf duyarsız her turlu calisir.<br>
   ```
   sEleCt * from Products where CategoryID = 1 or CategoryID = 3
   sEleCt * from Products where CategoryID = 1 and  UnitPrice >= 30
   
   ```

-- SELECT ANSII

* Alias Kullanilarak istenilen alanlarin cekilmesi <br>
    ``` select ContactName Adi, CompanyName SirketAdi,City Sehir  from Customers```

* 2 Alias Olmadan<br>
    ```select ContactName,CompanyName,City  from Customers```

* 3 Filtreleme Komutu<br>
   ```Select * from Customers where City = 'London' ```
   
* case insensitive yani buyuk kucuk harf duyarsız her turlu calisir.<br>
   ```sEleCt * from Products where CategoryID = 1 or CategoryID = 3```

-- SELECT ANSII

-- 1 Alias Kullanilarak istenilen alanlarin cekilmesi
    ``` select ContactName Adi, CompanyName SirketAdi,City Sehir  from Customers```

-- 2 Alias Olmadan
    ```select ContactName,CompanyName,City  from Customers```

-- 3 Filtreleme Komutu
   ```Select * from Customers where City = 'London' ```
   
-- case insensitive yani buyuk kucuk harf duyarsız her turlu calisir.
   ```sEleCt * from Products where CategoryID = 1 or CategoryID = 3```

USE AdventureWorks
GO
SELECT Person.StateProvince.Name AS Stan, Person.Address.City AS Miasto, COUNT(Person.StateProvince.Name) AS "ilosc" FROM Purchasing.Vendor 
JOIN Purchasing.VendorAddress ON Purchasing.Vendor.VendorID = Purchasing.VendorAddress.VendorID
JOIN Person.Address ON Purchasing.VendorAddress.AddressID = Person.Address.AddressID
JOIN Person.StateProvince ON Person.Address.StateProvinceID = Person.StateProvince.StateProvinceID
GROUP BY GROUPING SETS(
(Person.StateProvince.Name),
    (Person.StateProvince.Name, Person.Address.City)
)
ORDER BY Stan;
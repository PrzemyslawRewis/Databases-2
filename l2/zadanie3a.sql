USE AdventureWorks
GO
SELECT
    Person.StateProvince.Name AS Stan,
CASE
    WHEN Person.Address.City IS NULL THEN '404'
    ELSE Person.Address.City
END AS Miasto,
CASE
    WHEN COUNT(Person.StateProvince.Name) > 5 THEN 'duzo dostawcow'
    WHEN COUNT(Person.StateProvince.Name) = 5 THEN 'normalna ilosc'
    WHEN COUNT(Person.StateProvince.Name) < 5 THEN 'za malo dostawcow'
END AS "ilosc"
FROM Purchasing.Vendor 
JOIN Purchasing.VendorAddress ON Purchasing.Vendor.VendorID = Purchasing.VendorAddress.VendorID
JOIN Person.Address ON Purchasing.VendorAddress.AddressID = Person.Address.AddressID
JOIN Person.StateProvince  ON Person.Address.StateProvinceID = Person.StateProvince.StateProvinceID
GROUP BY GROUPING SETS(
(Person.StateProvince.Name),
    (Person.StateProvince.Name, Person.Address.City)
)
ORDER BY Stan;
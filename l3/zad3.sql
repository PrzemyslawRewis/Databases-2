USE AdventureWorks2008;
GO
IF OBJECT_ID('dbo.z3') IS NOT NULL 
    DROP FUNCTION dbo.z3;
GO

CREATE FUNCTION dbo.z3(@nazwisko AS nchar(255))
RETURNS TABLE AS
RETURN
	SELECT Sales.Customer.CustomerID, Sales.Customer.PersonID, Person.Person.BusinessEntityID
	FROM Sales.Customer 
	JOIN Sales.SalesOrderHeader ON Sales.SalesOrderHeader.CustomerID = Sales.Customer.CustomerID
	JOIN Person.Person ON Person.Person.BusinessEntityID = Sales.Customer.PersonID
	WHERE Person.Person.LastName=@nazwisko;
GO
SELECT * FROM dbo.z3('Adams');

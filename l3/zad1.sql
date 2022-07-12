USE AdventureWorks2008;
GO
IF OBJECT_ID('dbo.z1') IS NOT NULL
	DROP FUNCTION dbo.z1;
GO

CREATE FUNCTION dbo.z1(@ID INT)
RETURNS nchar(255)
WITH RETURNS NULL ON NULL INPUT AS
BEGIN
RETURN(
	SELECT
		Person.Person.LastName + ';' +
		Person.Person.FirstName + ';' +
		Person.EmailAddress.EmailAddress + ';' +
		Person.Address.AddressLine1
	FROM Person.Person 
	JOIN Person.EmailAddress ON Person.EmailAddress.BusinessEntityID = Person.Person.BusinessEntityID
	JOIN Person.BusinessEntityAddress ON Person.BusinessEntityAddress.BusinessEntityID = Person.Person.BusinessEntityID
	JOIN Person.BusinessEntity ON Person.BusinessEntity.BusinessEntityID = Person.Person.BusinessEntityID
	JOIN Person.Address ON Person.Address.AddressID = Person.BusinessEntityAddress.AddressID
	WHERE Person.BusinessEntity.BusinessEntityID = @ID
)
END
GO

SELECT dbo.z1(13);
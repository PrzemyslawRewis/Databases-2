USE AdventureWorks2008;
GO
IF OBJECT_ID('dbo.z2') IS NOT NULL
	DROP FUNCTION dbo.z2;
GO

CREATE FUNCTION dbo.z2(@min INT, @max INT)
RETURNS @wynik TABLE
(
	imie NCHAR(60),
	nazwisko NCHAR(60),
	mail NCHAR(60),
	adres NCHAR(60)
)
AS
BEGIN
	DECLARE @pomocnicza TABLE
	(
		imie NCHAR(60),
		nazwisko NCHAR(60),
		mail NCHAR(60),
		adres NCHAR(60),
		rn INT
	)
	INSERT INTO @pomocnicza(imie, nazwisko, mail, adres, rn)
	SELECT wp.FirstName, wp.LastName, wp.EmailAddress, wpp.AddressLine1, Row_Number() OVER (ORDER BY wp.LastName,wp.FirstName,wpp.AddressLine1) AS rn 
	FROM (SELECT Person.Person.BusinessEntityID, FirstName, LastName, EmailAddress FROM Person.Person, Person.EmailAddress WHERE Person.Person.BusinessEntityID = Person.EmailAddress.BusinessEntityID) AS wp,
	(SELECT Person.BusinessEntityAddress.BusinessEntityID, Person.Address.AddressLine1 FROM Person.Address INNER JOIN Person.BusinessEntityAddress ON Person.Address.AddressID = Person.BusinessEntityAddress.AddressID) As wpp 
	WHERE wp.BusinessEntityID = wpp.BusinessEntityID
	ORDER BY wp.LastName, wp.FirstName,wpp.AddressLine1;

	INSERT INTO @wynik(imie, nazwisko, mail, adres)
	SELECT imie, nazwisko, adres, mail FROM @pomocnicza WHERE rn BETWEEN @min AND @max;
RETURN
END;

GO
SELECT * FROM dbo.z2(50, 70);
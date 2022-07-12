USE AdventureWorks;

GO
DROP PROCEDURE zad3;

GO
CREATE PROCEDURE zad3(@text varchar(max))
AS
SELECT EmailAddress FROM HumanResources.Employee
	JOIN Person.Contact ON HumanResources.Employee.ContactID = Person.Contact.ContactID
	WHERE EmailAddress LIKE '%' + @text + '%';

GO
EXEC zad3 @text ='russel';
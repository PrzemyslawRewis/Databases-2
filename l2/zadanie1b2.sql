USE AdventureWorks
GO
WITH cte AS
(
      SELECT Row_Number() OVER (ORDER BY LastName)
      AS RowNumber, ContactID, FirstName, LastName
      FROM Person.Contact
)
SELECT * from cte WHERE (RowNumber > 51) AND (RowNumber < 100);
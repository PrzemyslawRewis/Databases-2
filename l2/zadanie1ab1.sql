-- a) operator ten zwroci wyniki, których RowNumber jest > 51 i < 100
-- ,ale zeby on zadzialal poprawnie trzeba skorzystac z CTE lub wewnetrznych 
-- i zewnetrznych zapytan
-- b) 
USE AdventureWorks
GO
IF OBJECT_ID('TEMPORARY') IS NOT NULL
DROP TABLE TEMPORARY;
GO
CREATE TABLE TEMPORARY (
    RowNumber int,
    ContactID int,
    FirstName nvarchar(50),
    LastName nvarchar(50)
);
INSERT INTO TEMPORARY SELECT Row_Number() OVER (ORDER BY LastName) AS
RowNumber, ContactID, FirstName, LastName
FROM Person.Contact ORDER BY RowNumber
SELECT * from TEMPORARY WHERE (RowNumber > 51) AND (RowNumber < 100);
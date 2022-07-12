USE AdventureWorks;
GO

IF OBJECT_ID('dbo.l4z3') IS NOT NULL
    DROP PROC dbo.l4z3;
GO

CREATE PROC dbo.l4z3
@AdresID AS sysname = NULL
AS
DECLARE @err AS NVARCHAR(250);
IF @AdresID IS NULL
BEGIN
    SET @err = 'ERROR: Parametr @AdresID nie moze byc pusty!';
    RAISERROR(@err, 13, 1);
    RETURN;
END

IF @AdresID < 1
BEGIN
    SET @err = 'ERROR: Parametr @AdresID nie moze byc ujemny!';
    RAISERROR(@err, 13, 1);
    RETURN;
END

SELECT * FROM Person.Address 
WHERE Person.Address.AddressID  = @AdresID;
GO


EXEC dbo.l4z3 @AdresID = -20;
USE AdventureWorks;
GO

IF OBJECT_ID('dbo.l4z1') IS NOT NULL
    DROP PROC dbo.l4z1;
GO

CREATE PROC dbo.l4z1
AS BEGIN
	DECLARE @id int, @godziny int
	DECLARE c CURSOR FOR
	SELECT	EmployeeID, SickLeaveHours FROM HumanResources.Employee WHERE EmployeeID BETWEEN 27 AND 96 ;
	OPEN c
		FETCH NEXT FROM c INTO @id, @godziny;
		WHILE @@FETCH_STATUS = 0
		BEGIN
			print 'Pracownik o numerze identyfikacyjnym:' + cast(@id as varchar) + ' byl przez ' + cast(@godziny as varchar) + ' godzin na zwolnieniu lekarskim.';
			FETCH NEXT FROM c INTO @id, @godziny;
		END
	CLOSE c
	DEALLOCATE c
END

GO
EXECUTE dbo.l4z1;
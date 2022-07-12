IF OBJECT_ID('dbo.l4z2') IS NOT NULL
	DROP TABLE dbo.l4z2;
GO

CREATE TABLE dbo.l4z2 (
	ID INT,
	czas datetime,
);
GO

IF OBJECT_ID('Purchasing.Wyzwalacz', 'TR') IS NOT NULL
	DROP TRIGGER Purchasing.Wyzwalacz;
GO

CREATE TRIGGER Purchasing.Wyzwalacz ON Purchasing.Vendor
	AFTER INSERT, UPDATE
	AS
	BEGIN
		INSERT INTO dbo.l4z2 VALUES((SELECT VendorID FROM inserted), CURRENT_TIMESTAMP)
	END
GO

INSERT INTO Purchasing.Vendor VALUES ('Proba1', 'Proba', 1, 1, 1, NULL, CURRENT_TIMESTAMP);
UPDATE Purchasing.Vendor SET Name = 'Proba1' WHERE AccountNumber = 'Proba1';
UPDATE Purchasing.Vendor SET Name = 'Proba2' WHERE AccountNumber = 'Proba1';
SELECT * FROM dbo.l4z2;
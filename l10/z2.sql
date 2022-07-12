use testCLR;
GO

CREATE TABLE produkty (
product_id INT  PRIMARY KEY,
product_name VARCHAR(50),
);


GO
CREATE TABLE zamowienia (
zamowienie_id INT PRIMARY KEY,
klient_name VARCHAR(50),
miasto VARCHAR(50),
);


GO
CREATE TABLE produkty_zamowienia (
product_id INT FOREIGN KEY REFERENCES produkty (product_id),
zamowienie_id INT FOREIGN KEY REFERENCES zamowienia (zamowienie_id),
);

EXEC dbo.z2l10;

SELECT * FROM produkty;
SELECT * FROM zamowienia;
SELECT * FROM produkty_zamowienia;
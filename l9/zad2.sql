use testCLR;

CREATE TABLE nums (
	num int
);
INSERT INTO nums VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9);
SELECT * FROM nums;
SELECT dbo.l9z2(num) as 'Podzielne przez 3' from nums;
DROP TABLE nums;
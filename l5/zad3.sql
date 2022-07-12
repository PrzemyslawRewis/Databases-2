USE AdventureWorks;
GO

EXEC sp_addrolemember @rolename=db_datawriter, @membername=[MSSQLSERVER\grupa1];
EXEC sp_addrolemember @rolename=db_datawriter, @membername=[MSSQLSERVER\grupa2];

EXEC sp_addrolemember @rolename=sysadmin, @membername=[MSSQLSERVER\tester3];
EXEC sp_addrolemember @rolename=db_datareader, @membername=[MSSQLSERVER\tester2];
EXEC sp_addrolemember @rolename=db_datareader, @membername=[MSSQLSERVER\tester4];

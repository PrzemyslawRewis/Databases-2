IF EXISTS(SELECT * FROM sys.databases WHERE name='Lab6db')
DROP DATABASE Lab6db;

CREATE DATABASE Lab6db;

USE Lab6db;
GO

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'Lab6user')
DROP LOGIN [Lab6user]

IF  EXISTS (SELECT * FROM sys.database_principals WHERE name = N'Lab6user')
DROP USER [Lab6user]

CREATE LOGIN [Lab6user] WITH PASSWORD=N'Passw0rd',
DEFAULT_DATABASE=[Lab6db], DEFAULT_LANGUAGE=[us_english]
GO
ALTER LOGIN [Lab6user] DISABLE

CREATE USER [Lab6user] FOR LOGIN [Lab6user]
EXEC sp_addrolemember @rolename=db_owner, @membername=[Lab6user];

-- Sprawdzamy jacy uzytkownicy sa db_ownerami
SELECT user_name(member_principal_id)
FROM   sys.database_role_members
WHERE  user_name(role_principal_id) = 'db_owner'

--EXEC sp_revokelogin 'MSSQLSERVER\grupa3';
--CREATE LOGIN [MSSQLSERVER\grupa3] FROM WINDOWS WITH DEFAULT_DATABASE=[master];

EXEC sp_addsrvrolemember @loginame=[MSSQLSERVER\grupa3], @rolename=dbcreator;
EXEC sp_addsrvrolemember @loginame=[MSSQLSERVER\grupa3], @rolename=serveradmin;

--SELECT * FROM sys.server_role_members
--SELECT * FROM sys.server_principals
--SELECT * FROM sys.server_principals
--JOIN sys.server_role_members ON principal_id = member_principal_id
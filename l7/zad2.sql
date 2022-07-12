USE testCLR

GO
CREATE ASSEMBLY [Lab7.zad2] FROM 'c:\Users\Administrator\Desktop\zadanie6\zad2.dll';

GO
CREATE FUNCTION [dbo].[zad2](@login NVARCHAR(max), @server NVARCHAR(max), @system NVARCHAR(max))
RETURNS NVARCHAR(max)
AS
EXTERNAL NAME
[Lab7.zad2].[Lab7].[zad2];

GO
SELECT hello=[dbo].[zad2](CURRENT_USER, @@SERVERNAME, @@VERSION);
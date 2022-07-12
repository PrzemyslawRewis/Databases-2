USE testCLR

GO
CREATE ASSEMBLY [Lab7.zad1] FROM 'c:\Users\Administrator\Desktop\zadanie6\zad1.dll';

GO
CREATE FUNCTION [dbo].[zad1]()
RETURNS [datetime]
AS
EXTERNAL NAME
[Lab7.zad1].[LabCLR].[zad1];

GO
SELECT SqlCLRSystemTime=[dbo].[zad1]();
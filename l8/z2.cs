using System;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data.SqlTypes;

public partial class UserDefinedFunctions
{
    [Microsoft.SqlServer.Server.SqlFunction]
    public static SqlString l8z2(SqlString f)
    {
        return new SqlString(DateTime.Now.ToString(f.ToString()));
    }
};
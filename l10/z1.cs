using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Text;

public partial class Triggers
{
    [Microsoft.SqlServer.Server.SqlTrigger (Name="trigger", Target="test1", Event="FOR INSERT")]
    public static void trigger()
    {
        using (SqlConnection connection = new SqlConnection("context connection=true"))
        {
            connection.Open();
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Eventlog (username, input) VALUES(USER, (SELECT CAST(num as VARCHAR(27)) FROM INSERTED))");
            SqlCommand c = new SqlCommand(sql.ToString(), connection);
            c.ExecuteNonQuery();
        }
    }
}
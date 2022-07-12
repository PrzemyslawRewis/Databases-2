using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Transactions;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void z2l10()
    {
        TransactionScope oTran = new TransactionScope();
        using (SqlConnection oConn = new SqlConnection ("context connection=true;"))
        {
            try
            {
                oConn.Open();
                SqlCommand oCmd =
                new SqlCommand("INSERT produkty VALUES (1, 'Sok')", oConn);
                oCmd.ExecuteNonQuery();
                oCmd.CommandText = "INSERT INTO zamowienia VALUES (1, 'Arek','Warszawa')";
                oCmd.ExecuteNonQuery();
                oCmd.CommandText = "INSERT INTO produkty_zamowienia VALUES (1, 1)";
                oCmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                SqlContext.Pipe.Send(ex.Message.ToString());
            }
            finally
            {
                oTran.Complete();
                oConn.Close();
            }
        }
        oTran.Dispose();
    }
};
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes; 
using Microsoft.SqlServer.Server; 
using System.Transactions;
namespace BankDistributedTransaction 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            bankTransaction(1000, "Alice", "John"); 
        }
        public static void bankTransaction(decimal val, string cust1, string cust2) 
        {
            int returnValue = 0;
            using (TransactionScope oTran = new TransactionScope()) 
            {
                using (SqlConnection oConn =
                new SqlConnection(@"Data Source=MSSQLSERVER024;Initial Catalog=AdventureWorks2008;User Id=lab13;Password=Passw0rd;"))
                {
                    try
                    {
                        oConn.Open();
                        SqlCommand update = new SqlCommand("update dbo.Konta set value = value +@value where name = @name", oConn);
                        update.Parameters.Add("@value", System.Data.SqlDbType.Money); 
                        update.Parameters.Add("@name", System.Data.SqlDbType.NVarChar); 
                        update.Parameters["@value"].Value = val; 
                        update.Parameters["@name"].Value = cust1;
                        returnValue = update.ExecuteNonQuery(); 
                        if (returnValue < 1) throw new Exception();
                        using (SqlConnection remConn = new SqlConnection(@"Data Source=MSSQLSERVER029;Initial Catalog=AdventureWorks2008;User Id=lab13;Password=Passw0rd;")) 
                        {
                            returnValue = 0; 
                            remConn.Open();
                            SqlCommand updateRemote = new SqlCommand("update dbo.Konta set value = value - @value where name = @name", remConn);
                            updateRemote.Parameters.Add("@value", System.Data.SqlDbType.Money);
                            updateRemote.Parameters.Add("@name", System.Data.SqlDbType.NVarChar); 
                            updateRemote.Parameters["@value"].Value = val; updateRemote.Parameters["@name"].Value = cust2;
                            returnValue = updateRemote.ExecuteNonQuery(); 
                            if (returnValue < 1) throw new Exception();
                            oTran.Complete();
                        } 
                    }
                    catch (SqlException exception) 
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (Exception exception) 
                    {
                        Console.WriteLine(exception.Message); 
                    }
            }
            }
            if (returnValue > 0)
            {
            Console.WriteLine("transaction complete");
            } 
            else 
            {
            Console.WriteLine("transaction rollback"); 
            }
            Console.ReadKey(); 
        }
    }
}
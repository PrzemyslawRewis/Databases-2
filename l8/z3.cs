using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

public partial class l8z3
{
    private class DataResult
    {
        public SqlInt32 ID;
        public SqlString Adres;
        public DataResult(SqlInt32 ID, SqlString Adres){
            this.ID = ID;
            this.Adres = Adres;
        }
    }
    [Microsoft.SqlServer.Server.SqlFunction
    (
        Name = "l8z3",
        DataAccess = DataAccessKind.Read,
        FillRowMethodName = "FillRowTable",
        TableDefinition = "EmployeeID int, AddressLine1 nvarchar(30)"
    )]
    public static IEnumerable zad3(SqlString ciag)
    {
        ArrayList x = new ArrayList();
        SqlConnection c = new SqlConnection("context connection=true");
        c.Open();
        SqlCommand cmdd = new SqlCommand(
            @"SELECT AdventureWorks.HumanResources.Employee.EmployeeID, AdventureWorks.Person.Address.AddressLine1
                FROM AdventureWorks.HumanResources.Employee 
	            JOIN AdventureWorks.HumanResources.EmployeeAddress ON AdventureWorks.HumanResources.Employee.EmployeeID=AdventureWorks.HumanResources.EmployeeAddress.EmployeeID
	            JOIN AdventureWorks.Person.Address ON AdventureWorks.HumanResources.EmployeeAddress.AddressID=AdventureWorks.Person.Address.AddressID
            ;",c
        );
        SqlDataReader R = cmdd.ExecuteReader();
        while (R.Read())
        {
            if (R["AddressLine1"].ToString().Contains(ciag.ToString()))
            {
                x.Add(new DataResult(R.GetSqlInt32(0), R.GetSqlString(1)));
            }
                
        }
        return x;
    }

    public static void FillRowTable(object dataResultObj, out SqlInt32 ID, out SqlString AddressLine1)
    {
        DataResult dataResult = (DataResult)dataResultObj;
        ID = dataResult.ID;
        AddressLine1 = dataResult.Adres;
    }
}
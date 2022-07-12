using System;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Data.SqlTypes;


public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void l8z1(SqlString ciag)
    {
        SqlConnection c = new SqlConnection("context connection=true");
        c.Open();
        SqlCommand cmdd = new SqlCommand
        (
            @"SELECT HumanResources.Employee.EmployeeID, Person.Address.AddressLine1
                FROM HumanResources.Employee 
	            JOIN HumanResources.EmployeeAddress ON HumanResources.Employee.EmployeeID = HumanResources.EmployeeAddress.EmployeeID
	            JOIN Person.Address ON HumanResources.EmployeeAddress.AddressID = Person.Address.AddressID
            ;",c
        );
        SqlDataReader R = cmdd.ExecuteReader();
        while (R.Read())
        {
            if (R["AddressLine1"].ToString().Contains(ciag.ToString()))
            {
                SqlContext.Pipe.Send(R["EmployeeID"].ToString() + " " + R["AddressLine1"].ToString());
            }
        }
    }
};
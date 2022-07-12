using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.IO;
namespace Lab06.Examples
{
    class Lab06Last
    {   
        static void Main(string[] args)
        {
            string sqlconnection = @"DATA SOURCE=MSSQLServer;" +
            "INITIAL CATALOG=Lab6db; INTEGRATED SECURITY=SSPI;";
            SqlConnection connection = new SqlConnection(sqlconnection);
            try
            {
                connection.Open();
                //a)
                string create_databases_query = "EXEC rob_taby";
                SqlCommand command = new SqlCommand(create_databases_query, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Tabele zostaly utworzone pomyslnie\n");

                //b)
                string insertstudentp="INSERT INTO student (id, fname, lname) VALUES (";
                string insertstudent=@"";
                using(var reader = new StreamReader(@"studenci.csv"))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        insertstudent+=insertstudentp+values[0]+", '"+values[1]+"', '"+values[2]+"');\n";
                    }
                }
                command = new SqlCommand(insertstudent, connection);
                command.ExecuteNonQuery();
                string insertwykladowcap=@"INSERT INTO wykladowca (id, fname, lname) VALUES (";
                string insertwykladowca="";
                using(var reader2 = new StreamReader(@"wykladowcy.csv"))
                {
                    while (!reader2.EndOfStream)
                    {
                        var line = reader2.ReadLine();
                        var values = line.Split(',');
                        insertwykladowca+=insertwykladowcap+values[0]+", '"+values[1]+"', '"+values[2]+"');\n";
                    }
                }
                command = new SqlCommand(insertwykladowca, connection);
                command.ExecuteNonQuery();
                string insertprzedmiotp=@"INSERT INTO przedmiot (id, name) VALUES (";
                string insertprzedmiot="";
                using(var reader3 = new StreamReader(@"przedmioty.csv"))
                {
                    while (!reader3.EndOfStream)
                    {
                        var line = reader3.ReadLine();
                        var values = line.Split(',');
                        insertprzedmiot+=insertprzedmiotp+values[0]+",'"+values[1]+"');\n";
                    }
                }
                command = new SqlCommand(insertprzedmiot, connection);
                command.ExecuteNonQuery();
                string insertgrupyp=@"INSERT INTO grupa (id_wykl, id_stud, id_przed) VALUES (";
                string insertgrupa="";
                using(var reader4 = new StreamReader(@"grupy.csv"))
                {
                    while (!reader4.EndOfStream)
                    {
                        var line = reader4.ReadLine();
                        var values = line.Split(',');
                        insertgrupa+=insertgrupyp+values[0]+","+values[1]+","+values[2]+");\n";
                    }
                }
                command = new SqlCommand(insertgrupa, connection);
                command.ExecuteNonQuery();
                Console.WriteLine("Dane OK\n");
                //c)
                string select1 = @"
                SELECT wykladowca.fname, wykladowca.lname, COUNT(student.id) AS ile_studentow FROM grupa
	                JOIN student ON student.id = grupa.id_stud
	                JOIN wykladowca ON wykladowca.id = grupa.id_wykl
	                GROUP BY wykladowca.fname, wykladowca.lname
                ";

                Console.WriteLine("Liczba studentow dla kazdego wykladowcy:\n");

                command = new SqlCommand(select1, connection);
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t{2}",
                    datareader["fname"].ToString(),
                    datareader["lname"].ToString(),
                    datareader["ile_studentow"].ToString());
                }
                datareader.Close();
                Console.WriteLine("\n");

                string select2 = @"
                SELECT przedmiot.name, COUNT(student.id) AS ile_studentow FROM grupa
	                JOIN student ON student.id = grupa.id_stud
	                JOIN przedmiot ON przedmiot.id = grupa.id_przed
	                GROUP BY przedmiot.name
                ";

                Console.WriteLine("Liczba studentow zapisana na dany przedmiot:\n");
                command = new SqlCommand(select2, connection);
                datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    Console.WriteLine("{0}\t{1}\t",
                    datareader["name"].ToString(),
                    datareader["ile_studentow"].ToString());
                }
                Console.WriteLine("\n");
            }
            catch (SqlException ex)
            { 
                Console.WriteLine(ex.Message); 
            }
            finally
            {   
                if(connection != null)
                {
                    connection.Dispose(); 
                }  
            }
            Console.Write("Nacisnij dowolny przycisk...");
            Console.ReadKey();
        }
    }
}
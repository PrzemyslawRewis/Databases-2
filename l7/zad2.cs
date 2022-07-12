using System;
using System.Text;

public partial class Lab7
{
    public static string zad2(string login, string server, string system)
    {
        StringBuilder result = new StringBuilder();
        result.Append("Witaj: ");
        result.Append(login);
        result.Append(", dzisiaj jest: ");
        result.Append(DateTime.Now.ToString());
        result.Append(", pracujesz na serwerze ");
        result.Append(server);
        result.Append("w systemie ");
        result.Append(system);
        return result.ToString();
    }
};
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct stdev
{
    private double suma;
    private double sumakwadratow;
    private int count;
    public void Init()
    {
        this.suma = 0;
        this.count = 0;
        this.sumakwadratow = 0;
    }

    public void Accumulate(double Value)
    {
        this.suma = this.suma + Value;
        this.sumakwadratow = this.sumakwadratow + (Value*Value);
        this.count++;
    }

    public void Merge(stdev Group)
    {
        this.suma = this.suma + Group.suma;
        this.sumakwadratow = this.sumakwadratow + Group.sumakwadratow;
    }

    public double Terminate()
    {
        double srednia = this.suma / this.count;
        double sredniakwadratow = this.sumakwadratow / this.count;
        return Math.Sqrt(sredniakwadratow - (srednia*srednia));
    }

    

}
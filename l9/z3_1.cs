using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct avg
{
    private double suma;
    private int count;
    public void Init()
    {
        this.suma = 0;
        this.count = 0;
    }

    public void Accumulate(double Value)
    {
        this.suma = this.suma + Value;
        this.count++;
    }

    public void Merge(avg Group)
    {
        this.suma = this.suma + Group.suma;
    }

    public double Terminate()
    {
        return this.suma / this.count;
    }

    

}
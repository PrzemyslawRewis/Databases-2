using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedAggregate(Format.Native)]
public struct l9z2
{
    private SqlInt32 iletrojs;
    
    public void Init()
    {
        this.iletrojs = 0;
    }
    public void Accumulate(SqlInt32 Value)
    {
        if ((Value) > 0 && (Value)%3 == 0)
        {
            this.iletrojs = this.iletrojs + 1;
        }
    }
    public void Merge(l9z2 Group)
    {
        this.iletrojs = this.iletrojs + Group.iletrojs;
    }
    public SqlInt32 Terminate()
    {
        return ((SqlInt32)this.iletrojs);
    }
};
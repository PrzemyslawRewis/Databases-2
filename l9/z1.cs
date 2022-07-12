using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
// Skrypt Lab09.05
[Serializable] 
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)] 
public struct ComplexNumber : INullable
{
    private double _x; //real part
    private double _y; //imaginary part
    public bool IsNull 
    {
        get 
        { 
            return m_Null; 
        } 
    }
    public static ComplexNumber Null 
    {
        get
        {   
            ComplexNumber h = new ComplexNumber(); h.m_Null = true; return h;
        } 
    }
    public ComplexNumber(double x, double y) 
    {
        _x = x;
        _y = y;
        m_Null = false; 
    }
    public ComplexNumber(bool nothing) 
    {
        this._x = this._y = 0;
        this.m_Null = true; 
    }
    public double RealPart 
    {
        get 
        { 
            return _x; 
        }
        set 
        { 
            _x = value; 
        } 
    }
    public double ImaginaryPart 
    {
        get 
        { 
            return _y; 
        }
        set 
        { 
            _y = value; 
        } 
    }
    public override string ToString() 
    {
        return _x.ToString() + "+" + _y.ToString() + "i"; 
    }
    public ComplexNumber sprzezona()
    { 
        ComplexNumber sprzezonal = new ComplexNumber(); 
        sprzezonal.m_Null = m_Null;
        sprzezonal._x = _x;
        sprzezonal._y = -_y;
        return sprzezonal;
    }
    public double modul()
    {
        return Math.Sqrt(Math.Pow(_x, 2.0) + Math.Pow(_y,2.0));
    }
    public static ComplexNumber Parse(SqlString s) 
    {
        string value = s.Value;
        if (s.IsNull || value.Trim() == "")
            return Null;
        string xstr = value.Substring(0, value.IndexOf('+')); 
        string ystr = value.Substring(value.IndexOf('+') + 1,value.Length - xstr.Length - 2); 
        double xx = double.Parse(xstr);
        double yy = double.Parse(ystr);
        return new ComplexNumber(xx, yy); 
    }
    // Dodawanie liczb zespolonych
    public static ComplexNumber Add(ComplexNumber c1, ComplexNumber c2) 
    {
        return new ComplexNumber(c1._x + c2._x, c1._y + c2._y); 
    }
    // Private member
    private bool m_Null; 
}
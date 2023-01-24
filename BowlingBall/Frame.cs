namespace BowlingBall;

public class Frame
{
    private string _throw1;
    private string? _throw2;
    private string? _throw3;
    public int Throw1
    {
        get
        {
            if (_throw1.Contains("X")) return 10;
            return int.Parse(_throw1);
        }
    }
    public int Throw2
    {
        get
        {
            if (_throw2!.Contains("X")) return 10;
            if (_throw2!.Contains("/")) return 10 - Throw1;
            return int.Parse(_throw2.Replace("-","0"));
        }
    }
    public int Throw3
    {
        get
        {
            if (_throw3!.Contains("X")) return 10;
            if (_throw3!.Contains("/")) return 10 - Throw2;
            return int.Parse(_throw3.Replace("-","0")); 
        }
    }
    public bool IsStrikeFrame 
    {
        get
        {
        if (_throw1 == "X") return true;
        return false;
        }
    }
    public bool IsSpareFrame 
    {
        get
        {
            if (_throw2 == "/") return true;
            return false;
        }
    }
    public int GetValue()
    {
        var value = 0;
        if (_throw3 != null) value += Throw3;
        if (_throw2 != null) value += Throw2;
        value += Throw1;
        return value;
    }
    public Frame(string throws)
    {
        _throw1 = throws.ToCharArray()[0].ToString();
        if (throws.Count() > 1) _throw2 = throws.ToCharArray()[1].ToString();
        if (throws.Count() > 2) _throw3 = throws.ToCharArray()[2].ToString();
    }
}
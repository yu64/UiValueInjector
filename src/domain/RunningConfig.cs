

public sealed class RunningConfig
{
    private readonly int _value1;
    private readonly string _value2;

    public RunningConfig(int value1, string value2)
    {
        _value1 = value1;
        _value2 = value2;
    }

    public int Value1 => _value1;
    public string Value2 => _value2;
}

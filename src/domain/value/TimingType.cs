

namespace UiValueInjector.Domain;

public enum TimingType
{
    Always,
    Once
}

public static class TimingTypeExt
{
    public static int? GetLimit(this TimingType type)
    {
        return type switch
        {
            TimingType.Always => null,
            TimingType.Once => 1,
            _ => throw new Exception("Not Found"),
        };
    }
}


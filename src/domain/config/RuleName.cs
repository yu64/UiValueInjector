
namespace UiValueInjector;

public readonly record struct RuleName
{
    public string Value { get; }

    public RuleName(string Value)
    {
        this.Value = Value;
    }
}


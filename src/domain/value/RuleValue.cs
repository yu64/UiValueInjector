
namespace UiValueInjector.Domain;

public readonly record struct RuleValue
{
    public readonly string Value { get; }

    public RuleValue(string Value)
    {
        this.Value = Value;
    }
}

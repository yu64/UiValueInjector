
namespace UiValueInjector.Domain;

public readonly record struct RuleValue
{
    public string Value { get; }

    public RuleValue(string Value)
    {
        this.Value = Value;
    }
}

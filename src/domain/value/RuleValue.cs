
namespace UiValueInjector.Domain;

public readonly record struct RuleValue
{
    private readonly string Value;

    public RuleValue(string Value)
    {
        this.Value = Value;
    }
}

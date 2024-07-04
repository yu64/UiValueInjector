
namespace UiValueInjector.Domain;

public readonly record struct RuleName
{
    private readonly string Value;

    public RuleName(string Value)
    {
        this.Value = Value;
    }
}


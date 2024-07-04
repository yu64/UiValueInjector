
namespace UiValueInjector.Domain;

public readonly record struct ElementSelector
{
    
    public readonly string Type { get; }
    public readonly string Value { get; }

    public ElementSelector(string type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}


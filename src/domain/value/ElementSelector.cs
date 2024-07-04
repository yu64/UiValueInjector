
namespace UiValueInjector.Domain;

public readonly record struct ElementSelector
{
    
    private readonly string Type;
    private readonly string Value;

    public ElementSelector(string type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}


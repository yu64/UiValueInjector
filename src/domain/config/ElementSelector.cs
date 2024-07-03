
namespace UiValueInjector.Domain;




public readonly record struct ElementSelector
{
    public ElementSelectorType Type { get; }
    public string Value { get; }

    public ElementSelector(ElementSelectorType type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}


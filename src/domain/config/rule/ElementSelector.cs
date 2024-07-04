
namespace UiValueInjector.Domain;




public readonly record struct ElementSelector
{
    private readonly ElementSelectorType Type;
    private readonly string Value;

    public ElementSelector(ElementSelectorType type, string value)
    {
        this.Type = type;
        this.Value = value;
    }
}


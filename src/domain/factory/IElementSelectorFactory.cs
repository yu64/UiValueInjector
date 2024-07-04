namespace UiValueInjector.Domain;

public interface IElementSelectorFactory
{
    
    public IElementSelector Create(ElementSelectorType type, string value);
}
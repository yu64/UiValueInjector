namespace UiValueInjector.Domain;

public interface IElementSelectorFactory<A> where A : IApp
{
    
    public IElementSelector<A> Create(ElementSelectorType type, string value);
}
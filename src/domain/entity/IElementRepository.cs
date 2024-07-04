using System.Collections.Immutable;

namespace UiValueInjector.Domain;

public interface IElementRepository
{   
    
    public ImmutableHashSet<IElement> SelectElement(ImmutableHashSet<ElementSelector> selectors);
    

}
using System.Collections.Immutable;

namespace UiValueInjector.Domain;

public interface IElementRepository : IDisposable
{   
    
    public ImmutableHashSet<IElement> SelectElement(ImmutableHashSet<ElementSelector> selectors);
    

}
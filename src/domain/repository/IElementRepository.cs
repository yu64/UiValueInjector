using System.Collections.Immutable;

namespace UiValueInjector.Domain;

public interface IElementRepository : IDisposable
{   
    
    public bool IsDispose();
    
    public ImmutableHashSet<IElement> SelectElement(ImmutableHashSet<ElementSelector> selectors);
    

}
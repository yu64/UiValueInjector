
using System.Collections.Immutable;

namespace UiValueInjector.Domain;




public interface IElementSelector
{
    public ImmutableHashSet<IElement> SelectElement(IApp app);

}


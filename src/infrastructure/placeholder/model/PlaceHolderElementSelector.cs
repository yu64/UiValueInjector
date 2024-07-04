

using System.Collections.Immutable;
using UiValueInjector.Domain;

public class PlaceHolderElementSelector : IElementSelector
{
    public ImmutableHashSet<IElement> SelectElement(IApp app)
    {
        throw new NotImplementedException();
    }

    public void SetValue(RuleValue value)
    {
        throw new NotImplementedException();
    }
}
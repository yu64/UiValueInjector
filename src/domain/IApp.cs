using System.Collections.Immutable;

namespace UiValueInjector.Domain;

public interface IApp
{   
    public ImmutableList<IElement> GetElements(RuleStatus rule);

}
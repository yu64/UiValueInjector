
using System.Collections.Immutable;

namespace UiValueInjector;

public readonly record struct Rule
{
    public RuleName Name { get; }
    public TimingType timing { get; }
    public RuleValue Value { get; }
    public ImmutableList<IElementFilter> Filters { get; }

}

using System.Collections.Immutable;

namespace UiValueInjector.Domain;

public readonly record struct Rule
{
    public RuleName Name { get; }
    public TimingType Timing { get; }
    public RuleValue Value { get; }
    public ImmutableList<ElementSelector> Selectors { get; }


    public Rule(
        RuleName name,
        TimingType timing,
        RuleValue value,
        ImmutableList<ElementSelector> selectors
    )
    {
        this.Name = name;
        this.Timing = timing;
        this.Value = value;
        this.Selectors = selectors;
    }

}
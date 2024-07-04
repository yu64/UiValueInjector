
using System.Collections.Immutable;

namespace UiValueInjector.Domain;

public readonly record struct Rule
{
    private readonly RuleName Name;
    private readonly TimingType Timing;
    private readonly RuleValue Value;
    private readonly ImmutableList<ElementSelector> Selectors;


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
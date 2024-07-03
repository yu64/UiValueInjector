
using System.Collections.Immutable;
using System.Data;

namespace UiValueInjector.Domain;

public readonly record struct RunningConfig
{
    public ImmutableList<Rule> Rules { get; }

    public RunningConfig(ImmutableList<Rule> rules)
    {
        this.Rules = rules;
    }
}


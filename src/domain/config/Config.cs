
using System.Collections.Immutable;
using System.Data;

namespace UiValueInjector.Domain;

public readonly record struct Config
{
    private readonly ImmutableList<Rule> Rules;

    public Config(ImmutableList<Rule> rules)
    {
        this.Rules = rules;
    }


}


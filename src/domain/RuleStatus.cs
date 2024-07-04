
using System.Collections.Immutable;

namespace UiValueInjector.Domain;

public readonly record struct RuleStatus
{
    

    private readonly Rule Rule;
    private readonly CallCount Count;

    public RuleStatus(Rule rule) : this(rule, new CallCount())
    {

    }

    public RuleStatus(Rule rule, CallCount count)
    {
        this.Rule = rule;
        this.Count = new CallCount();
    }





}


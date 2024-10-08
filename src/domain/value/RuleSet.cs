
using System.Collections.Immutable;
using System.Data;

namespace UiValueInjector.Domain;

public readonly record struct RuleSet
{
    private readonly ImmutableHashSet<Rule> Rules;

    public RuleSet(ImmutableHashSet<Rule> rules)
    {
        this.Rules = rules;
    }


    public bool IsDisable()
    {   
        //一つでも有効なものがあるか
        bool isEnable = this.Rules.Any((rule) => !rule.IsDisable());
        return !isEnable;
    }
    
    public void ApplyTo(IElementRepository app)
    {
        var enableRules = this.Rules.Where((rule) => !rule.IsDisable());

        foreach(var rule in enableRules)
        {
            rule.ApplyTo(app);
        }
    }

}


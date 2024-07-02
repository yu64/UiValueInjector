
using System.Data;

namespace UiValueInjector;

public readonly record struct RunningConfig
{
    public IDictionary<RuleName, Rule> Rules { get; }
}


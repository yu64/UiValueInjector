
using System.Collections.Immutable;
using System.Data;

namespace UiValueInjector.Domain;

/// <summary>
/// 設定項目とルールを保持するクラス
/// </summary>
public readonly record struct Config
{
    public readonly IAppConnector Connector { get; }
    public readonly RuleSet RuleSet { get; }

    public Config(
        IAppConnector connector,
        RuleSet ruleSet
    )
    {
        this.Connector = connector;
        this.RuleSet = ruleSet;
    }


}


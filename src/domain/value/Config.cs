
using System.Collections.Immutable;
using System.Data;

namespace UiValueInjector.Domain;

/// <summary>
/// 設定項目とルールを保持するクラス
/// </summary>
public readonly record struct Config
{
    public readonly IConnector Connector { get; }
    public readonly RuleSet RuleSet { get; }

    public Config(
        IConnector connector,
        RuleSet ruleSet
    )
    {
        this.Connector = connector;
        this.RuleSet = ruleSet;
    }


}


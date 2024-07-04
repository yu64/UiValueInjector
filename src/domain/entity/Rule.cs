
using System.Collections.Immutable;
using System.Diagnostics;

namespace UiValueInjector.Domain;

public record struct Rule
{
    private readonly RuleName Name;
    private readonly TimingType Timing;
    private readonly RuleValue Value;
    private readonly ImmutableHashSet<IElementSelector> Selectors;

    private RuleCallCount count;


    public Rule(
        RuleName name,
        TimingType timing,
        RuleValue value,
        ImmutableHashSet<IElementSelector> selectors
    )
    {
        this.Name = name;
        this.Timing = timing;
        this.Value = value;
        this.Selectors = selectors;
        this.count = new RuleCallCount();
    }

    public bool IsDisable()
    {
        return this.count.IsOverlimit(this.Timing);
    }

    public void ApplyTo(IApp app)
    {
        //ルールが無効であれば、実行しない。
        if(this.IsDisable())
        {
            Debug.WriteLine($"{this.Name}: Is Disable");
            return;
        }

        //ルールに基づいて抽出
        var eleCollection = this.Selectors
        .SelectMany((s) => s.SelectElement(app))
        .ToImmutableHashSet()
        ;

        //該当がない場合、終了
        if(eleCollection.IsEmpty)
        {
            Debug.WriteLine($"{this.Name}: Element Empty");
            return;
        }

        //該当の要素に値を入力
        foreach(var v in eleCollection)
        {
            Debug.WriteLine($"{this.Name} {v}: Set Value {this.Value}");
            v.SetValue(this.Value);
        }

        //呼び出し回数を更新
        this.count = this.count.Increment();
    }


}
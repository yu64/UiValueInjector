
using System.Collections.Immutable;
using System.Diagnostics;

namespace UiValueInjector.Domain;

public record Rule
{
    private readonly RuleName Name;
    private readonly TimingType Timing;
    private readonly RuleValue Value;
    private readonly ImmutableHashSet<ElementSelector> Selectors;

    private bool isFirst;


    public Rule(
        RuleName name,
        TimingType timing,
        RuleValue value,
        ImmutableHashSet<ElementSelector> selectors
    )
    {
        this.Name = name;
        this.Timing = timing;
        this.Value = value;
        this.Selectors = selectors;
        this.isFirst = true;
    }

    public bool IsDisable()
    {
        return this.Timing switch
        {
            TimingType.Once => !this.isFirst,
            TimingType.Always => false,
            _ => throw new Exception("Not Found")
        };
    }

    public void ApplyTo(IElementRepository repo)
    {
        //ルールが無効であれば、実行しない。
        if(this.IsDisable())
        {
            Debug.WriteLine($"{this.Name}: Is Disable");
            return;
        }

        //ルールに基づいて抽出
        var eleCollection = repo.SelectElement(this.Selectors);


        //該当がない場合、終了
        if(eleCollection.IsEmpty)
        {
            Debug.WriteLine($"{this.Name}: Element Empty");
            return;
        }

        //該当の要素に値を入力
        foreach(var ele in eleCollection)
        {
            Debug.WriteLine($"{this.Name} {ele}: Set Value {this.Value}");
            ele.SetValue(this.Value);
        }

        this.isFirst = false;
    }


}
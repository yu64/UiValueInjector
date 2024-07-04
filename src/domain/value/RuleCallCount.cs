
namespace UiValueInjector.Domain;

public readonly record struct RuleCallCount
{
    private readonly int Value;

    public RuleCallCount() : this(0)
    {
        
    }

    private RuleCallCount(int Value)
    {
        if(this.Value < 0)
        {
            throw new Exception("[Invaild] CallCount is negative.");
        }

        this.Value = Value;
    }

    public RuleCallCount Increment()
    {
        return new RuleCallCount(this.Value + 1);
    }

    public bool IsOverlimit(TimingType type)
    {
        var limit = type.GetLimit();
        if(limit == null)
        {
            return false;
        }

        return (limit <= this.Value);
    }
}


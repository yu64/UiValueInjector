
namespace UiValueInjector.Domain;

public readonly record struct CallCount
{
    private readonly int Value;

    public CallCount() : this(0)
    {
        
    }

    private CallCount(int Value)
    {
        if(this.Value < 0)
        {
            throw new Exception("[Invaild] CallCount is negative.");
        }

        this.Value = Value;
    }
}


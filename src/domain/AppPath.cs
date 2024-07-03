
namespace UiValueInjector.Domain;

public readonly record struct AppPath
{
    public string Value { get; }

    public AppPath(string Value)
    {
        this.Value = Value;
    }
}

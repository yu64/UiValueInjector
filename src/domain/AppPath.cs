
namespace UiValueInjector.Domain;

public readonly record struct AppPath
{
    private readonly string Value;

    public AppPath(string value)
    {
        this.Value = value;
    }
}

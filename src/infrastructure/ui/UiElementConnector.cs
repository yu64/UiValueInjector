
using System.Diagnostics;
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;

public class UiElementConnector : IConnector
{
    private readonly string path;
    
    public UiElementConnector(string path)
    {
        this.path = path;
    }

    public IElementRepository Connect()
    {
        var app = FlaUI.Core.Application.Launch(this.path);

        return new UiElementRepository(app);
    }
}

using System.Diagnostics;
using System.Runtime.InteropServices;
using Cysharp.Diagnostics;
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;

public class UiElementConnector : IConnector
{
    private readonly string path;
    
    public UiElementConnector(string path)
    {
        this.path = path;
    }

    public async Task<IElementRepository> Connect()
    {
        var cwd = Directory.GetCurrentDirectory();

        var record = ProcessX.GetDualAsyncEnumerable(this.path, workingDirectory: cwd);

        var app = FlaUI.Core.Application.Attach(record.Process);

        return new UiElementRepository(app);
    }
}
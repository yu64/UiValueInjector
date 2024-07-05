

using System.Collections.Immutable;
using System.Diagnostics;
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;

public class UiElementConnectorFactory : IConnectorFactory
{
    public UiElementConnectorFactory()
    {

    }

    public IConnector CreateLaunchConnector(string path)
    {
        return new UiElementConnector(path);
    }
}
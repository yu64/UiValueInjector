
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;


public class TextLineConnectorFactory : IConnectorFactory
{
    public IConnector CreateLaunchConnector(string path)
    {
        return new TextLineConnector(path);
    }
}

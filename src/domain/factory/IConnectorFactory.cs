namespace UiValueInjector.Domain;

public interface IConnectorFactory
{
    
    public IConnector CreateLaunchConnector(string path);
}

namespace UiValueInjector.Domain;

public interface IAppConnectorFactory
{
    
    public IAppConnector CreateLaunchConnector(string path);
}
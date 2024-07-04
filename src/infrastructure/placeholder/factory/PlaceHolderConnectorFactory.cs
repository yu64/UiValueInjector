namespace UiValueInjector.Domain;

public class PlaceHolderConnectorFactory : IAppConnectorFactory
{
    public IAppConnector CreateLaunchConnector(string path)
    {
        return new PlaceHolderAppConnector(path);
    }
}
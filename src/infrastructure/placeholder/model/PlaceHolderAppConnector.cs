

using UiValueInjector.Domain;

public class PlaceHolderAppConnector : IAppConnector
{
    private readonly string path;

    public PlaceHolderAppConnector(string path)
    {
        this.path = path;

        if(!File.Exists(this.path))
        {
            throw new Exception("File Not Found");
        }

    }

    public IApp Connect()
    {
        return new PlaceHolderApp(this.path);
    }

}
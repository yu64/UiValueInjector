
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;


public class TextLineConnector : IConnector
{
    private string path;

    public TextLineConnector(string path)
    {
        this.path = path;
    }

    public async Task<IElementRepository> Connect()
    {
        return new TextLineRepository(this.path);
    }
}


namespace UiValueInjector.Domain;

public interface IConnector
{   

    Task<IElementRepository> Connect();
}
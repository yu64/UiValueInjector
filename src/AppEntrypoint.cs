
using UiValueInjector.Domain;
using UiValueInjector.Presentation;
using UiValueInjector.Usecase;

namespace UiValueInjector;


class AppEntrypoint
{
    public static async Task<int> Main(string[] args)
    {

        var connectorFactory = (IAppConnectorFactory)new PlaceHolderConnectorFactory();
        var selectorFactory = (IElementSelectorFactory)new PlaceHolderSelectorFactory();

        var usecase = new InjectUsecase();
        var con = new ConsoleController(
            usecase,
            connectorFactory,
            selectorFactory
        );

        return await con.InvokeAsync(args);
    }
}
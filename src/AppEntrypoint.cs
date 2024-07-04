
using UiValueInjector.Domain;
using UiValueInjector.Presentation;
using UiValueInjector.Usecase;

namespace UiValueInjector;


class AppEntrypoint
{
    public static async Task<int> Main(string[] args)
    {

        var connectorFactory = (IAppConnectorFactory)null;
        var selectorFactory = (IElementSelectorFactory)null;

        var usecase = new InjectUsecase();
        var con = new ConsoleController(
            usecase,
            connectorFactory,
            selectorFactory
        );

        return await con.InvokeAsync(args);
    }
}
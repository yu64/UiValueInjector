
using UiValueInjector.Domain;
using UiValueInjector.Infrastructure.Text;
using UiValueInjector.Presentation;
using UiValueInjector.Usecase;

namespace UiValueInjector;


class AppEntrypoint
{
    public static async Task<int> Main(string[] args)
    {

        var connectorFactory = new TextLineConnectorFactory();

        var usecase = new InjectUsecase();

        var con = new ConsoleController(
            usecase,
            connectorFactory
        );

        return await con.InvokeAsync(args);
    }
}
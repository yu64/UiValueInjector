
using UiValueInjector.Presentation;
using UiValueInjector.Usecase;

namespace UiValueInjector;


class AppEntrypoint
{
    public static async Task<int> Main(string[] args)
    {
        var usecase = new InjectUsecase();
        var con = new ConsoleController(usecase);

        return await con.InvokeAsync(args);
    }
}
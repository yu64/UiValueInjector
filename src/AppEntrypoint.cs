
namespace UiValueInjector;


class AppEntrypoint
{
    public static async Task<int> Main(string[] args)
    {
        var usecase = new Usecase();
        var con = new ConsoleController(usecase);
        return await con.InvokeAsync(args);
    }
}
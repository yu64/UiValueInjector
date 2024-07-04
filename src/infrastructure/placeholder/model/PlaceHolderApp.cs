

using System.Text;
using UiValueInjector.Domain;

public class PlaceHolderApp : IApp
{
    private string[] lines;

    public PlaceHolderApp(string path)
    {
        this.lines = File.ReadAllLines(path, Encoding.GetEncoding("UTF-8"));


        

    }

    public void Dispose()
    {
        //なし
    }
}
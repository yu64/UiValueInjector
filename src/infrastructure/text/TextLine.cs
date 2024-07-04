using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;

public class TextLine : IElement
{
    private readonly TextLineRepository repo;

    private readonly string propertyName;

    public TextLine(TextLineRepository repo, string propertyName)
    {
        this.repo = repo;
        this.propertyName = propertyName;
    }


    public void SetValue(RuleValue value)
    {
        var lines = this.repo.Reload();

        lines[this.propertyName] = value.Value;
        
        this.repo.Write(lines);
    }
}
using System.Collections.Immutable;
using System.Text;
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;

public class TextLineRepository : IElementRepository
{
    private readonly string path;

    public TextLineRepository(string path)
    {
        this.path = path;
    }

    public IDictionary<string, string> Reload()
    {
        return File.ReadAllLines(this.path, Encoding.GetEncoding("UTF-8"))
        .Where((s) => s.Contains(":"))
        .Select((s) => s.Split(":"))
        .ToDictionary(
            v => v[0].Trim(), 
            v => v[1].Trim()
        );
    }

    public void Write(IDictionary<string, string> lines)
    {
        File.WriteAllLines(
            this.path, 
            lines.ToArray()
                .Select((p) => $"{p.Key}: {p.Value}")
        );
    }
    
    public bool IsDispose()
    {
        return false;
    }

    public ImmutableHashSet<IElement> SelectElement(ImmutableHashSet<ElementSelector> selectors)
    {
        var lines = this.Reload();

        var names = selectors
        .Where((s) => String.Equals(s.Type.ToLower(), "name"))
        .Select((s) => s.Value.ToLower());

        return lines
        .Where((p) => names.Contains(p.Key))
        .Select((p) => new TextLine(this, p.Key))
        .Select((v) => (IElement)v)
        .ToImmutableHashSet();
    }

    public void Dispose()
    {
        
    }
}
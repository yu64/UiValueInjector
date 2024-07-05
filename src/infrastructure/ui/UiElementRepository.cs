

using System.Collections.Immutable;
using System.Diagnostics;
using System.Windows.Forms.VisualStyles;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;

public class UiElementRepository : IElementRepository
{
    private readonly FlaUI.Core.Application app;
    private readonly UIA3Automation auto;

    public UiElementRepository(FlaUI.Core.Application app)
    {
        this.app = app;
        this.auto = new UIA3Automation();

    }

    public void Dispose()
    {
        this.app.Dispose();
        this.auto.Dispose();
    }

    public bool IsDispose()
    {
        try
        {
            Process.GetProcessById(this.app.ProcessId);
            return false; 
        }
        catch
        {
            return true;
        }
    }

    public ImmutableHashSet<IElement> SelectElement(ImmutableHashSet<ElementSelector> selectors)
    {
        var windowArray = new Window[]{this.app.GetMainWindow(this.auto)};

        var conditions = selectors
        .Select((s) => this.toCondition(s));

        var elements = windowArray
        .SelectMany((w) => conditions
            .Select((c) => w.FindAllDescendants(c))
            .SelectMany((v) => v)
            //.Aggregate((a, b) => a.Intersect(b).ToArray())
            .Select((v) => (IElement)new UiElement(v, this))
        )
        .ToImmutableHashSet();

        return elements;
    }


    private PropertyCondition toCondition(ElementSelector selector)
    {
        var cf = this.auto.ConditionFactory;
        return selector.Type.ToLower() switch
        {
            "automationid" => cf.ByAutomationId(selector.Value),
            "controltype" => cf.ByControlType(Enum.Parse<ControlType>(selector.Value)),
            "name" => cf.ByName(selector.Value, PropertyConditionFlags.MatchSubstring),
            _ => throw new Exception("Not Found Selector Type")
        };
    }
}
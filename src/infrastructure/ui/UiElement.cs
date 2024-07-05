
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;
using UiValueInjector.Domain;

namespace UiValueInjector.Infrastructure.Text;

public class UiElement : IElement
{
    private AutomationElement autoElement;
    private UiElementRepository uiElementRepository;

    public UiElement(AutomationElement v, UiElementRepository repo)
    {
        this.autoElement = v;
        this.uiElementRepository = repo;
    }

    public void SetValue(RuleValue value)
    {
        IValuePattern? valuePattern = this.autoElement.Patterns.Value.PatternOrDefault;
        if(valuePattern != null)
        {
            valuePattern.SetValue(value.Value);
            return;
        }

        this.autoElement.Focus();

        value.Value
        .ToCharArray()
        .Select((c) => (ushort)c)
        .ToList()
        .ForEach((c) => Keyboard.TypeScanCode(c, true))
        ;
    }
}
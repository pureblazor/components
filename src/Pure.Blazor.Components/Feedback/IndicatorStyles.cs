using Pure.Blazor.Components.Buttons;

namespace Pure.Blazor.Components.Indicator;

public class IndicatorStyles
{
    public readonly Dictionary<Accent, string> Background = new()
    {
        { Accent.Brand, "bg-brand-500/20" },
        { Accent.Danger, "bg-red-500/20" },
        { Accent.Success, "bg-green-500/20" },
        { Accent.Warning, "bg-yellow-500/20" },
        { Accent.Default, "bg-gray-500/20" }
    };

    public readonly Dictionary<Accent, string> Foreground = new()
    {
        { Accent.Brand, "bg-brand-500" },
        { Accent.Danger, "bg-red-500" },
        { Accent.Success, "bg-green-500" },
        { Accent.Warning, "bg-yellow-500" },
        { Accent.Default, "bg-gray-500" }
    };
}

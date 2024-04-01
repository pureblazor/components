using Pure.Blazor.Components.Common.Css;

namespace Pure.Blazor.Components.Common;

public enum Theme
{
    Off,
    On,
    Auto
}

public class ThemeProvider
{
    public StylePrioritizer? StylePrioritizer { get; set; } = new();
}

using Pure.Blazor.Components.Display;
using Pure.Blazor.Components.Feedback;
using Pure.Blazor.Components.Indicator;
using Pure.Blazor.Components.Layout;

namespace Pure.Blazor.Components.Buttons;

public class PureTheme
{
    public ButtonStyles Button { get; set; } = new();
    public DropdownStyles Dropdown { get; set; } = new();
    public IndicatorStyles Indicator { get; set; } = new();
    public BannerStyles Banner { get; set; } = new();
    public LinkStyles Link { get; set; } = new();
    public LeftNavStyles LeftNav { get; set; } = new();
    public BadgeStyles Badge { get; set; } = new();
}

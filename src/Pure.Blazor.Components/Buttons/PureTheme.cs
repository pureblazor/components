using Pure.Blazor.Components.Common.Css;
using Pure.Blazor.Components.Display;
using Pure.Blazor.Components.Feedback;
using Pure.Blazor.Components.Navigation;
using Pure.Blazor.Components.Primitives;

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
    public AlertStyles Alert { get; set; } = new();
}

public class DefaultTheme : IPureTheme
{
    public IStylePrioritizer StylePrioritizer { get; set; } = new StylePrioritizer();
    public Dictionary<string, ComponentStyle> Styles { get; set; }

    public DefaultTheme()
    {
        Styles = new Dictionary<string, ComponentStyle>
        {
            {
                nameof(PureButton),
                new ComponentStyle(ButtonStyles.Base, null, ButtonStyles.Variants, ButtonStyles.Sizes)
            },
            { nameof(PureDropdown), new ComponentStyle(DropdownStyles.Base, null, null, DropdownStyles.Sizes) },
            { nameof(PureBanner), new ComponentStyle(BannerStyles.Base, null, BannerStyles.Variants, null) },
            { nameof(PureLink), new ComponentStyle(LinkStyles.Base, null, null, null) },
            { nameof(PureBadge), new ComponentStyle("", null, BadgeStyles.Variants, null) },
            { nameof(PureAlert), new ComponentStyle(AlertStyles.Base, AlertStyles.Accents, null, null) },
            {
                nameof(PureColorIndicator),
                new ComponentStyle("", null, null, null)
                {
                    InnerContainer = new ComponentStyle("", IndicatorStyles.Background, null, null)
                    {
                        OuterContainer = new ComponentStyle("", IndicatorStyles.Foreground, null, null)
                    }
                }
            },
        };
    }
}

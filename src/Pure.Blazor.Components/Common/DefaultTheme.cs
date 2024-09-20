using Pure.Blazor.Components.Buttons;
using Pure.Blazor.Components.Common.Css;
using Pure.Blazor.Components.Display;
using Pure.Blazor.Components.Essentials;
using Pure.Blazor.Components.Feedback;
using Pure.Blazor.Components.Forms;
using Pure.Blazor.Components.Layout;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Common;

public record DefaultTheme : PureTheme
{
    public DefaultTheme()
    {
        ButtonDefaults.PressEffect = Effect.InsetShadow;
        ButtonDefaults.HoverEffect = Effect.Unset;
        StylePrioritizer = new StylePrioritizer();
        Styles = new()
        {
            {
                nameof(PureButton),
                new(ButtonStyles.Base) { Variants = ButtonStyles.Variants, Sizes = ButtonStyles.Sizes }
            },
            {
                nameof(PureInput),
                new("peer block border-1 focus:ring focus:ring-inset ring-brand-700 bg-gray-50 text-gray-800 rounded")
                {
                    Sizes = new Dictionary<PureSize, string>
                    {
                        { PureSize.ExtraSmall, "text-xs px-1 py-0.5" },
                        { PureSize.Small, "text-sm px-1 py-0.5" },
                        { PureSize.Medium, "text-sm px-2 py-1" },
                        { PureSize.Large, "text-md px-2.5 py-1.5" },
                        { PureSize.ExtraLarge, "text-lg px-3 py-2" }
                    }
                }
            },
            {
                nameof(PureTabButton), new("sm:w-auto sm:justify-start inline-flex items-center font-medium")
                {
                    Sizes = new Dictionary<PureSize, string>()
                    {
                        { PureSize.ExtraSmall, "sm:px-6 py-1 text-xs" },
                        { PureSize.Small, "sm:px-6 py-1 text-xs" },
                        { PureSize.Medium, "sm:px-6 px-3 py-2 text-sm" },
                        { PureSize.Large, "sm:px-6 px-4 py-3 text-lg" },
                        { PureSize.ExtraLarge, "sm:px-6 px-4 py-3 text-lg" },
                    }
                }
            },
            {
                nameof(PureIconButton),
                new(ButtonStyles.Base) { Variants = ButtonStyles.Variants, Sizes = ButtonStyles.Sizes }
            },
            {
                nameof(PureDropdown),
                new(DropdownStyles.Base)
                {
                    Sizes = DropdownStyles.Sizes, InnerContainer = new ComponentStyle(DropdownStyles.Container.Base)
                }
            },
            {
                nameof(PureSelect),
                new(DropdownStyles.Base)
                {
                    Sizes = DropdownStyles.Sizes, InnerContainer = new ComponentStyle(DropdownStyles.Container.Base)
                }
            },
            {
                nameof(PureDropdownItem),
                new(DropdownStyles.MenuItem.Base)
                {
                    Accents = DropdownStyles.MenuItem.Accents, Sizes = DropdownStyles.MenuItem.Sizes
                }
            },
            { nameof(PureBanner), new(BannerStyles.Base) { Variants = BannerStyles.Variants } },
            { nameof(PureLink), new(LinkStyles.Base) },
            {
                nameof(PureLabel), new("text-gray-800 inline-block")
                {
                    Sizes = new Dictionary<PureSize, string>
                    {
                        { PureSize.ExtraSmall, "font-bold text-xs leading-1" },
                        { PureSize.Small, "font-bold text-xs leading-3" },
                        { PureSize.Medium, "font-bold text-sm leading-7" },
                        { PureSize.Large, "font-bold text-lg leading-7" },
                        { PureSize.ExtraLarge, "font-bold text-lg leading-7" }
                    }
                }
            },
            { nameof(PureBadge), new("") { Variants = BadgeStyles.Variants } },
            { nameof(PureAlert), new(AlertStyles.Base) { Accents = AlertStyles.Accents } },
            {
                nameof(PureColorIndicator),
                new("")
                {
                    InnerContainer = new("")
                    {
                        Accents = IndicatorStyles.Background,
                        OuterContainer = new("") { Accents = IndicatorStyles.Foreground }
                    }
                }
            },
        };
    }
}

using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

public class DropdownMenuItemStyles
{
    private const string ExtraSmallMenuItem = "px-1 py-0.5 text-sm";
    private const string SmallMenuItem = "px-2 py-1 text-sm ";
    private const string MediumMenuItem = "px-4 py-2 text-sm ";
    private const string LargeMenuItem = "px-4 py-2 text-sm ";

    public string Base { get; set; } = "text-gray-700 hover:bg-gray-200 block text-sm grow text-left";

    public readonly Dictionary<Accent, string> Accents = new()
    {
        { Accent.Default, "" },
        { Accent.Brand, BrandAccentColors.LightBackgroundText },
        { Accent.Danger, $"{DangerAccentColors.LightBackgroundText}" },
        { Accent.Warning, "" },
        { Accent.Success, "" }
    };

    public readonly Dictionary<PureSize, string> Sizes = new()
    {
        { PureSize.Large, LargeMenuItem },
        { PureSize.Small, SmallMenuItem },
        { PureSize.Medium, MediumMenuItem },
        { PureSize.ExtraSmall, ExtraSmallMenuItem }
    };
}
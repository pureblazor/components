using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Buttons;

public class DropdownStyles
{
    private const string ExtraSmallButton = "px-1 py-0.5 text-sm";
    private const string SmallButton = "px-1 py-1 text-sm";
    private const string MediumButton = "px-2 py-2 text-sm";
    private const string LargeButton = "px-2 py-2 text-sm";

    public static string Base { get; set; } =
        "inline-flex gap-2 justify-center rounded-md font-semibold text-gray-700 border-1 border-gray-200 hover:border-gray-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-gray-300 group-focus-within/dropdown:rounded-b-none";

    public DropdownMenuContainerStyles Container { get; set; } = new();
    public DropdownMenuItemStyles MenuItem { get; set; } = new();

    public static readonly Dictionary<PureSize, string> Sizes = new()
    {
        { PureSize.ExtraLarge, LargeButton },
        { PureSize.Large, LargeButton },
        { PureSize.Small, SmallButton },
        { PureSize.Medium, MediumButton },
        { PureSize.ExtraSmall, ExtraSmallButton }
    };
}

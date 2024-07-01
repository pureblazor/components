using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Buttons;

public class DropdownStyles
{
    private const string ExtraSmallButton = "px-1 py-0.5 text-xs font-normal";
    private const string SmallButton = "px-1 py-1 text-xs";
    private const string MediumButton = "px-2 py-1.5 text-sm";
    private const string LargeButton = "px-4 py-3 text-lg";

    public static string Base { get; set; } =
        "w-full inline-flex grow-0 text-nowrap gap-2 justify-between rounded-md font-semibold text-gray-700 border-1 border-gray-200 hover:border-gray-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-gray-300 group-focus-within/dropdown:rounded-b-none";

    public static DropdownMenuContainerStyles Container { get; set; } = new();
    public static DropdownMenuItemStyles MenuItem { get; set; } = new();

    public static readonly Dictionary<PureSize, string> Sizes = new()
    {
        { PureSize.ExtraLarge, LargeButton },
        { PureSize.Large, LargeButton },
        { PureSize.Small, SmallButton },
        { PureSize.Medium, MediumButton },
        { PureSize.ExtraSmall, ExtraSmallButton }
    };
}

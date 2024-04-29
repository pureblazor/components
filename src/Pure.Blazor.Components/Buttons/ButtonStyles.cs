using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

/// <summary>
/// Base accent colors that have been checked for accessibility.
/// </summary>
public static class BaseAccentColors
{
    public const string Brand = $"{BrandAccentColors.Background} {BrandAccentColors.DarkBackgroundText}";
    public const string Warning = "bg-yellow-400 text-black";
    public const string Danger = $"{DangerAccentColors.Background} {DangerAccentColors.DarkBackgroundText}";
    public const string Success = "bg-green-500 text-black";
}

public static class BrandAccentColors
{
    public const string Background = "bg-brand-900";
    public const string Border = "border-brand-900";
    public const string LightBackgroundText = "text-brand-900";
    public const string DarkBackgroundText = "text-gray-100";
}

public static class DangerAccentColors
{
    public const string Background = "bg-red-800/95";
    public const string Border = "border-red-800/95";
    public const string LightBackgroundText = "text-red-800/95";
    public const string DarkBackgroundText = "text-gray-50";
}

public class DropdownStyles
{
    private const string ExtraSmallButton = "px-1 py-0.5 text-sm";
    private const string SmallButton = "px-1 py-1 text-sm";
    private const string MediumButton = "px-2 py-2 text-sm";
    private const string LargeButton = "px-2 py-2 text-sm";

    public string Base { get; set; } =
        "inline-flex gap-2 justify-center rounded-md font-semibold text-gray-700 border-1 border-gray-200 hover:border-gray-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-gray-300 group-focus-within/dropdown:rounded-b-none";

    public DropdownMenuContainerStyles Container { get; set; } = new();
    public DropdownMenuItemStyles MenuItem { get; set; } = new();

    public readonly Dictionary<PureSize, string> Sizes = new()
    {
        { PureSize.ExtraLarge, LargeButton },
        { PureSize.Large, LargeButton },
        { PureSize.Small, SmallButton },
        { PureSize.Medium, MediumButton },
        { PureSize.ExtraSmall, ExtraSmallButton }
    };
}

public class DropdownMenuContainerStyles
{
    public string Base { get; set; } =
        "origin-top-right absolute rounded-b-lg shadow-lg bg-white ring-1 ring-black/20 focus:outline-none invisible group-focus-within/dropdown:visible group-active/dropdown:visible z-10 font-medium";
}

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

public class ButtonStyles
{
    private const string ExtraSmallButton = "rounded px-1 py-0.5 text-xs font-normal";
    private const string SmallButton = "px-3 py-2 text-xs";
    private const string MediumButton = "px-3.5 py-2.5 text-sm";
    private const string LargeButton = "px-4 py-3 text-lg";

    private const string PrimaryButton = $"{BaseAccentColors.Brand} hover:bg-brand-950 border-brand-950 font-medium";
    private const string DefaultButton = $"bg-gray-300 hover:bg-gray-400 border-gray-950 font-medium";
    private const string DangerButton = $"{BaseAccentColors.Danger} border-red-950 hover:bg-red-900 font-medium";
    private const string WarningButton = $"{BaseAccentColors.Warning} hover:bg-yellow-500 font-medium";
    private const string SuccessButton = $"{BaseAccentColors.Success} hover:bg-green-600 font-medium";

    private const string PrimaryOutlineButton =
        "border-1 border-brand-700 text-brand-800 hover:bg-brand-700/10 font-medium";

    private const string DefaultOutlineButton =
        "border-1 border-gray-700 text-gray-800 hover:bg-gray-700/10 font-medium";

    private const string WarningOutlineButton = "border-yellow-400 text-yellow-900 hover:bg-yellow-400/10 font-medium";
    private const string DangerOutlineButton = "border-red-400 text-red-800 hover:bg-red-400/10 font-medium";
    private const string SuccessOutlineButton = "border-green-400 text-green-800 hover:bg-green-400/10 font-medium";

    private const string PrimarySubtleButton =
        "border-transparent bg-transparent hover:text-brand-900 hover:bg-gray-100 text-brand-800 font-medium";

    private const string DefaultSubtleButton =
        "border-transparent bg-transparent hover:text-gray-900 hover:bg-gray-100 text-gray-700 font-medium";

    private const string WarningSubtleButton =
        "border-transparent bg-transparent hover:bg-yellow-100 text-yellow-900 font-medium";

    private const string DangerSubtleButton =
        "border-transparent bg-transparent hover:bg-red-100 text-red-700 font-medium";

    private const string SuccessSubtleButton =
        "border-transparent bg-transparent hover:bg-green-400/10 text-green-700 font-medium";

    public readonly Dictionary<PureSize, string> Sizes = new()
    {
        { PureSize.Large, LargeButton },
        { PureSize.Small, SmallButton },
        { PureSize.Medium, MediumButton },
        { PureSize.ExtraSmall, ExtraSmallButton }
    };

    public readonly Dictionary<ButtonVariant, Dictionary<Accent, string>> Variants = new()
    {
        {
            ButtonVariant.Default,
            new Dictionary<Accent, string>
            {
                { Accent.Brand, PrimaryButton },
                { Accent.Danger, DangerButton },
                { Accent.Warning, WarningButton },
                { Accent.Success, SuccessButton },
                { Accent.Default, DefaultButton }
            }
        },
        {
            ButtonVariant.Outline,
            new Dictionary<Accent, string>
            {
                { Accent.Brand, PrimaryOutlineButton },
                { Accent.Danger, DangerOutlineButton },
                { Accent.Success, SuccessOutlineButton },
                { Accent.Warning, WarningOutlineButton },
                { Accent.Default, DefaultOutlineButton }
            }
        },
        {
            ButtonVariant.Subtle,
            new Dictionary<Accent, string>
            {
                { Accent.Brand, PrimarySubtleButton },
                { Accent.Danger, DangerSubtleButton },
                { Accent.Success, SuccessSubtleButton },
                { Accent.Warning, WarningSubtleButton },
                { Accent.Default, DefaultSubtleButton }
            }
        }
    };

    public string Base =>
        "flex justify-center items-center cursor-pointer gap-1 rounded-sm md:rounded-xs text-sm focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-brand-900 border-1";
}

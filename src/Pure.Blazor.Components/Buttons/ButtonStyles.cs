using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

/// <summary>
/// Base accent colors that have been checked for accessibility.
/// </summary>
public static class BaseAccentColors
{
    public const string Brand = "bg-brand-900 text-gray-100";
    public const string Warning = "bg-yellow-400 text-black";
    public const string Danger = "bg-red-800/95 text-gray-50";
    public const string Success = "bg-green-500 text-black";
}

public class ButtonStyles
{
    private const string ExtraSmallButton = "px-2.5 py-1.5 text-xs";
    private const string SmallButton = "px-3 py-2 text-xs";
    private const string MediumButton = "px-3.5 py-2.5 text-sm";
    private const string LargeButton = "px-4 py-3 text-lg";

    private const string PrimaryButton = $"{BaseAccentColors.Brand} hover:bg-brand-950 border-brand-950 font-medium";
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

    private const string DangerSubtleButton = "border-transparent bg-transparent hover:bg-red-100 text-red-700 font-medium";

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
                { Accent.Default, PrimaryButton }
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

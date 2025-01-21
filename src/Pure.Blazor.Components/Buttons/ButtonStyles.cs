using Pure.Blazor.Components;

namespace Pure.Blazor.Components;

internal class ButtonStyles
{
    private const string ExtraSmallButton = "rounded px-1 py-0.5 text-xs font-normal";
    private const string SmallButton = "px-3 py-1.5 text-xs";
    private const string MediumButton = "px-3.5 py-1.5 text-sm";
    private const string LargeButton = "px-4 py-3 text-lg";
    private const string ExtraLargeButton = "px-4 py-3 text-lg w-full";

    private const string PrimaryButton =
        $"{BaseAccentColors.Brand} hover:bg-brand-900 shadow-brand-950/90 border-transparent font-medium";

    private const string DefaultButton =
        "bg-white hover:bg-gray-50 border-gray-400 shadow-gray-500/70 text-gray-800 font-medium";

    private const string DangerButton =
        $"{BaseAccentColors.Danger} border-red-950 hover:bg-red-900/95 shadow-red-950/70 font-medium";

    private const string WarningButton =
        $"{BaseAccentColors.Warning} hover:bg-yellow-500 shadow-yellow-700/70 font-medium";

    private const string SuccessButton =
        $"{BaseAccentColors.Success} hover:bg-green-600 shadow-green-800/70 font-medium";

    private const string PrimaryOutlineButton =
        "border-1 border-brand-700 text-brand-800 hover:bg-brand-400/10 shadow-brand-400/20 font-medium";

    private const string DefaultOutlineButton =
        "border-1 border-gray-700 text-gray-800 hover:bg-gray-700/10 shadow-gray-700/50 font-medium";

    private const string WarningOutlineButton =
        "border-yellow-400 hover:bg-yellow-400/10 text-yellow-900 shadow-yellow-400/20 font-medium";

    private const string DangerOutlineButton =
        "border-red-400 hover:bg-red-400/5 text-red-800/80 shadow-red-400/15 font-medium";

    private const string SuccessOutlineButton =
        "border-green-400 hover:bg-green-400/10 text-green-800 shadow-green-400/20 font-medium";

    private const string PrimarySubtleButton =
        "border-transparent bg-transparent text-brand-800 hover:bg-brand-400/10 shadow-brand-400/20 font-medium";

    private const string DefaultSubtleButton =
        "border-transparent bg-transparent text-gray-900 hover:bg-gray-400/10 shadow-gray-400/20 text-gray-700 font-medium";

    private const string WarningSubtleButton =
        "border-transparent bg-transparent hover:bg-yellow-400/10 text-yellow-900 shadow-yellow-400/20 font-medium";

    private const string DangerSubtleButton =
        "border-transparent bg-transparent hover:bg-red-400/5 text-red-800/80 shadow-red-400/15 font-medium";

    private const string SuccessSubtleButton =
        "border-transparent bg-transparent hover:bg-green-400/10 text-green-800 shadow-green-400/20 font-medium";

    public static readonly Dictionary<PureSize, string> Sizes = new()
    {
        { PureSize.ExtraLarge, ExtraLargeButton },
        { PureSize.Large, LargeButton },
        { PureSize.Small, SmallButton },
        { PureSize.Medium, MediumButton },
        { PureSize.ExtraSmall, ExtraSmallButton }
    };

    public static readonly Dictionary<PureVariant, Dictionary<Accent, string>> Variants = new()
    {
        {
            PureVariant.Default,
            new()
            {
                { Accent.Brand, PrimaryButton },
                { Accent.Danger, DangerButton },
                { Accent.Warning, WarningButton },
                { Accent.Success, SuccessButton },
                { Accent.Default, DefaultButton }
            }
        },
        {
            PureVariant.Outline,
            new()
            {
                { Accent.Brand, PrimaryOutlineButton },
                { Accent.Danger, DangerOutlineButton },
                { Accent.Success, SuccessOutlineButton },
                { Accent.Warning, WarningOutlineButton },
                { Accent.Default, DefaultOutlineButton }
            }
        },
        {
            PureVariant.Subtle,
            new()
            {
                { Accent.Brand, PrimarySubtleButton },
                { Accent.Danger, DangerSubtleButton },
                { Accent.Success, SuccessSubtleButton },
                { Accent.Warning, WarningSubtleButton },
                { Accent.Default, DefaultSubtleButton }
            }
        }
    };

    public static string Base =>
        "flex justify-center items-center cursor-pointer gap-1 rounded-md focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-brand-900 border-1";
}

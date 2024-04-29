using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

public class AlertStyles
{
    // todo: change width of toast based on device, e.g. browser vs phone vs tablet
    public string Base =>
        "w-96 border-solid border-1 border-y-gray-200 border-r-gray-200 border-l-8 text-gray-900 bg-white shadow-md px-5 py-4 rounded mb-2 antialiased";

    public readonly Dictionary<Accent, string> Accents = new()
    {
        { Accent.Success, "border-l-green-500" },
        { Accent.Danger, "border-l-red-500" },
        { Accent.Brand, "border-l-brand-500" },
        { Accent.Warning, "border-l-yellow-500" },
        { Accent.Default, "border-l-gray-500" }
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

using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

public class ButtonStyles
{
    private const string ExtraSmallButton = "px-2.5 py-1.5 text-xs";
    private const string SmallButton = "px-3 py-2 text-xs";
    private const string MediumButton = "px-3.5 py-2.5 text-sm";
    private const string LargeButton = "px-4 py-3 text-lg";

    private const string PrimaryButton = "bg-brand-900 hover:bg-brand-950 text-gray-100";
    private const string DangerButton = "bg-red-800 hover:bg-red-800 text-gray-100";
    private const string SuccessButton = "bg-green-800 hover:bg-green-900 text-gray-100";

    private const string PrimaryOutlineButton = "border-gray-400 text-gray-800 hover:border-gray-400";
    private const string DangerOutlineButton = "border-red-400 text-gray-800 hover:border-red-400";
    private const string SuccessOutlineButton = "border-green-400 text-gray-800 hover:border-green-400";

    private const string PrimarySubtleButton = "bg-transparent hover:text-brand-900 hover:bg-gray-100 text-brand-800";
    private const string DangerSubtleButton = "bg-transparent hover:bg-red-800/20 text-gray-100";
    private const string SuccessSubtleButton = "bg-transparent hover:bg-green-900/20 text-gray-100";

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
                { Accent.Default, PrimaryOutlineButton }
            }
        },
        {
            ButtonVariant.Subtle,
            new Dictionary<Accent, string>
            {
                { Accent.Brand, PrimarySubtleButton },
                { Accent.Danger, DangerSubtleButton },
                { Accent.Success, SuccessSubtleButton },
                { Accent.Default, PrimarySubtleButton }
            }
        }
    };

    public string Base =>
        "inline-flex justify-center items-center gap-1 rounded-sm md:rounded-xs text-sm focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-brand-600 border border-transparent";
}

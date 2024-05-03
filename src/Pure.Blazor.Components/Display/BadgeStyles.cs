using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Display;

public class BadgeStyles
{
    private const string Primary = "border-1 border-transparent bg-brand-400 text-gray-950 font-semibold";
    private const string Danger = "border-1 border-transparent bg-red-800 text-gray-100 font-semibold";
    private const string Warning = "border-1 border-transparent bg-yellow-500 text-gray-900 font-semibold";
    private const string Success = "border-1 border-transparent bg-green-500 text-black font-semibold";
    private const string Default = "border-1 border-transparent bg-gray-600 text-gray-50 font-semibold";

    public static readonly Dictionary<PureVariant, Dictionary<Accent, string>> Variants = new()
    {
        {
            PureVariant.Default, new Dictionary<Accent, string>
            {
                { Accent.Brand, Primary },
                { Accent.Danger, Danger },
                { Accent.Warning, Warning },
                { Accent.Success, Success },
                { Accent.Default, Default }
            }
        },
        {
            PureVariant.Outline, new Dictionary<Accent, string>
            {
                { Accent.Brand, "border-1 border-brand-700 text-brand-700 font-bold" },
                { Accent.Danger, "border-1 border-red-800 text-red-800 font-bold" },
                { Accent.Warning, "border-1 border-yellow-700 text-yellow-800 font-bold" },
                { Accent.Success, "border-1 border-green-700 text-green-800 font-bold" },
                { Accent.Default, "border-1 border-gray-600 text-gray-600 font-bold" }
            }
        },
        {
            PureVariant.Subtle, new Dictionary<Accent, string>
            {
                { Accent.Brand, "border-1 border-transparent text-brand-700 font-bold" },
                { Accent.Danger, "border-1 border-transparent text-red-800 font-bold" },
                { Accent.Warning, "border-1 border-transparent text-yellow-800 font-bold" },
                { Accent.Success, "border-1 border-transparent text-green-800 font-bold" },
                { Accent.Default, "border-1 border-transparent text-gray-600 font-bold" }
            }
        }
    };
}

using Pure.Blazor.Components;

namespace Pure.Blazor.Components;

public class BannerStyles
{
    public static string Base => "p-3 border-1 border-gray-300 rounded-sm text-sm";

    public static readonly Dictionary<Accent, string> Container = new()
    {
        { Accent.Brand, "bg-brand-400 text-gray-900 font-bold" },
        { Accent.Danger, "bg-red-400" },
        { Accent.Success, "bg-green-400" },
        { Accent.Warning, "bg-yellow-400" },
        { Accent.Default, "bg-gray-300" }
    };

    public static readonly Dictionary<PureVariant, Dictionary<Accent, string>> Variants = new()
    {
        {
            PureVariant.Default, new Dictionary<Accent, string>
            {
                { Accent.Brand, "bg-brand-400 text-gray-900 font-bold" },
                { Accent.Danger, "bg-red-400" },
                { Accent.Success, "bg-green-400" },
                { Accent.Warning, "bg-yellow-100" },
                { Accent.Default, "bg-gray-300" }
            }
        },
        {
            PureVariant.Outline, new Dictionary<Accent, string>
            {
                { Accent.Brand, "border-1 border-brand-700 text-brand-800 font-bold" },
                { Accent.Danger, "border-1 border-red-800 text-red-800 font-bold" },
                { Accent.Warning, "border-1 border-yellow-700 text-yellow-800 font-bold" },
                { Accent.Success, "border-1 border-green-700 text-green-800 font-bold" },
                { Accent.Default, "border-1 border-gray-600 text-gray-800 font-bold" }
            }
        },
        {
            PureVariant.Subtle, new Dictionary<Accent, string>
            {
                { Accent.Brand, "border-1 border-transparent text-brand-700 font-bold" },
                { Accent.Danger, "border-1 border-transparent text-red-800 font-bold" },
                { Accent.Warning, "border-1 border-transparent text-yellow-800 font-bold" },
                { Accent.Success, "border-1 border-transparent text-green-800 font-bold" },
                { Accent.Default, "border-1 border-transparent text-gray-800 font-bold" }
            }
        }
    };
}

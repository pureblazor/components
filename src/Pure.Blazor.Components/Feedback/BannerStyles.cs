using Pure.Blazor.Components.Buttons;

namespace Pure.Blazor.Components.Banners;

public class BannerStyles
{
    public string Base => "p-3 border-1 rounded-sm text-sm";

    public readonly Dictionary<Accent, string> Container = new()
    {
        { Accent.Brand, "bg-brand-400 text-gray-900 font-bold" },
        { Accent.Danger, "bg-red-400" },
        { Accent.Success, "bg-green-400" },
        { Accent.Warning, "bg-yellow-400" },
        { Accent.Default, "bg-gray-300" }
    };
}

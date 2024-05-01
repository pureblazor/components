using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Feedback;

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

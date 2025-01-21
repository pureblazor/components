using System.Collections.Frozen;

namespace Pure.Blazor.Components;

using System.Collections.Immutable;

using System.Collections.Generic;
using System.Linq;

public class Pb
{
    /// <summary>
    /// Always-applied set of classes.
    /// </summary>
    public string? Base { get; set; }

    /// <summary>
    /// Stores multiple categories of variants. For example:
    ///
    /// {
    ///   ["variant"] = {
    ///       ["primary"] = "bg-blue-500 hover:bg-blue-600 text-white",
    ///       ["secondary"] = "bg-gray-200 hover:bg-gray-300 text-gray-900"
    ///   },
    ///   ["size"] = {
    ///       ["sm"] = "h-8 px-3 rounded-md text-sm",
    ///       ["lg"] = "h-10 px-5 rounded-md text-base"
    ///   }
    /// }
    ///
    /// This allows you to combine them as needed,
    /// e.g. (category: "variant", key: "primary") + (category: "size", key: "lg").
    /// </summary>
    public Dictionary<string, Dictionary<string, string>> VariantsByCategory { get; set; }
        = new Dictionary<string, Dictionary<string, string>>();

    /// <summary>
    /// Generates a final class string by merging `Base` plus matching classes
    /// from each of the category-variant pairs.
    ///
    /// Example usage:
    ///   GenerateClass(("variant", "primary"), ("size", "lg"))
    /// </summary>
    /// <param name="selections">
    /// An array of (Category, Key) pairs, e.g. ("variant", "primary"), ("size", "sm").
    /// </param>
    /// <returns>A space-separated string of classes.</returns>
    public string GenerateClass(params (string Category, string? Key)[] selections)
    {
        var combined = new List<string>();

        // 1. Always add the base classes if present
        if (!string.IsNullOrWhiteSpace(Base))
        {
            combined.Add(Base);
        }

        // 2. For each (category, key) pair, look up and add the matching classes
        foreach (var (category, key) in selections)
        {
            if (string.IsNullOrWhiteSpace(key))
                continue;

            if (VariantsByCategory.TryGetValue(category, out var categoryDict)
                && categoryDict.TryGetValue(key, out var classes)
                && !string.IsNullOrWhiteSpace(classes))
            {
                combined.Add(classes);
            }
        }

        // 3. (Optional) remove duplicates so we don’t accidentally produce
        //    "bg-blue-500 bg-blue-500" or conflicting overrides.
        // combined = combined.SelectMany(s => s.Split(' '))
        //                    .Distinct()
        //                    .ToList();

        return string.Join(" ", combined);
    }
}



public record ComponentStyle
{
    public IReadOnlyDictionary<Accent, string> Accents;
    public IReadOnlyDictionary<PureVariant, Dictionary<Accent, string>> Variants;
    public IReadOnlyDictionary<PureSize, string> Sizes;
    public string Disabled { get; set; } = "opacity-50 cursor-not-allowed";

    public ComponentStyle(string baseStyle)
    {
        this.Accents = new Dictionary<Accent, string>();
        this.Variants = new Dictionary<PureVariant, Dictionary<Accent, string>>();
        this.Sizes = new Dictionary<PureSize, string>();
        Base = baseStyle;
    }

    /// <summary>
    /// Basic style applied to the outer container of the component.
    /// </summary>
    public string Base { get; set; }

    /// <summary>
    /// Optional advanced style for the outer container of the component.
    /// Not all components with an outer container have this, only if the outer container requires Accent or Variant
    /// modifications.
    /// </summary>
    public ComponentStyle? OuterContainer { get; set; }

    /// <summary>
    /// Optional advanced style for the inner container of the component. Not all components have an inner container.
    /// </summary>
    public ComponentStyle? InnerContainer { get; set; }

    public string Accent(Accent accent)
    {
        return Accents.TryGetValue(accent, out var value) ? value : string.Empty;
    }

    public string Variant(PureVariant variant, Accent accent)
    {
        if (Variants.TryGetValue(variant, out var value) && value.TryGetValue(accent, out var style))
        {
            return style;
        }

        return string.Empty; // or return a default style
    }

    public string Size(PureSize size)
    {
        return Sizes.TryGetValue(size, out var value) ? value : string.Empty;
    }
}

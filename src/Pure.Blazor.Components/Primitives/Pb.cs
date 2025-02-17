namespace Pure.Blazor.Components;

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
        = new();

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

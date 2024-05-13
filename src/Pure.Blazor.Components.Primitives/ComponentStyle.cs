namespace Pure.Blazor.Components.Primitives;

public record ComponentStyle
{
    public readonly IReadOnlyDictionary<Accent, string> Accents;
    public readonly IReadOnlyDictionary<PureVariant, Dictionary<Accent, string>> Variants;
    public readonly IReadOnlyDictionary<PureSize, string> Sizes;
    public string Disabled { get; set; } = "opacity-50 cursor-not-allowed";

    public ComponentStyle(string baseStyle,
        IReadOnlyDictionary<Accent, string>? accents,
        IReadOnlyDictionary<PureVariant, Dictionary<Accent, string>>? variants,
        IReadOnlyDictionary<PureSize, string>? sizes)
    {
        this.Accents = accents ?? new Dictionary<Accent, string>();
        this.Variants = variants ?? new Dictionary<PureVariant, Dictionary<Accent, string>>();
        this.Sizes = sizes ?? new Dictionary<PureSize, string>();
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

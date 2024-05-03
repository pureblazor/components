namespace Pure.Blazor.Components.Primitives;

public interface IPureTheme
{
    public IStylePrioritizer StylePrioritizer { get; set; }
    public Dictionary<string, ComponentStyle> Styles { get; set; }

    public ComponentStyle GetStyle(Type type)
    {
        return GetStyleByName(type.Name);
    }

    public ComponentStyle GetStyleByName(string name)
    {
        // TODO: decide if we want this to be an exceptional event
        return Styles.GetValueOrDefault(name) ?? new ComponentStyle("", null, null, null);
    }
}

public enum PureVariant
{
    Default,
    Outline,
    Subtle
}

public enum Accent
{
    Default,
    Brand,
    Success,
    Danger,
    Warning,
}

public class ComponentStyle
{
    private readonly IReadOnlyDictionary<Accent, string> accents;
    private readonly IReadOnlyDictionary<PureVariant, Dictionary<Accent, string>> variants;
    private readonly IReadOnlyDictionary<PureSize, string> sizes;

    public ComponentStyle(string baseStyle,
        IReadOnlyDictionary<Accent, string>? accents,
        IReadOnlyDictionary<PureVariant, Dictionary<Accent, string>>? variants,
        IReadOnlyDictionary<PureSize, string>? sizes)
    {
        this.accents = accents ?? new Dictionary<Accent, string>();
        this.variants = variants ?? new Dictionary<PureVariant, Dictionary<Accent, string>>();
        this.sizes = sizes ?? new Dictionary<PureSize, string>();
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
        return accents.TryGetValue(accent, out var value) ? value : string.Empty;
    }

    public string Variant(PureVariant variant, Accent accent)
    {
        if (variants.TryGetValue(variant, out var value) && value.TryGetValue(accent, out var style))
        {
            return style;
        }

        return string.Empty; // or return a default style
    }

    public string Size(PureSize size)
    {
        return sizes.TryGetValue(size, out var value) ? value : string.Empty;
    }
}

namespace PureBlazor.Components;

/// <summary>
/// Built-in variants for Pb components. These variants are not scoped to a specific component,
/// but rather provided for a better dev experience. Some components may not support all variants.
///
/// For example, a button may support Primary, Secondary, Destructive, Outline, Ghost, but a
/// card may only support Primary, Secondary.
/// </summary>
public enum Variants
{
    Primary,
    Secondary,
    Destructive,
    Outline,
    Ghost,
}


namespace Pure.Blazor.Components.Primitives;

/// <summary>
/// Animation effects that can be applied to any component that supports it.
/// </summary>
public enum Effect
{
    /// <summary>
    /// Unset effect. Default values will be inherited from ancestors.
    /// </summary>
    Unset,

    /// <summary>
    /// Explicitly indicates no effect.
    /// </summary>
    None,

    // what's the best name here?
    Jiggle,

    /// <summary>
    /// Fade in and out effect.
    /// </summary>
    Pulse,

    /// <summary>
    ///
    /// </summary>
    Ping,

    // TODO: https://github.com/pureblazor/components/issues/57
    //Ripple,

    /// <summary>
    /// Applies an inset shadow effect.
    /// </summary>
    InsetShadow
}

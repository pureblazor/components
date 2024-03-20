namespace Pure.Blazor.Components;

public enum EntryMode
{
    Default,

    /// <summary>
    /// Receive model updates immediately, as the user types.
    /// </summary>
    Immediate,

    /// <summary>
    /// Receive model updates when the input loses focus.
    /// </summary>
    Blur
}
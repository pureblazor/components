using Pure.Blazor.Components;

namespace Pure.Blazor.Components;

public class ShowDialogOptions
{
    public object? Model { get; set; }
    public Func<DialogEvent, ValueTask>? OnEvent { get; set; }

    /// <summary>
    ///     The text displayed on the affirmative button.
    /// </summary>
    public string? AckButton { get; set; }

    public Accent? AckColor { get; set; }
}

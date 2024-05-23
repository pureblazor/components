using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Dialogs;

public class ShowDialogOptions
{
    public Func<DialogResult, Task>? OnEvent { get; set; }
    public Func<DialogResult, Task<DialogEventResult>>? OnConfirm { get; set; }

    /// <summary>
    ///     The text displayed on the affirmative button.
    /// </summary>
    public string? AckButton { get; set; }

    public Accent? AckColor { get; set; }
}
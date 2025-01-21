using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components;

public record DialogEventResult
{
    /// <summary>
    /// The message text to display in the dialog. For example, an error message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// The message fragment (component) to display in the dialog.
    /// </summary>
    public RenderFragment? MessageFragment { get; set; }

    /// <summary>
    /// If specified, the dialog will continue with the specified fragment. This is useful
    /// for showing a dialog with multiple chained steps.
    /// </summary>
    public DialogInstance? ContinueWith { get; set; }

    public bool Interrupted { get; set; }

    public static DialogEventResult Confirmed => new() { Interrupted = false };
    public static DialogEventResult Canceled => new() { Interrupted = true };

    public static DialogEventResult Error(string message) =>
        new() { Interrupted = true, Message = message };

    public static DialogEventResult Error(RenderFragment? messageFragment = null) =>
        new() { Interrupted = true, MessageFragment = messageFragment };
}

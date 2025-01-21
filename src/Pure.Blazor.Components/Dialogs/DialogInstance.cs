using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components;

namespace Pure.Blazor.Components;

public class DialogInstance
{
    public DialogInstance()
    {
    }

    public DialogInstance(string dialogId)
    {
        DialogId = dialogId;
    }

    /// <summary>
    ///     Used to track which dialog to show/close
    /// </summary>
    internal string? DialogId { get; set; }

    /// <summary>
    /// Fires for dialog events, such as confirm, cancel, dismiss, etc.
    ///
    /// If the OnConfirm event is set, this event will not be fired for the confirm event.
    /// </summary>
    public Func<DialogEvent, ValueTask>? OnEvent { get; set; }

    public string? Title { get; set; }
    public object? Model { get; set; }
    public RenderFragment? Body { get; set; }
    public string AckButton { get; set; } = DialogDefaults.AckButton;
    public Accent AckColor { get; set; } = DialogDefaults.AckColor;
    public bool Locked { get; set; }

    public Task ShowAsync(string title, RenderFragment body, ShowDialogOptions? options = null)
    {
        Title = title;
        Body = body;
        Model = options?.Model;

        AckButton = options?.AckButton ?? DialogDefaults.AckButton;
        AckColor = options?.AckColor ?? DialogDefaults.AckColor;

        DialogId = "component";
        OnEvent = options?.OnEvent;

        return Task.CompletedTask;
    }

    public async ValueTask ConfirmAsync()
    {
        if (OnEvent is null)
        {
            return;
        }

        await OnEvent.Invoke(DialogEvent.Confirm);
    }

    public async ValueTask CancelAsync()
    {
        if (OnEvent is null)
        {
            return;
        }

        await OnEvent.Invoke(DialogEvent.Cancel);
    }
}

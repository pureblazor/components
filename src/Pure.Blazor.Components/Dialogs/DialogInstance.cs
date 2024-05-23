using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Dialogs;

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
    public Func<DialogResult, Task>? OnEvent { get; set; }

    /// <summary>
    /// Fires for affirmative button clicks, providing the caller with the dialog result and
    /// allowing them to interrupt the dialog process. For example, to show an error message
    /// that the user must correct or acknowledge before continuing.
    /// </summary>
    public Func<DialogResult, Task<DialogEventResult>>? OnConfirm { get; set; }

    public string? Title { get; set; }
    public RenderFragment? Body { get; set; }
    public string AckButton { get; set; } = DialogDefaults.AckButton;
    public Accent AckColor { get; set; } = DialogDefaults.AckColor;
    public bool Locked { get; set; }

    public Task ShowAsync(string title, RenderFragment body, ShowDialogOptions? options = null)
    {
        Title = title;
        Body = body;
        AckButton = options?.AckButton ?? DialogDefaults.AckButton;
        AckColor = options?.AckColor ?? DialogDefaults.AckColor;

        DialogId = "component";
        OnEvent = options?.OnEvent;
        OnConfirm = options?.OnConfirm;

        return Task.CompletedTask;
    }

    public async Task<DialogEventResult> ConfirmAsync()
    {
        var res = DialogEventResult.Confirmed;
        if (OnConfirm is not null)
        {
            res = await OnConfirm(new DialogResult(DialogEvent.Confirm));
            if (res.Interrupted)
            {
                return res;
            }
        }
        else
        {
            OnEvent?.Invoke(new DialogResult(DialogEvent.Confirm));
        }

        // module ??= await js.Razor("Dialogs/PureDialog");
        // await module.InvokeVoidAsync("closeDialog", objRef, instance.DialogId);

        Reset();
        return res;
    }

    public Task CancelAsync()
    {
        OnEvent?.Invoke(new DialogResult(DialogEvent.Cancel));
        // module ??= await js.Razor("Dialogs/PureDialog");
        // await module.InvokeVoidAsync("closeDialog", objRef, instance.DialogId);

        Reset();

        return Task.CompletedTask;
    }

    private void Reset()
    {
        // DialogId = "";
        // Title = null;
        // Body = null;
        // DialogId = "";
        // OnEvent = null;
        // OnConfirm = null;
    }
}

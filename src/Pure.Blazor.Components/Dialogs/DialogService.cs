using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Dialogs;

public class DialogService
{
    private readonly ILogger<DialogService> log;
    private readonly DotNetObjectReference<DialogService> objRef;
    private readonly IJSRuntime js;
    private IJSObjectReference? module;

    public DialogService(IJSRuntime js, ILogger<DialogService> log)
    {
        this.js = js;
        this.log = log;
        objRef = DotNetObjectReference.Create(this);
    }

    // public bool IsOpen { get; set; }
    public event Action<DialogInstance>? OnOpen;

    /// <summary>
    /// Invoked by the JavaScript module when the dialog is closed.
    /// </summary>
    /// <param name="returnValue"></param>
    /// <returns></returns>
    [JSInvokable]
    public Task CloseAsync(string returnValue)
    {
        // instance.OnEvent?.Invoke(new DialogResult(DialogEvent.Dismiss));
        // IsOpen = false;
        return Task.CompletedTask;
    }


    public async Task ShowDialog(string title, RenderFragment body, ShowDialogOptions? options = null)
    {
        log.LogDebug("ShowDialog requested");
        var instance = new DialogInstance();
        await instance.ShowAsync(title, body, options);

        OnOpen?.Invoke(instance);
        module ??= await js.Razor("Dialogs/PureDialog");

        await module.InvokeVoidAsync("showDialog", objRef, instance.DialogId);
    }

    public async Task CloseDialogAsync(DialogInstance instance)
    {
        // await js.InvokeVoidAsync("closeDialog", objRef, instance.DialogId);
        module ??= await js.Razor("Dialogs/PureDialog");
        await module.InvokeVoidAsync("closeDialog", objRef, instance.DialogId);
    }

    public async Task<DialogEventResult> ConfirmDialogAsync(DialogInstance instance)
    {
        var res = await instance.ConfirmAsync();
        if (res.Interrupted)
        {
            return res;
        }

        await CloseDialogAsync(instance);

        return res;
    }

    public async Task CancelDialogAsync(DialogInstance instance)
    {
        await CloseDialogAsync(instance);
        await instance.CancelAsync();
    }
}

internal class DialogDefaults
{
    public const string AckButton = "Continue";
    public static readonly Accent AckColor = Accent.Brand;
}

public record DialogResult(DialogEvent Event);

public enum DialogEvent
{
    Dismiss,
    Confirm,
    Cancel,
}

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

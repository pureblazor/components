using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Pure.Blazor.Components;

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
        return Task.CompletedTask;
    }

    public ValueTask ShowDialogAsync(string title, RenderFragment body,
        Func<DialogEvent, ValueTask> onEvent)
    {
        return ShowDialogAsync(title, body, new ShowDialogOptions() { OnEvent = onEvent });
    }

    public async ValueTask ShowDialogAsync(string title, RenderFragment body, ShowDialogOptions? options = null)
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
        module ??= await js.Razor("Dialogs/PureDialog");
        await module.InvokeVoidAsync("closeDialog", objRef, instance.DialogId);
    }

    internal async Task ConfirmDialogAsync(DialogInstance instance)
    {
        await CloseDialogAsync(instance);
        await instance.ConfirmAsync();
    }

    public async Task CancelDialogAsync(DialogInstance instance)
    {
        await CloseDialogAsync(instance);
        await instance.CancelAsync();
    }
}

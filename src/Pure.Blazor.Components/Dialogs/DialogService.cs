using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Pure.Blazor.Components.Common;

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


    public async Task ShowDialogAsync(string title, RenderFragment body, ShowDialogOptions? options = null)
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

    internal async Task<DialogEventResult> ConfirmDialogAsync(DialogInstance instance)
    {
        try
        {
            var res = await instance.ConfirmAsync();
            if (res.Interrupted)
            {
                return res;
            }

            await CloseDialogAsync(instance);

            return res;
        }
        catch (Exception ex)
        {
            log.LogError(ex, "Error confirming dialog");
        }

        return new ();
    }

    public async Task CancelDialogAsync(DialogInstance instance)
    {
        await CloseDialogAsync(instance);
        await instance.CancelAsync();
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Dialogs;

/// <summary>
/// </summary>
/// <remarks>
///     Supports a single dialog at a time.
/// </remarks>
public class DialogService
{
    // private readonly Dictionary<string, DialogInstance> dialogs = new();
    private readonly DialogInstance _instance = new();

    private readonly ILogger<DialogService> log;
    private readonly DotNetObjectReference<DialogService> objRef;
    private readonly IJSRuntime JS;
    private IJSObjectReference? module;

    public DialogService(IJSRuntime js, ILogger<DialogService> log)
    {
        JS = js;
        this.log = log;
        objRef = DotNetObjectReference.Create(this);
    }

    public string? Title { get; private set; }
    public RenderFragment? Body { get; private set; }
    public string AckButton { get; private set; } = DialogDefaults.AckButton;
    public static Accent AckColor { get; private set; } = DialogDefaults.AckColor;
    public bool IsOpen { get; set; }
    public event Action? OnOpen;

    [JSInvokable]
    public Task<int[]> ReturnArrayAsync() => Task.FromResult(new[] { 1, 2, 3 });

    [JSInvokable]
    public Task CloseAsync(string returnValue)
    {
        _instance.OnEvent?.Invoke(new DialogResult(DialogEvent.Dismiss));
        IsOpen = false;
        return Task.CompletedTask;
    }

    public async Task ShowConfirmDialog(string title, Func<DialogResult, Task<DialogEventResult>> onEvent)
    {
        Title = title;
        AckButton = DialogDefaults.AckButton;
        AckColor = DialogDefaults.AckColor;

        _instance.OnEvent = onEvent;
        _instance.DialogId = "confirm";
        OnOpen?.Invoke();
        module ??= await JS.Razor("Dialogs/PureDialog");

        await module.InvokeVoidAsync("showDialog", objRef, _instance.DialogId);
        IsOpen = true;
    }

    public async Task ShowConfirmDialog(string title, ShowDialogOptions? options = null)
    {
        log.LogDebug("Showing confirmation dialog.");

        Title = title;
        AckButton = options?.AckButton ?? DialogDefaults.AckButton;
        AckColor = options?.AckColor ?? DialogDefaults.AckColor;

        _instance.OnEvent = options?.OnEvent;
        _instance.DialogId = "confirm";
        OnOpen?.Invoke();
        log.LogDebug("Invoking JS module...");
        module ??= await JS.Razor("Dialogs/PureDialog");
        log.LogDebug("Invoking JS...");

        try
        {
            await module.InvokeVoidAsync("showDialog", objRef, _instance.DialogId);
        }
        catch (Exception ex)
        {
            log.LogError(ex, "failed to show dialog");
        }

        log.LogDebug("Invoked JS...");
        IsOpen = true;
    }

    public async Task ShowDialog(string title, RenderFragment body, ShowDialogOptions? options = null)
    {
        log.LogDebug("ShowDialog requested");
        Title = title;
        Body = body;
        AckButton = options?.AckButton ?? DialogDefaults.AckButton;
        AckColor = options?.AckColor ?? DialogDefaults.AckColor;

        _instance.DialogId = "component";
        _instance.OnEvent = options?.OnEvent;
        OnOpen?.Invoke();
        module ??= await JS.Razor("Dialogs/PureDialog");

        await module.InvokeVoidAsync("showDialog", objRef, _instance.DialogId);
        IsOpen = true;
    }

    public async Task CloseDialogAsync()
    {
        await JS.InvokeVoidAsync("closeDialog", objRef, _instance.DialogId);
        IsOpen = false;
    }

    public async Task<DialogEventResult> ConfirmDialogAsync()
    {
        log.LogDebug("Confirmed dialog");
        var res = DialogEventResult.Confirmed;
        if (_instance.OnEvent is not null)
        {
            res = await _instance.OnEvent(new DialogResult(DialogEvent.Confirm));
            if (res.Interrupted)
            {
                return res;
            }
        }

        // _instance.OnConfirm?.Invoke(new DialogResult());
        module ??= await JS.Razor("Dialogs/PureDialog");
        await module.InvokeVoidAsync("closeDialog", objRef, _instance.DialogId);

        _instance.DialogId = "";
        Body = null;
        _instance.OnEvent = null;
        return res;
    }

    public async Task CancelDialogAsync()
    {
        _instance.OnEvent?.Invoke(new DialogResult(DialogEvent.Cancel));
        module ??= await JS.Razor("Dialogs/PureDialog");
        await module.InvokeVoidAsync("closeDialog", objRef, _instance.DialogId);

        // TODO: may make sense to move body/title and such to _instance
        Body = null;
        _instance.DialogId = "";
        _instance.OnEvent = null;
        IsOpen = false;
    }

    private class DialogDefaults
    {
        public const string AckButton = "Continue";
        public static readonly Accent AckColor = Accent.Brand;
    }
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
    public Func<DialogResult, Task<DialogEventResult>>? OnEvent { get; set; }


    /// <summary>
    ///     The text displayed on the affirmative button.
    /// </summary>
    public string? AckButton { get; set; }

    public Accent? AckColor { get; set; }
}

public class DialogInstance
{
    /// <summary>
    ///     Used to track which dialog to show/close
    /// </summary>
    internal string? DialogId { get; set; }

    public Func<DialogResult, Task<DialogEventResult>>? OnEvent { get; set; }
}

public record DialogEventResult
{
    public string? Message { get; set; }
    public RenderFragment? MessageFragment { get; set; }
    public bool Interrupted { get; set; }

    public static DialogEventResult Confirmed => new() { Interrupted = false };
    public static DialogEventResult Canceled => new() { Interrupted = true };

    public static DialogEventResult Error(string message) =>
        new() { Interrupted = true, Message = message };

    public static DialogEventResult Error(RenderFragment? messageFragment = null) =>
        new() { Interrupted = true, MessageFragment = messageFragment };
}

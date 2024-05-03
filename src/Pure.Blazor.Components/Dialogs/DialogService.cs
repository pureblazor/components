using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Pure.Blazor.Components.Buttons;
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
        _instance.OnClose?.Invoke();
        IsOpen = false;
        return Task.CompletedTask;
    }

    public async Task ShowConfirmDialog(string title, Action onConfirm, Action? onCancel = null)
    {
        Title = title;
        AckButton = DialogDefaults.AckButton;
        AckColor = DialogDefaults.AckColor;

        _instance.OnConfirm = onConfirm;
        _instance.OnCancel = onCancel;
        _instance.DialogId = "confirm";
        OnOpen?.Invoke();
        module ??= await JS.Razor("Dialogs/PureDialog");

        await module.InvokeVoidAsync("showDialog", objRef, _instance.DialogId);
        IsOpen = true;
    }

    public async Task ShowConfirmDialog(string title, ShowDialogOptions? options = null)
    {
        log.LogInformation("Showing confirmation dialog.");

        Title = title;
        AckButton = options?.AckButton ?? DialogDefaults.AckButton;
        AckColor = options?.AckColor ?? DialogDefaults.AckColor;

        _instance.OnClose = options?.OnClose;
        _instance.OnConfirm = options?.OnConfirm;
        _instance.OnCancel = options?.OnCancel;
        _instance.DialogId = "confirm";
        OnOpen?.Invoke();
        log.LogInformation("Invoking JS module...");
        module ??= await JS.Razor("Dialogs/PureDialog");
        log.LogInformation("Invoking JS...");

        try
        {
            await module.InvokeVoidAsync("showDialog", objRef, _instance.DialogId);
        }
        catch (Exception ex)
        {
            log.LogError(ex, "failed to show dialog");
        }

        log.LogInformation("Invoked JS...");
        IsOpen = true;
    }

    public async Task ShowDialog(string title, RenderFragment body, ShowDialogOptions? options = null)
    {
        log.LogInformation("ShowDialog requested");
        Title = title;
        Body = body;
        AckButton = options?.AckButton ?? DialogDefaults.AckButton;
        AckColor = options?.AckColor ?? DialogDefaults.AckColor;

        _instance.DialogId = "component";
        _instance.OnClose = options?.OnClose;
        _instance.OnConfirm = options?.OnConfirm;
        _instance.OnCancel = options?.OnCancel;
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

    public async Task ConfirmDialogAsync()
    {
        log.LogInformation("Confirmed dialog");
        _instance.OnConfirm?.Invoke();
        module ??= await JS.Razor("Dialogs/PureDialog");
        await module.InvokeVoidAsync("closeDialog", objRef, _instance.DialogId);

        _instance.DialogId = "";
        Body = null;
        _instance.OnClose = null;
        _instance.OnConfirm = null;
        _instance.OnCancel = null;
    }

    public async Task CancelDialogAsync()
    {
        _instance.OnCancel?.Invoke();
        module ??= await JS.Razor("Dialogs/PureDialog");
        await module.InvokeVoidAsync("closeDialog", objRef, _instance.DialogId);

        // TODO: may make sense to move body/title and such to _instance
        Body = null;
        _instance.DialogId = "";
        _instance.OnClose = null;
        _instance.OnConfirm = null;
        _instance.OnCancel = null;
        IsOpen = false;
    }

    private class DialogDefaults
    {
        public const string AckButton = "Continue";
        public static readonly Accent AckColor = Accent.Brand;
    }
}

public class ShowDialogOptions
{
    /// <summary>
    ///     Fires when the dialog is closed.
    /// </summary>
    public Action? OnClose { get; set; }

    /// <summary>
    ///     Fires when the dialog is cancelled.
    ///     e.g. by pressing the escape key, or clicking outside the dialog, or clicking the cancel button.
    /// </summary>
    public Action? OnCancel { get; set; }

    /// <summary>
    ///     Fires when the affirmative button is clicked.
    /// </summary>
    public Action? OnConfirm { get; set; }

    /// <summary>
    ///     The text displayed on the affirmative button.
    /// </summary>
    public string? AckButton { get; set; }

    public Accent? AckColor { get; set; }
}

public class DialogInstance
{
    /// <summary>
    ///     Fires when the dialog is closed.
    /// </summary>
    public Action? OnClose { get; set; }

    /// <summary>
    ///     Fires when the dialog is cancelled.
    ///     e.g. by pressing the escape key, or clicking outside the dialog, or clicking the cancel button.
    /// </summary>
    public Action? OnCancel { get; set; }

    /// <summary>
    ///     Fires when the affirmative button is clicked.
    /// </summary>
    public Action? OnConfirm { get; set; }

    /// <summary>
    ///     Used to track which dialog to show/close
    /// </summary>
    internal string? DialogId { get; set; }
}

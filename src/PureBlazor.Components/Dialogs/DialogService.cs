using Microsoft.Extensions.Options;
using Microsoft.JSInterop;

namespace PureBlazor.Components.Dialogs;

/// <summary>
///
/// </summary>
/// <remarks>
/// Supports a single dialog at a time.
/// </remarks>
public class DialogService
{
    private class DialogDefaults
    {
        public const string AckButton = "Continue";
        public static ColorWithShade AckColor = PureColor.Brand.Seven;
    }

    public event Action OnOpen;

    public string Title { get; private set; }
    public string AckButton { get; private set; } = DialogDefaults.AckButton;
    public static ColorWithShade AckColor { get; private set; } = DialogDefaults.AckColor;

    private readonly IJSRuntime JS;
    private readonly DotNetObjectReference<DialogService> _objRef;
    private readonly DialogInstance _instance = new();

    public DialogService(IJSRuntime js)
    {
        JS = js;
        _objRef = DotNetObjectReference.Create(this);
    }

    [JSInvokable]
    public Task<int[]> ReturnArrayAsync()
    {
        return Task.FromResult(new int[] { 1, 2, 3 });
    }

    [JSInvokable]
    public Task CloseAsync(string returnValue)
    {
        _instance.OnClose?.Invoke();
        return Task.CompletedTask;
    }

    public async Task ShowDialogAsync(string title, Action onConfirm, Action? onCancel = null)
    {
        Title = title;
        AckButton = DialogDefaults.AckButton;
        AckColor = DialogDefaults.AckColor;

        _instance.OnConfirm = onConfirm;
        _instance.OnCancel = onCancel;
        OnOpen?.Invoke();
        await JS.InvokeVoidAsync("showDialog", _objRef, "confirm");
    }

    public async Task ShowDialogAsync(string title, ShowDialogOptions? options = null)
    {
        Title = title;
        AckButton = options?.AckButton ?? DialogDefaults.AckButton;
        AckColor = options?.AckColor ?? DialogDefaults.AckColor;

        _instance.OnClose = options?.OnClose;
        _instance.OnConfirm = options?.OnConfirm;
        _instance.OnCancel = options?.OnCancel;
        OnOpen?.Invoke();

        await JS.InvokeVoidAsync("showDialog", _objRef, "confirm");
    }

    public async Task CloseDialogAsync()
    {
        await JS.InvokeVoidAsync("closeDialog", _objRef, "confirm");
    }

    public async Task ConfirmDialogAsync()
    {
        _instance.OnConfirm?.Invoke();
        await JS.InvokeVoidAsync("closeDialog", _objRef, "confirm");
    }

    public async Task CancelDialogAsync()
    {
        _instance.OnCancel?.Invoke();
        await JS.InvokeVoidAsync("closeDialog", _objRef, "confirm");
    }
}

public class ShowDialogOptions
{
    /// <summary>
    /// Fires when the dialog is closed.
    /// </summary>
    public Action? OnClose { get; set; }

    /// <summary>
    /// Fires when the dialog is cancelled.
    /// e.g. by pressing the escape key, or clicking outside the dialog, or clicking the cancel button.
    /// </summary>
    public Action? OnCancel { get; set; }

    /// <summary>
    /// Fires when the affirmative button is clicked.
    /// </summary>
    public Action? OnConfirm { get; set; }

    /// <summary>
    /// The text displayed on the affirmative button.
    /// </summary>
    public string? AckButton { get; set; }
    public ColorWithShade? AckColor { get; set; }
}

public class DialogInstance
{
    /// <summary>
    /// Fires when the dialog is closed.
    /// </summary>
    public Action? OnClose { get; set; }

    /// <summary>
    /// Fires when the dialog is cancelled.
    /// e.g. by pressing the escape key, or clicking outside the dialog, or clicking the cancel button.
    /// </summary>
    public Action? OnCancel { get; set; }

    /// <summary>
    /// Fires when the affirmative button is clicked.
    /// </summary>
    public Action? OnConfirm { get; set; }
}

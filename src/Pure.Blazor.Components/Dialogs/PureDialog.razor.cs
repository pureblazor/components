using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components.Dialogs;

public partial class PureDialog
{
    public string? Message { get; set; }
    public RenderFragment? MessageFragment { get; set; }
    [Inject] public required DialogService DialogService { get; set; }
    public bool IsConfirming { get; set; }
    public bool IsCanceling { get; set; }

    protected override void OnInitialized()
    {
        DialogService.OnOpen += () => StateHasChanged();
    }

    public async Task CancelAsync()
    {
        IsCanceling = true;
        await DialogService.CancelDialogAsync();
    }

    public async Task ConfirmAsync()
    {
        Message = "Saving...";
        IsConfirming = true;
        var result = await DialogService.ConfirmDialogAsync();
        Message = result.Message;
        MessageFragment = result.MessageFragment;
        IsConfirming = false;
    }
}

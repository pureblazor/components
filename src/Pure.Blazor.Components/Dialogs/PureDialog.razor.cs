using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components;

public partial class PureDialog
{
    public string? Message { get; set; }
    public RenderFragment? MessageFragment { get; set; }
    [Inject] public required DialogService DialogService { get; set; }
    private DialogInstance? dialog;

    protected override void OnInitialized()
    {
        DialogService.OnOpen += (d) =>
        {
            dialog = d;
            MessageFragment = null;
            Message = null;
            StateHasChanged();
        };
    }

    public async Task CancelAsync()
    {
        if (dialog is null)
        {
            return;
        }

        dialog.Locked = true;
        await DialogService.CancelDialogAsync(dialog);
    }

    public async Task ConfirmAsync()
    {
        if (dialog is null)
        {
            return;
        }

        Message = "Saving...";
        dialog.Locked = true;
        await DialogService.ConfirmDialogAsync(dialog);
        // if (result.Interrupted && result.ContinueWith is not null)
        // {
        //     dialog = result.ContinueWith;
        //     MessageFragment = null;
        //     Message = null;
        //     StateHasChanged();
        // }
        // else if (result.Interrupted)
        // {
        //     Message = result.Message;
        //     MessageFragment = result.MessageFragment;
        // }

        dialog.Locked = false;
    }
}

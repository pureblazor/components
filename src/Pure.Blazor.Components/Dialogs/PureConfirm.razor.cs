using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Pure.Blazor.Components.Dialogs;

public partial class PureConfirm
{
    [Inject] public required DialogService DialogService { get; set; }
    [Inject] public required ILogger<PureConfirm> Logger { get; set; }
    private DialogInstance? dialog;

    protected override void OnInitialized()
    {
        DialogService.OnOpen += (d) =>
        {
            dialog = d;
            StateHasChanged();
        };
    }

    public async Task CancelAsync()
    {
        if (dialog is null)
        {
            return;
        }

        await DialogService.CancelDialogAsync(dialog);
    }

    public async Task ConfirmAsync()
    {
        if (dialog is null)
        {
            return;
        }

        await DialogService.ConfirmDialogAsync(dialog);
    }
}

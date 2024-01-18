using Microsoft.AspNetCore.Components;

namespace PureBlazor.Components.Dialogs;

public partial class PureDialog
{
    [Inject]
    public required DialogService DialogService { get; set; }

    protected override void OnInitialized()
    {
        DialogService.OnOpen += () => StateHasChanged();
    }

    public async Task CancelAsync()
    {
        await DialogService.CancelDialogAsync();
    }

    public async Task ConfirmAsync()
    {
        await DialogService.ConfirmDialogAsync();
    }
}

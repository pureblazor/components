using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Pure.Blazor.Components.Dialogs;

public partial class PureConfirm
{
    [Inject]
    public required DialogService DialogService { get; set; }
[Inject]
public required ILogger<PureConfirm> Logger { get; set; }
    protected override void OnInitialized()
    {
        Logger.LogInformation("OnInitialized()");
        DialogService.OnOpen += StateHasChanged;
        Logger.LogInformation("DialogService.OnOpen += StateHasChanged");
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

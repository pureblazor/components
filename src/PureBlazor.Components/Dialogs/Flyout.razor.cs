using Microsoft.AspNetCore.Components;

namespace PureBlazor.Components.Dialogs;

public partial class Flyout
{
    [Parameter]
    public bool IsOpen { get; set; }

    [Parameter]
    public EventCallback OnDismiss { get; set; }
}
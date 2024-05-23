using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components.Dialogs;

public partial class PureFlyout
{
    [Parameter]
    public bool IsOpen { get; set; }

    [Parameter] public required string Title { get; set; }
    [Parameter] public string? Subtitle { get; set; }
    [Parameter] public RenderFragment? Actions { get; set; }

    [Parameter]
    public EventCallback OnDismiss { get; set; }

    public async Task Dismiss()
    {
        IsOpen = false;
        await OnDismiss.InvokeAsync();
    }
}

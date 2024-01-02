using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace PureBlazor.Components.Dialogs;

public partial class Flyout
{
    [Parameter]
    public bool IsOpen { get; set; }

    [Parameter]
    public EventCallback OnDismiss { get; set; }
}

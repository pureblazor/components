using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components.Buttons;

public partial class PureButton
{
    [Parameter] public RenderFragment? LeftIcon { get; set; }

    [Parameter] public RenderFragment? RightIcon { get; set; }
}

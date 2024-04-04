using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Icons;

namespace Pure.Blazor.Components.Buttons;

public partial class PureButton
{
    [Parameter] public PureIcons? LeftIcon { get; set; }

    [Parameter] public PureIcons? RightIcon { get; set; }
}

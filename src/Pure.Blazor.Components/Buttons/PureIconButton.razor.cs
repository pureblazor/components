using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Icons;

namespace Pure.Blazor.Components.Buttons;

public partial class PureIconButton
{
    [Parameter] public PureIcons Icon { get; set; }

    protected override void BuildCss()
    {
        InternalCss = ApplyStyle(
            $"{PureTheme.Button.Base} {PureTheme.Button.Variants[Variant][Accent]} {PureTheme.Button.Sizes[Size]}");
    }
}

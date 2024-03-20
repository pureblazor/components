using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Icons;

namespace Pure.Blazor.Components.Buttons;

public partial class PureIconButton
{
    [Parameter] public PureIcons Icon { get; set; }

    protected override string BuildCss() =>
        $"{PureStyles.Button.Base} {PureStyles.Button.Variants[Variant][Accent]} {PureStyles.Button.Sizes[Size]}";
}

using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Icons;

namespace Pure.Blazor.Components.Buttons;

public partial class PureIconButton
{
    [Parameter] public PureIcons Icon { get; set; }

    protected override void BuildCss()
    {
        InternalCss = ApplyStyle(
            $"{Css.Base} {Css.Variant(Variant, Accent)} {Css.Size(Size)}");
    }
}

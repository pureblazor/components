using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

public class PureButtonBase : PureComponent
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; } =
        new() { { "type", "button" } };

    protected bool Pressed { get; set; }
    protected string? InternalCss { get; private set; }

    [Parameter] public PureSize Size { get; set; } = PureSize.Medium;

    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Default;

    [Parameter] public Accent Accent { get; set; }

    [Parameter] public bool Loading { get; set; }

    /// <summary>
    ///     Displays simple text on the button.
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter] public bool Disabled { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        InternalCss = BuildCss();
    }

    protected void OnClicked(MouseEventArgs e)
    {
        if (Disabled)
        {
            return;
        }

        OnClick.InvokeAsync();
    }

    protected virtual string BuildCss() => Theme != Theme.Off
        ? $"{PureStyles.Button.Base} {PureStyles.Button.Variants[Variant][Accent]} {PureStyles.Button.Sizes[Size]}"
        : "";
}

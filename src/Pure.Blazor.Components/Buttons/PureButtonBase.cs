using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Pure.Blazor.Components.Common;

namespace Pure.Blazor.Components.Buttons;

public class PureButtonBase : PureComponent
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; } =
        new() { { "type", "button" } };
    [Parameter] public PureSize Size { get; set; } = PureSize.Medium;
    [Parameter] public ButtonVariant Variant { get; set; } = ButtonVariant.Default;
    [Parameter] public Accent Accent { get; set; }

    [Parameter]
    public string? Name { get; set; }

    /// <summary>
    ///     Indicate the button is in a loading state
    /// </summary>
    [Parameter]
    public bool Loading { get; set; }

    /// <summary>
    ///     Optional text to display when the button is loading.
    /// </summary>
    [Parameter]
    public string? LoadingText { get; set; }

    /// <summary>
    ///     Displays simple text on the button.
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter] public bool Disabled { get; set; }
    [Inject] public ILogger<PureButtonBase>? Logger { get; set; }
    protected string? InternalCss { get; set; }
    protected void OnClicked(MouseEventArgs e)
    {
        if (Disabled)
        {
            return;
        }

        OnClick.InvokeAsync();
    }

    protected override void BuildCss()
    {
        InternalCss = ApplyStyle(
            $"{PureTheme.Button.Base} {PureTheme.Button.Variants[Variant][Accent]} {PureTheme.Button.Sizes[Size]}");
    }
}

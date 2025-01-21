using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components;

namespace Pure.Blazor.Components;

public class PureButtonBase : PureComponent
{
    [Parameter] public string? Id { get; set; }
    [Parameter] public ButtonType ButtonType { get; set; }
    [Parameter] public PureSize Size { get; set; } = PureSize.Medium;
    [Parameter] public PureVariant Variant { get; set; }
    [Parameter] public Accent Accent { get; set; }
    [Parameter] public string? Title { get; set; }
    [Parameter] public string? Name { get; set; }

    /// <summary>
    /// Labels the button for accessibility if no child content is provided.
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

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

    [Parameter] public string? Value { get; set; }

    [Parameter] public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter] public bool StopPropagation { get; set; }
    [Parameter] public bool Disabled { get; set; }
    protected string? InternalCss { get; set; }

    protected void OnClicked(MouseEventArgs e)
    {
        if (Disabled || Loading)
        {
            return;
        }

        OnClick.InvokeAsync(e);
    }

    protected override void BuildCss()
    {
        if (Theme == Theme.Off)
        {
            InternalCss = "";
            return;
        }

        InternalCss =
            ApplyStyle(
                $"{Css.Base} {Css.Variant(Variant, Accent)} {Css.Size(Size)} {(Disabled || Loading ? Css.Disabled : "")}");
    }
}

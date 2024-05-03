using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components.Primitives;

public class PureComponent : ComponentBase
{
    protected override void OnParametersSet()
    {
        // todo: figure out how to build css less
        BuildCss();
    }

    /// <summary>
    ///     Add additional css classes to this component
    /// </summary>
    [Parameter]
    public string? Styles { get; set; }

    /// <summary>
    ///     Disables or enables the theme. Default is Auto, which means the theme is inherited from the parent component.
    /// </summary>
    [CascadingParameter]
    public Theme Theme { get; set; } = Theme.Auto;

    /// <summary>
    ///     The current theme styles
    /// </summary>
    [CascadingParameter]
    public required IPureTheme PureTheme { get; set; }

    [Parameter] public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Outer CSS is applied to the outermost element of the component.
    /// </summary>
    protected string? OuterCss { get; set; }

    /// <summary>
    /// Hook for all components to build their css. This is called automatically.
    /// </summary>
    protected virtual void BuildCss()
    {
    }

    /// <summary>
    /// Gets the component style from the theme for the specific type of component.
    /// </summary>
    protected ComponentStyle Css => PureTheme.GetStyle(GetType());

    protected ComponentStyle CssStyle(string name) => PureTheme.GetStyleByName(name);

    /// <summary>
    /// Applies the style based on the theme settings.
    ///
    /// If the theme is off, only user defined styles are applied.
    /// If the theme is on, the user defined styles are applied on top of the theme styles and override them where necessary.
    /// </summary>
    /// <param name="style"></param>
    /// <returns></returns>
    protected virtual string ApplyStyle(string? style)
    {
        if (Theme == Theme.Off)
        {
            return Styles ?? "";
        }

        if (style == null)
        {
            return Styles ?? "";
        }

        if (PureTheme?.StylePrioritizer != null && Styles != null)
        {
            return PureTheme.StylePrioritizer.PrioritizeStyles(style, Styles);
        }

        return $"{style} {Styles}";
    }
}

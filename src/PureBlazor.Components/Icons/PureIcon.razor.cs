using Microsoft.AspNetCore.Components;

namespace PureBlazor.Components.Icons;

public partial class PureIcon
{
    [Parameter]
    public required PureIcons Type { get; set; }

    [Parameter]
    public PureSize Size { get; set; } = PureSize.Medium;

    [Parameter]
    public PureAnimate Animate { get; set; } = PureAnimate.None;

    [Parameter]
    public string Css { get; set; } = "";

    private string InternalCss => BuildCss();

    private MarkupString Markup => BuildMarkup();

    public MarkupString BuildMarkup()
    {
        var path = Type switch
        {
            PureIcons.IconCheck => "<path stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m4.5 12.75 6 6 9-13.5\" />",
            PureIcons.IconSpin => "<path stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M16.023 9.348h4.992v-.001M2.985 19.644v-4.992m0 0h4.992m-4.993 0 3.181 3.183a8.25 8.25 0 0 0 13.803-3.7M4.031 9.865a8.25 8.25 0 0 1 13.803-3.7l3.181 3.182m0-4.991v4.99\" />",
            PureIcons.IconChevronDoubleLeft => "<path stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m18.75 4.5-7.5 7.5 7.5 7.5m-6-15L5.25 12l7.5 7.5\" />",
            PureIcons.IconChevronLeft => "<path stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"M15.75 19.5 8.25 12l7.5-7.5\" />",
            PureIcons.IconChevronDoubleRight => "<path stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m5.25 4.5 7.5 7.5-7.5 7.5m6-15 7.5 7.5-7.5 7.5\" />",
            PureIcons.IconChevronRight => "<path stroke-linecap=\"round\" stroke-linejoin=\"round\" d=\"m8.25 4.5 7.5 7.5-7.5 7.5\" />",
            _ => ""
        };

        return (MarkupString)path;
    }

    private string BuildCss()
    {
        var css = Size switch
        {
            PureSize.ExtraSmall => "w-3 h-3",
            PureSize.Small => "w-4 h-4",
            PureSize.Medium => "w-5 h-5",
            PureSize.Large => "w-6 h-6",
            PureSize.ExtraLarge => "w-7 h-7",
            _ => "w-6 h-6"
        };

        if (Animate == PureAnimate.Spin)
        {
            css = $"{css} animate-spin";
        }

        return css;
    }
}

public enum PureIcons
{
    IconCheck,
    IconSpin,
    IconChevronDoubleLeft,
    IconChevronLeft,
    IconChevronDoubleRight,
    IconChevronRight,
}

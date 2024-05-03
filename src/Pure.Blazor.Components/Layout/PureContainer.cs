using Microsoft.AspNetCore.Components.Rendering;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Layout;

public class PureContainer : PureComponent
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var baseStyles = "md:container mx-auto px-4";
        var styles = ApplyStyle(baseStyles);
        builder.OpenElement(0, "div");
        builder.AddAttribute(1, "class", styles);
        builder.AddContent(2, ChildContent);
        builder.CloseElement();
    }
}

public enum PureContainerType
{
    Fixed,
    Fluid
}

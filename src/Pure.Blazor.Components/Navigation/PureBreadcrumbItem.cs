using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace Pure.Blazor.Components;

public class PureBreadcrumbItem : PureComponent
{
    private const string separator = " / ";
    [Parameter] public string? Href { get; set; }
    [Parameter] public string? Name { get; set; }
    [CascadingParameter] public required PureBreadcrumb Parent { get; set; }

    protected override void OnInitialized()
    {
        Parent.AddBreadcrumb(this);
    }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        var last = IsLast();
        RenderFragment content = ChildContent ?? (b =>
        {
            b.OpenElement(0, "span");
            b.AddContent(1, Name);
            b.CloseElement();
        });
        builder.OpenElement(0, "li");

        if (last)
        {
            builder.AddAttribute(1, "aria-current", "page");
        }

        builder.OpenElement(2, "div");
        builder.AddAttribute(3, "class", "flex items-center");
        if (!IsFirst())
        {
         builder.AddContent(4, separator);
         // builder.OpenComponent<PureIcon>(4);
         // builder.AddComponentParameter(5, "Icon", PureIcons.IconChevronRight);
         // builder.AddComponentParameter(6, "Size", PureSize.Small);
         // builder.AddComponentParameter(7, "Styles", "rtl:rotate-180");
         // builder.CloseComponent();
        }

        if (last)
        {
            builder.OpenRegion(8);
            builder.OpenElement(1, "span");
            builder.AddAttribute(2, "class", "ms-1 text-sm text-gray-800/90 md:ms-2");
            builder.AddContent(3, content);
            builder.CloseElement();
            builder.CloseRegion();
        }
        else
        {
            builder.OpenRegion(9);
            builder.OpenComponent<PureLink>(1);
            builder.AddComponentParameter(2, "Href", Href);
            builder.AddComponentParameter(3, "Styles", "ms-1 md:ms-2 text-sm text-brand-800");
            builder.AddComponentParameter(4, "ChildContent", content);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        builder.CloseElement();
        builder.CloseElement();
    }

    private bool IsFirst()
    {
        return Parent.Breadcrumbs.IndexOf(this) == 0;
    }

    private bool IsLast()
    {
        return Parent.Breadcrumbs.IndexOf(this) == Parent.Breadcrumbs.Count - 1;
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components.Icons;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Buttons;

public class PureButton : PureButtonBase
{
    [Parameter] public PureIcons? LeftIcon { get; set; }

    [Parameter] public PureIcons? RightIcon { get; set; }

    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        builder.OpenElement(0, "button");
        builder.AddAttributeIfNotNullOrEmpty(1, "id", Id);
        builder.AddAttributeIfNotNullOrEmpty(2, "aria-label", Label);

        if (Disabled)
        {
            builder.AddAttribute(3, "disabled", "disabled");
        }

        builder.AddAttribute(4, "onclick", EventCallback.Factory.Create<MouseEventArgs>(this, OnClicked));

        var buttonType = ButtonType switch
        {
            ButtonType.Submit => "submit",
            ButtonType.Button => "button",
            _ => ""
        };

        builder.AddAttributeIfNotNullOrEmpty(5, "type", buttonType);
        builder.AddAttributeIfNotNullOrEmpty(6, "name", Name);
        builder.AddAttributeIfNotNullOrEmpty(7, "title", Title);
        builder.AddAttributeIfNotNullOrEmpty(8, "value", Value);
        builder.AddAttributeIfNotNullOrEmpty(9, "class", ApplyStyle(InternalCss));
        if (StopPropagation)
        {
            builder.AddEventPreventDefaultAttribute(10, "onclick", true);
            builder.AddEventStopPropagationAttribute(11, "onclick", true);
        }

        if (LeftIcon is not null)
        {
            builder.OpenRegion(12);
            builder.OpenComponent<PureIcon>(1);
            builder.AddAttribute(2, "Icon", LeftIcon);
            builder.AddAttribute(3, "Size", Size);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        if (LoadingText is not null && Loading)
        {
            builder.AddContent(13, LoadingText);
        }
        else if (ChildContent is not null)
        {
            builder.AddContent(14, ChildContent);
        }
        else
        {
            builder.AddContent(15, Text);
        }

        if (RightIcon is not null)
        {
            builder.OpenRegion(16);
            builder.OpenComponent<PureIcon>(1);
            builder.AddAttribute(2, "Icon", RightIcon);
            builder.AddAttribute(3, "Size", Size);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        builder.CloseElement();
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components.Icons;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Buttons;

public enum ButtonPressEffect
{
    None,

    // what's the best name here?
    Jiggle,

    Ripple,
}

public class PureButton : PureButtonBase
{
    public bool IsPressed { get; set; }

    [Parameter] public PureIcons? LeftIcon { get; set; }

    [Parameter] public PureIcons? RightIcon { get; set; }

    private void SetPressed(bool pressed)
    {
        Console.WriteLine($"Setting IsPressed to {pressed}");
        IsPressed = pressed;
    }

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
        builder.AddAttribute(5, "onmousedown", EventCallback.Factory.Create<MouseEventArgs>(this, () => SetPressed(true)));
        builder.AddAttribute(6, "onmouseup", EventCallback.Factory.Create<MouseEventArgs>(this, () => SetPressed(false)));
        var buttonType = ButtonType switch
        {
            ButtonType.Submit => "submit",
            ButtonType.Button => "button",
            _ => ""
        };

        builder.AddAttributeIfNotNullOrEmpty(7, "type", buttonType);
        builder.AddAttributeIfNotNullOrEmpty(8, "name", Name);
        builder.AddAttributeIfNotNullOrEmpty(9, "title", Title);
        builder.AddAttributeIfNotNullOrEmpty(10, "value", Value);

        Console.WriteLine($"Rendering IsPressed: {IsPressed}");
        builder.AddAttributeIfNotNullOrEmpty(11, "class", $"{ApplyStyle(InternalCss)} {(IsPressed ? "translate-y-px" : "translate-y-0")}");
        if (StopPropagation)
        {
            builder.AddEventPreventDefaultAttribute(12, "onclick", true);
            builder.AddEventStopPropagationAttribute(13, "onclick", true);
        }

        if (LeftIcon is not null)
        {
            builder.OpenRegion(14);
            builder.OpenComponent<PureIcon>(1);
            builder.AddAttribute(2, "Icon", LeftIcon);
            builder.AddAttribute(3, "Size", Size);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        if (LoadingText is not null && Loading)
        {
            builder.AddContent(15, LoadingText);
        }
        else if (ChildContent is not null)
        {
            builder.AddContent(16, ChildContent);
        }
        else
        {
            builder.AddContent(17, Text);
        }

        if (RightIcon is not null)
        {
            builder.OpenRegion(18);
            builder.OpenComponent<PureIcon>(1);
            builder.AddAttribute(2, "Icon", RightIcon);
            builder.AddAttribute(3, "Size", Size);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        builder.CloseElement();
    }
}

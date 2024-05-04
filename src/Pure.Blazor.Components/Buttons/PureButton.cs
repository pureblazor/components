using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Pure.Blazor.Components.Icons;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Buttons;

public class PureButton : PureButtonBase
{
    private bool IsPressed { get; set; }

    [Parameter] public PureIcons? LeftIcon { get; set; }
    [Parameter] public PureIcons? RightIcon { get; set; }
    [Parameter] public Effect PressEffect { get; set; }
    [Parameter] public Effect HoverEffect { get; set; }

    private void SetPressed(bool pressed)
    {
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
        if (PressEffect is not Effect.None || PureTheme.ButtonDefaults.PressEffect is not Effect.None)
        {
            builder.AddAttribute(5, "onmousedown",
                EventCallback.Factory.Create<MouseEventArgs>(this, () => SetPressed(true)));
            builder.AddAttribute(6, "onmouseup",
                EventCallback.Factory.Create<MouseEventArgs>(this, () => SetPressed(false)));
        }


        var effect = HoverEffect;
        if (effect is Effect.Unset)
        {
            effect = PureTheme.ButtonDefaults.HoverEffect;
        }

        var hoverEffectCss = GetHoverEffect(effect);
        var buttonType = ButtonType switch
        {
            ButtonType.Submit => "submit",
            ButtonType.Button => "button",
            _ => ""
        };

        var pressEffect = PressEffect;
        if (pressEffect is Effect.Unset)
        {
            pressEffect = PureTheme.ButtonDefaults.PressEffect;
        }

        var pressEffectCss = GetPressEffect(pressEffect, IsPressed);

        builder.AddAttributeIfNotNullOrEmpty(10, "type", buttonType);
        builder.AddAttributeIfNotNullOrEmpty(11, "name", Name);
        builder.AddAttributeIfNotNullOrEmpty(12, "title", Title);
        builder.AddAttributeIfNotNullOrEmpty(13, "value", Value);

        builder.AddAttributeIfNotNullOrEmpty(14, "class",
            $"{ApplyStyle(InternalCss)} {pressEffectCss} {hoverEffectCss}");
        if (StopPropagation)
        {
            builder.AddEventPreventDefaultAttribute(15, "onclick", true);
            builder.AddEventStopPropagationAttribute(16, "onclick", true);
        }

        if (LeftIcon is not null)
        {
            builder.OpenRegion(17);
            builder.OpenComponent<PureIcon>(1);
            builder.AddAttribute(2, "Icon", LeftIcon);
            builder.AddAttribute(3, "Size", Size);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        if (LoadingText is not null && Loading)
        {
            builder.AddContent(18, LoadingText);
        }
        else if (ChildContent is not null)
        {
            builder.AddContent(19, ChildContent);
        }
        else
        {
            builder.AddContent(20, Text);
        }

        if (RightIcon is not null)
        {
            builder.OpenRegion(21);
            builder.OpenComponent<PureIcon>(1);
            builder.AddAttribute(2, "Icon", RightIcon);
            builder.AddAttribute(3, "Size", Size);
            builder.CloseComponent();
            builder.CloseRegion();
        }

        builder.CloseElement();
    }

    private static string GetPressEffect(Effect effect, bool pressed)
    {
        return effect switch
        {
            Effect.Jiggle when pressed => "motion-safe:translate-y-px",
            Effect.Jiggle => "translate-y-0",
            Effect.Pulse when pressed => "animate-pulse",
            Effect.Ping when pressed => "motion-safe:animate-ping",
            Effect.InsetShadow when pressed => "shadow-inner",
            Effect.InsetShadow => "shadow-none",
            _ => ""
        };
    }

    private static string GetHoverEffect(Effect effect)
    {
        return effect switch
        {
            Effect.Jiggle => "motion-safe:hover:translate-y-px",
            Effect.Pulse => "hover:animate-pulse",
            Effect.Ping => "motion-safe:hover:animate-ping",
            _ => ""
        };
    }
}

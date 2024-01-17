﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using PureBlazor.Components.Styling;

namespace PureBlazor.Components.Buttons;

public class PureButtonBase : ComponentBase
{
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; } =
    new()
    {
        {"type", "button" }
    };

    protected bool Pressed { get; set; }
    protected string? InternalCss { get; set; }

    [Parameter]
    public PureSize Size { get; set; } = PureSize.Medium;

    [Parameter]
    public ColorWithShade Color { get; set; } = PureColor.Neutral;

    [Parameter]
    public ButtonVariant Variant { get; set; } = ButtonVariant.Filled;

    [Parameter]
    public PureSize Radius { get; set; } = PureSize.ExtraSmall;

    [Parameter]
    public bool Uppercase { get; set; }

    [Parameter]
    public bool Loading { get; set; }

    [Parameter]
    public string? Styles { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        InternalCss = BuildCss();
    }

    public void OnClicked(MouseEventArgs e)
    {
        if (Disabled)
        {
            return;
        }

        OnClick.InvokeAsync();
    }

    public virtual string BuildCss()
    {
        var builder = TailwindBuilder.New();

        switch (Variant)
        {
            case ButtonVariant.Filled:
                builder.AddBackground(Color).AddClasses("text-white");
                builder.AddBackgroundHover(Color.Eight);
                break;
            case ButtonVariant.Outline:
                builder.AddBorder(Color).SetFontColor(Color);
                break;
            case ButtonVariant.Default:
                builder.AddBorder(PureColor.Neutral).SetFontColor(PureColor.Neutral.Six);
                break;
            case ButtonVariant.Subtle:
                builder.AddBackgroundHover(Color.Two).SetFontColor(Color);
                break;
            default:
                break;
        }

        builder = AddPadding(builder).SetFontSize(Size);

        if (Uppercase)
        {
            builder = builder.AddTextTransform(TextTransform.Uppercase);
        }

        builder.AddClasses("rounded-sm font-semibold");

        if (Disabled)
        {
            //builder.AddClasses("");
        }

        return builder.Build();
    }

    internal TailwindBuilder AddPadding(TailwindBuilder builder)
    {
        return Size switch
        {
            PureSize.ExtraSmall => builder.AddPadding(2.5, 1.5),
            PureSize.Small => builder.AddPadding(3, 2),
            PureSize.Medium => builder.AddPadding(3.5, 2.5),
            PureSize.Large => builder.AddPadding(4, 3),
            _ => builder.AddPadding(3, 2),
        };
    }
}
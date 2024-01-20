﻿using Microsoft.AspNetCore.Components;

namespace PureBlazor.Components.Buttons;

public interface IButtonProps
{
    /// <summary>
    /// Size of the button
    /// </summary>
    public PureSize Size { get; set; }

    /// <summary>
    /// Color of the button
    /// </summary>
    public ColorWithShade Color { get; set; }

    /// <summary>
    /// Adds icon before button text
    /// </summary>
    public RenderFragment? LeftIcon { get; set; }

    /// <summary>
    /// Adds icon after button text
    /// </summary>
    public RenderFragment? RightIcon { get; set; }

    /// <summary>
    /// Controls the border radius of the button
    /// </summary>
    public PureSize Radius { get; set; }

    /// <summary>
    /// Sets the button text to uppercase
    /// </summary>
    public bool Uppercase { get; set; }

    /// <summary>
    /// Indicates the loading state
    /// </summary>
    public bool Loading { get; set; }

    /// <summary>
    /// Button label contents
    /// </summary>
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Custom styles to apply to the component
    /// </summary>
    public string Styles { get; set; }
}

public enum ButtonVariant
{
    Default,
    Filled,
    Outline,
    Light,
    White,
    Subtle
}

public enum TabVariant
{
    Default,
    Outline
}

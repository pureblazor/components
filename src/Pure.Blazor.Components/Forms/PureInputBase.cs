using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Primitives;
using Pure.Core.Abstractions;

namespace Pure.Blazor.Components.Forms;

public class PureInputBase : PureComponent
{
    private string currentValue = "";

    /// <summary>
    /// ID attribute for the input element. Defaults to a unique ID.
    /// </summary>
    [Parameter]
    public string Id { get; set; } = $"entry-{Uuid.New()}";

    /// <summary>
    ///     Optional label (recommended)
    /// </summary>
    [Parameter]
    public string? Label { get; set; }

    /// <summary>
    ///     Optional helper text
    /// </summary>
    [Parameter]
    public string? HelperText { get; set; }

    /// <summary>
    /// The name attribute for the input element.
    /// </summary>
    [Parameter]
    public string? Name { get; set; }

    [Parameter]
    public string Value
    {
        get => currentValue;
        set { currentValue = value; }
    }

    [Parameter] public EventCallback<string> ValueChanged { get; set; }
}

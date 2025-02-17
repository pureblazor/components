using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components;

public partial class Switch
{
    public override Task SetParametersAsync(ParameterView parameters)
    {
        return base.SetParametersAsync(parameters);
    }

    protected override bool TryParseValueFromString(string? value, out bool result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        if (bool.TryParse(value, out result))
        {
            validationErrorMessage = null;
            return true;
        }

        validationErrorMessage = $"The {FieldIdentifier.FieldName} field must be a boolean.";
        return false;
    }

    /// <summary>
    /// Toggles the Value manually when the user clicks on the container.
    /// </summary>
    private void ToggleValue()
    {
        Value = !Value;
        ValueChanged.InvokeAsync(Value);
        // Value = !Value;
        // ValueChanged.InvokeAsync(Value);
    }

    // /// <summary>
    // /// Handles the actual input change event so that changes
    // /// from clicking or keyboard events will propagate.
    // /// </summary>
    // private void OnValueChanged(ChangeEventArgs e)
    // {
    //     if (bool.TryParse(e.Value?.ToString(), out bool newValue))
    //     {
    //         Value = newValue;
    //         ValueChanged.InvokeAsync(Value);
    //     }
    // }

    /// <summary>
    /// Container classes replicate the Shadcn structure:
    /// relative inline-flex items-center cursor-pointer ...
    /// </summary>
    private string ContainerClasses => """
        relative inline-flex h-[24px] w-[44px] shrink-0
        cursor-pointer items-center rounded-full
        border-2 border-transparent transition-colors
        duration-200 ease-in-out
        peer-focus:outline-none peer-focus:ring-2
        peer-focus:ring-ring peer-focus:ring-offset-2
    """;

    /// <summary>
    /// Track classes for the background color changes (off/on).
    /// You can adjust these based on your brand colors or design.
    /// </summary>
    private string TrackClasses =>
        CurrentValue
            ? """
              block h-6 w-11 bg-primary absolute
              peer-focus:outline-none
              rounded-full transition-colors
              """
            : """
              block h-6 w-11 bg-gray-200 absolute
              peer-focus:outline-none
              rounded-full transition-colors
              """;

    /// <summary>
    /// Thumb classes. The transform will move the thumb to the right
    /// when the switch is on, or left when off.
    /// This is how Shadcn accomplishes the toggle effect with a single
    /// HTML element.
    /// </summary>
    private string ThumbClasses =>
        $"""
        pointer-events-none block h-5 w-5 rounded-full bg-white
        shadow-lg ring-0 transition-transform duration-200
        {(CurrentValue ? "translate-x-5" : "translate-x-0")}
        """;
}

using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components;

namespace Pure.Blazor.Components;

public partial class PureDropdown
{
    // todo: use source generator to generate the script path
    protected override string ScriptPath => "Buttons/PureDropdown.razor";

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? TitleFragment { get; set; }

    /// <summary>
    ///     Position (side) to open the dropdown menu.
    /// </summary>
    [Parameter]
    public DropdownPosition Position { get; set; } = DropdownPosition.Left;

    [Parameter] public PureSize Size { get; set; } = PureSize.Medium;

    // /// <summary>
    // ///     Returns the menu item selected.
    // /// </summary>
    // [Parameter]
    // public EventCallback<DropdownMenuItem> OnItemSelected { get; set; }
}

public enum DropdownPosition
{
    Left,
    Right
}

using Microsoft.AspNetCore.Components;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Icons;

namespace Pure.Blazor.Components.Buttons;

public partial class PureDropdown
{
    // todo: use source generator to generate the script path
    protected override string ScriptPath => "Buttons/PureDropdown.razor";

    /// <summary>
    ///     Position (side) to open the dropdown menu.
    /// </summary>
    [Parameter]
    public DropdownPosition Position { get; set; } = DropdownPosition.Left;

    [Parameter] public PureSize Size { get; set; } = PureSize.Medium;
    [Parameter] public PureIcons Icon { get; set; } = PureIcons.IconChevronUpDown;
    [Parameter] public RenderFragment? Menu { get; set; }

    /// <summary>
    ///     Dropdown menu items.
    /// </summary>
    [Parameter]
    public List<DropdownMenuItem> Items { get; set; } = new();

    /// <summary>
    ///     Returns the menu item selected.
    /// </summary>
    [Parameter]
    public EventCallback<DropdownMenuItem> OnItemSelected { get; set; }
}

public enum DropdownPosition
{
    Left,
    Right
}

// todo: move to it's own file and update references
public class DropdownMenuItem
{
    /// <summary>
    ///     The text to display on the menu item.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    ///     The value to send to the server.
    /// </summary>
    public string? Value { get; set; }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PureBlazor.Components.Utilities;

namespace PureBlazor.Components.Buttons;

public partial class PureDropdown
{
    [Inject]
    public IElementUtils Utils { get; set; } = null!;

    /// <summary>
    /// Inner content for the dropdown button.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// Position (side) to open the dropdown menu.
    /// </summary>
    [Parameter]
    public DropdownPosition Position { get; set; } = DropdownPosition.Left;

    /// <summary>
    /// Dropdown menu items.
    /// </summary>
    [Parameter]
    public List<DropdownMenuItem> Items { get; set; } = new();

    /// <summary>
    /// Returns the menu item selected.
    /// </summary>
    [Parameter]
    public EventCallback<DropdownMenuItem> OnItemSelected { get; set; }

    public async Task OnItemClick(MouseEventArgs args, DropdownMenuItem item)
    {
        await Utils.Blur();

        await OnItemSelected.InvokeAsync(item);
    }
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
    /// The text to display on the menu item.
    /// </summary>
    public string? Text { get; set; }

    /// <summary>
    /// The value to send to the server.
    /// </summary>
    public string? Value { get; set; }
}

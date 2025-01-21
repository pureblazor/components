using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components;

public partial class PurePaginationItem
{
    [Parameter]
    public int Value { get; set; }

    /// <summary>
    /// Whether the current item should be rendered as the 'active' page.
    /// </summary>
    [Parameter]
    public bool Active { get; set; }

    /// <summary>
    /// Disables the control; preventing it from being clicked.
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    [Parameter]
    public EventCallback<int> OnClick { get; set; }
    public async Task OnElementClick(MouseEventArgs args) => await OnClick.InvokeAsync(Value);


}

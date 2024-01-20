using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace PureBlazor.Components.Pagination;

public partial class PurePaginationItem
{
    [Parameter]
    public int Value { get; set; }

    [Parameter]
    public bool Active { get; set; }

    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// Inner content for the Pagination Button.
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    [Parameter]
    public EventCallback<int> OnClick { get; set; }

    public async Task OnElementClick(MouseEventArgs args) => await OnClick.InvokeAsync(Value);
}
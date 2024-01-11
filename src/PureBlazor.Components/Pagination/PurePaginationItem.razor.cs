using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using PureBlazor.Components.Styling;
using System.Drawing;

namespace PureBlazor.Components.Pagination;

public partial class PurePaginationItem
{
    [Parameter]
    public int Value { get; set; }

    [Parameter]
    /// <summary>
    /// Whether the current item should be rendered as the 'active' page.
    /// </summary>
    public bool Active { get; set; }

    [Parameter]
    /// <summary>
    /// Disables the control; preventing it from being clicked.
    /// </summary>
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

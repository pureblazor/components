using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using PureBlazor.Components.Styling;

namespace PureBlazor.Components.Buttons;

public partial class PureButton
{

    [Parameter]
    public RenderFragment? LeftIcon { get; set; }

    [Parameter]
    public RenderFragment? RightIcon { get; set; }
}

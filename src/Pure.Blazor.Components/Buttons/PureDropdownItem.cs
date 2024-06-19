using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Primitives;

namespace Pure.Blazor.Components.Buttons;

public class PureDropdownItem : InteropComponent
{
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
        if (OnItemSelected.HasDelegate)
        {
            builder.OpenElement(0, "button");
            builder.AddAttribute(1, "type", "button");
            // builder.AddEventPreventDefaultAttribute(2, "onclick", true);
            // builder.AddEventStopPropagationAttribute(3, "onclick", true);
            builder.AddAttribute(4, "class", ApplyStyle($"{Css.Base} {Css.Size(Parent.Size)} {Css.Accent(Accent)}"));
            builder.AddAttribute(5, "role", "menuitem");
            builder.AddAttribute(6, "tabindex", "-1");
            builder.AddAttribute(7, "onclick",
                EventCallback.Factory.Create<MouseEventArgs>(this, OnItemClick));
            builder.AddContent(8, ChildContent);
            builder.CloseElement();
        }
        else
        {
            builder.OpenElement(0, "div");
            builder.AddAttribute(4, "class", ApplyStyle($"{Css.Base} {Css.Size(Parent.Size)} {Css.Accent(Accent)}"));
            builder.AddAttribute(5, "role", "menuitem");
            builder.AddAttribute(6, "tabindex", "-1");
            builder.AddContent(8, ChildContent);
            builder.CloseElement();
        }
    }

    // todo: use source generator to generate the script path
    protected override string ScriptPath => "Buttons/PureDropdown.razor";

    [CascadingParameter, EditorRequired] public required PureDropdown Parent { get; set; }

    [Parameter] public EventCallback<string> OnItemSelected { get; set; }

    [Parameter] public Accent Accent { get; set; }

    private async Task OnItemClick(MouseEventArgs _)
    {
        Logger.LogTrace("Dropdown item clicked");
        await OnItemSelected.InvokeAsync();
        try
        {
            await Module.InvokeVoidAsync("blur");
        }
        catch (Exception e)
        {
            Logger.LogError(e, "Failed to close dropdown item");
        }
    }
}

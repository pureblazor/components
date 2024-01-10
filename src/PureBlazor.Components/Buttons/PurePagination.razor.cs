using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using PureBlazor.Components.Styling;
using System.Drawing;

namespace PureBlazor.Components.Buttons;

public partial class PurePagination
{
    ///// <summary>
    ///// Inner content for the dropdown button.
    ///// </summary>
    //[Parameter]
    //public RenderFragment? ChildContent { get; set; }
    [Parameter]
    public int Total { get; set; }
    [Parameter]
    public int Value { get; set; }
    [Parameter]
    public EventCallback<int> OnChange { get; set; }


    public string PageItemCss(int page)
    {
        var builder = TailwindBuilder.New();
        var current = page == Value;

        builder.AddClasses("flex items-center justify-center px-3 h-8 ms-0 leading-tight text-gray-500 bg-white border border-e-0 border-gray-300 rounded-s-lg hover:bg-gray-100 hover:text-gray-700 dark:bg-gray-800 dark:border-gray-700 dark:text-gray-400 dark:hover:bg-gray-700 dark:hover:text-white");

        return builder.Build();
    }

    public async Task OnElementClick(MouseEventArgs args, int page)
    {
        await OnChange.InvokeAsync(page)
    }
}

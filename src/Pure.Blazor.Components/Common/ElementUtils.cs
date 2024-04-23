using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Pure.Blazor.Components.Common;

public class ElementUtils : IElementUtils
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private readonly IJSRuntime JS;

    public ElementUtils(IJSRuntime jsRuntime)
    {
        _moduleTask = new Lazy<Task<IJSObjectReference>>(jsRuntime.Script("pureblazor"));

        JS = jsRuntime;
    }

    /// <summary>
    ///     Blurs the active element.
    /// </summary>
    /// <returns></returns>
    public async ValueTask Blur()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("blurActive");
    }

    public async ValueTask<string> GetInnerHTML(ElementReference reference)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string>("getInnerHTML", reference);
    }

    public async ValueTask ScrollToFragment(string elementId)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("scrollToFragment", elementId);
    }

    /// <summary>
    ///     Blurs the supplied element.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public async ValueTask Blur(ElementReference element)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("blur", element);
    }
}

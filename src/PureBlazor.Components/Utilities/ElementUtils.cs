using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PureBlazor.Components.Utilities;

public interface IElementUtils
{
    ValueTask Blur();
    ValueTask ChangeDarkMode(bool on);
    ValueTask<bool> IsDarkMode();
    ValueTask ScrollToFragment(string elementId);
    ValueTask<string> GetInnerHTML(ElementReference reference);
}

public class ElementUtils : IElementUtils
{
    //private readonly Lazy<Task<IJSObjectReference>> _moduleTask;
    private readonly IJSRuntime JS;
    public ElementUtils(IJSRuntime jsRuntime)
    {
        JS = jsRuntime;
        //_moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
        //    "import", "./_content/PureBlazor.Components/makani.js").AsTask());
    }

    /// <summary>
    /// Blurs the active element.
    /// </summary>
    /// <returns></returns>
    public async ValueTask Blur()
    {
        //var module = await _moduleTask.Value;

        await JS.InvokeVoidAsync("blurActive");
    }

    public async ValueTask<string> GetInnerHTML(ElementReference reference)
    {
        return await JS.InvokeAsync<string>("getInnerHTML", reference);
    }

    /// <summary>
    /// Blurs the supplied element.
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    public async ValueTask Blur(ElementReference element)
    {
        //var module = await _moduleTask.Value;

        await JS.InvokeVoidAsync("blur", element);
    }

    public async ValueTask ChangeDarkMode(bool on)
    {
        //var module = await _moduleTask.Value;
        await JS.InvokeVoidAsync("changeDarkMode", on);
    }

    public async ValueTask<bool> IsDarkMode()
    {
        //var module = await _moduleTask.Value;
        return await JS.InvokeAsync<bool>("isDarkMode");
    }

    public async ValueTask ScrollToFragment(string elementId)
    {
        //var module = await _moduleTask.Value;
        await JS.InvokeVoidAsync("scrollToFragment", elementId);
    }
}

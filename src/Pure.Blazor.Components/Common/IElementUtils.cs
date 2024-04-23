using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components.Common;

public interface IElementUtils
{
    ValueTask Blur();
    ValueTask ScrollToFragment(string elementId);
    ValueTask<string> GetInnerHTML(ElementReference reference);
}

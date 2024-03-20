using Microsoft.AspNetCore.Components;

namespace Pure.Blazor.Components.Common;

public interface IElementUtils
{
    ValueTask Blur();
    ValueTask ChangeDarkMode(bool on);
    ValueTask<bool> IsDarkMode();
    ValueTask ScrollToFragment(string elementId);
    ValueTask<string> GetInnerHTML(ElementReference reference);
}

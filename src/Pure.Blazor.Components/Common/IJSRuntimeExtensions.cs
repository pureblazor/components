using Microsoft.JSInterop;

namespace Pure.Blazor.Components;

// ReSharper disable once InconsistentNaming
public static class JSRuntimeExtensions
{
    private const string Root = "./_content/PureBlazor.Components";

    /// <summary>
    ///     Imports the colocated razor component javascript
    /// </summary>
    /// <param name="JS"></param>
    /// <param name="module">The relative path to the razor component, e.g. Display/PureCode</param>
    /// <returns></returns>
    public static async Task<IJSObjectReference> Razor(this IJSRuntime JS, string module) =>
        await JS.InvokeAsync<IJSObjectReference>("import",
            $"{Root}/{module}.razor.js");

    public static async Task<IJSObjectReference> Script(this IJSRuntime JS, string module) =>
        await JS.InvokeAsync<IJSObjectReference>("import",
            $"{Root}/{module}.js");
}

using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace Pure.Blazor.Components.Common;

public abstract class InteropComponent : PureComponent, IAsyncDisposable
{
    protected virtual string Root => "./_content/PureBlazor.Components";

    // set the default value to NoOpJsObjectReference to avoid null reference exceptions
    // this is a fallback in case the module fails to load
    // so we can guarantee callers will not have to check for null
    // we may want to add an option to disable this fallback in the future
    protected IJSObjectReference Module = new NoOpJsObjectReference();

    /// <summary>
    /// The path to the colocated script file, relative to the root of the project.
    ///
    /// For example, `Components/MyComponent.razor`, `Buttons/PureDropdown.razor`
    /// </summary>
    protected abstract string ScriptPath { get; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            try
            {
                Module = await Js.InvokeAsync<IJSObjectReference>(
                    "import", $"{Root}/{ScriptPath}.js");
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Failed to load module {ScriptPath}, falling back to NoOpJsObjectReference",
                    ScriptPath);
            }
        }
    }

    [Inject] public required ILogger<InteropComponent> Logger { get; set; }
    [Inject] public required IJSRuntime Js { get; set; }

    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (Module is not null)
        {
            await Module.DisposeAsync();
        }
    }
}

using Microsoft.JSInterop;

namespace Pure.Blazor.Components.Common;

public class PrismUtils
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public PrismUtils(IJSRuntime jsRuntime) =>
        moduleTask = new Lazy<Task<IJSObjectReference>>(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/PureBlazor.Components/pureBlazor.js").AsTask());

    public async ValueTask HighlightAll()
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("highlight");
    }
}

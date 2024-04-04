using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;

namespace Pure.Blazor.Components;

public static class WebAssemblyHostBuilderExtensions
{
    public static WebAssemblyHostBuilder AddPureBlazorComponents(this WebAssemblyHostBuilder builder)
    {
        // javascript
        builder.Services.AddSingleton<IElementUtils, ElementUtils>();

        // services
        builder.Services.AddSingleton<ToastService>();
        builder.Services.AddSingleton<DialogService>();

        return builder;
    }
}

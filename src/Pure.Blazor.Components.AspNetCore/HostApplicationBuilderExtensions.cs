using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;
using Pure.Blazor.Components.Feedback;

namespace Pure.Blazor.Components.AspNetCore;

public static class HostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddPureBlazorComponents(this IHostApplicationBuilder builder)
    {
        // javascript
        builder.Services.AddScoped<IElementUtils, ElementUtils>();

        // services
        builder.Services.AddScoped<AlertService>();
        builder.Services.AddScoped<DialogService>();

        return builder;
    }
}

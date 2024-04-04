using Pure.Blazor.Components.Docs;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Serilog.Events;
using Pure.Blazor.Components;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// todo: create aspnet core package
builder.Services.AddScoped<IElementUtils, ElementUtils>();

// services
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<DialogService>();
// builder.Services.AddPureBlazorComponents();


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .MinimumLevel.Debug()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Debug()
    .CreateLogger();

builder.Logging.AddSerilog();

await builder.Build().RunAsync();

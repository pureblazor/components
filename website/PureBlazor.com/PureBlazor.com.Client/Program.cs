using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pure.Blazor.Components;
using Pure.Blazor.Components.Common;
using Pure.Blazor.Components.Dialogs;
using Pure.Blazor.Components.Feedback;
using PureBlazor.com.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddHttpClient<ServerClient>(options =>
{
    options.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});

builder.AddPureBlazorComponents();
builder.Services.AddSingleton<SnippetService>();

await builder.Build().RunAsync();

public class ServerClient(HttpClient client)
{
    public async Task AddToNewsletter(NewsletterForm form)
    {
        await client.PostAsJsonAsync("/newsletter/sign-up", form);
    }
}

public class NewsletterForm
{
    [Required, EmailAddress] public string EmailAddress { get; set; } = "";
}

public record SendGridContactRequest(List<SendGridContact> Contacts, List<string> list_ids);
public record SendGridContact(string Email);

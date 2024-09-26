using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace PureBlazor.com;
public class NewsletterService(IOptions<EmailOptions> emailOptions, ILogger<NewsletterService> logger)
{
    private readonly HtmlEncoder encoder = HtmlEncoder.Default;

    public async Task SendEmail(NewsletterForm form)
    {

    }

    private async Task CreateContact(SendGridClient client, string email)
    {

    }
}

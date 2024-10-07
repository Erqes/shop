using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;

namespace Infrastructure.Service;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public async Task SendEmail(string email, string body, string subject)
    {
        var apikey = configuration["apikey"];
        var options = new RestClientOptions("https://api.mailgun.net/v3")
        {
            Authenticator = new HttpBasicAuthenticator("api",
                apikey)
        };
        var request = new RestRequest("", Method.Post);
        var client = new RestClient(options);
        request.AddParameter("domain", "sandbox4a51168ba6f1458ea4e1b071e5bdfc2b.mailgun.org",
            ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "Excited User <mailgun@sandbox4a51168ba6f1458ea4e1b071e5bdfc2b.mailgun.org>");
        request.AddParameter("to", email);
        request.AddParameter("subject", subject);
        request.AddParameter("text", body);
        await client.ExecuteAsync(request);
    }
}
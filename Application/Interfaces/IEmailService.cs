namespace Infrastructure.Service;

public interface IEmailService
{
    Task SendEmail(string email, string body, string subject);
}
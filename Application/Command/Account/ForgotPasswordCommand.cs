using MediatR;

namespace Application.Command.Customer;

public class ForgotPasswordCommand(string email):IRequest
{
    public string Email { get; set; } = email;
}
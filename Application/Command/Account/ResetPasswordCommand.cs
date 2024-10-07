using Application.DTOs.Customer;
using MediatR;

namespace Application.Command.Customer;

public class ResetPasswordCommand(string userId,string token,string password, string confirmPassword):IRequest<string>
{
    public string UserId { get; set; } = userId;
    public string Token { get; set; } = token;
    public string NewPassword { get; set; } = password;
    public string ConfirmPassword { get; set; } = confirmPassword;
}
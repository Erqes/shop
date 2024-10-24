using Application.DTOs.Customer;
using MediatR;

namespace Application.Command.Customer;

public class SignInCommand(SignInDTO dto):IRequest<string>
{
    public string Email { get; set; } = dto.Email;
    public string Password { get; set; } = dto.Password;
   
}
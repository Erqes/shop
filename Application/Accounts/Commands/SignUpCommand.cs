using Application.DTOs.Customer;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Command.Customer;

public record SignUpCommand: IRequest
{
    public SignUpCommand(SignUpDTO dto) 
    {
        FirstName = dto.FirstName;
        LastName = dto.LastName;
        Email = dto.Email;
        Password = dto.Password;
        ConfirmPassword = dto.ConfirmPassword;
    }


    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
using Application.DTOs.Customer;
using MediatR;

namespace Application.Command.Customer;

public class ResetPasswordCommand(ResetPasswordDTO dto):IRequest<string>
{
    public string UserId { get; set; } = dto.UserId;
    public string Token { get; set; } = dto.Token;
    public string NewPassword { get; set; } = dto.NewPassword;
    public string ConfirmPassword { get; set; } = dto.ConfirmPassword;
}
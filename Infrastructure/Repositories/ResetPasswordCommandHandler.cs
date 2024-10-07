using Application.Command.Customer;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class ResetPasswordCommandHandler:IRequestHandler<ResetPasswordCommand,string>
{
    private readonly UserManager<User> _userManager;

    public ResetPasswordCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
    {
        if (command.NewPassword != command.ConfirmPassword)
            throw new Exception("Password doesn't match");
        var user = await _userManager.FindByIdAsync(command.UserId);
        if (user == null)
            throw new Exception("There is no such user");
        var isPasswordChanged=await _userManager.ResetPasswordAsync(user, command.Token, command.NewPassword);
        if (!isPasswordChanged.Succeeded)
            throw new Exception("An error occured while changing password");
        return "Password has been changed";
    }
}
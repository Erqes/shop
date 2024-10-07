using Application.Command.Customer;
using Domain.Entities;
using Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories;

public class SignInCommandHandler:IRequestHandler<SignInCommand,string>
{
    private readonly UserManager<User> _userManager;
    private readonly TokenProvider _tokenProvider;

    public SignInCommandHandler(UserManager<User> userManager, TokenProvider tokenProvider)
    {
        _userManager = userManager;
        _tokenProvider = tokenProvider;
    }

    public async Task<string> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(command.Email);
        if (user == null)
            throw new Exception("User not exists");
        var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, command.Password);
        if (!isPasswordCorrect == true)
            throw new Exception("Wrong password");
        return _tokenProvider.CreateJwt(user);

    }
}
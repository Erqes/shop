using System.Text;
using Application.Accounts.Query;
using Domain.Entities;
using Infrastructure.Service;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Infrastructure.Queries;

public class ConfirmEmailQueryHandler:IRequestHandler<ConfirmEmailQuery,string>
{
    private readonly UserManager<User> _userManager;
    private readonly TokenProvider _tokenProvider;

    public ConfirmEmailQueryHandler(UserManager<User> userManager, TokenProvider tokenProvider)
    {
        _userManager = userManager;
        _tokenProvider = tokenProvider;
    }

    public async Task<string> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
    {
        if (request.Code == null || request.UserId == null)
            throw new Exception("url not valid");
            

        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
         throw new Exception("Wrong credentials");
        
        var isConfirmed=await _userManager.ConfirmEmailAsync(user, request.Code);
        if (!isConfirmed.Succeeded)
           throw new Exception("Email not confirmed");
        return _tokenProvider.CreateJwt(user);
    }
}
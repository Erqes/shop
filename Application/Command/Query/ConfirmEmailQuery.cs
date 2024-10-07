using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Application.Command.Query;

public class ConfirmEmailQuery(string userId, string code) : IRequest<string>
{
    public string UserId { get; set; } = userId;
    public string Code { get; set; } = code;
}
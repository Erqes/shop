using MediatR;

namespace Application.Accounts.Query;

public class ConfirmEmailQuery(string userId, string code) : IRequest<string>
{
    public string UserId { get; set; } = userId;
    public string Code { get; set; } = code;
}
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User: IdentityUser
{
    public Customer Customer { get; set; }
}
namespace Infrastructure.Common;

public class AuthenticationSettings
{
    public string JwtKey { get; set; }
    public int JwtExpireMinutes { get; set; }
    public string Issuer { get; set; }
}
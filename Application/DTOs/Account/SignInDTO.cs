namespace Application.DTOs.Customer;

public class SignInDTO
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
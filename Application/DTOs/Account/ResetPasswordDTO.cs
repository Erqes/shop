namespace Application.DTOs.Customer;

public class ResetPasswordDTO
{
    public string UserId { get; set; }
    public string Token { get; set; }
    public string NewPassword { get; set; }
    public string ConfirmPassword { get; set; }
}
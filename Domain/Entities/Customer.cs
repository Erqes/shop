namespace Domain.Entities;

public class Customer
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int? Phone { get; set;}
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostCode { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
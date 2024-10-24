namespace Domain.Entities;

public class OrderProduct
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long Quantity { get; set; }
    public Order Order { get; set; }
    public long ProductId { get; set; }
    public Product Product { get; set; }
}
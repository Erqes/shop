namespace Domain.Entities;

public class Order
{
    public long Id { get; set; }
    public string OrderDetails { get; set; }
    public DateTime OrderDate { get; set; }
    public Customer Customer { get; set; }
    public long CustomerId { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
    public long ShipmentId { get; set; }
    public Shipment Shipment { get; set; }
}
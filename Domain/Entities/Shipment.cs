using Microsoft.VisualBasic;

namespace Domain.Entities;

public class Shipment
{
    public long Id { get; set; }
    public int ShipmentTrackingNumber { get; set; }
    public DateTime ShipmentDate { get; set; }
    public string ShipmentDetails { get; set; }
    public string ShipmentStatus { get; set; }
    public ICollection<Order> Orders { get; set; } 
    
}
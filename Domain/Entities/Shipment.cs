﻿using Microsoft.VisualBasic;

namespace Domain.Entities;

public class Shipment
{
    public long Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address1 { get; set; }
    public string? Address2 { get; set; }
    public string PostalCode { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; } 
    
}
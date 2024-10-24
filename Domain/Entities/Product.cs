﻿using Domain.Enums;

namespace Domain.Entities;

public class Product
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public Brand Brand { get; set; }
    public long Quantity { get; set; }
    public string? ProductImage { get; set; }
    public string? Color { get; set; }
    public string? Description { get; set; }
    public string? PowerSupply { get; set; }
    public string? Display { get; set; }
    public string? Processor { get; set; }
    public string? Gpu { get; set; }
    public string? MainBoard { get; set; }
    public string? Camera { get; set; }
    public string? DiagonalScreenSize { get; set; }
    public double Price { get; set; }
    public ProductType ProductType { get; set; }    
    public ICollection<OrderProduct>? OrderProducts { get; set; }
}
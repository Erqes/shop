using Domain.Enums;

namespace Application.DTOs.Products;

public class GetProductListQueryResponse
{
    public long Id { get; set; }
    public string ProductName { get; set; }
    public Brand Brand { get; set; }
    public string? Color { get; set; }
    public string? Display { get; set; }
    public string? Processor { get; set; }
    public string? Gpu { get; set; }
    public string? MainBoard { get; set; }
    public string? DiagonalScreenSize { get; set; }
    public float Price { get; set; }
    public ProductType ProductType { get; set; }    
}
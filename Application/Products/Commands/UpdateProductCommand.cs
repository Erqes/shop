using Application.DTOs.Products;
using Domain.Enums;
using MediatR;

namespace Application.Products.Commands;

public class UpdateProductCommand(long id,UpdateProductCommandDTO dto):IRequest
{
    public long Id { get; set; } = id;
    public string? ProductName { get; set; } = dto.ProductName;
    public Brand? Brand { get; set; } = dto.Brand;
    public long? Quantity { get; set; } = dto.Quantity;
    public string? Color { get; set; } = dto.Color;
    public string? Description { get; set; } = dto.Description;
    public string? PowerSupply { get; set; } = dto.PowerSupply;
    public string? Display { get; set; } = dto.Display;
    public string? Processor { get; set; } = dto.Processor;
    public string? Gpu { get; set; } = dto.Gpu;
    public string? MainBoard { get; set; } = dto.MainBoard;
    public string? Camera { get; set; } = dto.Camera;
    public string? DiagonalScreenSize { get; set; } = dto.DiagonalScreenSize;
    public float? Price { get; set; } = dto.Price;
    public ProductType? ProductType { get; set; } = dto.ProductType;
}
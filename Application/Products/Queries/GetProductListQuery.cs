using Application.DTOs.Products;
using Domain.Enums;
using MediatR;

namespace Application.Products;

public class GetProductListQuery:IRequest<ICollection<GetProductListQueryResponse>>
{
    public string? Search { get; init; }
    public Brand? Brand { get; set; }
    public ProductType? Type { get; set; }
    public float? PriceFrom { get; set; }
    public float? PriceTo { get; set; }
}
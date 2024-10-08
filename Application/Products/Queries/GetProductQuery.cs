using Application.DTOs.Products;
using MediatR;

namespace Application.Products;

public class GetProductQuery(long id):IRequest<GetProductQueryResponse>
{
    public long Id { get; set; } = id;
}
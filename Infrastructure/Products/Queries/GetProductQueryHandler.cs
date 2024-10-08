using Application;
using Application.DTOs.Products;
using Application.Products;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products;

public class GetProductQueryHandler:IRequestHandler<GetProductQuery,GetProductQueryResponse>
{
    private readonly ShopDbContext _dbContext;

    public GetProductQueryHandler(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var query = await _dbContext.Products.Where(p => p.Id == request.Id).Select(query=> new GetProductQueryResponse
        {
            Id = query.Id,
            ProductName = query.ProductName,
            Brand = query.Brand,
            Quantity = query.Quantity,
            Color = query.Color,
            Description = query.Description,
            PowerSupply = query.PowerSupply,
            Display = query.Display,
            Processor = query.Processor,
            Gpu = query.Gpu,
            MainBoard = query.MainBoard,
            Camera = query.Camera,
            DiagonalScreenSize = query.DiagonalScreenSize,
            Price = query.Price,
            ProductType = query.ProductType
        }).SingleOrDefaultAsync(cancellationToken);
        if (query == null)
            throw new Exception("Product not found");
        if (query.Quantity == 0)
            throw new Exception("Product out of stock");
        return query;
    }
}
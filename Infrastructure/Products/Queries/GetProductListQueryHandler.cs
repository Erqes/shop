using Application;
using Application.DTOs.Products;
using Application.Products;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products;

public class GetProductListQueryHandler:IRequestHandler<GetProductListQuery,ICollection<GetProductListQueryResponse>>
{
    private readonly ShopDbContext _dbContext;

    public GetProductListQueryHandler(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ICollection<GetProductListQueryResponse>> Handle(GetProductListQuery request,
        CancellationToken cancellationToken)
    {
        var products = _dbContext.Products.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var searchTxt = $"%{request.Search}%";
            products = products.Where(a => EF.Functions.ILike(a.ProductName, searchTxt));
        }
        if(request.Brand.HasValue)
            products = products.Where(p => p.Brand == request.Brand);
        if(request.Type.HasValue)
            products = products.Where(p => p.ProductType == request.Type);
        if(request.PriceFrom.HasValue)
            products = products.Where(p => p.Price >= request.PriceFrom);
        if(request.PriceTo.HasValue)
            products = products.Where(p => p.Price <= request.PriceTo);
        var response = await products.Select(products => new GetProductListQueryResponse
        {
            Id = products.Id,
            ProductName = products.ProductName,
            Brand = products.Brand,
            Color = products.Color,
            Display = products.Display,
            Processor = products.Processor,
            Gpu = products.Gpu,
            MainBoard = products.MainBoard,
            DiagonalScreenSize = products.DiagonalScreenSize,
            Price = products.Price,
            ProductType = products.ProductType,

        }).ToListAsync(cancellationToken);
        return response;

    }


}
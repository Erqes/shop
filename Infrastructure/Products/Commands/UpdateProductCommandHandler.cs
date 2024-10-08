using Application;
using Application.DTOs.Products;
using Application.Products.Commands;
using Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Products.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly ShopDbContext _dbContext;


    public UpdateProductCommandHandler(ShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product = await _dbContext.Products.Where(p => p.Id == command.Id).FirstOrDefaultAsync(cancellationToken);
        if (product == null)
            throw new Exception("Product not found.");
        TypeAdapterConfig<UpdateProductCommand, Product>
            .NewConfig()
            .IgnoreNullValues(true);
        command.Adapt(product);
        _dbContext.Update(product);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
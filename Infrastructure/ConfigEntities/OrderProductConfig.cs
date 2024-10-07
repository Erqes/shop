using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.ConfigEntities;

public class OrderProductConfig:IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> modelBuilder)
    {
        modelBuilder.HasKey(op => op.Id);
        modelBuilder.HasOne(op => op.Order);
        modelBuilder.HasOne(op => op.Product);
        
    }
}
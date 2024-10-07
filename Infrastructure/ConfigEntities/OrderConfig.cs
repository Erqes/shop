using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.ConfigEntities;

public class OrderConfig: IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> modelBuilder)
    {
        modelBuilder.HasKey(o => o.Id);
        

    }
}
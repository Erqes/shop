using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.ConfigEntities;

public class ProductConfig:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> modelBuilder)
    {
        modelBuilder.HasKey(p => p.Id);
        modelBuilder.Property(p => p.ProductType)
            .IsRequired()
            .HasConversion(new EnumToStringConverter<ProductType>());
        modelBuilder.Property(p=>p.Brand)
            .HasConversion(new EnumToStringConverter<Brand>());
        

    }
}
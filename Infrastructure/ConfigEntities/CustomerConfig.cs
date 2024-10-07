using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Application.ConfigEntities;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> modelBuilder)
    {
        modelBuilder.HasKey(c => c.Id);
        modelBuilder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
        modelBuilder.HasOne(c => c.User)
            .WithOne(u => u.Customer)
            .HasForeignKey<Customer>(c => c.UserId);
        modelBuilder.Property(c => c.FirstName)
            .IsRequired();
        modelBuilder.Property(c => c.LastName)
            .IsRequired();
    }
}
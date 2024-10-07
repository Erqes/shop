using Application;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Infrastructure;

public class RoleSeed: IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Name = RolesValues.User,
                NormalizedName = "USER",
                ConcurrencyStamp = "1"
            },
            new IdentityRole
            {
                Name = RolesValues.Customer,
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "2"
            });
    }
}
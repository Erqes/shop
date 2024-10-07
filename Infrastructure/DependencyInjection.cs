using System.Reflection;
using Application;
using Domain;
using Domain.Entities;
using Infrastructure.Repositories;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddDbContext<ShopDbContext>(option=>
            option.UseNpgsql(configuration.GetConnectionString("Database")));
        services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ShopDbContext>()
            .AddApiEndpoints();
        services.AddScoped<IProductSeed, ProductSeed>();
        services.AddSingleton<TokenProvider>();
        services.AddSingleton<IActionContextAccessor,ActionContextAccessor>();
        services.AddSingleton<IEmailService,EmailService>();
        services.AddHttpContextAccessor();
        
        return services;
    }
}
using System.Reflection;
using Application.DTOs.Products;
using Application.Validation;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddScoped<IValidator<UpdateProductCommandDTO>, UpdateProductCommandDTOValidation>();
        return services;
    }
}
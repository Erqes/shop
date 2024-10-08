using Application.DTOs.Products;
using FluentValidation;

namespace Application.Validation;

public class UpdateProductCommandDTOValidation:AbstractValidator<UpdateProductCommandDTO>
{
    public UpdateProductCommandDTOValidation()
    {
        RuleFor(p => p.Price).GreaterThan(0);
    }
}
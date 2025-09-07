using FluentValidation;

namespace ProductManager.Application.Products.Commands.Create;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required")
            .NotNull()
            .WithMessage("Product name is required");
    }
}
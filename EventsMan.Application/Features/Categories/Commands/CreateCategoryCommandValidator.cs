using FluentValidation;

namespace EventsMan.Application.Features.Categories.Commands;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required!")
            .NotNull()
            .MaximumLength(10).WithMessage("{PropertyName} cannot be long than 10");
    }
}
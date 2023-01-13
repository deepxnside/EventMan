using FluentValidation;

namespace EventsMan.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandValidator : AbstractValidator<UpdateEventCommand>
{
   public UpdateEventCommandValidator()
   {
      RuleFor(p => p.Name)
         .NotEmpty().WithMessage("{PropertyName} cannot be empty")
         .NotNull()
         .MaximumLength(10).WithMessage("{PropertyName} must to not be more than 10 characters");

      RuleFor(p => p.Price)
         .NotEmpty().WithMessage("{PropertyName} cannot be empty")
         .GreaterThan(0);
   } 
}
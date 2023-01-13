using MediatR;

namespace EventsMan.Application.Features.Categories.Commands;

public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
   public string Name { get; set; } = string.Empty;
}
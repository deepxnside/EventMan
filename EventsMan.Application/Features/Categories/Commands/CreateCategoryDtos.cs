namespace EventsMan.Application.Features.Categories.Commands;

public class CreateCategoryDtos
{
   public Guid CategoryId { get; set; }
   public string Name { get; set; } = string.Empty;
}
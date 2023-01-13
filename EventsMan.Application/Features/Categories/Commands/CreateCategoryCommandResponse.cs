using EventsMan.Contracts.Common;

namespace EventsMan.Application.Features.Categories.Commands;

public class CreateCategoryCommandResponse : BaseResponse
{
   public CreateCategoryCommandResponse() : base()
   {
      
   }

   public CreateCategoryDtos Category { get; set; } = default!;
}
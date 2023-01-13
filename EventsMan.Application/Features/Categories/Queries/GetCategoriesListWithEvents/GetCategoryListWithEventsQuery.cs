using MediatR;

namespace EventsMan.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class GetCategoryListWithEventsQuery : IRequest<IEnumerable<CategoryEventListVm>>
{
    public bool IncludeHistory { get; set; }
}
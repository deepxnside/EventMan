using MediatR;

namespace EventsMan.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoryListQuery: IRequest<IEnumerable<CategoryListVm>>
{
    
}
using AutoMapper;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

public class GetCategoryListWithEventsQueryHandler: IRequestHandler< GetCategoryListWithEventsQuery, IEnumerable<CategoryEventListVm>>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository )
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<IEnumerable<CategoryEventListVm>> Handle(GetCategoryListWithEventsQuery request, CancellationToken cancellationToken)
    {
        var CategoriesWithEvents=_categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);
        return (_mapper.Map<IEnumerable<CategoryEventListVm>>(CategoriesWithEvents));
    }
}
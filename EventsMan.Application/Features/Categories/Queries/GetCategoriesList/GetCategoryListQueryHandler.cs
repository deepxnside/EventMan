using AutoMapper;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoryListQueryHandler: IRequestHandler<GetCategoryListQuery,IEnumerable<CategoryListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public GetCategoryListQueryHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository )
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<IEnumerable<CategoryListVm>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
        var Categories= (await _categoryRepository.ListAllAsync()).OrderBy(x => x.Name);

        return _mapper.Map<IEnumerable<CategoryListVm>>(Categories);
    }
}
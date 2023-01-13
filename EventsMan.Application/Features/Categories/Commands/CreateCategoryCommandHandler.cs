using System.Net.Security;
using AutoMapper;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Categories.Commands;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public CreateCategoryCommandHandler(IMapper mapper, IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var createCategoryCommandResponse = new CreateCategoryCommandResponse();
        var Validator = new CreateCategoryCommandValidator();
        var validationResult = await Validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count>0)
        {
            createCategoryCommandResponse.Success = false;
            createCategoryCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createCategoryCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createCategoryCommandResponse.Success)
        {
            var category = new Category() { Name = request.Name };
            category = await _categoryRepository.AddAsync(category);
            createCategoryCommandResponse.Category = _mapper.Map<CreateCategoryDtos>(category);
        }

        return createCategoryCommandResponse;
    }
}
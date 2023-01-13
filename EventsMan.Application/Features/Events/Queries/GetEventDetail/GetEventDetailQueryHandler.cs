using AutoMapper;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Events.Queries.GetEventDetail;

public class EventDetailQueryHandler : IRequestHandler<GetEventDetailQuery,EventDetailVm>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Event> _eventRepository;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public EventDetailQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository,
        IAsyncRepository<Category> categoryRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
        _categoryRepository = categoryRepository;
    }
    public async Task<EventDetailVm> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(request.Id);
        var eventDetailDto = _mapper.Map<EventDetailVm>(@event);

        var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);

        eventDetailDto.Category = _mapper.Map<CategoryDto>(category);

        return eventDetailDto;
    }
}
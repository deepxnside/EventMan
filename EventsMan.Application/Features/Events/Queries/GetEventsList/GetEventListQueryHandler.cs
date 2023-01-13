using AutoMapper;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Events.Queries.GetEventsList;

public class GetEventListQueryHandler:IRequestHandler<GetEventListQuery,IEnumerable<EventListVm>>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Event> _eventRepository;

    public GetEventListQueryHandler(IMapper mapper,IAsyncRepository<Event> eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }
    public async Task<IEnumerable<EventListVm>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
    {
        var eventsList = (await _eventRepository.ListAllAsync()).OrderBy(x => x.Date);
       return _mapper.Map<IEnumerable<EventListVm>>(eventsList);
    }
}
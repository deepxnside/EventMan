using MediatR;

namespace EventsMan.Application.Features.Events.Queries.GetEventsList;

public class GetEventListQuery:IRequest<IEnumerable<EventListVm>>
{
    
}
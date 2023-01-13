using AutoMapper;
using EventsMan.Application.Exceptions;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Events.Commands.UpdateEvent;

public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Event> _eventRepository;

    public UpdateEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }
    public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(request.EventId);

        if (@event == null)
        {
            throw new NotFoundException(nameof(Event), request.EventId);
        }
        
        _mapper.Map(request, @event, typeof(UpdateEventCommand), typeof(Event));
        await _eventRepository.UpdateAsync(@event);
        
        return Unit.Value;
    }
}
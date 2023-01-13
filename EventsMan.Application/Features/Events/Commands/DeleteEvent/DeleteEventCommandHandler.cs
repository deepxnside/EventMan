using AutoMapper;
using EventsMan.Application.Exceptions;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Events.Commands.DeleteEvent;

public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
{
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Event> _eventRepository;

    public DeleteEventCommandHandler(IMapper mapper, IAsyncRepository<Event> eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }
    public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
    {
        var @event = await _eventRepository.GetByIdAsync(request.EventId);

        if (@event == null)
        {
            throw new NotFoundException(nameof(Event), request.EventId);
        }

        await _eventRepository.DeleteAsync(@event);
        
        return Unit.Value;
    }
}
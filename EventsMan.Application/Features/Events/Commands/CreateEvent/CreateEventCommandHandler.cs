using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Security.Cryptography;
using AutoMapper;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using FluentValidation;
using MediatR;

namespace EventsMan.Application.Features.Events.Commands.CreateEvent;

public class CreateEventCommandHandler: IRequestHandler<CreateEventCommand,Guid>
{
    private readonly IMapper _mapper;
    private readonly IEventRepository _eventRepository;

    public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository)
    {
        _mapper = mapper;
        _eventRepository = eventRepository;
    }
    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateEventCommandValidator(_eventRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count>0)
        {
            throw new Exceptions.ValidationException(validationResult);
        }

        var @event = _mapper.Map<Event>(request);

        return @event.EventId;
    }
}
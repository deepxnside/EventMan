using EventsMan.Contracts.Common;

namespace EventsMan.Application.Features.Events.Commands;

public class CreateEventCommandResponse : BaseResponse
{
    public CreateEventCommandResponse() : base()
    {
        
    }

    public CreateEventDto Event{get;set;}
}
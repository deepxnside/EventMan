using EventsMan.Domain.Entities;

namespace EventsMan.Application.Persistence;

public interface IEventRepository : IAsyncRepository<Event>
{
   Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate);
}
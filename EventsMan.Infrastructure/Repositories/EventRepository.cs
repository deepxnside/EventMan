using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using EventsMan.Infrastructure.Data;
using EventsMan.Infrastructure.Repositories.Common;

namespace EventsMan.Infrastructure.Repositories;

public class EventRepository : BaseRepository<Event>, IEventRepository
{
    public EventRepository(EventManDbContext dbContext) : base(dbContext)
    {
        
    }
    public Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
    {
        throw new NotImplementedException();
    }
}
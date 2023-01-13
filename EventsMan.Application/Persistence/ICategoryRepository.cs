using EventsMan.Domain.Entities;

namespace EventsMan.Application.Persistence;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    Task<IEnumerable<Category>> GetCategoriesWithEvents(bool eventStatus);
}
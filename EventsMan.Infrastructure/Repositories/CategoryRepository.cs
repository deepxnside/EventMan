using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using EventsMan.Infrastructure.Data;
using EventsMan.Infrastructure.Repositories.Common;

namespace EventsMan.Infrastructure.Repositories;

public class CategoryRepository : BaseRepository<Category>,ICategoryRepository
{
    public CategoryRepository(EventManDbContext dbContext) : base(dbContext)
    {
    }

    public Task<IEnumerable<Category>> GetCategoriesWithEvents(bool eventStatus)
    {
        throw new NotImplementedException();
    }
}
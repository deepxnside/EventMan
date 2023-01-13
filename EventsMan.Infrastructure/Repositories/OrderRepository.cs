using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using EventsMan.Infrastructure.Data;
using EventsMan.Infrastructure.Repositories.Common;

namespace EventsMan.Infrastructure.Repositories;

public class OrderRepository : BaseRepository<Order> ,IOrderRepository
{
    public OrderRepository(EventManDbContext dbContext) : base(dbContext)
    {
    }

    public Task<List<Order>> GetPagedOrdersForMonth(DateTime requestDate, int requestPage, int requestSize)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetTotalCountOfOrdersForMonth(DateTime requestDate)
    {
        throw new NotImplementedException();
    }
}
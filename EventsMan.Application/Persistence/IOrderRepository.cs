using EventsMan.Domain.Entities;

namespace EventsMan.Application.Persistence;

public interface IOrderRepository : IAsyncRepository<Order>
{
    Task<List<Order>> GetPagedOrdersForMonth(DateTime requestDate, int requestPage, int requestSize);
    Task<int> GetTotalCountOfOrdersForMonth(DateTime requestDate);
}
using AutoMapper;
using EventsMan.Application.Persistence;
using EventsMan.Domain.Entities;
using MediatR;

namespace EventsMan.Application.Features.Orders.Queries;

public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrdersForMonthQuery,PagedOrdersForMonthVm>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrdersForMonthQueryHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }
    public async Task<PagedOrdersForMonthVm> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
    {
        var list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
        var totalOrders = _mapper.Map <List<OrdersForMonthDto>>(list);

        int count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);
        return new PagedOrdersForMonthVm()
            { Count = count, OrdersForMonth = totalOrders, Page = request.Page, Size = request.Size };
    }
}
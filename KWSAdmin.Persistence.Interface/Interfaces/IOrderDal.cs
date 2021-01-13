using KWSAdmin.Persistence.Interface.Dtos;
using System.Collections.Generic;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IOrderDal
    {
        OrderDto GetOrderById(int id);

        bool AddOrder(OrderDto order);

        bool UpdateOrder(OrderDto order);

        List<OrderDto> GetAllOrders();

        bool DeleteOrder(int id);
    }
}

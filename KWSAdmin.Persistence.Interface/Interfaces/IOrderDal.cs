using System.Collections.Generic;
using System.Data.SqlTypes;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IOrderDal
    {
        OrderDto GetById(int id);

        void Add(OrderDto order);

        void UpdateOrder(OrderDto order);

        List<OrderDto> GetAllOrders();

        void DeleteOrder(int id);
    }
}

using System.Collections.Generic;
using System.Data.SqlTypes;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IOrderDal
    {
        OrderDto GetById(int id, SqlConnection connection);

        void Add(OrderDto order, SqlConnection connection);

        void UpdateOrder(OrderDto order, SqlConnection connection);

        List<OrderDto> GetAllOrders(SqlConnection connection);

        void DeleteOrder(int id, SqlConnection connection);
    }
}

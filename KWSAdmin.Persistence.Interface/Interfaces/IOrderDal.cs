using Interface;
using KWSAdmin.Persistence.Interface.Dtos;


namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IOrderDal
    {
        OrderDto GetById(int id);

        void Add(OrderDto order);
    }
}

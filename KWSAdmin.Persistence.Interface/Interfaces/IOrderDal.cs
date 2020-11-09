using Interface;
using KWSAdmin.persistence.Interface.Dtos;


namespace KWSAdmin.persistence.Interface.Interfaces
{
    public interface IOrderDal
    {
        OrderDto GetById(int id);

        void Add(OrderDto order);
    }
}

using Interface;
using KWSAdmin.Persistence.Interface.Dtos;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    interface IAccuDal
    { 
        AccuDto GetById(int id);

        void Add(AccuDto order);
    }
}

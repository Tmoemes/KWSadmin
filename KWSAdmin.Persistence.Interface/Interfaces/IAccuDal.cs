using System.Collections.Generic;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccuDal
    { 
        AccuDto GetById(int id);

        void Add(AccuDto accu);

        void UpdateAccu(AccuDto accu);

        List<AccuDto> GetAllAccus();

        void DeleteAccu(int id);
    }
}

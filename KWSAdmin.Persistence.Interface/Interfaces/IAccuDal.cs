using KWSAdmin.Persistence.Interface.Dtos;
using System.Collections.Generic;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccuDal
    {
        AccuDto GetAccuById(int id);

        void AddAccu(AccuDto accu);

        void UpdateAccu(AccuDto accu);

        List<AccuDto> GetAllAccus();

        void DeleteAccu(int id);
    }
}

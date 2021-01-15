using KWSAdmin.Persistence.Interface.Dtos;
using System.Collections.Generic;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccuDal
    {
        AccuDto GetAccuById(int id);

        bool AddAccu(AccuDto accu);

        bool UpdateAccu(AccuDto accu);

        List<AccuDto> GetAllAccus();

        bool DeleteAccu(int id);
    }
}

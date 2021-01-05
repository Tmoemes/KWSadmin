using System.Collections.Generic;
using Interface;
using KWSAdmin.Persistence.Interface.Dtos;
using System.Data.SqlClient;

namespace KWSAdmin.Persistence.Interface.Interfaces
{
    public interface IAccuDal
    { 
        AccuDto GetById(int id, SqlConnection connection);

        void Add(AccuDto accu, SqlConnection connection);

        void UpdateAccu(AccuDto accu, SqlConnection connection);

        List<AccuDto> GetAllAccus(SqlConnection connection);
    }
}

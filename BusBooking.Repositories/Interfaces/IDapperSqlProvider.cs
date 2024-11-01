using BusBooking.Models.Models;
using Dapper;

namespace BusBooking.Repositories.Interfaces
{
    public interface IDapperSqlProvider
    {
        Task<ServiceResponseData<List<T>>> ExecuteProc<T>(string procName, DynamicParameters procParams);
    }
}

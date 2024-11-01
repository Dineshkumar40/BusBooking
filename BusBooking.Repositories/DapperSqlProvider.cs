using BusBooking.Models.Models;
using BusBooking.Repositories.Interfaces;
using Dapper;
using System.Data.Common;
using System.Data.SqlClient;

namespace BusBooking.Repositories
{
    public class DapperSqlProvider : IDapperSqlProvider
    {
        private readonly string _connectionString;
        public DapperSqlProvider(string connectionString) 
        {
            _connectionString = connectionString;
        }
        private DbConnection GetConnection() 
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<ServiceResponseData<List<T>>> ExecuteProc<T>(string procName, DynamicParameters procParams)
        {
            ServiceResponseData<List<T>> response = null;

            try
            {
                using (var dbConnection = GetConnection())
                {
                    var result = await dbConnection.QueryAsync<T>(procName, procParams, commandType: System.Data.CommandType.StoredProcedure);
                    response = new ServiceResponseData<List<T>>
                    {
                        Status = ServiceStatusType.Success,
                        Data = result.ToList(),
                    };
                }
            }
            catch (Exception ex)
            {
                response = new ServiceResponseData<List<T>>
                {
                    Status = ServiceStatusType.Failure,
                    Messages = new List<Message>
                    {
                        new Message()
                        {
                            Code = "500",
                            Description = ex.Message
                        }
                    }
                };
            }

            return response;
        }

    }
}

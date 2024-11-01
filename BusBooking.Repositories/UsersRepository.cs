using BusBooking.Models.Models;
using BusBooking.Repositories.Interfaces;
using Dapper;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace BusBooking.Repositories
{
    public class UsersRepository(IDapperSqlProvider dapperSqlProvider) : IUsersRepository
    {
        public async Task<ServiceResponseData<List<Users>>> GetUsers()
        {
            return await dapperSqlProvider.ExecuteProc<Users>("GetAllUsers", null);
        }

        public async Task<ServiceResponse> AddUser(AddUserRequest addUser)
        {
            ServiceResponse response = new ServiceResponse();
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", Guid.NewGuid());
                dynamicParameters.Add("@fName", addUser.FName);
                dynamicParameters.Add("@lName", addUser.LName);
                dynamicParameters.Add("@age", addUser.Age);
                dynamicParameters.Add("@gender", addUser.Gender);
                dynamicParameters.Add("@roleType", addUser.RoleType);


                var dbResponse = await dapperSqlProvider.ExecuteProc<int>("CreateOrUpdate", dynamicParameters);

                response.Status = dbResponse.Status;
                response.Messages = dbResponse.Messages;
            }
            catch(Exception ex)
            {

            }

            return response;
        }

        public async Task<ServiceResponse> UpdateUser(UpdateUserRequest updateUser)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", updateUser.Id);
                dynamicParameters.Add("@fName", updateUser.FName);
                dynamicParameters.Add("@lName", updateUser.LName);
                dynamicParameters.Add("@age", updateUser.Age);
                dynamicParameters.Add("@gender", updateUser.Gender);
                dynamicParameters.Add("@roleType", updateUser.RoleType);

                var dbResponse = await dapperSqlProvider.ExecuteProc<int>("CreateOrUpdate", dynamicParameters);

                response.Status = dbResponse.Status;
                response.Messages = dbResponse.Messages;
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        public async Task<ServiceResponse> DeleteUser(int id)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@id", id);

                var dbResponse = await dapperSqlProvider.ExecuteProc<int>("DeleteUser", dynamicParameters);

                response.Status = dbResponse.Status;
                response.Messages = dbResponse.Messages;
            }
            catch (Exception ex)
            {

            }
            return response;


            
        }
        public async Task<ServiceResponseData<List<UserGetBuses>>> SearchBuses(SearchBuses searchBuses)
        {
            var response = new ServiceResponseData<List<UserGetBuses>>();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@FromLocation", searchBuses.From);
                dynamicParameters.Add("@ToLocation", searchBuses.To);
                dynamicParameters.Add("@TravelDays", searchBuses.TravelDate.DayOfWeek.ToString());

                var dbResponse = await dapperSqlProvider.ExecuteProc<UserGetBuses>("SearchBuses", dynamicParameters);
                response.Data = dbResponse.Data;
                response.Status = dbResponse.Status;
                response.Messages = dbResponse.Messages;
            }
            catch (Exception ex)
            {

            }
            return response;
        }
        
        public async Task<ServiceResponseData<List<GetRoutes>>> GetRoutes()
        {
            return await dapperSqlProvider.ExecuteProc<GetRoutes>("GetAllRoutes", null);

        }

        public async Task<ServiceResponse> AddRoutes(AddRoutes addRoutes)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@routeId",addRoutes.RouteId);
                dynamicParameters.Add("@routeName",addRoutes.RouteName);
                dynamicParameters.Add("@fromLocation", addRoutes.StartLocation);
                dynamicParameters.Add("@toLocation", addRoutes.EndLocation);
                dynamicParameters.Add("@duration", addRoutes.Duration);

                var dbResponse = await dapperSqlProvider.ExecuteProc<int>("AddOrUpdateBusRoute", dynamicParameters);
                response.Status = dbResponse.Status;
                response.Messages = dbResponse.Messages;

            }
            catch (Exception ex)
            {

            }
            return response;
        }
         public async Task<ServiceResponse> EditRoutes(EditRoutes editRoutes)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@routeId", editRoutes.RouteId);
                dynamicParameters.Add("@routeName", editRoutes.RouteName);
                dynamicParameters.Add("@fromLocation", editRoutes.StartLocation);
                dynamicParameters.Add("@toLocation", editRoutes.EndLocation);
                dynamicParameters.Add("@duration", editRoutes.Duration);

                var dbResponse = await dapperSqlProvider.ExecuteProc<int>("AddOrUpdateBusRoute", dynamicParameters);
                response.Status = dbResponse.Status;
                response.Messages = dbResponse.Messages;

            }
            catch (Exception ex)
            {

            }
            return response;

        }

        public async Task<ServiceResponse> DeleteRoute(DeleteRoute deleteRoute)
        {
            ServiceResponse response = new ServiceResponse();

            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@routeId", deleteRoute.RouteId);
                

                var dbResponse = await dapperSqlProvider.ExecuteProc<int>("DeleteRouteById", dynamicParameters);
                response.Status = dbResponse.Status;
                response.Messages = dbResponse.Messages;

            }
            catch (Exception ex)
            {

            }
            return response;

        }












        //public async Task<ServiceResponseData<List<BookingDetails>>> GetBookingInformation(BookingInformation bookingInformation)
        //{
        //    DynamicParameters dynamicParameters = new DynamicParameters();  
        //    dynamicParameters.Add("@BookingDate",bookingInformation.BookingDate);
        //    dynamicParameters.Add("@BusId", bookingInformation.BusId);

        //    return await dapperSqlProvider.ExecuteProc<BookingDetails>("AddOrSelectBookingInformartion", dynamicParameters);
        //}




    }
}

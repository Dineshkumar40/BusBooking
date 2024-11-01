using BusBooking.Models.Models;
using BusBooking.Repositories.Interfaces;


namespace BusBooking.Services.Interfaces
{
    public interface IUsersService
    {
        Task<ServiceResponseData<List<Users>>> GetUsers();
        Task<ServiceResponse> AddUser(AddUserRequest addUserRequest);
        Task<ServiceResponse> UpdateUser(UpdateUserRequest updateUserRequest);
        Task <ServiceResponse>DeleteUser(int id);   
        Task<ServiceResponseData<List<UserGetBuses>>> SearchBuses(SearchBuses searchBuses);
        Task<ServiceResponseData<List<GetRoutes>>> GetRoutes();
        Task<ServiceResponse> AddRoutes(AddRoutes addRoutes);
        Task<ServiceResponse> EditRoutes(EditRoutes editRoutes);

        Task<ServiceResponse> DeleteRoute(DeleteRoute deleteRoute);


        //Task<ServiceResponseData<List<BookingDetails>>> GetBookingInformation(BookingInformation bookingInformation);



    }
}

using BusBooking.Models.Models;

namespace BusBooking.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<ServiceResponseData<List<Users>>> GetUsers();
        Task<ServiceResponse> AddUser(AddUserRequest addUser);
        Task<ServiceResponse> UpdateUser(UpdateUserRequest updateUser);
        Task<ServiceResponse> DeleteUser(int id);
        Task<ServiceResponseData<List<UserGetBuses>>> SearchBuses(SearchBuses searchBuses);
        Task<ServiceResponseData<List<GetRoutes>>> GetRoutes();
        Task<ServiceResponse> AddRoutes(AddRoutes addRoutes);
        Task<ServiceResponse> EditRoutes(EditRoutes editRoutes);
        Task<ServiceResponse> DeleteRoute(DeleteRoute deleteRoute);




        //Task<ServiceResponseData<List<BookingDetails>>> GetBookingInformation(BookingInformation bookingInformation);


    }
}

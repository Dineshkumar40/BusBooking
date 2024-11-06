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
        Task<ServiceResponseData<List<AdminGetRoutes>>> GetRoutes();
        Task<ServiceResponse> AddRoutes(AddRoutes addRoutes);
        Task<ServiceResponse> EditRoutes(EditRoutes editRoutes);
        Task<ServiceResponse> DeleteRoute(DeleteRoute deleteRoute);
        Task<ServiceResponseData<List<AdminGetBuses>>> AdminGetBuses();
        Task<ServiceResponse> AdminAddBuses(AdminAddOrEditBuses adminAddOrEditBuses );
        Task<ServiceResponse> AdminEditBuses(AdminAddOrEditBuses adminAddOrEditBuses);
        Task<ServiceResponseData<List<GetSeats>>> AdminGetSeats(ToGetSeats toGetSeats);
        Task<ServiceResponse> AdminBlockOrUnSeats(AdminBlockOrUnSeats adminBlockOrUnSeats);
        Task<ServiceResponse> BookingDetails( SendBookingDetails bookingDetails);
        Task<ServiceResponseData<List<GetBookingDetails>>> GetBookingDetails(UserRequestToGetBookingDetails userRequestToGetBookingDetails);



    }
}

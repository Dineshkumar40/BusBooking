using BusBooking.Models.Models;
using BusBooking.Repositories;
using BusBooking.Repositories.Interfaces;
using BusBooking.Services.Interfaces;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace BusBooking.Services
{
    public class UsersService(IUsersRepository usersRepository) : IUsersService
    {
        public async Task<ServiceResponseData<List<Users>>> GetUsers()
        {
            return await usersRepository.GetUsers();
        }

        public async Task<ServiceResponse> AddUser(AddUserRequest addUserRequest)
        {
            return await usersRepository.AddUser(addUserRequest);
        }

        public async Task<ServiceResponse> UpdateUser(UpdateUserRequest updateUserRequest)
        {
            return await usersRepository.UpdateUser(updateUserRequest);
        }

        public async Task<ServiceResponse> DeleteUser(int id)
        {
            return await usersRepository.DeleteUser(id);
        }
        public async Task<ServiceResponseData<List<UserGetBuses>>> SearchBuses(SearchBuses searchBuses)
        {
            return await usersRepository.SearchBuses(searchBuses);
        }
      
       public async Task<ServiceResponseData<List<AdminGetRoutes>>> GetRoutes()
        {
            return await usersRepository.GetRoutes();
        }
        public async Task<ServiceResponse> AddRoutes(AddRoutes addRoutes)
        {
            return await usersRepository.AddRoutes(addRoutes);
        }
        public async Task<ServiceResponse> EditRoutes(EditRoutes editRoutes)
        {
            return await usersRepository.EditRoutes(editRoutes);
        }
        public async Task<ServiceResponse> DeleteRoute(DeleteRoute deleteRoute)
        {
            return await usersRepository.DeleteRoute(deleteRoute);
        }
        public async Task<ServiceResponseData<List<AdminGetBuses>>> AdminGetBuses()
        {
            return await usersRepository.AdminGetBuses();
        }
        public async Task<ServiceResponse> AdminAddBuses(AdminAddOrEditBuses adminAddOrEditBuses)
        {
            return await usersRepository.AdminAddBuses(adminAddOrEditBuses);
        }
        public async Task<ServiceResponse> AdminEditBuses(AdminAddOrEditBuses adminAddOrEditBuses)
        {
            return await usersRepository.AdminEditBuses(adminAddOrEditBuses);
        }
        public async Task<ServiceResponseData<List<GetSeats>>> AdminGetSeats(ToGetSeats toGetSeats)
        {
            return await usersRepository.AdminGetSeats(toGetSeats);
        }
        public async Task<ServiceResponse> AdminBlockOrUnSeats(AdminBlockOrUnSeats adminBlockOrUnSeats)
        {
            return await usersRepository.AdminBlockOrUnSeats(adminBlockOrUnSeats);
        }
        public async Task<ServiceResponse> BookingDetails(SendBookingDetails bookingDetails)
        {
            return await usersRepository.BookingDetails(bookingDetails);
        }
        public async Task<ServiceResponseData<List<GetBookingDetails>>> GetBookingDetails(UserRequestToGetBookingDetails userRequestToGetBookingDetails)
        {
            return await usersRepository.GetBookingDetails(userRequestToGetBookingDetails);
        }
        public async Task<ServiceResponse> ToAuth(ToAuth auth)
        {
            return await usersRepository.ToAuth(auth);
        }
        public async Task<ServiceResponseData<CheckAuth>> CheckAuth(ToAuth toAuth)
        {
            return await usersRepository.GetAuth(toAuth);
        }
        






        //public async Task<ServiceResponseData<List<BookingDetails>>> GetBookingInformation(BookingInformation bookingInformation)
        //{
        //    var bookingInfoResponse = await usersRepository.GetBookingInformation(bookingInformation);

        //    if(bookingInfoResponse.Status == ServiceStatusType.Success)
        //    {
        //        if(bookingInfoResponse.Data?.Any() == true)
        //        {
        //            var bookingInfo = bookingInfoResponse.Data.FirstOrDefault();

        //            if (bookingInfo != null)
        //            {
        //                var seatCount = bookingInfo.BookingInformation.Count;



        //                //for



        //                //bookingInfo.Data
        //            }

        //        }
        //        else
        //        {
        //            var bookingInfo = new BookingDetails();
        //            bookingInfo.BusId = "";
        //            bookingInfo.BookedDate = "";
        //            //for

        //            var booking = new BookingInfo()
        //            {
        //                SeatNo = "s2",
        //                UserId = "",
        //                UserName = ""
        //            };

        //            bookingInfo.BookingInformation.Add(booking);

        //        }
        //    }

        //}



    }

}


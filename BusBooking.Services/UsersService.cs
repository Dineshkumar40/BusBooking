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
      
       public async Task<ServiceResponseData<List<GetRoutes>>> GetRoutes()
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


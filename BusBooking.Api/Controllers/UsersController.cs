﻿using BusBooking.Api.Extensions;
using BusBooking.Models.Models;
using BusBooking.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("user")]
    public class UsersController(IUsersService usersService) : ControllerBase
    {
        [HttpGet]
        [Route("getUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await usersService.GetUsers();
            return result.ToActionResult();
        } 

        [HttpPost]
        [Route("addUsers")]
        public async Task<IActionResult> AddUser(AddUserRequest addUser)
        {
            var result =  await usersService.AddUser(addUser);
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("updateUsers")]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest updateUser)
        {
           var result = await usersService.UpdateUser(updateUser);
            return result.ToActionResult();
        }

        [HttpDelete]
        [Route("deleteUsers")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await usersService.DeleteUser(id);
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("searchbuses")]
        public async Task<IActionResult> SearchBueses(SearchBuses searchBuses)
        {
            var result = await usersService.SearchBuses(searchBuses);
            return result.ToActionResult();
        }

        [HttpGet]
        [Route("getRoutes")]
        public async Task<IActionResult> GetRoutes()
        {
            var result = await usersService.GetRoutes();
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("addRoutes")]
        public async Task<IActionResult> AddRoutes(AddRoutes addRoutes)
        {
            var result = await usersService.AddRoutes(addRoutes);
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("editRoutes")]
        public async Task<IActionResult> EditRoutes(EditRoutes editRoutes)
        {
            var result = await usersService.AddRoutes(editRoutes);
            return result.ToActionResult();
        }

        [HttpDelete]
        [Route("deleteRoute")]
        public async Task<IActionResult> DeleteRoute(DeleteRoute deleteRoute)
        {
            var result = await usersService.DeleteRoute(deleteRoute);
            return result.ToActionResult();
        }

        [HttpGet]
        [Route("adminGetBuses")]
        public async Task<IActionResult> AdminGetBuses()
        {
            var result = await usersService.AdminGetBuses();
            return result.ToActionResult();
        }

        [HttpPost]
        [Route("addBuses")]
        public async Task<IActionResult>AdminAddBuses (AdminAddOrEditBuses adminAddOrEditBuses)
        {
            var result = await usersService.AdminAddBuses(adminAddOrEditBuses);
            return result.ToActionResult();
        }
        [HttpPost]
        [Route("editBuses")]
        public async Task<IActionResult> AdminEditBuses(AdminAddOrEditBuses adminAddOrEditBuses)
        {
            var result = await usersService.AdminEditBuses(adminAddOrEditBuses);
            return result.ToActionResult();
        }
        [HttpPost]
        [Route("blockOrUnblock")]
        public async Task<IActionResult> AdmiBlockOrUnblock(AdminBlockOrUnSeats adminBlockOrUnSeats )
        {
            var result = await usersService.AdminBlockOrUnSeats(adminBlockOrUnSeats);
            return result.ToActionResult();
        }
        [HttpPost]
        [Route("adminGetSeats")]
        public async Task<IActionResult> AdminGetSeats(ToGetSeats toGetSeats)
        {
            var result = await usersService.AdminGetSeats(toGetSeats);
            return result.ToActionResult();
        }
        [HttpPost]
        [Route("bookingDetails")]
        public async Task<IActionResult> BookingDetails(SendBookingDetails bookingDetails)
        {
            var result = await usersService.BookingDetails(bookingDetails);
            return result.ToActionResult();
        }
        [HttpPost]
        [Route("userGetBookingDetails")]
        public async Task<IActionResult> GetBookingDetails(UserRequestToGetBookingDetails userRequestToGetBookingDetails)
        {
            var result = await usersService.GetBookingDetails(userRequestToGetBookingDetails);
            return result.ToActionResult();
        }
        [HttpGet]
        [Route("adminGetBookingDetails")]
        public async Task<IActionResult> AdminBookingDetails()
        {
            var result = await usersService.AdminGetBookingDetails();
            return result.ToActionResult();
        }












        //[HttpPost]
        //[Route("addbuses")]
        //public async Task<IActionResult> AddBusInfo(AddBusInfo addBusInfo)
        //{
        //    var result = await usersService.AddBusInfo(addBusInfo);
        //    return result.ToActionResult();
        //}


    }

}

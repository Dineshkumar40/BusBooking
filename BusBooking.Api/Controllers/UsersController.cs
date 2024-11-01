using BusBooking.Api.Extensions;
using BusBooking.Models.Models;
using BusBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Api.Controllers
{
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







        //[HttpPost]
        //[Route("addbuses")]
        //public async Task<IActionResult> AddBusInfo(AddBusInfo addBusInfo)
        //{
        //    var result = await usersService.AddBusInfo(addBusInfo);
        //    return result.ToActionResult();
        //}


    }

}

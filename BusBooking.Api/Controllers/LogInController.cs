using BusBooking.Api.Extensions;
using BusBooking.Models.Models;
using BusBooking.Services;
using BusBooking.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Api.Controllers
{
    
    [ApiController]
    [Route("login")]
    public class LogInController(ILogInServices logInServices) : ControllerBase
    {
        [HttpPost]
        [Route("toAuth")]
        public async Task<IActionResult> ToAuth(ToAuth auth)
        {
            var result = await logInServices.ToAuth(auth);
            return result.ToActionResult();
        }
        [HttpPost]
        [Route("CheckAuth")]
        public async Task<IActionResult> CheckAuth(ToAuth auth)
        {
            var result = await logInServices.CheckAuth(auth);
            return result.ToActionResult();
        }

    }
}

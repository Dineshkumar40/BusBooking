using BusBooking.Models.Models;
using BusBooking.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BusBooking.Api.Extensions
{
    public static class ResponseExtension
    {
        public static IActionResult ToActionResult<T>(this ServiceResponseData<T> response)
        {
            return response.Status == ServiceStatusType.Success ? new OkObjectResult(response.Data) : GetActionResult(response);
        }

        public static IActionResult ToActionResult(this ServiceResponse response)
        {
            return GetActionResult(response);
        }

        private static IActionResult GetActionResult(ServiceResponse response)
        {
            var result = new ObjectResult(response);
            result.StatusCode = StatusCodes.Status200OK;
            return result;
        }
    }
}

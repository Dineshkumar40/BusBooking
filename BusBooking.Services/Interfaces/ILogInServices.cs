using BusBooking.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Services.Interfaces
{
    public interface ILogInServices
    {
        Task<ServiceResponse> ToAuth(ToAuth auth);
        Task<ServiceResponseData<CheckAuth>> CheckAuth(ToAuth ToAuth);

    }
}

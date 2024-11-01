using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class UpdateUserRequest : AddUserRequest 
    {
        public required string Id { get; set; }
        
    }
}

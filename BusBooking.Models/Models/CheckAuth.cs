﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class CheckAuth
    {
        public string UserId { get; set; }
        public string RoleType { get; set; }
        public string JwtToken { get; set; }    
    }
    
}

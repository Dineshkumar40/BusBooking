﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class GetSeats
    {
        public string SeatNumber { get; set; }
        public string IsAvailable { get; set; }
        public string IsBlocked { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class UserGetBuses
    {
        public string BusId { get; set; }
        public string BusName { get; set; }
        public string BusNumber { get; set; }

        public string BusType { get; set; }
        public int TotalSeats { get; set; }
        public int AvailableSeats { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public decimal Fare { get; set; }
        public int RouteId { get; set; }
        public int Complementary { get; set; }
    }

}

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
        public int AvailableSeats { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public int Fare { get; set; }
        public string RouteName { get; set; }
        public int Complementary { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string TotalTime { get; set; }
    }

}

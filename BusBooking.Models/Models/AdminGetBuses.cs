using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class AdminGetBuses
    {
        public string BusId { get; set; }
        public string BusName { get; set; }
        public string BusNumber { get; set; }
        public int TotalSeats { get; set; }
        public string BusType { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }  
        public string TotalTime { get; set; }
        public string AvailableSeats { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int Fare { get; set; }
        public string RouteId { get; set; }
        public string RouteName { get; set; }
        public string Complementory { get; set; }
        public string TravelDays { get; set; }
    }
}

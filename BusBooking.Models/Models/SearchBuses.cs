using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class SearchBuses
    {
        public string? StartLocation {  get; set; }
        public string? EndLocation { get; set; }
        public DateTime? TravelDate { get; set; }     
        public string? BusType { get; set; }
        public string? DepartureTimeSlots { get; set; }
        public string? ArrivalTimeSlots { get; set; }
    }
}

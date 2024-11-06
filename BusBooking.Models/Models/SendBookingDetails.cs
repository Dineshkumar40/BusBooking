using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class SendBookingDetails
    {
        public string UserId { get; set; }
        public string NoOfSeats { get; set; }
        public string BusId { get; set; }
        public string BookingId { get; set; }
        public string Month { get; set; }
        public string SeatNumbers { get; set; }
        public List<PassengerInfo> PassengerInformation { get; set; }
    }
}

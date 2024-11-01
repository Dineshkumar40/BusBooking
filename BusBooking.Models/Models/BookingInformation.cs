using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Models.Models
{
    public class BookingInformation
    {
        public string BookingDate { get; set; }
        public string BusId {  get; set; }
        public string UserID { get; set; }
        public int NoOfSeats { get; set; }
    }
}
